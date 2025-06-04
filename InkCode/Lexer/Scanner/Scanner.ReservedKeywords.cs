namespace InkCode.Lexer
{
    internal partial class Scanner
    {
        internal static readonly Dictionary<string, Token.TokenType> ReservedKeywords = new()
        {
            { "False", Token.TokenType.FALSE},
            { "GoTo", Token.TokenType.GOTO},
            { "True", Token.TokenType.TRUE },
            { "Spawn", Token.TokenType.SPAWN },
            { "Color", Token.TokenType.COLOR },
            { "Size", Token.TokenType.SIZE },
            { "DrawLine", Token.TokenType.DRAW_LINE },
            { "DrawCircle", Token.TokenType.DRAW_CIRCLE },
            { "DrawRectangle", Token.TokenType.DRAW_RECTANGLE },
            { "Fill", Token.TokenType.FILL },
            { "Move", Token.TokenType.MOVE},
            { "GetActualX", Token.TokenType.GET_ACTUAL_X },
            { "GetActualY", Token.TokenType.GET_ACTUAL_Y },
            { "GetCanvasLength", Token.TokenType.GET_CANVAS_LENGTH },
            { "GetCanvasWidth", Token.TokenType.GET_CANVAS_WIDTH},
            { "GetColorCount", Token.TokenType.GET_COLOR_COUNT },
            { "GetBrushColor", Token.TokenType.GET_BRUSH_SIZE},
            { "GetBrushSize", Token.TokenType.GET_BRUSH_SIZE},
            { "IsBrushColor", Token.TokenType.IS_BRUSH_COLOR },
            { "IsBrushSize", Token.TokenType.IS_BRUSH_SIZE },
            { "IsCanvasColor", Token.TokenType.IS_CANVAS_COLOR },
        };
    }
}