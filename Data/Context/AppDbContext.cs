using Microsoft.EntityFrameworkCore;
using POC.EF.SqlServer.API.Entities;

namespace POC.EF.SqlServer.API.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        private const string CONNECTION_STRING = $"Data Source=34.173.40.202;Initial Catalog=ef-sql-server;User ID=sqlserver;Password=tlcosta2589;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(CONNECTION_STRING);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(e => e.Name).HasMaxLength(200);

            modelBuilder.Entity<Company>().Property(c => c.Name).HasMaxLength(200);
            modelBuilder.Entity<Company>().Property(c => c.ZipCode).HasMaxLength(8);
            modelBuilder.Entity<Company>().Property(c => c.Phone).HasMaxLength(11);
        }

    }
}
