using Lab3.CheckPoint.Vehicles;
using Lab3.CheckPoint.Vehicles.VehicleCharacteristics;

namespace Lab3.Sample.Vehicles;

public class Truck : AVehicle
{
    private const int MinSpeed = 70;
    private const int MaxSpeed = 100;
    
    
    public Truck(Color color, BodyType bodyType, int licensePlateNumber, bool hasPassenger, float speedPercents) : base(color, bodyType, licensePlateNumber, hasPassenger, speedPercents)
    {
    }


    protected override int GenerateSpeed(float percents)
    {
        return (int)Math.Round((MaxSpeed - MinSpeed) * percents) + MinSpeed;
    }
}