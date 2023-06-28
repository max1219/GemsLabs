using Lab3.CheckPoint.Interfaces;
using Lab3.CheckPoint.Vehicles;

namespace Lab3.CheckPoint;

public class CheckPoint
{
    private const int SpeedLimit = 110;
    
    private CheckPointStatistics _statistics;
    private readonly ITheftDetectionSystem _theftDetectionSystem;
    private readonly IOutStream _outStream;

    public CheckPointStatistics Statistics => _statistics;

    public CheckPoint(ITheftDetectionSystem theftDetectionSystem, IOutStream outStream)
    {
        _theftDetectionSystem = theftDetectionSystem;
        _outStream = outStream;
        _statistics = new CheckPointStatistics();
    }

    public void RegisterVehicle(AVehicle vehicle)
    {
        _statistics.TotalVehiclesCount++;
        _statistics.AverageSpeed += (vehicle.Speed - _statistics.AverageSpeed) / _statistics.TotalVehiclesCount;
        if (vehicle.Speed > SpeedLimit)
        {
            _statistics.SpeedLimitBreakersCount++;
            _outStream.OnSpeedLimitBreak(vehicle.LicensePlateNumber);
        }
        if (_theftDetectionSystem.CheckLicensePlateNumber(vehicle.LicensePlateNumber))
        {
            _statistics.CarjackersCount++;
            _outStream.OnDetectCarjacker(vehicle.LicensePlateNumber);
        }
        _statistics.AddCountByBodyType(vehicle.BodyType);
    }
}