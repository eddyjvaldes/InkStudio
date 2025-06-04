using InkCode.ErrorManager;

namespace InkCode.Lexer
{
    internal partial class Scanner
    {
        void AddSymbolError(char symbol)
        {
            ErrorMessage.ReportInvalidSymbol(errorReporter, symbol, line);
        }

        void AddStringError()
        {
            string str = source[start..current];
            ErrorMessage.ReportInvalidString(errorReporter, str, line);
        }
    }
}