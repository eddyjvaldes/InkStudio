using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class ExpressionParser
    {
        static VariableExpression CreateVariableExpression(List<Token> token, int index)
        {
            return new VariableExpression(token[index].Lexeme);
        }

        static LiteralExpression CreateLiteralExpression(List<Token> token, int index)
        {
            return new LiteralExpression(token[index].Literal!);
        }

        static LiteralExpression CreateNegativeNumberLiteral(List<Token> token, int index)
        {
            int number = -(int)token[index].Literal!;

            return new LiteralExpression(number);
        }

        static BinaryExpression CreateBinaryExpression(Token.TokenType symbol, Expression left,
                                                        Expression right)
        {
            return new BinaryExpression(symbol, left, right);
        }

        static FunctionCall CreateFunctionCallExpression(Token.TokenType function
                                                        , List<Expression> expression)
        {
            return new FunctionCall(function, expression);
        }

        static FunctionCall CreateFunctionCallExpression(Token.TokenType function)
        {
            return new FunctionCall(function, []);
        }
    }
}