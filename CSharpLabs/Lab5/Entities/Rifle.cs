namespace Lab5.Entities;

public class Rifle
{
    public Magazine ConnectedMagazine { get; set; }
    public bool Fuse { get; set; }
    public bool Loaded => _chamber is not null;

    private Ammo? _chamber = null;

    public Rifle(Magazine magazine)
    {
        ConnectedMagazine = magazine;
    }

    public Ammo? Reload()
    {
        if (Fuse)
        {
            throw new InvalidOperationException("Cannot reload rifle with fuse");
        }

        Ammo? lastAmmo = _chamber;
        _chamber = ConnectedMagazine?.RemoveAmmo();
        return lastAmmo;
    }

    public Ammo? Fire()
    {
        if (Fuse)
        {
            return null;
        }
        _chamber?.Use();
        Ammo? lastAmmo = _chamber;
        _chamber = null;
        return lastAmmo;
    }
}