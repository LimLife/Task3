using System.Text.RegularExpressions;
using Task031023.Domain;

namespace Task031023.Application
{
    public class SecondApplicationProp : IApplicationProperty
    {
        public required IRepository Repository { get; init; }
        public async Task Do()
        {
            Console.WriteLine("Input format for Example: \"Ivanov Petr Sergeevich\" 2009-07-12 Male");
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("Empty input");
                await Do();
            }
            string pattern = "\"([^\"]*)\" (\\d{4}-\\d{2}-\\d{2}) (\\w+)";
            Match match = Regex.Match(str, pattern);

            if (match.Success)
            {
                string fullName = match.Groups[1].Value;
                DateTime birthDate = DateTime.Parse(match.Groups[2].Value);
                string gender = match.Groups[3].Value;

                string[] nameParts = fullName.Split(' ');
                string lastName = nameParts[0];
                string firstName = nameParts[1];
                string surnName = nameParts[2];

                bool success = Enum.TryParse(gender, out Gender genderParse);
                if (success)
                {
                    var employee = new Employee
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        SurnName = surnName,
                        DateOfBirth = birthDate,
                        Gender = genderParse
                    };
                    await Repository.AddEmployeeAsync(employee);
                }
            }
        }
    }
}
