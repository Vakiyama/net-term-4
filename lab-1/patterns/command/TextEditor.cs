using System.Text;

namespace Lab1
{
    public class TextEditor
    {
        private StringBuilder _contents = new StringBuilder();

        public void AddText(string text)
        {
            _contents.Append(text);
        }

        public void RemoveText(string text)
        {
            _contents.Remove(_contents.Length - text.Length, text.Length);
        }

        public string GetText() => _contents.ToString();
    }
}
