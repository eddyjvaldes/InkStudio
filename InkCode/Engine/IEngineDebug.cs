namespace InkCode.Engine
{
    public interface IEngineDebug
    {
        void Report(string message)
        {
            Console.WriteLine(message);
        }
    }
}