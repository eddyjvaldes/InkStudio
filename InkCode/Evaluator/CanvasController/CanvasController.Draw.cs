namespace InkCode.Evaluator
{
    internal partial class CanvasController
    {
        internal bool DrawLine(int dirX, int dirY, int distance)
        {
            if (Math.Abs(dirX) <= 1 && Math.Abs(dirY) <= 1 && distance > 0)
            {
                Draw(canvasState.positionX, canvasState.positionY);

                for (int i = 0; i < distance; i++)
                {
                    if (Move(dirY, dirX))
                    {
                        if (!Draw(canvasState.positionX, canvasState.positionY))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        internal bool DrawCircle(int dirX, int dirY, int radius)
        {
            if (Math.Abs(dirX) <= 1 && Math.Abs(dirY) <= 1 && radius % 2 != 0)
            {
                if (Move(dirX, dirY))
                {
                    if (IsPositionValidCircle(dirX, dirY, radius))
                    {
                        for (int i = -radius; i <= radius; i++)
                        {
                            int x = dirX + i;
                            int circle = (int)Math.Sqrt(radius * radius - i * i);

                            if (!(Draw(x, dirY + circle) && Draw(x, dirY - circle)))
                            {
                                return false;
                            }
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        internal bool DrawRectangle(int dirX, int dirY, int distance, int width, int height)
        {
            if (
                Math.Abs(dirX) <= 1
                && Math.Abs(dirY) <= 1
                && distance > 0
                && width > 1
                && height > 1
            )
            {
                int x = canvasState.positionX + dirX * distance;
                int y = canvasState.positionY + dirY * distance;

                if (IsPositionValidRectangle(x, y, width, height))
                {
                    int midHeight = height / 2;
                    int midWidth = width / 2;

                    Move(-midWidth + x, midHeight + y);

                    DrawLine(1, 0, 2 * midWidth + 1);
                    DrawLine(0, -1, 2 * midHeight + 1);
                    DrawLine(-1, 0, 2 * midWidth + 1);
                    DrawLine(0, 1, 2 * midHeight + 1);

                    Move(midWidth, -midHeight);

                    return true;
                }

            }

            return false;

        }

        internal bool Fill()
        {
            bool[,] canvasMask = new bool[canvasState.CanvasX, canvasState.CanvasY];
            Queue<(int x, int y)> queue = new();

            CanvasState.Color targetColor = canvasState.Canvas[
                canvasState.positionX,
                canvasState.positionY
            ];

            queue.Enqueue((canvasState.positionX, canvasState.positionY));
            canvasMask[canvasState.positionX, canvasState.positionY] = true;

            Fill(canvasMask, targetColor, queue);

            return true;
        }

        void Fill(bool[,] canvasMask, CanvasState.Color targetColor, Queue<(int, int)> queue)
        {
            if (queue.Count != 0)
            {
                (int X, int Y) = queue.Dequeue();

                canvasState.Canvas[X, Y] = canvasState.BrushColor;

                int right = X + 1;
                int left = X - 1;
                int down = Y + 1;
                int up = Y - 1;

                if (right < canvasState.CanvasX)
                {
                    HandleAddQueue(right, Y, targetColor, queue, canvasMask);
                }

                if (left >= 0)
                {
                    HandleAddQueue(left, Y, targetColor, queue, canvasMask);
                }

                if (up >= 0)
                {
                    HandleAddQueue(X, up, targetColor, queue, canvasMask);
                }

                if (down < canvasState.CanvasY)
                {
                    HandleAddQueue(X, down, targetColor, queue, canvasMask);
                }

                Fill(canvasMask, targetColor, queue);
            }
        }


    }
}