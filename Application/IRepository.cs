using Task031023.Domain;

namespace Task031023.Application
{
    public interface IRepository
    {
        public Task CreateTableAsync();
        public Task AddEmployeeAsync(List<Employee> employees);
        public Task<List<Employee>> GetEmployeeUniqueAsync();
        public Task<List<Employee>> GetEmployeeStartsWithAsync();
        public Task AddEmployeeAsync(Employee employee);
    }
}
