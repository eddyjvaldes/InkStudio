using InkCode.Lexer;

namespace InkCode.Evaluator
{
    internal partial class Executor
    {
        internal object? Operation(Token.TokenType operation, object left, object right)
        {
            switch (operation)
            {
                case Token.TokenType.STAR: return HandleStar(left, right);
                case Token.TokenType.SLASH: return HandleSlash(left, right);
                case Token.TokenType.PERCENT: return HandlePercent(left, right);
                case Token.TokenType.POWER: return HandlePower(left, right);
                case Token.TokenType.PLUS: return HandlePlus(left, right);
                case Token.TokenType.MINUS: return HandleMinus(left, right);
                case Token.TokenType.LESS: return HandleLess(left, right);
                case Token.TokenType.LESS_EQUAL: return HandleLessEqual(left, right);
                case Token.TokenType.GREATER: return HandleGreater(left, right);
                case Token.TokenType.GREATER_EQUAL: return HandleGreaterEqual(left, right);
                case Token.TokenType.EQUAL_EQUAL: return HandleEqualEqual(left, right);
                case Token.TokenType.BANG_EQUAL: return HandleBangEqual(left, right);
                case Token.TokenType.OR: return HandleOr(right, left);
                case Token.TokenType.AND: return HandleAnd(right, left);

                default:
                    // error
                    return null;
            }
        }
    }
}