namespace InkCode.Evaluator
{
    internal partial class FunctionExecutor
    {
        object? HandleSpawn(List<object> args, int line)
        {
            if (args.Count == 2)
            {
                List<int> positions = ReturnIntegerArguments(args);

                if (positions.Count == args.Count)
                {
                    if (!canvasController.SetPosition(positions[0], positions[1]))
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

        object? HandleColor(List<object> args, int line)
        {
            if (args.Count == 1)
            {
                if (args[0] is string input)
                {
                    if (!canvasController.ChangeBrushColor(input))
                    {
                        AddInvalidOperationError($"Change {input} color", line);
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

        object? HandleSize(List<object> args, int line)
        {
            if (args.Count == 1)
            {
                if (args[0] is int integer)
                {
                    if (!canvasController.ChangeBrushSize(integer))
                    {
                        AddInvalidOperationError($"Change to {integer} the size of the brush", line);
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
    }
}