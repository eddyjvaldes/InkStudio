using InkCode.ErrorManager;
using InkCode.Lexer;
using InkCode.Parser;

namespace InkCode.Engine
{
    public partial class InkEngine(IErrorListener errorListener)
    {
        string? path;
        readonly ErrorReporter errorReporter = new(errorListener);

        public int RunFile()
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path), "Path must not be null.");
            }

            string content = FileContent(path);
            Run(content);

            return CheckErrors();
        }

        void Run(string source)
        {
            List<Instruction> instructions = InterpretSource(source);
        }

        public void Debug(IEngineDebug engineDebug, string source)
        {
            List<Token> tokens = ScanContent(source);
            ReportTokens(engineDebug, tokens);

            DebugParser(engineDebug, tokens);
        }

        int CheckErrors()
        {
            if (errorReporter.HadError)
            {
                errorReporter.ReportAllErrors();
                return 1;
            }

            return 0;
        }
    }
}