using Task031023.Domain;

namespace Task031023.Application
{
    public class Application
    {
        private readonly Dictionary<ApplicationParameters, IApplicationProperty> _app;
        private IApplicationProperty _applicationProperty;
        public Application(IRepository repository)
        {
            _app = new Dictionary<ApplicationParameters, IApplicationProperty>
            {
              { ApplicationParameters.First, new FirstApplicationProp   { Repository = repository } },
              { ApplicationParameters.Second, new SecondApplicationProp { Repository = repository } },
              { ApplicationParameters.Third, new ThirdApplicationProp   { Repository = repository } },
              { ApplicationParameters.Fourth, new FourthApplicationProp { Repository = repository } },
              { ApplicationParameters.Fifth, new FifthApplicationProp   { Repository = repository } }
            };
        }
        public void ChooseParameters(ApplicationParameters parameters)
        {
            this.MessageInfoApplication(parameters);
            _app.TryGetValue(parameters, out _applicationProperty);
        }
        public async Task Do()
        {
            await _applicationProperty.Do();
        }
    }
}