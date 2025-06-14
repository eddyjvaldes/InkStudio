namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        static object? HandleStar(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left * (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandleSlash(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left / (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandlePercent(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left % (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandlePower(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)Math.Pow((int)left, (int)right);
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandlePlus(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left + (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandleMinus(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left - (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandleLess(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left < (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandleLessEqual(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left <= (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandleGreater(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left > (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandleGreaterEqual(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left >= (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandleEqualEqual(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left == (int)right;
            }
            else
            {
                // error
                return null;
            }
        }

        static object? HandleBangEqual(object left, object right)
        {
            if (AreInteger(left, right))
            {
                return (int)left != (int)right;
            }
            else
            {
                // error
                return null;
            }
        }
    }
}