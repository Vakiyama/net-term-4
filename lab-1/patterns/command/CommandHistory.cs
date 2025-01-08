namespace Lab1
{
    public interface Command
    {
        public void ExecuteCommand();
        public void UndoCommand();
    }

    public class CommandHistory
    {
        private Stack<Command> _stack = new Stack<Command>();

        public void AddCommand(Command command)
        {
            _stack.Push(command);
        }

        public void UndoCommand()
        {
            Command last = _stack.Pop();
            try
            {
                last.UndoCommand();
            }
            catch
            {
                _stack.Push(last);
                Console.WriteLine("Failed to undo command.");
            }
        }
    }
}
