using IT_StudioTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_StudioTestTask
{
    public class AppDB2Content : DbContext
    {
        public DbSet<CopyPhoto> CopyPhoto { get; set; }
        public AppDB2Content(DbContextOptions<AppDB2Content> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
