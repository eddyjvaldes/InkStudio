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
                        AddOutCanvasError(line);
                    }
                }
                else
                {
                    AddArgumentsError(line);
                }
            }
            else
            {
                AddArgumentsError(line);
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
                        AddOutCanvasError(line);
                    }
                }
                else
                {
                    AddArgumentsError(line);
                }
            }
            else
            {
                AddArgumentsError(line);
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
                        AddOutCanvasError(line);
                    }
                }
                else
                {
                    AddArgumentsError(line);
                }
            }
            else
            {
                AddArgumentsError(line);
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
                AddArgumentsError(line);
            }

            return null;
        }
    }
}