using Lab3.CheckPoint.Vehicles.VehicleCharacteristics;

namespace Lab3.CheckPoint;

public struct CheckPointStatistics
{
    public int TotalVehiclesCount { get; set; }
    public int AverageSpeed { get; set; }
    public int SpeedLimitBreakersCount { get; set; }
    public int CarjackersCount { get; set; }

    private readonly Dictionary<BodyType, int> _countByBodyTypes;

    public CheckPointStatistics()
    {
        TotalVehiclesCount = 0;
        AverageSpeed = 0;
        SpeedLimitBreakersCount = 0;
        CarjackersCount = 0;
        _countByBodyTypes = new Dictionary<BodyType, int>();
    }

    public int GetCountByBodyType(BodyType bodyType)
    {
        if (_countByBodyTypes.TryGetValue(bodyType, out int result))
            return result;
        return 0;
    }

    public void AddCountByBodyType(BodyType bodyType)
    {
        _countByBodyTypes[bodyType] = GetCountByBodyType(bodyType) + 1;
    }

    public override string ToString()
    {
        return
            $"{nameof(TotalVehiclesCount)}: {TotalVehiclesCount}, {nameof(AverageSpeed)}: {AverageSpeed}, {nameof(SpeedLimitBreakersCount)}: {SpeedLimitBreakersCount}, {nameof(CarjackersCount)}: {CarjackersCount}\n{nameof(_countByBodyTypes)}:\n{String.Join(Environment.NewLine, _countByBodyTypes)}";
    }
}