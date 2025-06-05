using InkCode.Lexer;

namespace InkCode.Parser
{
    internal partial class Interpreter
    {
        void AddLabel()
        {
            if (!labelsCollection.TryAdd(PeekLexeme(), PeekStartLine()))
            {
                AddLabelError();
            }
        }

        bool IsLabel()
        {
            return PeekType() == Token.TokenType.IDENTIFIER && PeekLineCount() == 1;
        }

        int GotoLabelLine()
        {
            string name = PeekLexeme(2);

            return labelsCollection[name];
        }

        bool IsGotoValid()
        {
            if (PeekLineCount() >= 7)
            {
                return CheckGotoBrackets() && CheckGotoLabel() && CheckGotoParenthesis();
            }

            return false;
        }

        bool IsAsigneProcess()
        {
            if (PeekLineCount() >= 3)
            {
                if (MatchTypeIndex(1, Token.TokenType.ASIGNE))
                {
                    return true;
                }
            }

            return false;
        }

        bool CheckGotoBrackets()
        {
            return MatchTypeIndex(1, Token.TokenType.LEFT_BRACKET)
                    && MatchTypeIndex(3, Token.TokenType.RIGHT_BRACKET);
        }

        bool CheckGotoLabel()
        {
            if (MatchTypeIndex(2, Token.TokenType.IDENTIFIER))
            {
                if (labelsCollection.ContainsKey(tokens[start + 2].Lexeme))
                {
                    return true;
                }
            }

            return false;
        }

        bool CheckGotoParenthesis()
        {
            return MatchTypeIndex(4, Token.TokenType.LEFT_PAREN)
            && MatchTypeIndex(current - 1, Token.TokenType.RIGHT_PAREN);
        }
    }
}