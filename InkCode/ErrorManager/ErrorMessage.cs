namespace InkCode.ErrorManager
{
    internal static class ErrorMessage
    {
        internal static void ReportInvalidSymbol(ErrorReporter errorReporter, char symbol, int line)
        {
            errorReporter.AddError(line, $"Invalid character: '{symbol}'.");
        }

        internal static void ReportInvalidString(ErrorReporter errorReporter, string str, int line)
        {
            errorReporter.AddError(line, $"Invalid string: \"{str}\".");
        }

        internal static void ReportInvalidLabel(ErrorReporter errorReporter, string label, int line)
        {
            errorReporter.AddError(line, $"There is another label with the name \"{label}]\"");
        }

        internal static void ReportInvalidFunction(
            ErrorReporter errorReporter,
            string function,
            int line
        )
        {
            errorReporter.AddError(line, $"Invalid function: \"{function}\"");
        }

        internal static void ReportInvalidSpawnFunction(ErrorReporter errorReporter, int line)
        {
            errorReporter.AddError(
                line,
                "The first function of the code has to be \"Spawn\" function"
            );
        }

        internal static void ReportInvalidAsigne(ErrorReporter errorReporter, string name, int line)
        {
            errorReporter.AddError(line, $"There is a label with the name \"{name}\"");
        }

        internal static void ReportInvalidStatement(ErrorReporter errorReporter, int line)
        {
            errorReporter.AddError(line, $"Invalid statement");
        }

        internal static void ReportInvalidArguments(ErrorReporter errorReporter, int line)
        {
            errorReporter.AddError(line, "Invalid arguments");
        }

        internal static void ReportInvalidOperation(ErrorReporter errorReporter, string operation, int line)
        {
            errorReporter.AddError(line, $"Invalid operation {operation}");
        }

        internal static void ReportInvalidVariable(ErrorReporter errorReporter, string name, int line)
        {
            errorReporter.AddError(line, $"The variable {name} does not exist");
        }

        internal static void ReportGoToExceedsLimitCalls(ErrorReporter errorReporter, int line)
        {
            errorReporter.AddError(
                line,
                "The expression GoTo exceeds the maximum limit of calls" + "(10 000)"
            );
        }

        internal static void ReportOutCanvas(ErrorReporter errorReporter, int line)
        {
            errorReporter.AddError(line, "Output of the canvas");
        }
    }
}