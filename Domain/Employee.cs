namespace Task031023.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurnName { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public Gender Gender { get; set; }

        public int Age { get; set; }
    }
}
