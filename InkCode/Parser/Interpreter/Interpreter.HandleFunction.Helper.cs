using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class Interpreter
    {
        List<Expression>? ParserArguments(int lower, int upper)
        {
            List<Expression> expressions = [];

            int index = lower;

            for (int i = lower; i <= upper; i++)
            {
                if (MatchTypeIndex(i, Token.TokenType.COMMA))
                {
                    if (lower < i && i < upper)
                    {
                        Expression? expression = ExpressionParser.Parse(tokens, index, i - 1);

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
                    Expression? expression = ExpressionParser.Parse(tokens, index, upper);

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

        bool CheckFunctionParenthesis()
        {
            return MatchTypeIndex(1, Token.TokenType.LEFT_PAREN)
                    && MatchTypeIndex(current - 1, Token.TokenType.RIGHT_PAREN);

        }

        bool IsFunctionValid()
        {
            if (PeekLineCount() >= 3)
            {
                if (CheckFunctionParenthesis())
                {
                    return true;
                }
            }

            return false;
        }
    }
}