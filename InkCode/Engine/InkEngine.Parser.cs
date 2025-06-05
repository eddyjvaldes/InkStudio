using InkCode.Lexer;
using InkCode.Parser;

namespace InkCode.Engine
{
    public partial class InkEngine
    {
        List<Instruction> InterpretSource(string source)
        {
            Interpreter interpreter = new(ScanContent(source), errorReporter);
            return interpreter.Interpret();
        }

        public void DebugParser(IEngineDebug engineDebug, string source)
        {
            Interpreter interpreter = new(ScanContent(source), errorReporter);

            ReportInstruction(engineDebug, interpreter.Interpret());

            CheckErrors();
        }

        public void DebugExpressionParser(IEngineDebug engineDebug, string source)
        {
            List<Token> tokens = ScanContent(source);

            Expression? expression = ExpressionParser.Parse(tokens, 0, tokens.Count - 2);

            ReportExpression(engineDebug, expression);
        }

        void DebugParser(IEngineDebug engineDebug, List<Token> tokens)
        {
            Interpreter interpreter = new(tokens, errorReporter);

            ReportInstruction(engineDebug, interpreter.Interpret());

            CheckErrors();
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
        }

        static void ReportExpression(IEngineDebug engineDebug, Expression? expression)
        {
            engineDebug.Report("Expression: ");

            if (expression is BinaryExpression binaryExpression)
            {
                engineDebug.Report(binaryExpression.ToString());
            }
            else if (expression is FunctionCall functionCall)
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
        }
    }
}