namespace Lab1
{
    public class Invoker
    {
        private CommandHistory _commandHistory;

        public Invoker(CommandHistory commandHistory)
        {
            _commandHistory = commandHistory;
        }

        public void ExecuteCommand(Command command)
        {
            command.ExecuteCommand();
            _commandHistory.AddCommand(command);
        }

        public void UndoCommand()
        {
            _commandHistory.UndoCommand();
        }
    }
}
