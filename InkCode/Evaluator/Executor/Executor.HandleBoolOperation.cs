namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        object? HandleOr(object left, object right, int line)
        {
            if (AreBoolean(left, right))
            {
                return (bool)left || (bool)right;
            }
            else
            {
                AddInvalidOperationError($"{left} || {right}", line);

                return null;
            }
        }

        object? HandleAnd(object left, object right, int line)
        {
            if (AreBoolean(left, right))
            {
                return (bool)left && (bool)right;
            }
            else
            {
                AddInvalidOperationError($"{left} && {right}", line);
                
                return null;
            }
        }
    }
}