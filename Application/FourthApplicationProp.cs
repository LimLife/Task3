using System.Collections.Concurrent;
using Task031023.Application.Entity;
using Task031023.Domain;

namespace Task031023.Application
{
    public class FourthApplicationProp : IApplicationProperty
    {
        public required IRepository Repository { get; init; }

        private const int ITEMS = 1000000;
        private RandomEmployee _randomEmployee { get; init; } = new RandomEmployee();

        public async Task Do()
        {
            var employye = new BlockingCollection<List<Employee>>();
            var list = new List<Task>();
            for (int i = 0; i < 4; i++)
            {
                list.Add(Task.Run(() =>
                {
                    var batch = new List<Employee>();
                    for (int j = 0; j < ITEMS / 4; j++)
                    {
                        batch.Add(_randomEmployee.GetEmployees());
                        if (batch.Count >= 10000)
                        {
                            employye.Add(batch);
                            batch = new List<Employee>();
                        }
                    }
                    if (batch.Count > 0)
                    {
                        employye.Add(batch);
                    }
                }));
            }

            var consumerTask = Task.Run(async () =>
            {
                foreach (var employee in employye.GetConsumingEnumerable())
                {
                    await Repository.AddEmployee(employee);
                }
            });

            await Task.WhenAll(list);
            employye.CompleteAdding();
            await consumerTask;
        }
    }
}
