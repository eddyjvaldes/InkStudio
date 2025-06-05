namespace InkCode.Parser
{
    internal class AssignmentInstruction : Instruction
    {
        readonly internal string Name;
        internal Expression Expression;

        internal AssignmentInstruction(string name, Expression expression, int line) : base(line)
        {
            Name = name;
            Expression = expression;
        }

        public override string ToString()
        {
            return $"{Line} :Assignment Instruction: {Name} | Expression: {Expression}";
        }
    }
}