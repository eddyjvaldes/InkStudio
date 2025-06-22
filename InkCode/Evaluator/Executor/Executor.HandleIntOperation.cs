namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        object? HandleStar(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left * (int)right;
            }

            AddInvalidOperationError($"{left} * {right}", line);

            return null;
        }

        object? HandleSlash(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                int a = (int)left;
                int b = (int)right;

                if (b != 0)
                {
                    if (MCD(a, b) != 1)
                    {
                        return a / b;
                    }
                }
            }

            AddInvalidOperationError($"{left} / {right}", line);

            return null;
        }

        object? HandlePercent(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left % (int)right;
            }

            AddInvalidOperationError($"{left} % {right}", line);

            return null;
        }

        object? HandlePower(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)Math.Pow((int)left, (int)right);
            }

            AddInvalidOperationError($"{left} ^ {right}", line);

            return null;
        }

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

        object? HandleMinus(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left - (int)right;
            }

            AddInvalidOperationError($"{left} - {right}", line);

            return null;
        }

        object? HandleLess(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left < (int)right;
            }

                AddInvalidOperationError($"{left} < {right}", line);

                return null;
        }


        object? HandleLessEqual(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left <= (int)right;
            }
            
            AddInvalidOperationError($"{left} <= {right}", line);

            return null;
        }

        object? HandleGreater(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left > (int)right;
            }
            
            AddInvalidOperationError($"{left} > {right}", line);

            return null;
        }

        object? HandleGreaterEqual(object left, object right, int line)
        {
            if (AreInteger(left, right))
            {
                return (int)left >= (int)right;
            }
            
            AddInvalidOperationError($"{left} >= {right}", line);

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
