namespace Task031023.Application
{
    public class FirstApplicationProp : IApplicationProperty
    {
        public required IRepository Repository { get; init; }

        public async Task Do()
        {
            await Repository.CreateTable();         
        }
    }
}
