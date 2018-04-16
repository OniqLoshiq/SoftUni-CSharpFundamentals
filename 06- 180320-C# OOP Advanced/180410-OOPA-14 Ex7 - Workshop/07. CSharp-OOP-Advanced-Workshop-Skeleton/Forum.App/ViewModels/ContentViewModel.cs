using System.Collections.Generic;
using System.Linq;

namespace Forum.App.ViewModels
{
    public class ContentViewModel
    {
        private const int lineLength = 37;

        public string[] Content { get; }

        public ContentViewModel(string text)
        {
            this.Content = this.GetLines(text);
        }

        private string[] GetLines(string text)
        {
            char[] textChars = text.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < text.Length; i += lineLength)
            {
                char[] row = textChars.Skip(i).Take(lineLength).ToArray();
                string line = string.Join("", row);
                lines.Add(line);
            }

            return lines.ToArray();
        }
    }
}
