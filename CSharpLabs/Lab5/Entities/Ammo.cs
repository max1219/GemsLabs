namespace Lab5.Entities;

public class Ammo
{
    public bool Used { get; private set; }

    public void Use()
    {
        if (Used)
        {
            throw new InvalidOperationException("Cannot use used ammo");
        }

        Used = true;
    }
}