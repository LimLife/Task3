using Microsoft.EntityFrameworkCore;
using Task031023.Domain;

namespace Task031023.Infrastructure
{
    public class EmployeeDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDB(DbContextOptions<EmployeeDB> db) : base(db) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

    }
}
