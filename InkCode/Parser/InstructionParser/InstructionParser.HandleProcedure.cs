namespace InkCode.Parser
{
    internal partial class InstructionParser
    {
        void FindLabels()
        {
            while (!IsAtEnd())
            {
                Advance();

                if (IsLabel())
                {
                    AddLabel();
                    tokens.RemoveAt(start);

                    current = start;
                }

                start = current;
                line = PeekStartLine();
            }

            current = 0;
            start = 0;
            line = PeekStartLine();
        }

        void HandleAsigne()
        {
            if (IsAsigneProcess())
            {
                if (!labelsCollection.ContainsKey(PeekLexeme()))
                {
                    Expression? args = expressionParser.Parse(start + 2, current - 1);

                    if (args != null)
                    {
                        AddAssignmentInstruction(args);
                    }
                    else
                    {
                        AddArgumentError();
                    }
                }
                else
                {
                    AddAsigneError();
                }
            }
            else
            {
                AddStatementError();
            }
        }

        void HandleGoto()
        {
            if (IsGotoValid())
            {
                Expression? args = expressionParser.Parse(start + 5, current - 2);

                if (args != null)
                {
                    AddGotoInstruction(args, GotoLabelLine());

                    return;
                }
            }
            else
            {
                AddFunctionError();
            }
        }
    }
}