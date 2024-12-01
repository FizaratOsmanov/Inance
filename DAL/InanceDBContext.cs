using Inance.Models;
using Microsoft.EntityFrameworkCore;

namespace Inance.DAL
{
    public class InanceDBContext : DbContext 
    {
        public InanceDBContext(DbContextOptions  options):base(options)
        {
            
        }

        public DbSet<Masters> Masters { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Services> Services { get; set; }

    }
}
