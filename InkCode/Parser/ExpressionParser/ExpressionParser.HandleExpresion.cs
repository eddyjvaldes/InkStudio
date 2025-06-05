using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class ExpressionParser
    {
        static Expression? HandleSingleExpression(List<Token> tokens, int index, ref bool hadError)
        {
            Token.TokenType type = tokens[index].Type;

            switch (type)
            {
                case Token.TokenType.IDENTIFIER:
                    return CreateVariableExpression(tokens, index);

                case Token.TokenType.TRUE:
                case Token.TokenType.FALSE:
                case Token.TokenType.NUMBER:
                case Token.TokenType.STRING:
                    return CreateLiteralExpression(tokens, index);

                default:
                    hadError = true;
                    return null;
            }
        }

        static LiteralExpression? HandleNegativeNumber(List<Token> tokens, int lower, int upper,
                                                ref bool hadError)
        {
            if (IsNegativeNumber(tokens, lower, upper))
            {
                return CreateNegativeNumberLiteral(tokens, upper);
            }

            hadError = true;
            return null;
        }

        static BinaryExpression? HandleBinaryExpression(List<Token> tokens, int index, int lower,
                                                        int upper, ref bool hadError)
        {
            Expression? left = Parse(tokens, lower, index - 1);
            Expression? right = Parse(tokens, index + 1, upper);

            if (left != null && right != null)
            {
                return CreateBinaryExpression(tokens[index].Type, left, right);
            }

            hadError = true;
            return null;
        }

        static Expression? HandleGroupingExpression(List<Token> tokens, int lower, int upper,
                                                    ref bool hadError)
        {
            Expression? expression = Parse(tokens, lower + 1, upper - 1);

            if (expression != null)
            {
                return expression;
            }

            hadError = true;
            return null;
        }

        static FunctionCall? HandleFunctionCallExpression(List<Token> tokens, int lower, int upper,
                                                            ref bool hadError)
        {
            Token.TokenType function = tokens[lower].Type;

            switch (function)
            {
                case Token.TokenType.GET_COLOR_COUNT:
                case Token.TokenType.IS_BRUSH_COLOR:
                case Token.TokenType.IS_BRUSH_SIZE:
                case Token.TokenType.IS_CANVAS_COLOR:

                    List<Expression>? expression = ParseFunctionArguments(tokens, lower + 2,
                                                                            upper - 1);

                    if (expression != null)
                    {
                        return CreateFunctionCallExpression(function, expression);
                    }
                    else
                    {
                        hadError = true;
                        return null;
                    }

                case Token.TokenType.GET_ACTUAL_X:
                case Token.TokenType.GET_ACTUAL_Y:
                case Token.TokenType.GET_CANVAS_LENGTH:
                case Token.TokenType.GET_CANVAS_WIDTH:
                case Token.TokenType.GET_BRUSH_COLOR:
                case Token.TokenType.GET_BRUSH_SIZE:
                    if (upper - lower == 2)
                    {
                        return CreateFunctionCallExpression(function);
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