using InkCode.ErrorManager;
using InkCode.Evaluator;

namespace InkCode.Engine
{
    public partial class InkEngine(IErrorListener errorListener)
    {
        readonly ErrorReporter errorReporter = new(errorListener);

        public CanvasState.Color[,] RunFile(string path, int canvasX, int canvasY)
        {
            errorReporter.Clear();
            string content = FileContent(path);
            
            return Run(content, canvasX, canvasY);
        }

        public CanvasState.Color[,] Run(string content, int canvasX, int canvasY)
        {
            errorReporter.Clear();

            CanvasState.Color[,] canvas = InterpreteSource(content, canvasX, canvasY);

            ReportErrors();

            return canvas;
        }

        void ReportErrors()
        {
            if (errorReporter.HadError)
            {
                errorReporter.ReportAllErrors();
            }
        }
    }
}