using Microsoft.EntityFrameworkCore;

namespace CS2WeeklyManage.Models.Commons
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().Property(i => i.Id)
                                       .ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }
    }
}