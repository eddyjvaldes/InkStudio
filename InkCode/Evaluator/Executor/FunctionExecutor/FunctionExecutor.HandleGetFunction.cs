namespace InkCode.Evaluator
{
    internal partial class FunctionExecutor
    {
        object? HandleGetActualX(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.positionX;
            }

            AddArgumentsError(line); 

            return null;
        }

        object? HandleGetActualY(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.positionY;
            }

            AddArgumentsError(line);

            return null;
        }

        object? HandleGetCanvasLength(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.CanvasX;
            }

            AddArgumentsError(line);

            return null;
        }

        object? HandleGetCanvasWidth(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.CanvasY;
            }

            AddArgumentsError(line);

            return null;
        }

        object? HandleGetBrushColor(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.BrushColor;
            }

            AddArgumentsError(line);

            return null;
        }

        object? HandleGetBrushSize(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.BrushSize;
            }

            AddArgumentsError(line);

            return null;
        }
    }
}