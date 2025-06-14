using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class ExpressionParser(List<Token> tokens)
    {
        readonly List<Token> tokens = tokens;

        internal Expression? Parse(int lower, int upper)
        {
            if (AreArgumentsValid(lower, upper))
            {
                bool hadError = false;

                return Parse(lower, upper, ref hadError);
            }

            return null;
        }

        Expression? Parse(int lower, int upper, ref bool hadError)
        {
            if (!hadError)
            {
                int length = upper - lower;

                if (length == 0)
                {
                    return HandleSingleExpression(lower, ref hadError);
                }
                else if (length == 1)
                {
                    return HandleNegativeNumber(lower, upper, ref hadError);
                }
                else if (length > 1)
                {
                    int index = FindLowestPrecedenceOperator(lower, upper);

                    if (index != -1)
                    {
                        return HandleBinaryExpression(index, lower, upper, ref hadError);
                    }
                    else if (IsGroupingExpression(lower, upper))
                    {
                        return HandleGroupingExpression(lower, upper, ref hadError);
                    }
                    else if (IsFunctionCall(lower, upper))
                    {
                        return HandleFunctionCallExpression(lower, upper, ref hadError);
                    }
                }
            }

            hadError = true;
            return null;
        }
    }
}