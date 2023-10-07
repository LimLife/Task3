using Task031023.Application;
using Task031023.Infrastructure;
using Task031023.Infrastructure.Repository;

var db = new EmployeeDB();
IRepository repository = new Repository() { Context = db };
Application app = new(repository);
ApplicationInput path = new(app);

path?.Input();





