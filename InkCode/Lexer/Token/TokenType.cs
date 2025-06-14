namespace InkCode.Lexer
{
    internal partial class Token
    {
        internal enum TokenType
        {
            // Single-character tokens
            PLUS, MINUS, SLASH, PERCENT,
            LEFT_PAREN, RIGHT_PAREN,
            LEFT_BRACKET, RIGHT_BRACKET,
            COMMA,

            // One or two character tokens
            ASIGNE,
            EQUAL_EQUAL,
            BANG_EQUAL,
            GREATER, GREATER_EQUAL,
            LESS, LESS_EQUAL,
            STAR, POWER,
            AND,
            OR,

            // Literals
            IDENTIFIER, STRING, NUMBER,

            // Keywords
            FALSE, GOTO, TRUE,
            SPAWN,
            COLOR, SIZE,
            DRAW_LINE, DRAW_CIRCLE, DRAW_RECTANGLE, FILL,
            GET_ACTUAL_X, GET_ACTUAL_Y, GET_CANVAS_LENGTH, GET_CANVAS_WIDTH,
            GET_COLOR_COUNT, GET_BRUSH_COLOR, GET_BRUSH_SIZE,
            IS_BRUSH_COLOR, IS_BRUSH_SIZE, IS_CANVAS_COLOR,

            // End of file
            EOF
        }
    }
}