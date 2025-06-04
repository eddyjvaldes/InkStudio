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

        public void DebugLexer(string type, string lexeme, object? literal, int line)
        {
            Console.WriteLine($"type: {type}/\n"
                             + $"lexeme: {lexeme}\n"
                             + $"literal: {literal}\n"
                             + $"line: {line}\n");
        }
    }
}