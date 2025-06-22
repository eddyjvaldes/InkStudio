namespace InkCode.Evaluator
{
    internal partial class OperationExecutor
    {
        object? HandlePlus(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left + (int)right;
            }
            else if (AreString(left, right))
            {
                return (string)left + (string)right;
            }

            AddInvalidOperationError($"{left} + {right}", line);

            return null;
        }
        
        object? HandleEqualEqual(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left == (int)right;
            }
            else if (AreBoolean(left, right))
            {
                return (bool)left == (bool)right;
            }
            else if (AreString(left, right))
            {
                return (string)left == (string)right;
            }
            
            AddInvalidOperationError($"{left} == {right}", line);

            return null;
        }

        object? HandleBangEqual(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left != (int)right;
            }
            else if (AreBoolean(left, right))
            {
                return (bool)left != (bool)right;
            }
            else if (AreString(left, right))
            {
                return (string)left != (string)right;
            } 

            AddInvalidOperationError($"{left} != {right}", line);

            return null;
        }
    }
}