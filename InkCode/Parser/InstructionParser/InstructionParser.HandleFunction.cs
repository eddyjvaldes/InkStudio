namespace InkCode.Parser
{
    internal partial class InstructionParser
    {
        void HandleSpawn()
        {
            if (line == tokens[0].Line)
            {
                HandleFunction();
            }
            else
            {
                AddFunctionError();
            }
        }

        void HandleFunction()
        {
            if (IsFunctionValid())
            {
                List<Expression>? args = ParserArguments(start + 2, current - 2);

                if (args != null)
                {
                    AddFunctionCallInstruction(args);
                }
                else
                {
                    AddArgumentError();
                }
            }
            else
            {
                AddFunctionError();
            }
        }

        void HandleParameterlessFunction()
        {
            if (PeekLineCount() != 3)
            {
                AddStatementError();
            }
        }
    }
}