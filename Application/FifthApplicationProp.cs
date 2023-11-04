using System.Text;

namespace Task031023.Application
{
    public class FifthApplicationProp : IApplicationProperty
    {
        public required IRepository Repository { get; init; }

        public async Task Do()
        {
            await Repository.GetEmployeeStartsWithAsync();
        }
    }
}
