namespace Lab1
{
    public class AddTextCommand : Command
    {
        private TextEditor _editor;
        private string _text;

        public AddTextCommand(TextEditor editor, string text)
        {
            _editor = editor;
            _text = text;
        }

        public void ExecuteCommand()
        {
            _editor.AddText(_text);
        }

        public void UndoCommand()
        {
            _editor.RemoveText(_text);
        }
    }
}
