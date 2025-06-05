using InkCode.Engine;

namespace InkStudio.CLI
{
    class Program
    {
        static void Main()
        {
            // DebugEngine("");
            // DebugExpressionParser("");
        }

        static void DebugEngine(string source)
        {
            Console.WriteLine($"source: {source}\n");
            EngineDebug engineDebug = new();
            ErrorReporter errorReporter = new();

            InkEngine inkEngine = new(errorReporter);

            inkEngine.Debug(engineDebug, source);
        }

        static void DebugExpressionParser(string source)
        {
            EngineDebug engineDebug = new();
            ErrorReporter errorReporter = new();

            InkEngine inkEngine = new(errorReporter);

            inkEngine.DebugExpressionParser(engineDebug, source);
        }
    }
}