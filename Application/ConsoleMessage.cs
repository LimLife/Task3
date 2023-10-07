using Task031023.Domain;

namespace Task031023.Application
{
    public static class ConsoleMessage
    {
        public static void MessageInfoApplication(this Application application, ApplicationParameters parameters)
        {
            Console.WriteLine($"Choose: {parameters}");
        }
        public static void ChooseParameters(this ApplicationInput path)
        {
            Console.WriteLine("For choose app parameters enter: \n\t For first:  0 or First \n\t For second: 1 or Second" +
                "\n\t For Third:  2 or Third \n\t For Fourth: 3 or Fourth \n\t For Fifth:  4 or Fifth ");

        }
        public static void InfoMessage(this ApplicationInput path)
        {
            Console.WriteLine("For change app parameters enter: choose");
        }
        public static void ExceptionInput(string str)
        {
            Console.WriteLine($"Invalid input {str}");
        }
        public static void Message(this ApplicationInput input,string str)
        {
            Console.WriteLine(str);
        }
    }

}
