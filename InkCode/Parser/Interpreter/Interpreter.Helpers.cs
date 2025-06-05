using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class Interpreter
    {
        void Advance()
        {
            while (line == tokens[current].Line && !IsAtEnd())
            {
                current++;
            }
        }

        bool MatchTypeIndex(int index, Token.TokenType expected)
        {
            if (tokens[start + index].Type != expected)
            {
                return false;
            }

            return true;
        }

        bool IsAtEnd()
        {
            return tokens[current].Type == Token.TokenType.EOF;
        }

        Token PeekToken(int index = 0)
        {
            return tokens[start + index];
        }

        int PeekStartLine()
        {
            return tokens[start].Line;
        }

        Token.TokenType PeekType(int index = 0)
        {
            return tokens[start + index].Type;
        }

        string PeekLexeme(int index = 0)
        {
            return tokens[start + index].Lexeme;
        }

        int PeekLineCount()
        {
            return current - start;
        }
    }
}