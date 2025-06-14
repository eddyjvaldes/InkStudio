using InkCode.Lexer;

namespace InkCode.Engine
{
    public partial class InkEngine
    {
        List<Token> ScanContent(string source)
        {
            Scanner scanner = new(source, errorReporter);
            return scanner.Scan();
        }

        public void DebugLexer(IEngineDebug engineDebug, string source)
        {
            ReportTokens(engineDebug, ScanContent(source));
            ReportErrors();
        }

        static void ReportTokens(IEngineDebug engineDebug, List<Token> tokens)
        {
            engineDebug.Report("Lexer: ");

            foreach (var token in tokens)
            {
                engineDebug.Report(token.ToString());
            }

            engineDebug.Report("");
        }
    }
}