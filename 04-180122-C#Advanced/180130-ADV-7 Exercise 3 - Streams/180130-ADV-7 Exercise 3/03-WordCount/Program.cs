using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = String.Empty;

            Dictionary<string, int> allWords = new Dictionary<string, int>();

            using (StreamReader readerWords = new StreamReader("../Resources/words.txt"))
            {
                while ((line = readerWords.ReadLine()) != null)
                {
                    allWords.Add(line, 0);
                }
            }

            using (StreamReader readerSentences = new StreamReader("../Resources/text.txt"))
            {
                while ((line = readerSentences.ReadLine()) != null)
                {
                    string[] words = line.ToLower().Split(new string[] { " ", ".", ",", "!", "?", "-", "..." }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (allWords.ContainsKey(word))
                        {
                            allWords[word] += 1;
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (var word in allWords.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
