using InkCode.ErrorManager;

namespace InkCode.Lexer
{
    internal partial class Scanner(string source, ErrorReporter errorReporter)
    {
        readonly string source = source;
        readonly ErrorReporter errorReporter = errorReporter;
        readonly List<Token> tokens = [];
        int start = 0;
        int current = 0;
        int line = 1;

        internal List<Token> Scan()
        {
            if (source.Length > 0)
            {
                while (!IsAtEnd())
                {
                    start = current;
                    ScanToken();
                }
            }

            AddEOFToken();

            return tokens;
        }

        void ScanToken()
        {
            char c = Advance();

            switch (c)
            {
                // single characters
                case '(': AddSymbolToken(Token.TokenType.LEFT_PAREN); break;
                case ')': AddSymbolToken(Token.TokenType.RIGHT_PAREN); break;
                case '[': AddSymbolToken(Token.TokenType.LEFT_BRACKET); break;
                case ']': AddSymbolToken(Token.TokenType.RIGHT_BRACKET); break;
                case ',': AddSymbolToken(Token.TokenType.COMMA); break;
                case '+': AddSymbolToken(Token.TokenType.PLUS); break;
                case '-': AddSymbolToken(Token.TokenType.MINUS); break;
                case '%': AddSymbolToken(Token.TokenType.PERCENT); break;

                // two characters
                case '=': HandleEqual(); break;
                case '<': HandleLess(); break;
                case '&': HandleAnd(); break;
                case '|': HandleOr(); break;
                case '/': HandleSlash(); break;

                case '!': HandleBang(); break;

                case '>':
                    AddSymbolToken(Match('=') ? Token.TokenType.GREATER_EQUAL : Token.TokenType.GREATER);
                    break;

                case '*':
                    AddSymbolToken(Match('*') ? Token.TokenType.POWER : Token.TokenType.STAR);
                    break;

                // Whitespace
                case ' ':
                case '\r':
                case '\t':
                    break;

                case '\n':
                    line++;
                    break;

                // String literal
                case '"': AnalyzeString(); break;

                default:
                    // Number literal and Identifier
                    if (char.IsDigit(c))
                    {
                        AnalyzeNumber();
                    }
                    else if (IsAlpha(c))
                    {
                        AnalyzeIdentifier();
                    }
                    else
                    {
                        AddSymbolError(c);
                    }
                    break;
            }
        }
    }
}