using InkCode.Lexer;

namespace InkCode.Parser
{
    internal class FunctionCall : Expression
    {
        internal List<Expression> Args = [];
        internal Token.TokenType Function;

        internal FunctionCall(Token.TokenType function, List<Expression> args)
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