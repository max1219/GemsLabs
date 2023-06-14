using System;

namespace Lab0
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("1. LeapYearChecker\n2. TemperatureConverter\nEnter the number - ");
            string selected = Console.ReadLine();
            Console.Clear();
            if (selected == "1")
            {
                LearYearCheckerMenu();
            }
            else if (selected == "2")
            {
                TemperatureConverterMenu();
            }
            else
            {
                throw new ArgumentException("You entered incorrect data and broke the program");
            }
        }

        private static void LearYearCheckerMenu()
        {
            Console.Write("Enter year - ");
            int year = Convert.ToInt32(Console.ReadLine());
            bool isLeap = Task1.LeapYearChecker.Check(year);
            Console.WriteLine($"{year} is {(isLeap ? "leap" : "not leap")}");
        }

        private static void TemperatureConverterMenu()
        {
            Console.Write("Enter temperature at the format \"<num><type>\" where type is f/F/c/C - ");
            string line = Console.ReadLine();
            char type = line[line.Length - 1];
            float temperature = float.Parse(line.Substring(0, line.Length - 1));
            float result;
            if (type == 'c' || type == 'C')
            {
                result = Task2.TemperatureConverter.C2F(temperature);
            }
            else if (type == 'f' || type == 'F')
            {
                result = Task2.TemperatureConverter.F2C(temperature);
            }
            else
            {
                throw new ArgumentException("You entered incorrect data and broke the program");
            }

            Console.WriteLine($"Result is {result}{(type == 'c' || type == 'C' ? "F": "C")}");
        }
    }
}