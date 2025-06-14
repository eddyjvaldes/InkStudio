namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        object? HandleGetActualX(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.positionX;
            }
            else
            {
                // error
            }

            return null;
        }

        object? HandleGetActualY(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.positionY;
            }
            else
            {
                // error
            }

            return null;
        }

        object? HandleGetCanvasLength(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.CanvasX;
            }
            else
            {
                // error
            }

            return null;
        }

        object? HandleGetCanvasWidth(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.CanvasY;
            }
            else
            {
                // error
            }

            return null;
        }

        object? HandleGetBrushColor(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.BrushColor;
            }
            else
            {
                // error
            }

            return null;
        }

        object? HandleGetBrushSize(List<object> args, int line)
        {
            if (args.Count == 0)
            {
                return canvasController.canvasState.BrushSize;
            }
            else
            {
                // error
            }

            return null;
        }
    }
}