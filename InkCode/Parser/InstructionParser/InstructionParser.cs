using InkCode.ErrorManager;
using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class InstructionParser(List<Token> tokens, ErrorReporter errorReporter)
    {
        readonly List<Instruction> instructions = [];
        readonly List<Token> tokens = tokens;
        readonly Dictionary<string, int> labelsCollection = [];
        readonly ExpressionParser expressionParser = new(tokens);
        readonly ErrorReporter errorReporter = errorReporter;
        int start = 0;
        int current = 0;
        int line = tokens[0].Line;

        internal List<Instruction> Parse()
        {
            FindLabels();

            if (PeekType() != Token.TokenType.SPAWN)
            {
                AddSpawnFunctionError();
            }

            ParseTokens();

            return instructions;
        }

        void ParseTokens()
        {
            while (!IsAtEnd())
            {
                ParseLine();

                start = current;
                line = PeekStartLine();
            }
        }

        void ParseLine()
        {
            Advance();

            switch (PeekType())
            {
                // processes
                case Token.TokenType.IDENTIFIER: HandleAsigne(); break;
                case Token.TokenType.GOTO: HandleGoto(); break;

                // functions
                case Token.TokenType.SPAWN: HandleSpawn(); break;
                case Token.TokenType.COLOR:
                case Token.TokenType.SIZE:
                case Token.TokenType.DRAW_LINE:
                case Token.TokenType.DRAW_CIRCLE:
                case Token.TokenType.DRAW_RECTANGLE:
                case Token.TokenType.FILL:
                case Token.TokenType.GET_COLOR_COUNT:
                case Token.TokenType.IS_BRUSH_COLOR:
                case Token.TokenType.IS_BRUSH_SIZE:
                case Token.TokenType.IS_CANVAS_COLOR:
                case Token.TokenType.GET_ACTUAL_X:
                case Token.TokenType.GET_ACTUAL_Y:
                case Token.TokenType.GET_CANVAS_LENGTH:
                case Token.TokenType.GET_CANVAS_WIDTH:
                case Token.TokenType.GET_BRUSH_COLOR:
                case Token.TokenType.GET_BRUSH_SIZE:
                    HandleFunction();
                    break;

                default:
                    AddStatementError();
                    break;
            }
        }
    }
}