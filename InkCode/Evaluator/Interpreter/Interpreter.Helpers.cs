using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class Interpreter
    {
        bool IsAtEnd()
        {
            return current >= instructions.Count;
        }

        List<object>? EvaluateArguments(FunctionCallInstruction functionCall, int line)
        {
            List<object> args = [];

            foreach (var arg in functionCall.Args)
            {
                object? expression = expressionEvaluator.Evaluate(arg, line);

                if (expression != null)
                {
                    args.Add(expression);
                }
            }

            if (functionCall.Args.Count == args.Count)
            {
                return args;
            }

            return null;
        }

        int SearchLineIndex(int line)
        {
            return SearchLineIndex(line, 0, instructions.Count - 1);
        }

        int SearchLineIndex(int line, int lower, int upper)
        {
            if (lower > upper)
            {
                return lower;
            }

            int mid = (lower + upper) / 2;
            int midLine = instructions[mid].Line;

            if (line < midLine)
            {
                return SearchLineIndex(line, lower, mid - 1);
            }
            else if (line > midLine)
            {
                return SearchLineIndex(line, mid + 1, upper);
            }
            else
            {
                return mid;
            }
        }
    }
}