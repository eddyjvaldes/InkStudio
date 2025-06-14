namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        internal void HandleAsigne(string name, object args)
        {
            if (!canvasController.canvasState.LiteralsCollection.TryAdd(name, args))
            {
                canvasController.canvasState.LiteralsCollection[name] = args;
            }
        }

        internal static int? HandleGoto(int line, object args)
        {
            if (args is bool validArgs)
            {
                if (validArgs)
                {
                    return line;
                }
            }

            // error
            return -1;
        }
    }
}