using EmailApp.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailApp.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
        : base(options)
        {

        }
        public DbSet<TargetEmail> targetEmails { get; set; }
        public DbSet<Natification> natifications { get; set; }

    }
}
