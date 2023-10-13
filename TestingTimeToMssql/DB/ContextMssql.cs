using Microsoft.EntityFrameworkCore;
using TestingTimeToMssql.Modules;

namespace TestingTimeToMssql.DB
{
    public class ContextMssql : DbContext
    {
        public ContextMssql(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<UserBis> userBis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(i => i.pesel).IsUnique();
            modelBuilder.Entity<User>().Property(i => i.pesel).IsRequired();
        }
    }
}
