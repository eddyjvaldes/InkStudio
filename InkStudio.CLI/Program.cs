namespace InkStudio.CLI
{
    class Program
    {
        static void Main()
        {
            EngineDebug engineDebug = new();

            engineDebug.DebugInterpreter("Spawn(0,0) \n Color(\"Yellow\") \n DrawLine(1,1, 3)", 7, 7);
        }
    }
}