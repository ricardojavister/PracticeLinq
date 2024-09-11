using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ScoreRecord> ScoreRecords => Set<ScoreRecord>();
    }

}
