using InkCode.Lexer;

namespace InkCode.Parser
{
    internal static partial class ExpressionParser
    {
        internal static Expression? Parse(List<Token> args, int lower, int upper)
        {
            if (AreArgumentsValid(args))
            {
                bool hadError = false;

                return Parse(args, lower, upper, ref hadError);
            }

            return null;
        }

        static Expression? Parse(List<Token> tokens, int lower, int upper, ref bool hadError)
        {
            if (!hadError)
            {
                int length = upper - lower;

                if (length == 0)
                {
                    return HandleSingleExpression(tokens, lower, ref hadError);
                }
                else if (length == 1)
                {
                    return HandleNegativeNumber(tokens, lower, upper, ref hadError);
                }
                else if (length > 1)
                {
                    int index = FindLowestPrecedenceOperator(tokens, lower, upper);

                    if (index != -1)
                    {
                        return HandleBinaryExpression(tokens, index, lower, upper, ref hadError);
                    }
                    else if (IsGroupingExpression(tokens, lower, upper))
                    {
                        return HandleGroupingExpression(tokens, lower, upper, ref hadError);
                    }
                    else if (IsFunctionCall(tokens, lower, upper))
                    {
                        return HandleFunctionCallExpression(tokens, lower, upper, ref hadError);
                    }
                }
            }

            hadError = true;
            return null;
        }
    }
}