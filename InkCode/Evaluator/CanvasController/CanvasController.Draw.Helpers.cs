namespace InkCode.Evaluator
{
    internal partial class CanvasController
    {
        void HandleAddQueue(
            int x,
            int y,
            CanvasState.Color targetColor,
            Queue<(int X, int Y)> queue,
            bool[,] canvasMask
        )
        {
            if (!canvasMask[x, y])
            {
                if (canvasState.Canvas[x, y] == targetColor)
                {
                    queue.Enqueue((x, y));
                }
            }
        }

        bool Draw(int x, int y)
        {
            if (canvasState.BrushSize == 1)
            {
                if (canvasState.BrushColor != CanvasState.Color.Transparent)
                {
                    canvasState.Canvas[x, y] = canvasState.BrushColor;
                }
                
                return true;
            }
            else
            {
                int r = (canvasState.BrushSize - 1) / 2;

                if (IsPositionValidCircle(r))
                {
                    if (canvasState.BrushColor != CanvasState.Color.Transparent)
                    {
                        for (int i = -r; i <= r; i++)
                        {
                            int circle = (int)Math.Sqrt(r * r - i * i);

                            for (int j = -circle; j <= circle; j++)
                            {
                                canvasState.Canvas[x + i, y + j] = canvasState.BrushColor;
                            }
                        }
                    }

                    return true;
                }
            }

            return false;
        }
    }
}