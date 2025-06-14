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
                object? left = Evaluate(expression.Left, line);
                object? right = Evaluate(expression.Right, line);

                if (left != null && right != null)
                {
                    return executor.Operation(expression.Operation, left, right);
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
                    object? arg = Evaluate(expression, line);

                    if (arg != null)
                    {
                        expressions.Add(arg);
                    }
                }

                if (functionCall.Args.Count == expressions.Count)
                {
                    return executor.Function(functionCall.Function, expressions, line);
                }
            }

            hadError = true;
            return null;
        }

        object? HandleVariableExpression(
            VariableExpression variableExpression,
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
            }

            hadError = true;
            return null;
        }
    }
}