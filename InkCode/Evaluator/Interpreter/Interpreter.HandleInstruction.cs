using InkCode.Lexer;
using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class Interpreter
    {
        void HandleFunctionCall(
            FunctionCallInstruction functionCallInstruction,
            bool safe,
            int line
        )
        {
            Token.TokenType function = functionCallInstruction.Function;
            List<object>? args = EvaluateArguments(functionCallInstruction, line);

            if (args != null)
            {
                AnalyzeFunctionConstantArgs(functionCallInstruction, args);

                if (safe)
                {
                    functionExecutor.Function(function, args, line);
                }
            }

            if (IsParameterlessFunction(function))
            {
                instructions.RemoveAt(current);
                current--;
            }
        }

        void HandleAssignment(AssignmentInstruction assignmentInstruction, bool safe, int line)
        {
            object? arg = expressionEvaluator.Evaluate(assignmentInstruction.Expression, line);

            if (arg != null)
            {
                if (
                    assignmentInstruction.Expression is not LiteralExpression
                    && ExpressionEvaluator.IsConstantExpression(assignmentInstruction.Expression)
                )
                {
                    assignmentInstruction.Expression = new LiteralExpression(arg);
                }

                if (safe)
                {
                    proccessExecutor.HandleAsigne(assignmentInstruction.Name, arg);
                }
            }
        }

        void HandleGoto(GotoInstruction gotoInstruction, bool safe, int line)
        {
            object? arg = expressionEvaluator.Evaluate(gotoInstruction.Condition, line);

            if (arg != null)
            {
                if (
                    gotoInstruction.Condition is not LiteralExpression
                    && ExpressionEvaluator.IsConstantExpression(gotoInstruction.Condition)
                )
                {
                    gotoInstruction.Condition = new LiteralExpression(arg);
                }
                
                if (proccessExecutor.HandleGoto(line, gotoInstruction.Calls, arg))
                {
                    if (safe)
                    {
                        gotoInstruction.Calls++;
                        
                        current = SearchLineIndex(gotoInstruction.LabelLine) - 1;
                    }
                }
            }
        }
    }
}