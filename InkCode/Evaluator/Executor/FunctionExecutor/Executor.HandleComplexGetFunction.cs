namespace InkCode.Evaluator
{
    internal partial class FunctionExecutor
    {
        object? HandleGetColorCount(List<object> args, int line)
        {
            if (args.Count == 5)
            {
                if (args[0] is string color)
                {
                    if (Enum.TryParse<CanvasState.Color>(color, out var validColor))
                    {
                        List<int> ints = ReturnIntegerArguments(args);

                        if (ints.Count == 4)
                        {
                            return canvasController.GetColorCount(
                                validColor,
                                ints[1],
                                ints[2],
                                ints[3],
                                ints[4]
                            );
                        }
                    }
                }
            }

            AddArgumentsError(line);

            return null;
        }

        object? HandleIsBrushColor(List<object> args, int line)
        {
            if (args.Count == 1)
            {
                if (args[0] is string color)
                {
                    if (Enum.TryParse<CanvasState.Color>(color, out var validColor))
                    {
                        return validColor == canvasController.canvasState.BrushColor;
                    }
                }
            }

            AddArgumentsError(line);

            return null;
        }

        object? HandleIsBrushSize(List<object> args, int line)
        {
            if (args.Count == 1)
            {
                if (args[0] is int size)
                {
                    return size == canvasController.canvasState.BrushSize;
                }
            }

            AddArgumentsError(line);

            return null;
        }

        object? HandleIsCanvasColor(List<object> args, int line)
        {
            if (args.Count == 3)
            {
                if (args[0] is string color)
                {
                    if (Enum.TryParse<CanvasState.Color>(color, out var validColor))
                    {
                        List<int> ints = ReturnIntegerArguments(args);

                        if (ints.Count == 2)
                        {
                            return canvasController.IsCanvasColor(validColor, ints[0], ints[1]);
                        }
                    }
                }
            }

            AddArgumentsError(line);

            return null;
        }
    }
}