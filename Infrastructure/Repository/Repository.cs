using Microsoft.EntityFrameworkCore;
using Task031023.Application;
using System.Diagnostics;
using Task031023.Domain;

namespace Task031023.Infrastructure.Repository
{
    public class Repository : IRepository
    {
        public required EmployeeDB Context { get; init; }

        public async Task AddEmployee(List<Employee> employees)
        {
            if (!Context.Database.CanConnect()) { Console.WriteLine("DB not created"); return; };
            using var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                await Context.Employees.AddRangeAsync(employees);
                await Context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public async Task AddEmployee(Employee employee)
        {
            if (!Context.Database.CanConnect()) { Console.WriteLine("DB not created"); return; };
            await Context.AddAsync(employee);
            await Context.SaveChangesAsync();
        }

        public async Task CreateTable()
        {
            await Context.Database.MigrateAsync();
            await Console.Out.WriteLineAsync("Created to Repo");
        }

        public async Task<List<Employee>> GetEmployeeStartsWith()
        {
            if (!Context.Database.CanConnect()) return null;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = await Context.Employees.AsNoTracking()
                 .Where(e => e.Gender == Gender.Male && e.LastName.StartsWith("F"))
                 .ToListAsync();
            stopwatch.Stop();
            await Console.Out.WriteLineAsync($"Time {stopwatch.ElapsedMilliseconds} ms");
            return result;
        }

        public async Task<List<Employee>> GetEmployeeUnique()
        {
            if (!Context.Database.CanConnect()) return null;
            var result = await Context.Employees.AsQueryable().AsNoTracking()
                .GroupBy(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.SurnName,
                    e.DateOfBirth
                }).Select(g => new Employee
                {
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    SurnName = g.Key.SurnName,
                    DateOfBirth = g.Key.DateOfBirth,
                    Gender = g.First().Gender,
                    Age = DateTime.Now.Year - g.Key.DateOfBirth.Year - (DateTime.Now.DayOfYear < g.Key.DateOfBirth.DayOfYear ? 1 : 0)
                })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ThenBy(e => e.SurnName)
            .ToListAsync();
            return result;
        }
    }
}
