namespace InkStudio.CLI
{
    class Program
    {
        static void Main()
        {
            EngineDebug engineDebug = new();

            engineDebug.DebugInterpreter("Spawn(0,0) \n Color(\"Blue\") \n DrawLine(1, 0, 3)",5,5);
        }
    }
}