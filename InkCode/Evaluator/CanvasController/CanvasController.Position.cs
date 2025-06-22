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

        bool IsPositionValidCircle(int radius, int x = 0, int y = 0)
        {
            int posX = canvasState.positionX + x;
            int posY = canvasState.positionY + y;

            if (
                IsPositionValid(posX - radius, posY)
                && IsPositionValid(posX + radius, posY)
                && IsPositionValid(posX, posY + radius)
                && IsPositionValid(posX, posY - radius)
            )
            {
                return true;
            }

            return false;
        }

        bool IsPositionValidRectangle(int x, int y, int midWidth, int midHeight)
        {
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