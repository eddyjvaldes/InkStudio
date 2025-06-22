using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class ExpressionParser
    {
        bool IsNegativeNumber(int lower, int upper)
        {
            return MatchIndex(lower, Token.TokenType.MINUS)
                && MatchIndex(upper, Token.TokenType.NUMBER);
        }

        bool IsGroupingExpression(int lower, int upper)
        {
            return MatchIndex(lower, Token.TokenType.LEFT_PAREN)
                && MatchIndex(upper, Token.TokenType.RIGHT_PAREN);
        }

        bool IsFunctionCall(int lower, int upper)
        {
            if (
                MatchIndex(lower + 1, Token.TokenType.LEFT_PAREN)
                && MatchIndex(upper, Token.TokenType.RIGHT_PAREN)
            )
            {
                switch (tokens[lower].Type)
                {
                    case Token.TokenType.GET_COLOR_COUNT:
                    case Token.TokenType.IS_BRUSH_COLOR:
                    case Token.TokenType.IS_BRUSH_SIZE:
                    case Token.TokenType.IS_CANVAS_COLOR:
                    case Token.TokenType.GET_ACTUAL_X:
                    case Token.TokenType.GET_ACTUAL_Y:
                    case Token.TokenType.GET_CANVAS_LENGTH:
                    case Token.TokenType.GET_CANVAS_WIDTH:
                    case Token.TokenType.GET_BRUSH_COLOR:
                    case Token.TokenType.GET_BRUSH_SIZE:
                        return true;

                    default:
                        return false;
                }
            }

            return false;
        }

        List<Expression>? ParseFunctionArguments(int lower, int upper)
        {
            List<Expression> expressions = [];

            if (upper < lower)
            {
                return expressions;
            }

            int index = lower;

            for (int i = lower; i <= upper; i++)
            {
                if (MatchIndex(i, Token.TokenType.COMMA))
                {
                    if (lower < i && i < upper)
                    {
                        Expression? expression = Parse(index, i - 1);

                        index = i + 1;

                        if (expression != null)
                        {
                            expressions.Add(expression);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (i == upper)
                {
                    Expression? expression = Parse(index, i);

                    if (expression != null)
                    {
                        expressions.Add(expression);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return expressions;
        }
    }
}