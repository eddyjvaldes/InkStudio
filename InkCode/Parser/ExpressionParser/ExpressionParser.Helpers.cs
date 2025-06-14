using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class ExpressionParser
    {
        bool MatchIndex(int index, Token.TokenType expect)
        {
            return tokens[index].Type == expect;
        }

        bool AreArgumentsValid(int lower, int upper)
        {
            if (tokens.Count > 0)
            {
                return AreParenthesesBalanced(lower, upper);
            }

            return false;
        }

        bool AreParenthesesBalanced(int lower, int upper)
        {
            int depth = 0;

            for (int i = lower; i <= upper; i++)
            {
                Token.TokenType type = tokens[i].Type;

                if (type == Token.TokenType.LEFT_PAREN)
                {
                    depth++;
                }
                else if (type == Token.TokenType.RIGHT_PAREN)
                {
                    depth--;
                }
            }

            if (depth == 0)
            {
                return true;
            }

            return false;
        }
    }
}