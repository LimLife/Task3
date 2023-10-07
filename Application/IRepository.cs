using Task031023.Domain;

namespace Task031023.Application
{
    public interface IRepository
    {
        public Task CreateTable();
        public Task AddEmployee(List<Employee> employees);
        public Task<List<Employee>> GetEmployeeUnique();
        public Task<List<Employee>> GetEmployeeStartsWith();
        public Task AddEmployee(Employee employee);
    }
}
