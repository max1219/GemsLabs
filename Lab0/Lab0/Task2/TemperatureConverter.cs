namespace Lab0.Task2
{
    public class TemperatureConverter
    {
        public static float C2F(float c)
        {
            return c * 1.8f + 32;
        }

        public static float F2C(float f)
        {
            return (f - 32) * 5 / 9;
        }
    }
}