namespace InkCode.ErrorManager
{
    public interface IErrorListener
    {
        void Report(int line, string message);
    }
}