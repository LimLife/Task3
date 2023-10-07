using System.Text;

namespace Task031023.Application
{
    public class FifthApplicationProp : IApplicationProperty
    {
        public required IRepository Repository { get; init; }

        public async Task Do()
        {
            //var list =
                await Repository.GetEmployeeStartsWith();
          //  if (list == null) { Console.WriteLine("BD is not created"); return; }
            //var builder = new StringBuilder();
            //builder.AppendLine("| № | ФИО | Дата рождения | Пол |");
            //builder.AppendLine("|---|-----|---------------|-----|");
            //int index = 1;
            //foreach (var item in list)
            //{
            //    await Console.Out.WriteLineAsync(builder.AppendLine($"| {index++} | {item.FirstName} {item.LastName} {item.SurnName} | {item.DateOfBirth.ToString("dd.MM.yyyy")} | {item.Gender} |"));
            //}
        }
    }
}
