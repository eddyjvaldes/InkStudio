namespace InkCode.Lexer
{
    internal partial class Scanner
    {
        void HandleIdentifierToken()
        {
            if (ReservedKeywords.TryGetValue(source[start..current], out Token.TokenType type))
            {
                AddKeyWordToken(type);
            }
            else
            {
                AddIdentifierToken();
            }
        }

        void HandleLess()
        {
            if (Match('='))
            {
                AddSymbolToken(Token.TokenType.LESS_EQUAL);
            }
            else if (source[current] == '-')
            {
                AddSymbolToken(Token.TokenType.ASIGNE);
            }
            else
            {
                AddSymbolToken(Token.TokenType.LESS);
            }
        }

        void HandleAnd()
        {
            if (Match('&'))
            {
                AddSymbolToken(Token.TokenType.AND);
            }
            else
            {
                AddSymbolError('&');
            }
        }

        void HandleOr()
        {
            if (Match('|'))
            {
                AddSymbolToken(Token.TokenType.OR);
            }
            else
            {
                AddSymbolError('|');
            }
        }

        void HandleSlash()
        {
            if (Match('/'))
            {
                SkipComment();
            }
            else
            {
                AddSymbolToken(Token.TokenType.SLASH);
            }
        }

        void HandleEqual()
        {
            if (Match('='))
            {
                AddSymbolToken(Token.TokenType.EQUAL_EQUAL);
            }
            else
            {
                AddSymbolError('=');
            }
        }

        void HandleBang()
        {
            if (Match('='))
            {
                AddSymbolToken(Token.TokenType.BANG_EQUAL);
            }
            else
            {
                AddSymbolError('!');
            }
        }
    }
}