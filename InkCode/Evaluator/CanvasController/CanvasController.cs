namespace InkCode.Evaluator
{
    internal partial class CanvasController(CanvasState canvasState)
    {
        readonly internal CanvasState canvasState = canvasState;

        internal bool ChangeBrushColor(string input)
        {
            if (Enum.TryParse<CanvasState.Color>(input, out var color))
            {
                canvasState.BrushColor = color;
                return true;
            }

            return false;
        }

        internal bool ChangeBrushSize(int size)
        {
            if (size > 0)
            {
                if (size % 2 == 0)
                {
                    canvasState.BrushSize = size - 1;
                }
                else
                {
                    canvasState.BrushSize = size;
                }

                return true;
            }

            return false;
        }
    }
}