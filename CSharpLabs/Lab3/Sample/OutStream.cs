using Lab3.CheckPoint.Interfaces;

namespace Lab3.Sample;

public class OutStream : IOutStream
{
    public void OnSpeedLimitBreak(int licensePlateNumber)
    {
        Console.WriteLine("Превышение скорости - " + licensePlateNumber);
    }

    public void OnDetectCarjacker(int licensePlateNumber)
    {
        Console.WriteLine("Перехват - " + licensePlateNumber);
    }
}