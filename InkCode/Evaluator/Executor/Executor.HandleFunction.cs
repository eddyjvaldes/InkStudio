using InkCode.ErrorManager;

namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        object? HandleSpawn(List<object> args, int line)
        {
            if (args.Count == 2)
            {
                List<int> positions = ReturnIntegerArguments(args);

                if (positions.Count == args.Count)
                {
                    if (!canvasController.SetPosition(positions[0], positions[1]))
                    {
                        // error
                    }
                }
                else
                {
                    // error
                }
            }
            else
            {
                // error
            }

            return null;
        }

        object? HandleColor(List<object> args, int line)
        {
            if (args.Count == 1)
            {
                if (args[0] is string input)
                {
                    if (!canvasController.ChangeBrushColor(input))
                    {
                        // error
                    }
                }
                else
                {
                    // error
                }
            }
            else
            {
                // error
            }

            return null;
        }

        object? HandleSize(List<object> args, int line)
        {
            if (args.Count == 1)
            {
                if (args[0] is int integer)
                {
                    if (!canvasController.ChangeBrushSize(integer))
                    {
                        // error
                    }
                }
                else
                {
                    // error
                }
            }
            else
            {
                // error
            }

            return null;
        }
    }
}