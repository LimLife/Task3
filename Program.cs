using Task031023.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Task031023.Infrastructure;
using Task031023.Application;

var op = new DbContextOptionsBuilder<EmployeeDB>();
ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("application.json");
IConfigurationRoot configurationRoot = builder.Build();
string conntectionString = configurationRoot.GetConnectionString("employee");
op.UseSqlite(conntectionString);
var db = new EmployeeDB(op.Options);

IRepository repository = new Repository() { Context = db };
Application app = new(repository);
ApplicationInput path = new(app);

await path?.Input();





