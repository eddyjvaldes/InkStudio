using InkCode.ErrorManager;
using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class ExpressionEvaluator(
        CanvasController canvasController,
        FunctionExecutor functionExecutor,
        OperationExecutor operationExecutor,
        ErrorReporter errorReporter
    )
    {
        readonly CanvasController canvasController = canvasController;
        readonly FunctionExecutor functionExecutor =functionExecutor;
        readonly OperationExecutor operationExecutor = operationExecutor;

        internal object? Evaluate(Expression expression, int line)
        {
            bool hadError = false;

            return Evaluate(expression, line, ref hadError);
        }

        internal object? Evaluate(Expression expression, int line, ref bool hadError)
        {
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
                return HandleVariableExpression(variableExpression, line, ref hadError);
            }
            else
            {
                hadError = true;
                return null;
            }
        }
    }
}