namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        internal void HandleAsigne(string name, object args)
        {
            canvasController.canvasState.LiteralsCollection.TryAdd(name, args);

            canvasController.canvasState.LiteralsCollection[name] = args;
        }

        internal bool HandleGoto(int line, object arg)
        {
            if (arg is bool condition)
            {
                if (condition == true)
                {
                    return true;
                }
            }
            else
            {
                AddArgumentsError(line);
            }

            return false; 
        }
    }
}