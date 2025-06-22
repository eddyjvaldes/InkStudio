using InkCode.ErrorManager;

namespace InkCode.Evaluator
{
    internal partial class ExpressionEvaluator
    {
        void AddVariableError(string name, int line)
        {
            ErrorMessage.ReportInvalidVariable(errorReporter, name, line);
        }
    }
}