using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UUM.WebAPI.Models;

namespace UUM.WebAPI.Data
{
    public class UUMWebAPIContext : DbContext
    {
        public UUMWebAPIContext (DbContextOptions<UUMWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<UUM.WebAPI.Models.Register> Register { get; set; }
    }
}
