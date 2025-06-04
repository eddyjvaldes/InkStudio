using InkCode.ErrorManager;

namespace InkStudio.CLI
{
    public class ErrorReporter : IErrorListener
    {
        public void Report(int line, string message)
        {
            Console.WriteLine($"{line} : {message}");
        }
    }
}