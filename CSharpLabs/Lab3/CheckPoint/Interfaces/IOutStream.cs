namespace Lab3.CheckPoint.Interfaces;

public interface IOutStream
{
    void OnSpeedLimitBreak(int licensePlateNumber);
    void OnDetectCarjacker(int licensePlateNumber);

}