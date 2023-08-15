using Lab7.CheckPoint.Vehicles;

namespace Lab7.Sample;

public class TrafficFlowTerminalStolen   : IDisposable
{
    private readonly CheckPoint.CheckPoint _checkPoint;
    
    public TrafficFlowTerminalStolen  (CheckPoint.CheckPoint checkPoint)
    {
        _checkPoint = checkPoint;
        _checkPoint.OnVehicleStolen += OnVehicleStolen;
    }

    private void OnVehicleStolen(AVehicle vehicle)
    {
        Console.WriteLine("Stolen " + vehicle);
    }

    public void Dispose()
    {
        _checkPoint.OnVehicleStolen -= OnVehicleStolen;
    }
}