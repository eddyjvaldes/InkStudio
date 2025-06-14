using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class ExpressionParser
    {
        VariableExpression CreateVariableExpression(int index)
        {
            return new VariableExpression(tokens[index].Lexeme);
        }

        LiteralExpression CreateLiteralExpression(int index)
        {
            return new LiteralExpression(tokens[index].Literal!);
        }

        LiteralExpression CreateNegativeNumberLiteral(int index)
        {
            int number = -(int)tokens[index].Literal!;

            return new LiteralExpression(number);
        }

        static BinaryExpression CreateBinaryExpression(
            Token.TokenType symbol,
            Expression left,
            Expression right
        )
        {
            return new BinaryExpression(symbol, left, right);
        }

        static FunctionCallExpression CreateFunctionCallExpression(
            Token.TokenType function,
            List<Expression> expression
        )
        {
            return new FunctionCallExpression(function, expression);
        }

        static FunctionCallExpression CreateFunctionCallExpression(Token.TokenType function)
        {
            return new FunctionCallExpression(function, []);
        }
    }
}