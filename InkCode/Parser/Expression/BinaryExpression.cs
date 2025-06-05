using InkCode.Lexer;

namespace InkCode.Parser
{
    internal class BinaryExpression : Expression
    {
        internal Expression Left;
        internal Expression Right;
        internal Token.TokenType Operation;

        internal BinaryExpression(Token.TokenType operation, Expression left, Expression right)
        {
            Left = left;
            Right = right;
            Operation = operation;
        }

        public override string ToString()
        {
            return $"Binary expression:  Left: {Left} | Operation {Operation} | Right {Right}";
        }
    }
}