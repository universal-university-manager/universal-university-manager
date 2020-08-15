using Microsoft.EntityFrameworkCore;
using UUM.Model.ViewModels;

namespace UUM.Model.Context
{
    /// <summary>
    /// Context properties and connection with the database
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Parameters to create or connect to the database
        /// </summary>
        private const string Server = @"Server=(localdb)\mssqllocaldb;Database=UumDatabase01;Integrated Security=True";

        /// <summary>
        /// Properties of the tables that will be generated or used in the database
        /// </summary>
        public System.Data.Entity.DbSet<UserModel> Users { get; set; }
        public object Addresses { get; set; }

        //public System.Data.Entity.DbSet<AddressModel> Addresses { get; set; }

        //public System.Data.Entity.DbSet<CourseModel> Courses { get; set; }

        //public System.Data.Entity.DbSet<LoginModel> Logins { get; set; }

        //public System.Data.Entity.DbSet<ReportCardModel> Newsletters { get; set; }

        //public System.Data.Entity.DbSet<StudentModel> Students { get; set; }

        //public System.Data.Entity.DbSet<TeachingUnitModel> TeachingUnits { get; set; }

        /// <summary>
        /// Properties of how the database should be loaded
        /// </summary>
        /// <param name="optionsBuilder">options Builder instance</param>
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Server);
    }
}
