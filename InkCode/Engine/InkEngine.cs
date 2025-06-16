using InkCode.ErrorManager;

namespace InkCode.Engine
{
    public partial class InkEngine(IErrorListener errorListener)
    {
        readonly ErrorReporter errorReporter = new(errorListener);

        public void RunFile(string path, int canvasX, int canvasY)
        {
            string content = FileContent(path);
            Run(content, canvasX, canvasY);
        }

        public void Run(string content, int canvasX, int canvasY)
        {
            InterpreteSource(content, canvasX, canvasY);

            ReportErrors();
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