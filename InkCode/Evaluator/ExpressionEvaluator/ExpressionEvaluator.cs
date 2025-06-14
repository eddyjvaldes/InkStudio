using InkCode.ErrorManager;
using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class ExpressionEvaluator(
        CanvasController canvasController,
        ErrorReporter errorReporter
    )
    {
        readonly Executor executor = new(canvasController, errorReporter);

        internal object? Evaluate(Expression expression, int line)
        {
            bool hadError = false;

            if (expression is BinaryExpression binaryExpression)
            {
                return HandleBinaryExpression(binaryExpression, line, ref hadError);
            }
            else if (expression is FunctionCallExpression functionCall)
            {
                return HandleFunctionCallExpression(functionCall, line, ref hadError);
            }
            else if (expression is LiteralExpression literalExpression)
            {
                return literalExpression.Literal;
            }
            else if (expression is VariableExpression variableExpression)
            {
                return HandleVariableExpression(variableExpression, ref hadError);
            }
            else
            {
                hadError = true;
                return null;
            }
        }
    }
}