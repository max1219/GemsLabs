using Lab7.CheckPoint.Interfaces;
using Lab7.CheckPoint.Vehicles;

namespace Lab7.CheckPoint;

public class CheckPoint
{
    private const int SpeedLimit = 110;
    
    private CheckPointStatistics _statistics;
    private readonly ITheftDetectionSystem _theftDetectionSystem;

    public delegate void CheckPointEvent(AVehicle vehicle);
    public event CheckPointEvent? OnVehiclePass;
    public event CheckPointEvent? OnVehicleSpeeding;
    public event CheckPointEvent? OnVehicleStolen;
    
    public CheckPointStatistics Statistics => _statistics;
    

    public CheckPoint(ITheftDetectionSystem theftDetectionSystem)
    {
        _theftDetectionSystem = theftDetectionSystem;
        _statistics = new CheckPointStatistics();
    }

    public void RegisterVehicle(AVehicle vehicle)
    {
        _statistics.TotalVehiclesCount++;
        _statistics.AverageSpeed += (vehicle.Speed - _statistics.AverageSpeed) / _statistics.TotalVehiclesCount;
        if (vehicle.Speed > SpeedLimit)
        {
            _statistics.SpeedLimitBreakersCount++;
            OnVehicleSpeeding?.Invoke(vehicle);
        }
        if (_theftDetectionSystem.CheckLicensePlateNumber(vehicle.LicensePlateNumber))
        {
            _statistics.CarjackersCount++; 
            OnVehicleStolen?.Invoke(vehicle);
        }
        _statistics.AddCountByBodyType(vehicle.BodyType);
        OnVehiclePass?.Invoke(vehicle);
    }
}