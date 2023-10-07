namespace Task031023.Application
{
    public class FirstApplicationProp : IApplicationProperty
    {
        public required IRepository Repository { get; init; }

        /// <summary>
        /// Create Table
        /// </summary>
        public async Task Do()
        {
            await Repository.CreateTable();
            Console.WriteLine("Created Table");
            return;
        }
    }
}
