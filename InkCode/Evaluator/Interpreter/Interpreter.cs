using InkCode.ErrorManager;
using InkCode.Parser;

namespace InkCode.Evaluator
{
    internal partial class Interpreter
    {
        readonly List<Instruction> instructions;
        readonly ErrorReporter errorReporter;
        readonly CanvasController canvasController;
        readonly ExpressionEvaluator expressionEvaluator;
        readonly FunctionExecutor functionExecutor;
        readonly ProccessExecutor proccessExecutor;
        readonly OperationExecutor operationExecutor;
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

            functionExecutor = new(canvasController, errorReporter);
            proccessExecutor = new(canvasController, errorReporter);
            operationExecutor = new(canvasController, errorReporter);

            expressionEvaluator = new(
                canvasController,
                functionExecutor,
                operationExecutor,
                errorReporter
                );

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