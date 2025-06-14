using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class InstructionParser
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
            if (tokens[index].Type != expected)
            {
                return false;
            }

            return true;
        }

        bool IsAtEnd()
        {
            return tokens[current].Type == Token.TokenType.EOF;
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