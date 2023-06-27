using System;

namespace Lab1.Task2;

public class EagleAndTails
{
    public static void Play(out int total, out int wins)
    {
        total = 0;
        wins = 0;
        Random random = new Random();
        while (true)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();
            if (input != "0" && input != "1") break;
            total++;
            int isWin = random.Next(2);
            if (isWin == 1)
            {
                wins++;
                Console.WriteLine("Угадали");
            }
            else
            {
                Console.WriteLine("Не угадали");
            }
        }
    }
}