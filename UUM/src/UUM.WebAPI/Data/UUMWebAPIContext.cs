using Microsoft.EntityFrameworkCore;

namespace UUM.WebAPI.Data
{
    public class UUMWebAPIContext : DbContext
    {
        public UUMWebAPIContext (DbContextOptions<UUMWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Register> Register { get; set; }
    }
}
