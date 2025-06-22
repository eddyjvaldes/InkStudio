using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class ExpressionParser
    {
        Expression? HandleSingleExpression(int index, ref bool hadError)
        {
            Token.TokenType type = tokens[index].Type;

            switch (type)
            {
                case Token.TokenType.IDENTIFIER:
                    return CreateVariableExpression(index);

                case Token.TokenType.TRUE:
                case Token.TokenType.FALSE:
                case Token.TokenType.NUMBER:
                case Token.TokenType.STRING:
                    return CreateLiteralExpression(index);

                default:
                    hadError = true;
                    return null;
            }
        }

        LiteralExpression? HandleNegativeNumber(
            int lower,
            int upper,
            ref bool hadError
        )
        {
            if (IsNegativeNumber(lower, upper))
            {
                return CreateNegativeNumberLiteral(upper);
            }

            hadError = true;
            return null;
        }

        BinaryExpression? HandleBinaryExpression(
            int index,
            int lower,
            int upper,
            ref bool hadError
        )
        {
            Expression? left = Parse(lower, index - 1);
            Expression? right = Parse(index + 1, upper);

            if (left != null && right != null)
            {
                return CreateBinaryExpression(tokens[index].Type, left, right);
            }

            hadError = true;
            return null;
        }

        Expression? HandleGroupingExpression(
            int lower,
            int upper,
            ref bool hadError
        )
        {
            Expression? expression = Parse(lower + 1, upper - 1);

            if (expression != null)
            {
                return expression;
            }

            hadError = true;
            return null;
        }

        FunctionCallExpression? HandleFunctionCallExpression(
            int lower,
            int upper,
            ref bool hadError
        )
        {
            Token.TokenType function = tokens[lower].Type;

            switch (function)
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

                    List<Expression>? expression = ParseFunctionArguments(lower + 2, upper - 1);

                    if (expression != null)
                    {
                        return CreateFunctionCallExpression(function, expression);
                    }
                    else
                    {
                        hadError = true;
                        return null;
                    }

                default:
                    hadError = true;
                    return null;
            }
        }
    }
}