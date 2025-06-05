using InkCode.Lexer;

namespace InkCode.Parser
{
    internal static partial class ExpressionParser
    {
        static bool MatchIndex(List<Token> tokens, int index, Token.TokenType expect)
        {
            return tokens[index].Type == expect;
        }

        static bool AreArgumentsValid(List<Token> args)
        {
            if (args.Count > 0)
            {
                return AreParenthesesBalanced(args);
            }

            return false;
        }

        static bool AreParenthesesBalanced(List<Token> args)
        {
            int depth = 0;

            foreach (var token in args)
            {
                Token.TokenType type = token.Type;

                if (type == Token.TokenType.LEFT_PAREN)
                {
                    depth++;
                }
                else if (type == Token.TokenType.RIGHT_PAREN)
                {
                    depth--;
                }
            }

            if (depth == 0)
            {
                return true;
            }

            return false;
        }
    }
}