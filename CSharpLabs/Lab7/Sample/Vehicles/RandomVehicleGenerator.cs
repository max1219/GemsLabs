using Lab7.CheckPoint.Vehicles;
using Lab7.CheckPoint.Vehicles.VehicleCharacteristics;

namespace Lab7.Sample.Vehicles;

public class RandomVehicleGenerator
{
    private static readonly Func<Color, BodyType, int, bool, float, AVehicle>[] VehicleFactories = {
        (color, bodyType, licensePlateNumber, hasPassenger, speedPercents) =>
            new Car(color, bodyType, licensePlateNumber, hasPassenger, speedPercents),
        (color, bodyType, licensePlateNumber, hasPassenger, speedPercents) =>
            new Bus(color, bodyType, licensePlateNumber, hasPassenger, speedPercents),
        (color, bodyType, licensePlateNumber, hasPassenger, speedPercents) =>
            new Truck(color, bodyType, licensePlateNumber, hasPassenger, speedPercents),
    };
    private static readonly Random Random = new Random();

    private readonly int _colorsCount;
    private readonly int _bodyTypesCount;

    public RandomVehicleGenerator()
    {
        _colorsCount = Enum.GetNames(typeof(Color)).Length;
        _bodyTypesCount = Enum.GetNames(typeof(BodyType)).Length;
    }

    public AVehicle NextVehicle()
    {
        Color color = (Color)Random.Next(_colorsCount);
        BodyType bodyType = (BodyType)Random.Next(_bodyTypesCount);
        int licensePlateNumber = 100 + Random.Next(900);
        bool hasPassenger = Random.Next(2) == 1;
        float speedPercent = Random.NextSingle();
        int vehicleType = Random.Next(VehicleFactories.Length);
        return VehicleFactories[vehicleType](color, bodyType, licensePlateNumber, hasPassenger, speedPercent);
    }
}