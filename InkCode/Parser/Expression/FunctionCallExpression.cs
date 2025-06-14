using InkCode.Lexer;

namespace InkCode.Parser
{
    internal class FunctionCallExpression : Expression
    {
        internal List<Expression> Args = [];
        internal Token.TokenType Function;

        internal FunctionCallExpression(Token.TokenType function, List<Expression> args)
        {
            Function = function;
            Args = args;
        }

        public override string ToString()
        {
            string message = "Function Call" + Function.ToString() + ": ";

            foreach (var args in Args)
            {
                message += args + ", ";
            }

            return message;
        }
    }
}