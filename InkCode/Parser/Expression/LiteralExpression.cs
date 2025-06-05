namespace InkCode.Parser
{
    internal class LiteralExpression : Expression
    {
        internal object Literal;

        internal LiteralExpression(object literal)
        {
            Literal = literal;
        }

        public override string ToString()
        {
            return $"Literal Expression: {Literal}";
        }
    }
}