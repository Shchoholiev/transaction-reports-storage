using Microsoft.EntityFrameworkCore;
using TransactionReportsStorage.Core.Entities;
using TransactionReportsStorage.Infrastructure.FluentAPI;

namespace TransactionReportsStorage.Infrastructure.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecordEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CellEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }

        public DbSet<Record> Records { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Cell> Cells { get; set; }
    }
}
