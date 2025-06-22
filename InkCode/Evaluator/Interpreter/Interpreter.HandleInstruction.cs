using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class Interpreter
    {
        void HandleFunctionCall(FunctionCallInstruction functionCallInstruction, int line)
        {

            List<object>? args = EvaluateArguments(functionCallInstruction, line);

            if (args != null)
            {
                executor.Function(functionCallInstruction.Function, args, line);
            }
        }

        void HandleAssignment(AssignmentInstruction assignmentInstruction, int line)
        {
            object? arg = expressionEvaluator.Evaluate(assignmentInstruction.Expression, line);

            if (arg != null)
            {
                executor.HandleAsigne(assignmentInstruction.Name, arg);
            }
        }

        void HandleGoto(GotoInstruction gotoInstruction, int line)
        {
            object? arg = expressionEvaluator.Evaluate(gotoInstruction.Condition, line);

            if (arg != null)
            {
                if (executor.HandleGoto(line, arg))
                {
                    current = SearchLineIndex(gotoInstruction.LabelLine);
                }
            }
        }
    }
}