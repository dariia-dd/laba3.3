using System;
using System.IO;

namespace OOP_lab_3_9_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fromFile = new StreamReader("input.txt");
            StreamWriter toFile = File.CreateText("output.txt");

            string str = fromFile.ReadToEnd();

            string[] words = str.Split(new char[] { '\r', '\n', ' ', ':', ';', '.', ',', '?', '!', '(', ')', '{', '}', '[', ']', '@', '#', '№', '$', '^', '%', '&', '*', '/', '|' }, StringSplitOptions.RemoveEmptyEntries);

            int count = words.Length;

            for (int i = 0; i < words.Length; ++i)
            {
                if (words[i][0] == words[i][words[i].Length - 1])
                {
                    words[i] = words[i].Remove(0);
                }
            }

            for (int i = 0; i < words.Length; ++i)
            {
                if (!string.IsNullOrWhiteSpace(words[i]))
                {
                    for (int j = i + 1; j < words.Length; ++j)
                    {
                        if (words[i] == words[j])
                        {
                            --count;
                        }
                    }
                }
                else
                {
                    --count;
                }
            }

            toFile.WriteLine("Kiлькiсть рiзних слiв: {0}", count);

            toFile.Close();
        }
    }
}
