namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        object? HandleOr(object left, object right)
        {
            if (AreBoolean(left, right))
            {
                return (bool)left || (bool)right;
            }
            else
            {
                // error
                return null;
            }
        }

        object? HandleAnd(object left, object right)
        {
            if (AreBoolean(left, right))
            {
                return (bool)left && (bool)right;
            }
            else
            {
                // error
                return null;
            }
        }
    }
}