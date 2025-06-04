namespace InkCode.Lexer
{
    internal partial class Scanner
    {
        void AnalyzeString()
        {
            while (Peek() != '"' && !IsAtEnd())
            {
                if (Peek() == '\n')
                {
                    AddStringError();

                    return;
                }

                Advance();
            }

            if (IsAtEnd())
            {
                AddStringError();
                return;
            }

            Advance();

            AddStringToken();
        }

        void AnalyzeNumber()
        {
            while (char.IsDigit(Peek()))
            {
                Advance();
            }

            AddNumberToken();
        }

        void AnalyzeIdentifier()
        {
            while (IsAlphaNumeric(Peek()))
            {
                Advance();
            }

            HandleIdentifierToken();
        }
    }
}

