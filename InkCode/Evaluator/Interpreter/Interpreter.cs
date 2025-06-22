using InkCode.ErrorManager;
using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class Interpreter
    {
        readonly List<Instruction> instructions;
        readonly ErrorReporter errorReporter;
        readonly CanvasController canvasController;
        readonly Executor executor;
        readonly ExpressionEvaluator expressionEvaluator;
        int current = 0;

        internal Interpreter(
            List<Instruction> instructions,
            int canvasX,
            int canvasY,
            ErrorReporter errorReporter
        )
        {
            this.instructions = instructions;
            this.errorReporter = errorReporter;
            canvasController = new(new CanvasState(canvasX, canvasY));
            executor = new(canvasController, errorReporter);
            expressionEvaluator = new(canvasController, errorReporter);
        }

        internal CanvasState.Color[,] Execute()
        {
            while (!IsAtEnd())
            {

                ExecuteInstruction(IsSafeLine());
                current++;
            }

            return canvasController.canvasState.Canvas;
        }

        void ExecuteInstruction(bool safe)
        {
            Instruction instruction = instructions[current];
            int line = instructions[current].Line;

            if (instruction is FunctionCallInstruction functionCall)
            {
                HandleFunctionCall(functionCall, safe, line);
            }
            else if (instruction is AssignmentInstruction assignment)
            {
                HandleAssignment(assignment, safe, line);
            }
            else if (instruction is GotoInstruction gotoInstruction)
            {
                HandleGoto(gotoInstruction, safe, line);
            }
        }
    }
}