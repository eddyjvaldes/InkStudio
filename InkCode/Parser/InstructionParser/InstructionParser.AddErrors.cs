using InkCode.ErrorManager;

namespace InkCode.Parser
{
    internal partial class InstructionParser
    {
        void AddLabelError()
        {
            ErrorMessage.ReportInvalidLabel(errorReporter, PeekLexeme(), PeekStartLine());
        }

        void AddAsigneError()
        {
            ErrorMessage.ReportInvalidAsigne(errorReporter, PeekLexeme(), PeekStartLine());
        }

        void AddFunctionError()
        {
            ErrorMessage.ReportInvalidFunction(errorReporter, PeekLexeme(), PeekStartLine());
        }

        void AddSpawnFunctionError()
        {
            ErrorMessage.ReportInvalidSpawnFunction(errorReporter, 1);
        }

        void AddArgumentError()
        {
            ErrorMessage.ReportInvalidArguments(errorReporter, PeekStartLine());
        }

        void AddStatementError()
        {
            ErrorMessage.ReportInvalidStatement(errorReporter, PeekStartLine());
        }
    }
}
