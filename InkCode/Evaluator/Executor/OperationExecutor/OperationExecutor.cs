using InkCode.ErrorManager;
using InkCode.Lexer;

namespace InkCode.Evaluator
{
    internal partial class OperationExecutor : Executor
    {
        internal OperationExecutor(
            CanvasController canvasController, ErrorReporter errorReporter)
            : base(canvasController, errorReporter)
        { }
        
        internal object? Operation(Token.TokenType operation, object left, object right, int line)
        {
            switch (operation)
            {
                case Token.TokenType.STAR: return HandleStar(left, right, line);
                case Token.TokenType.SLASH: return HandleSlash(left, right, line);
                case Token.TokenType.PERCENT: return HandlePercent(left, right, line);
                case Token.TokenType.POWER: return HandlePower(left, right, line);
                case Token.TokenType.PLUS: return HandlePlus(left, right, line);
                case Token.TokenType.MINUS: return HandleMinus(left, right, line);
                case Token.TokenType.LESS: return HandleLess(left, right, line);
                case Token.TokenType.LESS_EQUAL: return HandleLessEqual(left, right, line);
                case Token.TokenType.GREATER: return HandleGreater(left, right, line);
                case Token.TokenType.GREATER_EQUAL: return HandleGreaterEqual(left, right, line);
                case Token.TokenType.EQUAL_EQUAL: return HandleEqualEqual(left, right, line);
                case Token.TokenType.BANG_EQUAL: return HandleBangEqual(left, right, line);
                case Token.TokenType.OR: return HandleOr(right, left, line);
                case Token.TokenType.AND: return HandleAnd(right, left, line);

                default:
                    AddInvalidOperationError($"{left} {operation} {right}", line);
                    return null;
            }
        }
    }
}