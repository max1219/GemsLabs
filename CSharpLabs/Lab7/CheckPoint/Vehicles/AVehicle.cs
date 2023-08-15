using Lab7.CheckPoint.Vehicles.VehicleCharacteristics;

namespace Lab7.CheckPoint.Vehicles;

public abstract class AVehicle
{
    public Color Color { get; init; }
    public BodyType BodyType { get; init; }
    public int LicensePlateNumber { get; init; }
    public bool HasPassenger { get; init; }
    public int Speed { get; init; }

    protected AVehicle(Color color, BodyType bodyType, int licensePlateNumber, bool hasPassenger, float speedPercents)
    {
        Color = color;
        BodyType = bodyType;
        LicensePlateNumber = licensePlateNumber;
        HasPassenger = hasPassenger;
        Speed = GenerateSpeed(speedPercents);
    }

    protected abstract int GenerateSpeed(float percents);

    public override string ToString()
    {
        return
            $"{nameof(Color)}: {Color}, {nameof(BodyType)}: {BodyType}, {nameof(LicensePlateNumber)}: {LicensePlateNumber}, {nameof(HasPassenger)}: {HasPassenger}, {nameof(Speed)}: {Speed}";
    }
}