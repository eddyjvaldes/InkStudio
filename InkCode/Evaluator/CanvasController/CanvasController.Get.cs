namespace InkCode.Evaluator
{
    internal partial class CanvasController
    {
        internal bool IsCanvasColor(CanvasState.Color color, int vertical, int horizontal)
        {
            int x = canvasState.positionX + horizontal;
            int y = canvasState.positionY + vertical;

            if (IsPositionValid(x, y))
            {
                if (canvasState.Canvas[x, y] == color)
                {
                    return true;
                }
            }

            return false;
        }

        internal int GetColorCount(CanvasState.Color color, int x1, int y1, int x2, int y2)
        {
            int count = 0;

            if (IsPositionValid(x1, y1) && IsPositionValid(x2, y2))
            {
                int c;

                if (x1 > x2)
                {
                    c = x1;
                    x1 = x2;
                    x2 = c;
                }

                if (y1 > y2)
                {
                    c = y1;
                    y1 = y2;
                    y2 = c;
                }

                for (int i = x1; i <= x2; i++)
                {
                    for (int j = y1; j <= y2; j++)
                    {
                        if (canvasState.Canvas[i, j] == color)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
}