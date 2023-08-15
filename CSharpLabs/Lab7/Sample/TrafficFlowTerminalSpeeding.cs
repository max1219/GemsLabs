using Lab7.CheckPoint.Vehicles;

namespace Lab7.Sample;

public class TrafficFlowTerminalSpeeding  : IDisposable
{
    private readonly CheckPoint.CheckPoint _checkPoint;
    
    public TrafficFlowTerminalSpeeding (CheckPoint.CheckPoint checkPoint)
    {
        _checkPoint = checkPoint;
        _checkPoint.OnVehicleSpeeding += OnVehicleSpeeding;
    }

    private void OnVehicleSpeeding(AVehicle vehicle)
    {
        Console.WriteLine("Speeding " + vehicle);
    }

    public void Dispose()
    {
        _checkPoint.OnVehicleSpeeding -= OnVehicleSpeeding;
    }
}