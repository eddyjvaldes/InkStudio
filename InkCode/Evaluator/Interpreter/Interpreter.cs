using InkCode.ErrorManager;
using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class Interpreter
    {
        readonly List<Instruction> instructions;
        readonly CanvasController canvasController;
        readonly Executor executor;
        readonly ExpressionEvaluator expressionEvaluator;
        readonly ErrorReporter errorReporter;
        int current = 0;

        internal Interpreter(
            List<Instruction> instructions,
            int canvasX,
            int canvasY,
            ErrorReporter errorReporter
        )
        {
            this.instructions = instructions;
            canvasController = new(new CanvasState(canvasX, canvasY));
            executor = new(canvasController, errorReporter);
            expressionEvaluator = new(canvasController, errorReporter);
            this.errorReporter = errorReporter;

        }

        internal CanvasState.Color[,] Execute()
        {
            while (!IsAtEnd())
            {
                ExecuteInstruction();
                current++;
            }

            return canvasController.canvasState.Canvas;
        }

        void ExecuteInstruction()
        {
            Instruction instruction = instructions[current];
            int line = instructions[current].Line;

            if (instruction is FunctionCallInstruction functionCall)
            {
                HandleFunctionCall(functionCall, line);
            }
            else if (instruction is AssignmentInstruction assignment)
            {
                HandleAssignment(assignment, line);
            }
            else if (instruction is GotoInstruction gotoInstruction)
            {
                HandleGoto(gotoInstruction, line);
            }
            else
            {
                // error
            }
        }
    }
}