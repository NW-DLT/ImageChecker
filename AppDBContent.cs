using IT_StudioTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_StudioTestTask
{
    public class AppDBContent : DbContext
    {
        public DbSet<Photos> Photos { get; set; }
        public AppDBContent(DbContextOptions<AppDBContent> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
