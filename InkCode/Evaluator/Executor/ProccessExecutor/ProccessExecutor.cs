using InkCode.ErrorManager;

namespace InkCode.Evaluator
{
    internal class ProccessExecutor : Executor
    {
        internal ProccessExecutor(
            CanvasController canvasController, ErrorReporter errorReporter)
            : base(canvasController, errorReporter)
        { }

        internal void HandleAsigne(string name, object args)
        {
            canvasController.canvasState.LiteralsCollection.TryAdd(name, args);

            canvasController.canvasState.LiteralsCollection[name] = args;
        }

        internal bool HandleGoto(int line, int calls, object arg)
        {
            if (arg is bool condition)
            {
                if (calls < 10000)
                {
                    if (condition == true)
                    {
                        return true;
                    }
                }
                else
                {
                    AddGoToCallsError(line);
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