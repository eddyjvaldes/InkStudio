using InkCode.Engine;

namespace InkStudio.CLI
{
    public class EngineDebug : IEngineDebug
    {
        public static void DebugLexer(string source)
        {
            EngineDebug engineDebug = new();
            ErrorReporter errorReporter = new();

            InkEngine inkEngine = new(errorReporter);

            inkEngine.DebugLexer(engineDebug, source);
        }

        public void Report(string message)
        {
            Console.WriteLine(message);
        }
    }
}