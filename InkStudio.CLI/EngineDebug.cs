using InkCode.Engine;
using InkCode.Evaluator;

namespace InkStudio.CLI
{
    public class EngineDebug : IEngineDebug
    {
        public void Report(string message)
        {
            Console.WriteLine(message);
        }

        public void Report(int line, string message)
        {
            Console.WriteLine($"line: {line} | message: {message}");
        }

        public void PaintCanvas(CanvasState.Color[,] canvas)
        {
            Console.WriteLine("Canvas:");

            for (int i = 0; i < canvas.GetLength(0); i++)
            {
                for (int j = 0; j < canvas.GetLength(1); j++)
                {
                    Console.Write("|" + canvas[i, j] + "|");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        internal InkEngine CreateEngine()
        {
            return new InkEngine(this);
        }

        internal void DebugLexer(string source)
        {
            CreateEngine().DebugLexer(this, source);
        }

        internal void DebugExpressionParser(string source)
        {
            CreateEngine().DebugExpressionParser(this, source);
        }

        internal void DebugParser(string source)
        {
            CreateEngine().DebugParser(this, source);
        }

        internal void DebugInterpreterExpression(string source)
        {
            CreateEngine().InterpreterExpression(this, source, 1, 1);
        }

        internal void DebugInterpreter(string source, int canvasX, int canvasY)
        {
            CreateEngine().DebugInterpreter(this, source, canvasX, canvasY);
        }
    }
}