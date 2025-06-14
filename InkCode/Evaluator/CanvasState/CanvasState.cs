namespace InkCode.Evaluator
{
    public partial class CanvasState
    {
        // Canvas
        internal readonly int CanvasX;
        internal readonly int CanvasY;
        internal readonly Color[,] Canvas;

        // Position
        internal int positionX;
        internal int positionY;

        // Brush
        internal int BrushSize = 1;
        internal Color BrushColor = Color.Transparent;

        // Variable
        internal readonly Dictionary<string, object> LiteralsCollection = [];

        internal CanvasState(int canvasX, int canvasY)
        {
            // analizar la exception
            if (canvasX * canvasY <= 0)
            {
                throw new Exception("Invalid canvas dimensions");
            }

            CanvasX = canvasX;
            CanvasY = canvasY;
            Canvas = new Color[CanvasX, CanvasY];
        }
    }
}