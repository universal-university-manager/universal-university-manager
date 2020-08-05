using Microsoft.EntityFrameworkCore;

namespace Uum.Web.Models
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
        public DbSet<UserModel> Users { get; set; }

        public DbSet<AddressModel> Addresses { get; set; }

        public DbSet<CourseModel> Courses { get; set; }

        public DbSet<LoginModel> Logins { get; set; }

        public DbSet<ReportCardModel> Newsletters { get; set; }

        public DbSet<StudentModel> Students { get; set; }

        public DbSet<TeachingUnitModel> TeachingUnits { get; set; }

        /// <summary>
        /// Properties of how the database should be loaded
        /// </summary>
        /// <param name="optionsBuilder">options Builder instance</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer(Server);
    }
}
