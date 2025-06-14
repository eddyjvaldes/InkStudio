using InkCode.ErrorManager;
using InkCode.Lexer;

namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        internal object? Function(Token.TokenType function, List<object> args, int line)
        {
            switch (function)
            {
                case Token.TokenType.SPAWN: return HandleSpawn(args, line);
                case Token.TokenType.COLOR: return HandleColor(args, line);
                case Token.TokenType.SIZE: return HandleSize(args, line);
                case Token.TokenType.DRAW_LINE: return HandleDrawLine(args, line);
                case Token.TokenType.DRAW_CIRCLE: return HandleDrawCircle(args, line);
                case Token.TokenType.DRAW_RECTANGLE: return HandleDrawRectangle(args, line);
                case Token.TokenType.FILL: return HandleFill(args, line);
                case Token.TokenType.GET_ACTUAL_X: return HandleGetActualX(args, line);
                case Token.TokenType.GET_ACTUAL_Y: return HandleGetActualY(args, line);
                case Token.TokenType.GET_CANVAS_LENGTH: return HandleGetCanvasLength(args, line);
                case Token.TokenType.GET_CANVAS_WIDTH: return HandleGetCanvasWidth(args, line);
                case Token.TokenType.GET_COLOR_COUNT: return HandleGetColorCount(args, line);
                case Token.TokenType.GET_BRUSH_COLOR: return HandleGetBrushColor(args, line);
                case Token.TokenType.GET_BRUSH_SIZE: return HandleGetBrushSize(args, line);
                case Token.TokenType.IS_BRUSH_COLOR: return HandleIsBrushColor(args, line);
                case Token.TokenType.IS_BRUSH_SIZE: return HandleIsBrushSize(args, line);
                case Token.TokenType.IS_CANVAS_COLOR: return HandleIsCanvasColor(args, line);

                default:
                    // error
                    return null;
            }
        }
    }
}