namespace InkCode.Parser
{
    internal partial class Interpreter
    {
        void AddFunctionCallInstruction(List<Expression> arg)
        {
            instructions.Add(new FunctionCallInstruction(PeekType(), arg, PeekStartLine()));
        }

        void AddAssignmentInstruction(Expression expression)
        {
            instructions.Add(new AssignmentInstruction(PeekLexeme(), expression,
                                                        PeekStartLine()));
        }

        void AddGotoInstruction(Expression expression, int labelLine)
        {
            instructions.Add(new GotoInstruction(expression, labelLine, PeekStartLine()));
        }
    }
}