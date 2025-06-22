namespace InkCode.Evaluator
{
    abstract internal partial class Executor
    {
        protected static List<int> ReturnIntegerArguments(List<object> args)
        {
            List<int> ints = [];

            foreach (var arg in args)
            {
                if (arg is int integer)
                {
                    ints.Add(integer);
                }
            }

            return ints;
        }

        protected static bool AreInteger(object left, object right)
        {
            if (left is int && right is int)
            {
                return true;
            }

            return false;
        }

        protected static bool AreBoolean(object left, object right)
        {
            if (left is bool && right is bool)
            {
                return true;
            }

            return false;
        }

        protected static bool AreString(object left, object right)
        {
            if (left is string && right is string)
            {
                return true;
            }

            return false;
        }

        protected internal static int MCD(int a, int b)
        {
            int rest = a % b;

            if (rest == 0)
            {
                return b;
            }

            return MCD(b, rest);
        }
    }
}