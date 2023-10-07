using Microsoft.Extensions.Configuration;
using Task031023.Domain;

namespace Task031023.Application.Entity
{
    public class RandomEmployee
    {
        private readonly Random _random;

        private readonly List<string> _firstNameMale;
        private readonly List<string> _firstNameFemale;
        private readonly List<string> _lastName;
        private readonly List<string> _surnName;
        private readonly List<DateTime> _dateTime;

        private int _countFirstMale => _firstNameFemale.Count;
        private int _countFirstFemale => _firstNameFemale.Count;
        private int _countLastName => _lastName.Count;
        private int _countSurnName => _surnName.Count;
        private int _countDate => _dateTime.Count;

        private Gender _gender = Gender.Male;
        public RandomEmployee()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("application.json", optional: false);

            IConfiguration config = builder.Build();

            _firstNameMale = config.GetSection("firstNameMale").Get<List<string>>();
            _firstNameFemale = config.GetSection("firstNameFemale").Get<List<string>>();
            _lastName = config.GetSection("lastName").Get<List<string>>();
            _surnName = config.GetSection("surnName").Get<List<string>>();
            _dateTime = config.GetSection("dateTime").Get<List<DateTime>>();
            _random = new Random();
        }
        public Employee GetEmployees()
        {
            _gender = _gender == Gender.Male ? Gender.Female : Gender.Male;
            var name = _gender == Gender.Male ? _firstNameMale[_random.Next(0, _countFirstMale)] : _firstNameFemale[_random.Next(0, _countFirstFemale)];
            var lastName = _lastName[_random.Next(0, _countLastName)];
            var surnName = _surnName[_random.Next(0, _countSurnName)];
            var date = _dateTime[_random.Next(0, _countDate)];
            return new Employee { Gender = _gender, FirstName = name, LastName = lastName, SurnName = surnName, DateOfBirth = date };
        }
    }
}
