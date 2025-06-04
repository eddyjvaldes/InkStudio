namespace InkCode.Lexer
{
    internal partial class Token(Token.TokenType type, string lexeme, object? literal, int line)
    {
        readonly internal TokenType Type = type;
        readonly internal string Lexeme = lexeme;
        readonly internal object? Literal = literal;
        readonly internal int Line = line;
    }
}