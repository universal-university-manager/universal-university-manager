using Microsoft.EntityFrameworkCore;

namespace Uum.Web.Models
{
    /// <summary>
    /// Context properties and connection with the database
    /// </summary>
    public class Context : DbContext
    {
        private const string Server = @"Server=(localdb)\mssqllocaldb;Database=UumDatabase01;Integrated Security=True";

        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer(Server);
    }
}
