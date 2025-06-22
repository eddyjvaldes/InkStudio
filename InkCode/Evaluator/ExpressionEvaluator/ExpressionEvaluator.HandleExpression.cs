using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class ExpressionEvaluator
    {
        object? HandleBinaryExpression(
            BinaryExpression expression,
            int line,
            ref bool hadError
        )
        {
            if (!hadError)
            {
                object? left = Evaluate(expression.Left, line, ref hadError);
                object? right = Evaluate(expression.Right, line, ref hadError);

                if (left != null && right != null)
                {
                    if (
                        expression.Left is not LiteralExpression
                        && IsConstantExpression(expression.Left)
                    )
                    {
                        expression.Left = new LiteralExpression(left);
                    }

                    if (
                        expression.Right is not LiteralExpression
                        && IsConstantExpression(expression.Right)
                    )
                    {
                        expression.Right = new LiteralExpression(right);
                    }
                    
                    return operationExecutor.Operation(expression.Operation, left, right, line);
                }
            }

            hadError = true;
            return null;
        }

        object? HandleFunctionCallExpression(
            FunctionCallExpression functionCall,
            int line,
            ref bool hadError
        )
        {
            if (!hadError)
            {
                List<object> expressions = [];

                foreach (var expression in functionCall.Args)
                {
                    object? arg = Evaluate(expression, line, ref hadError);

                    if (arg != null)
                    {
                        expressions.Add(arg);
                    }
                }

                if (functionCall.Args.Count == expressions.Count)
                {
                    return functionExecutor.Function(functionCall.Function, expressions, line);
                }
            }

            hadError = true;
            return null;
        }

        object? HandleVariableExpression(
            VariableExpression variableExpression,
            int line,
            ref bool hadError
        )
        {
            if (!hadError)
            {
                string name = variableExpression.Name;

                if (canvasController.canvasState.LiteralsCollection.TryGetValue(
                    name,
                    out object? value
                    )
                )
                {
                    return value;
                }

                AddVariableError(name, line);
            }

            hadError = true;
            return null;
        }
    }
}