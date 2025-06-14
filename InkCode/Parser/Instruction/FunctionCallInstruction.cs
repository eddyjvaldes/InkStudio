using InkCode.Lexer;

namespace InkCode.Parser
{
    internal class FunctionCallInstruction : Instruction
    {
        readonly internal Token.TokenType Function;
        internal List<Expression> Args;

        internal FunctionCallInstruction(
            Token.TokenType function,
            List<Expression> args,
            int line)
            : base(line)
        {
            Function = function;
            Args = args;
        }

        public override string ToString()
        {
            string message = $"{Line} :Function Call Instruction: {Function} | Args: ";

            foreach (var arg in Args)
            {
                message += arg + " ,";
            }

            return message;
        }
    }
}