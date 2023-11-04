using System.Collections.Concurrent;
using System.Threading.Channels;
using Task031023.Application.Entity;
using Task031023.Domain;

namespace Task031023.Application
{
    public class FourthApplicationProp : IApplicationProperty
    {
        public required IRepository Repository { get; init; }

        private const int Items = 1000000;
        private RandomEmployee _randomEmployee { get; init; } = new RandomEmployee();

        public async Task Do()
        {
            var employeeChannel = Channel.CreateBounded<List<Employee>>(new BoundedChannelOptions(4)
            {
                FullMode = BoundedChannelFullMode.Wait
            });

            var producerTasks = new List<Task>();
            for (int i = 0; i < 4; i++)
            {
                producerTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        var batch = new List<Employee>();
                        for (int j = 0; j < Items / 4; j++)
                        {
                            batch.Add(_randomEmployee.GetEmployees());
                            if (batch.Count >= 10000)
                            {
                                await employeeChannel.Writer.WriteAsync(batch);
                                batch = new List<Employee>();
                            }
                        }
                        if (batch.Count > 0)
                        {
                            await employeeChannel.Writer.WriteAsync(batch);
                        }
                    }
                    finally
                    {
                        employeeChannel.Writer.Complete();
                    }
                }));
            }

            var consumerTask = Task.Run(async () =>
            {
                await foreach (var employee in employeeChannel.Reader.ReadAllAsync())
                {
                    await Repository.AddEmployeeAsync(employee);
                }
            });
            await Task.WhenAll(producerTasks);
            await consumerTask;
        }
    }
}
