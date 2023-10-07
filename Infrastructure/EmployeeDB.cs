using Microsoft.EntityFrameworkCore;
using Task031023.Domain;

namespace Task031023.Infrastructure
{
    public class EmployeeDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Employee.db;Mode=ReadWriteCreate");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
