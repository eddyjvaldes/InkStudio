using InkCode.ErrorManager;

namespace InkCode.Evaluator
{
    internal partial class Executor(CanvasController canvasController, ErrorReporter errorReporter)
    {
        readonly CanvasController canvasController = canvasController;
        readonly ErrorReporter errorReporter = errorReporter;
    }
}