namespace InkCode.Evaluator
{
    internal partial class CanvasController
    {
        internal bool DrawLine(int dirX, int dirY, int distance)
        {
            if (Math.Abs(dirX) <= 1 && Math.Abs(dirY) <= 1 && distance > 0)
            {
                int posX = canvasState.positionX;
                int posY = canvasState.positionY;

                if (IsPositionValid(posX + dirX * distance, posY + dirY * distance))
                {
                    for (int i = 0; i <= distance; i++)
                    {
                        if (!Draw(posX + i * dirX, posY + i * dirY))
                        {
                            return false;
                        }
                    }

                    Move(dirX, dirY, distance);

                    return true;
                }
            }

            return false;
        }

        internal bool DrawCircle(int dirX, int dirY, int radius)
        {
            if (Math.Abs(dirX) <= 1 && Math.Abs(dirY) <= 1 && radius > 0)
            {
                if (IsPositionValidCircle(radius, dirX, dirY))
                {
                    /*
                    Move(dirX, dirY - radius);

                    DrawLine(-1, 1, radius);
                    DrawLine(1, 1, radius);
                    DrawLine(1, -1, radius);
                    DrawLine(-1, -1, radius);

                    Move(0, radius);

                    return true;
                    */

                    int x = 0;
                    int y = radius;
                    int d = 3 - 2 * radius;

                    while (x <= y)
                    {
                        DrawSymmetricPoints(x, y);

                        if (d < 0)
                        {
                            d += 4 * x + 6;
                        }
                        else
                        {
                            d += 4 * (x - y) + 10;
                            y--;
                        }

                        x++;
                    }

                    return true;
                }
            }

            return false;
        }

        internal bool DrawRectangle(int dirX, int dirY, int distance, int width, int height)
        {
            if (
                Math.Abs(dirX) <= 1
                && Math.Abs(dirY) <= 1
                && distance >= 0
                && width >= 1
                && height >= 1
            )
            {               
                int x = canvasState.positionX + dirX * distance;
                int y = canvasState.positionY + dirY * distance;



                if (width % 2 == 0)
                {
                    width--;
                }

                if (height % 2 == 0)
                {
                    height--;
                }
                
                int midWidth = width / 2 + 1;
                int midHeight = height / 2 + 1;

                if (IsPositionValidRectangle(x, y, midWidth, midHeight))
                {
                    Move(dirX * distance - midHeight, dirY * distance - midHeight);

                    DrawLine(0, 1, 2 * midWidth);
                    DrawLine(1, 0, 2 * midHeight);
                    DrawLine(0, -1, 2 * midWidth);
                    DrawLine(-1, 0, 2 * midHeight);

                    Move(midWidth, -midHeight);

                    return true;
                }
            }

            return false;
        }

        internal bool Fill()
        {
            if (canvasState.BrushColor != CanvasState.Color.Transparent)
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
            }

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