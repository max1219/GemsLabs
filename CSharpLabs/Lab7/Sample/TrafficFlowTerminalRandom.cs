using Lab7.CheckPoint.Vehicles;

namespace Lab7.Sample;

public class TrafficFlowTerminalRandom : IDisposable
{
    private readonly CheckPoint.CheckPoint _checkPoint;
    private readonly Random _random;
    
    public TrafficFlowTerminalRandom(CheckPoint.CheckPoint checkPoint)
    {
        _checkPoint = checkPoint;
        _checkPoint.OnVehiclePass += OnVehiclePass;
        _random = new Random();
    }

    private void OnVehiclePass(AVehicle vehicle)
    {
        if (_random.Next(2) == 0)
        {
            Console.WriteLine("Random " + vehicle);
        }
    }

    public void Dispose()
    {
        _checkPoint.OnVehiclePass -= OnVehiclePass;
    }
}