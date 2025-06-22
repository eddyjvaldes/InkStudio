using InkCode.Parser;


namespace InkCode.Evaluator
{
    internal partial class ExpressionEvaluator
    {
        internal static bool IsConstantExpression(Expression expression)
        {
            if (expression is BinaryExpression binaryExpression)
            {
                return IsConstantExpression(binaryExpression.Left)
                    && IsConstantExpression(binaryExpression.Right);
            }
            else if (expression is LiteralExpression)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}