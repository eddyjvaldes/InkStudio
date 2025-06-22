using InkCode.ErrorManager;

namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        void AddStamentError(int line)
        {
            ErrorMessage.ReportInvalidStatement(errorReporter, line);
        }

        void AddArgumentsError(int line)
        {
            ErrorMessage.ReportInvalidArguments(errorReporter, line);
        }

        void AddInvalidOperationError(string operation, int line)
        {
            ErrorMessage.ReportInvalidOperation(errorReporter, operation, line);
        }

        void AddOutCanvasError(int line)
        {
            ErrorMessage.ReportOutCanvas(errorReporter, line);
        }
    }
}