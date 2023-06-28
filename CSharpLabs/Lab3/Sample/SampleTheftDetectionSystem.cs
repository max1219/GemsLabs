using Lab3.CheckPoint.Interfaces;

namespace Lab3.Sample;

public class SampleTheftDetectionSystem : ITheftDetectionSystem
{

    public bool CheckLicensePlateNumber(int licensePlateNumber)
    {
        return licensePlateNumber < 250;
    }
}