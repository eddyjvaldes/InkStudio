namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        static List<int> ReturnIntegerArguments(List<object> args)
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

        static bool AreInteger(object left, object right)
        {
            if (left is int && right is int)
            {
                return true;
            }

            return false;
        }

        static bool AreBoolean(object left, object right)
        {
            if (left is bool && right is bool)
            {
                return true;
            }

            return false;
        }

        static bool AreString(object left, object right)
        {
            if (left is string && right is string)
            {
                return true;
            }

            return false;
        }

        internal static int MCD(int a, int b)
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