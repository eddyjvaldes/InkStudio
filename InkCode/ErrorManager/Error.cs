namespace InkCode.ErrorManager
{
    internal class Error(int line, string message)
    {
        readonly internal int Line = line;
        readonly internal string Message = message;
    }
}