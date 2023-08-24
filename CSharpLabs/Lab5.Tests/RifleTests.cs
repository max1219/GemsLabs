using Lab5.Entities;
using Xunit;

namespace Lab5.Tests;

public class RifleTests
{
    // Chamber патронник Trigger курок Fuse предохранитель

    [Fact]
    public void HasNotAndEmptyMagazine_Reload_StayNotLoaded()
    {
        Rifle rifle1 = new Rifle(null);
        Rifle rifle2 = new Rifle(new Magazine(30));
        rifle1.Reload();
        rifle2.Reload();
        
        Assert.False(rifle1.Loaded);
        Assert.False(rifle2.Loaded);
    }

    [Fact]
    public void LoadedMagazine_Reload_BecomeLoaded()
    {
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(new Ammo());
        Rifle rifle = new Rifle(magazine);

        rifle.Reload();
        
        Assert.True(rifle.Loaded);
    }

    [Fact]
    public void OneAmmoMagazine_DoubleReload_NotLoaded()
    {
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(new Ammo());
        Rifle rifle = new Rifle(magazine);

        rifle.Reload();
        rifle.Reload();
        
        Assert.False(rifle.Loaded);
    }

    [Fact]
    public void LoadedMagazine_DoubleReload_ReturnsSameNotUsedAmmo()
    {
        Ammo ammo = new Ammo();
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(ammo);
        Rifle rifle = new Rifle(magazine);

        rifle.Reload();
        Ammo? newAmmo = rifle.Reload();
        
        Assert.Same(ammo, newAmmo);
        Assert.False(ammo.Used);
    }

    [Fact]
    public void Fuse_Reload_ThrowsInvalidOperation()
    {
        Rifle rifle1 = new Rifle(null);
        Rifle rifle2 = new Rifle(new Magazine(30));
        rifle1.Fuse = true;
        rifle2.Fuse = true;

        Assert.Throws<InvalidOperationException>(() => rifle1.Reload());
        Assert.Throws<InvalidOperationException>(() => rifle2.Reload());
    }

    [Fact]
    public void NotLoaded_Fire_ReturnsNull()
    {
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(new Ammo());
        Rifle rifle = new Rifle(magazine);
        
        Assert.Null(rifle.Fire());
    }

    [Fact]
    public void Fuse_Shot_ReturnsNull()
    {
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(new Ammo());
        Rifle rifle = new Rifle(magazine);
        rifle.Reload();
        rifle.Fuse = true;
        
        Assert.Null(rifle.Fire());
    }

    [Fact]
    public void Loaded_Fire_ReturnsSameUsedAmmoAndNotLoaded()
    {
        Ammo ammo = new Ammo();
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(ammo);
        Rifle rifle = new Rifle(magazine);
        rifle.Reload();
        
        Ammo? newAmmo = rifle.Fire();
        
        Assert.False(rifle.Loaded);
        Assert.Same(ammo, newAmmo);
        Assert.True(newAmmo!.Used);
    }
}