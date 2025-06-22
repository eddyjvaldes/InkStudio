namespace InkCode.Parser
{
    internal class GotoInstruction : Instruction
    {
        internal Expression Condition;
        readonly internal int LabelLine;
        internal int Calls = 0;

        internal GotoInstruction(Expression condition, int labelLine, int line) : base(line)
        {
            Condition = condition;
            LabelLine = labelLine;
        }
       public override string ToString()
        {
            return $"{Line}: Goto Instruction: {Condition} | Label Line: {LabelLine}";
        }
    }
}