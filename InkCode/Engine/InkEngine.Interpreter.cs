using InkCode.Evaluator;
using InkCode.Lexer;
using InkCode.Parser;

namespace InkCode.Engine
{
    public partial class InkEngine
    {
        CanvasState.Color[,] InterpreteSource(string source, int canvasX, int canvasY)
        {
            Interpreter interpreter = new(ParseSource(source), canvasX, canvasY, errorReporter);

            return interpreter.Execute();
        }

        public void DebugInterpreter(
            IEngineDebug engineDebug,
            string source,
            int canvasX,
            int canvasY
        )
        {
            engineDebug.PaintCanvas(InterpreteSource(source, canvasX, canvasY));

            ReportErrors();
        }

        public void InterpreterExpression(
            IEngineDebug engineDebug,
            string source,
            int canvasX,
            int canvasY
        )
        {
            List<Token> tokens = ScanContent(source);
            ExpressionParser expressionParser = new(tokens);
            Expression? expression = expressionParser.Parse(0, tokens.Count - 2);
            CanvasController canvasController = new(new (canvasX, canvasY));

            if (expression != null)
            {
                ExpressionEvaluator expressionEvaluator = new(
                    new CanvasController(new CanvasState(canvasX, canvasY)),
                    new(canvasController, errorReporter),
                    new(canvasController, errorReporter),
                    errorReporter
                );

                object? value = expressionEvaluator.Evaluate(expression, 1);

                engineDebug.Report($"value: {value}");
            }

            ReportErrors();
        }
    }
}