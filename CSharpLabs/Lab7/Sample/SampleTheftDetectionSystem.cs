using Lab7.CheckPoint.Interfaces;

namespace Lab7.Sample;

public class SampleTheftDetectionSystem : ITheftDetectionSystem
{

    public bool CheckLicensePlateNumber(int licensePlateNumber)
    {
        return licensePlateNumber < 250;
    }
}