namespace InkCode.Lexer
{
    internal partial class Scanner
    {
        bool Match(char expected)
        {
            if (IsAtEnd() || source[current] != expected)
            {
                return false;
            }

            current++;
            return true;
        }

        void SkipComment()
        {
            while (Peek() != '\n' && !IsAtEnd())
            {
                Advance();
            }
        }

        bool IsAtEnd()
        {
            return current >= source.Length;
        }

        char Advance()
        {
            current++;
            return source[current - 1];
        }

        char Peek()
        {
            if (IsAtEnd())
            {
                return '\0';
            }
            else
            {
                return source[current];
            }
        }

        static bool IsAlpha(char c)
        {
            return char.IsLetter(c) || c == '_';
        }

        static bool IsAlphaNumeric(char c)
        {
            return IsAlpha(c) || char.IsDigit(c);
        }
    }
}