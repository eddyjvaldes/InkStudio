using InkCode.Lexer;
using InkCode.Parser;

namespace InkCode.Engine
{
    public partial class InkEngine
    {
        List<Instruction> ParseSource(string source)
        {
            InstructionParser interpreter = new(ScanContent(source), errorReporter);
            return interpreter.Parse();
        }

        public void DebugParser(IEngineDebug engineDebug, string source)
        {
            ReportInstruction(engineDebug, ParseSource(source));

            ReportErrors();
        }

        public void DebugExpressionParser(IEngineDebug engineDebug, string source)
        {
            List<Token> tokens = ScanContent(source);
            ExpressionParser expressionParser = new(tokens);

            ReportExpression(engineDebug, expressionParser.Parse(0, tokens.Count - 2));

            ReportErrors();
        }

        static void ReportInstruction(IEngineDebug engineDebug, List<Instruction> instructions)
        {
            engineDebug.Report("Parser:");

            foreach (var instruction in instructions)
            {
                if (instruction is AssignmentInstruction assignment)
                {
                    engineDebug.Report(assignment.ToString());
                }
                else if (instruction is FunctionCallInstruction functionCall)
                {
                    engineDebug.Report(functionCall.ToString());
                }
                else if (instruction is GotoInstruction gotoInstruction)
                {
                    engineDebug.Report(gotoInstruction.ToString());
                }
                else
                {
                    engineDebug.Report("Error");
                }
            }

            engineDebug.Report("");
        }


        static void ReportExpression(IEngineDebug engineDebug, Expression? expression)
        {
            engineDebug.Report("Expression: ");

            if (expression is BinaryExpression binaryExpression)
            {
                engineDebug.Report(binaryExpression.ToString());
            }
            else if (expression is FunctionCallExpression functionCall)
            {
                engineDebug.Report(functionCall.ToString());
            }
            else if (expression is LiteralExpression literalExpression)
            {
                engineDebug.Report(literalExpression.ToString());
            }
            else if (expression is VariableExpression variableExpression)
            {
                engineDebug.Report(variableExpression.ToString());
            }
            else
            {
                engineDebug.Report("Error");
            }

            engineDebug.Report("");
        }
    }
}