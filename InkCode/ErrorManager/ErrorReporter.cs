namespace InkCode.ErrorManager
{
    internal class ErrorReporter(IErrorListener listener)
    {
        internal bool HadError { get; private set; } = false;
        readonly List<Error> Errors = [];
        readonly IErrorListener listener = listener;

        internal void AddError(int line, string message)
        {
            InsertError(CreateError(line, message));

            HadError = true;
        }

        internal void ReportAllErrors()
        {
            foreach (var error in Errors)
            {
                listener.Report(error.Line, error.Message);
            }
        }

        internal void Clear()
        {
            HadError = false;
            Errors.Clear();
        }

        void InsertError(Error error)
        {
            if (Errors.Count == 0)
            {
                Errors.Add(error);
            }
            else
            {
                Errors.Insert(IndexError(error), error);
            }
        }

        static Error CreateError(int line, string message)
        {
            return new Error(line, message);
        }

        int IndexError(Error error)
        {
            return SearchLineIndex(error.Line, 0, Errors.Count - 1);
        }

        int SearchLineIndex(int line, int lower, int upper)
        {
            if (lower > upper)
            {
                return lower;
            }

            int mid = (lower + upper) / 2;
            int midLine = Errors[mid].Line;

            if (line < midLine)
            {
                return SearchLineIndex(line, lower, mid - 1);
            }
            else if (line > midLine)
            {
                return SearchLineIndex(line, mid + 1, upper);
            }
            else
            {
                return mid;
            }
        }
    }
}