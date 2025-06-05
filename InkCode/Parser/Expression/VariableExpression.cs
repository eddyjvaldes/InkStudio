namespace InkCode.Parser
{
    internal class VariableExpression : Expression
    {
        readonly internal string Name;

        internal VariableExpression(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return "VariableExpression: " + Name.ToString();
        }
    }
}