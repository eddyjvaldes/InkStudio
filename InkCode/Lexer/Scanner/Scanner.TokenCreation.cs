namespace InkCode.Lexer
{
    internal partial class Scanner
    {
        void AddStringToken()
        {
            AddToken(Token.TokenType.STRING, source.Substring(start + 1, current - start - 2));
        }

        void AddNumberToken()
        {
            AddToken(Token.TokenType.NUMBER, int.Parse(source[start..current]));
        }

        void AddIdentifierToken()
        {
            AddToken(Token.TokenType.IDENTIFIER, null);
        }

        void AddKeyWordToken(Token.TokenType type)
        {
            if (type == Token.TokenType.TRUE)
            {
                AddToken(type, true);
            }
            else if (type == Token.TokenType.FALSE)
            {
                AddToken(type, false);
            }
            else
            {
                AddToken(type, null);
            }
        }

        void AddSymbolToken(Token.TokenType type)
        {
            AddToken(type, null);
        }

        void AddToken(Token.TokenType type, object? literal)
        {
            tokens.Add(new Token(type, source[start..current], literal, line));
        }

        void AddEOFToken()
        {
            tokens.Add(new Token(Token.TokenType.EOF, "", null, line));
        }
    }
}