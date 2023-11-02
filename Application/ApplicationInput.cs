using Task031023.Domain;

namespace Task031023.Application
{
    public class ApplicationInput
    {
        private readonly Application _appclication;
        private State _state = State.Choose;
        public ApplicationInput(Application application)
        {
            this.ChooseParameters();
            _appclication = application;
        }

        public async Task Input()
        {
            string str = string.Empty;
            switch (_state)
            {
                case State.Choose:
                    Console.Write("Enter:");
                    str = Console.ReadLine();
                    var seccess = Enum.TryParse(str, out ApplicationParameters appEnum);
                    if (!seccess)
                    {
                        ConsoleMessage.ExceptionInput(str);
                        return;
                    }
                    _appclication.ChooseParameters(appEnum);
                    _state = State.Working;
                    break;
                case State.Working:
                  await  _appclication.Do();
                    this.Message("Enter: 'Choose' for Choose another parameters applications");
                    this.Message("Enter: 'End' for Close application");
                    str = Console.ReadLine();
                    if (string.IsNullOrEmpty(str)) {await Input(); }
                    if (str.ToLower() == "choose") { _state = State.Choose; this.ChooseParameters(); }
                    if (str.ToLower() == "end") _state = State.End;
                    break;
                case State.End:
                    Environment.Exit(0);
                    break;
            }
            Input(); 
        }
    }
}



class Application
{
    public event Action<string> LineRead;

    public void Start()
    {
        LineRead += OnLineRead;

        while (true)
        {
            var line = Console.ReadLine();
            LineRead?.Invoke(line);
        }
    }

    private void OnLineRead(string line)
    {
        // Обработка ввода пользователя
        Console.WriteLine($"Вы ввели: {line}");
    }
}

