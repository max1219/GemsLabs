using Lab3.CheckPoint.Vehicles;
using Lab3.CheckPoint.Vehicles.VehicleCharacteristics;

namespace Lab3.Sample.Vehicles;

public class Bus : AVehicle
{
    private const int MinSpeed = 80;
    private const int MaxSpeed = 110;
    
    
    public Bus(Color color, BodyType bodyType, int licensePlateNumber, bool hasPassenger, float speedPercents) : base(color, bodyType, licensePlateNumber, hasPassenger, speedPercents)
    {
    }


    protected override int GenerateSpeed(float percents)
    {
        return (int)Math.Round((MaxSpeed - MinSpeed) * percents) + MinSpeed;
    }
}