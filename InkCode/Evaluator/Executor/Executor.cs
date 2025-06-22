using InkCode.ErrorManager;

namespace InkCode.Evaluator
{
    abstract internal partial class Executor(CanvasController canvasController, ErrorReporter errorReporter)
    {
        protected readonly CanvasController canvasController = canvasController;
        protected readonly ErrorReporter errorReporter = errorReporter;
    }
}