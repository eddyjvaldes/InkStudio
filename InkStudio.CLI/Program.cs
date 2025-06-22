namespace InkStudio.CLI
{
    class Program
    {
        static void Main()
        {
            EngineDebug engineDebug = new();

            engineDebug.DebugInterpreter("Spawn(1, 1) \n a \n GoTo [a] (True)", 5, 5);
        }
    }
}