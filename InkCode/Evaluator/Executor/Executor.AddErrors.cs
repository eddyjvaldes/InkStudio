using InkCode.ErrorManager;

namespace InkCode.Evaluator
{
    abstract internal partial class Executor
    {
        protected void AddStamentError(int line)
        {
            ErrorMessage.ReportInvalidStatement(errorReporter, line);
        }

        protected void AddArgumentsError(int line)
        {
            ErrorMessage.ReportInvalidArguments(errorReporter, line);
        }

        protected void AddInvalidOperationError(string operation, int line)
        {
            ErrorMessage.ReportInvalidOperation(errorReporter, operation, line);
        }

        protected void AddOutCanvasError(int line)
        {
            ErrorMessage.ReportOutCanvas(errorReporter, line);
        }

        protected void AddGoToCallsError(int line)
        {
            ErrorMessage.ReportGoToExceedsLimitCalls(errorReporter, line);
        }
    }
}