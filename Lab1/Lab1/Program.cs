using System;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("1. MaxWordFinder\n2. EagleAndTails\nEnter the number - ");
            string selected = Console.ReadLine();
            Console.Clear();
            if (selected == "1")
            {
                MaxWordFinderMenu();
            }
            else if (selected == "2")
            {
                EagleAndTailsMenu();
            }
            else
            {
                throw new ArgumentException("You entered incorrect data and broke the program");
            }
        }

        private static void MaxWordFinderMenu()
        {
            Console.WriteLine("Вводите слова, завершая каждое нажатием Enter.\nДля выхода наберите \"exit\"");
            string result = Task1.MaxWordFinder.FindMaxWord();
            Console.WriteLine($"Самое длинное слово: \"{result.ToUpper()}\" ({result.Length})");
        }

        private static void EagleAndTailsMenu()
        {
            Task2.EagleAndTails.Play(out int total, out int wins);
            Console.WriteLine($"Игра закончена со счетом {wins}, угадано {wins * 100.0f / total}% бросков");
        }
    }
}