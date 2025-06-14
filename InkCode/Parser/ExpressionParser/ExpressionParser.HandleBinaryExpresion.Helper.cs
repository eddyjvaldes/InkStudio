using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class ExpressionParser
    {
        int FindLowestPrecedenceOperator(int lower, int upper)
        {
            int minPrecedence = int.MaxValue;
            int index = -1;
            int depth = 0;

            for (int i = lower; i <= upper; i++)
            {
                if (MatchIndex(i, Token.TokenType.LEFT_PAREN))
                {
                    depth++;
                }
                else if (MatchIndex(i, Token.TokenType.RIGHT_PAREN))
                {
                    depth--;
                }
                else if (depth == 0 && IsValidBinaryOperator(i, lower))
                {
                    int precedence = GetPrecedence(i);

                    if (precedence <= minPrecedence)
                    {
                        minPrecedence = precedence;
                        index = i;
                    }
                }
            }

            return index;
        }

        int GetPrecedence(int index)
        {
            switch (tokens[index].Type)
            {
                case Token.TokenType.STAR:
                case Token.TokenType.SLASH:
                case Token.TokenType.PERCENT:
                    return 5;

                case Token.TokenType.POWER:
                    return 4;

                case Token.TokenType.PLUS:
                case Token.TokenType.MINUS:
                    return 3;

                case Token.TokenType.LESS:
                case Token.TokenType.LESS_EQUAL:
                case Token.TokenType.GREATER:
                case Token.TokenType.GREATER_EQUAL:
                case Token.TokenType.EQUAL_EQUAL:
                case Token.TokenType.BANG_EQUAL:
                    return 2;

                case Token.TokenType.OR:
                    return 1;

                case Token.TokenType.AND:
                    return 0;

                default:
                    return int.MaxValue;
            }
        }

        bool IsBinaryOperator(int index)
        {
            switch (tokens[index].Type)
            {
                case Token.TokenType.STAR:
                case Token.TokenType.SLASH:
                case Token.TokenType.PERCENT:
                case Token.TokenType.POWER:
                case Token.TokenType.PLUS:
                case Token.TokenType.MINUS:
                case Token.TokenType.LESS:
                case Token.TokenType.LESS_EQUAL:
                case Token.TokenType.GREATER:
                case Token.TokenType.GREATER_EQUAL:
                case Token.TokenType.EQUAL_EQUAL:
                case Token.TokenType.BANG_EQUAL:
                case Token.TokenType.OR:
                case Token.TokenType.AND:
                    return true;

                default:
                    return false;
            }
        }

        bool IsValidBinaryOperator(int index, int lower)
        {
            if (IsBinaryOperator(index))
            {
                if (index == lower && MatchIndex(lower, Token.TokenType.MINUS))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}