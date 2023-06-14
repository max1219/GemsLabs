namespace Lab0.Task1
{
    public class LeapYearChecker
    {
        public static bool Check(int year)
        {
            return year % 4 == 0 && year % 100 != 0
                   || year % 400 == 0;
        }
    }
}