namespace InkCode.Engine
{
    public interface IEngineDebug
    {
        void DebugLexer(string type, string lexeme, object? literal, int line);
    }
}