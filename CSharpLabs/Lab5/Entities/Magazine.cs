namespace Lab5.Entities;

public class Magazine
{
    public int Capacity { get; private set; }
    public int Count => _ammos.Count;

    private readonly Stack<Ammo> _ammos = new();

    public Magazine(int capacity)
    {
        Capacity = capacity;
    }

    public Ammo? RemoveAmmo()
    {
        if (Count == 0)
        {
            return null;
        }
        return _ammos.Pop();
    }

    public void AddAmmo(Ammo ammo)
    {
        if (Count == Capacity)
        {
            throw new InvalidOperationException("Cannot add ammo to full magazine");
        }
        _ammos.Push(ammo);
    }
}