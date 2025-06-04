using InkCode.Lexer;

namespace InkCode.Engine
{
    public partial class InkEngine
    {
        List<Token> ScanContent(string source)
        {
            Scanner scanner = new(source, errorReporter);
            List<Token> tokens = scanner.Scan();

            return tokens;
        }

        public void DebugLexer(IEngineDebug engineDebug, string source)
        {
            List<Token> tokens = ScanContent(source);

            DebugTokens(engineDebug, tokens);

            CheckErrors();
        }

        static void DebugTokens(IEngineDebug engineDebug, List<Token> tokens)
        {
            foreach (var token in tokens)
            {
                engineDebug.DebugLexer(token.Type.ToString(), token.Lexeme, token.Literal
                                        , token.Line);
            }
        }
    }
}