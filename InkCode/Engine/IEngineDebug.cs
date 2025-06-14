using InkCode.ErrorManager;
using InkCode.Evaluator;

namespace InkCode.Engine
{
    public interface IEngineDebug : IErrorListener
    {
        void Report(string message);
        void PaintCanvas(CanvasState.Color[,] colors);
    }
}