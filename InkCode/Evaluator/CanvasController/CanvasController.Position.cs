namespace InkCode.Evaluator
{
    internal partial class CanvasController
    {
        bool Move(int dirX, int dirY, int distance = 1)
        {
            int x = canvasState.positionX + dirX * distance;
            int y = canvasState.positionY + dirY * distance;

            if (!SetPosition(x, y))
            {
                return false;
            }

            return true;
        }

        bool IsPositionValidCircle(int x, int y, int radius)
        {
            if (
                IsPositionValid(x - radius, y)
                && IsPositionValid(x + radius, y)
                && IsPositionValid(x, y + radius)
                && IsPositionValid(x, y - radius)
            )
            {
                return true;
            }

            return false;
        }

        bool IsPositionValidRectangle(int x, int y, int width, int height)
        {
            int midWidth = width / 2;
            int midHeight = height / 2;

            if (
                IsPositionValid(x + midWidth, y)
                && IsPositionValid(x - midWidth, y)
                && IsPositionValid(x, y + midHeight)
                && IsPositionValid(x, y - midHeight)
            )
            {
                return true;
            }

            return false;
        }

        bool IsPositionValid(int positionX, int positionY)
        {

            return positionX * positionY >= 0
                && positionX < canvasState.CanvasX
                && positionY < canvasState.CanvasY;
        }

        internal bool SetPosition(
            int x,
            int y
        )
        {
            if (IsPositionValid(x, y))
            {
                canvasState.positionX = x;
                canvasState.positionY = y;
                return true;
            }

            return false;
        }
    }
}