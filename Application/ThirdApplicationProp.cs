using System.Text;

namespace Task031023.Application
{
    public class ThirdApplicationProp : IApplicationProperty
    {
        public required IRepository Repository { get; init; }
        public async Task Do()
        {
            var builder = new StringBuilder();
            var employee = await Repository.GetEmployeeUnique();
            if (employee == null)
            {
                Console.WriteLine("Data base empty or not created");
                return;
            }
            builder.AppendLine("| № | ФИО | Дата рождения | Пол | Возраст |");
            builder.AppendLine("|---|-----|---------------|-----|---------|");
            int index = 1;
            foreach (var item in employee)
            {
                builder.AppendLine($"| {index++} | {item.FirstName} {item.LastName} {item.SurnName} | {item.DateOfBirth:dd.MM.yyyy} | {item.Gender} | {item.Age} |");
            }
            await Console.Out.WriteLineAsync(builder.ToString());

        }
    }
}
