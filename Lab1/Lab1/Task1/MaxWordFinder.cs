using System;

namespace Lab1.Task1
{
    public class MaxWordFinder
    {
        public static string FindMaxWord()
        {
            string word;
            string maxWord = "";
            while(true)
            {
                word = Console.ReadLine();
                if (word == "exit")
                {
                    break;
                }
                if (word != null && maxWord.Length < word.Length)
                {
                    maxWord = word;
                }
            }

            return maxWord;
        }
    }
}