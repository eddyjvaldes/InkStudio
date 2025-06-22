using InkCode.Lexer;
using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class Interpreter
    {
        bool IsAtEnd()
        {
            return current >= instructions.Count;
        }

        bool IsSafeLine()
        {
            int first = errorReporter.FirstErrorLine();

            if (first == -1 || first > instructions[current].Line)
            {
                return true;
            }

            return false;
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

        static bool IsParameterlessFunction(Token.TokenType function)
        {
            switch (function)
            {

                case Token.TokenType.GET_ACTUAL_X:
                case Token.TokenType.GET_ACTUAL_Y:
                case Token.TokenType.GET_CANVAS_LENGTH:
                case Token.TokenType.GET_CANVAS_WIDTH:
                case Token.TokenType.GET_BRUSH_COLOR:
                case Token.TokenType.GET_BRUSH_SIZE:
                    return true;

                default:
                    return false;
            }
        }

        static void AnalyzeFunctionConstantArgs(
            FunctionCallInstruction functionCallInstruction,
            List<object> args
        )
        {
            List<Expression> functionArgs = functionCallInstruction.Args;

            for (int i = 0; i < args.Count; i++)
            {
                if (
                    functionArgs[i] is not LiteralExpression
                    && ExpressionEvaluator.IsConstantExpression(functionArgs[i])
                )
                {
                    functionArgs[i] = new LiteralExpression(args[i]); 
                }
            }
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