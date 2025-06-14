namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        internal object? HandleDrawLine(List<object> args, int line)
        {
            if (args.Count == 3)
            {
                List<int> ints = ReturnIntegerArguments(args);

                if (args.Count == ints.Count)
                {
                    if (!canvasController.DrawLine(ints[0], ints[1], ints[2]))
                    {
                        // error
                    }
                }
                else
                {
                    // error
                }
            }
            else
            {
                // error
            }

            return null;
        }

        internal object? HandleDrawCircle(List<object> args, int line)
        {
            if (args.Count == 3)
            {
                List<int> ints = ReturnIntegerArguments(args);

                if (args.Count == ints.Count)
                {
                    if (!canvasController.DrawCircle(ints[0], ints[1], ints[2]))
                    {
                        // error
                    }
                }
                else
                {
                    // error
                }
            }
            else
            {
                // error
            }

            return null;
        }

        internal object? HandleDrawRectangle(List<object> args, int line)
        {
            if (args.Count == 5)
            {
                List<int> ints = ReturnIntegerArguments(args);

                if (args.Count == ints.Count)
                {
                    if (!canvasController.DrawRectangle(
                        ints[0],
                        ints[1],
                        ints[2],
                        ints[3],
                        ints[4]
                    )
                    )
                    {
                        // error
                    }
                }
                else
                {
                    // error
                }
            }
            else
            {
                // error
            }

            return null;
        }

        internal object? HandleFill(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                canvasController.Fill();
            }
            else
            {
                // error
            }

            return null;
        }
    }
}