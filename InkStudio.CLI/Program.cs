namespace InkStudio.CLI
{
    class Program
    {
        static void Main()
        {
            EngineDebug engineDebug = new();

            engineDebug.DebugInterpreter("Spawn(1 , 1 - 1) \n Color(\"Blu\" + \"e\") \n DrawLine(1, GetActualX(), 4)", 5, 5);
        }
    }
}