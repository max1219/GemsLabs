using Lab5.Entities;
using Xunit;

namespace Lab5.Tests;

public class MagazineTests
{
    [Fact]
    public void Empty_RemoveAmmo_ReturnsNull()
    {
        Magazine magazine = new Magazine(30);

        Assert.Null(magazine.RemoveAmmo());
    }

    [Fact]
    public void Empty_CountIsZero()
    {
        Magazine magazine = new Magazine(30);

        Assert.Equal(0, magazine.Count);
    }

    [Fact]
    public void HasSomeAmmo_CountIsSome()
    {
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(new Ammo());
        magazine.AddAmmo(new Ammo());

        Assert.Equal(2, magazine.Count);
    }

    [Fact]
    public void HasSomeAmmo_RemoveOne_CountBecomeLess()
    {
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(new Ammo());
        magazine.AddAmmo(new Ammo());

        magazine.RemoveAmmo();

        Assert.Equal(1, magazine.Count);
    }

    [Fact]
    public void Full_AddAmmo_ThrowsInvalidOperation()
    {
        Magazine magazine = new Magazine(1);
        magazine.AddAmmo(new Ammo());

        Assert.Throws<InvalidOperationException>(() => magazine.AddAmmo(new Ammo()));
    }

    [Fact]
    public void HasSomeAmmo_TestFILO()
    {
        Ammo a1 = new Ammo();
        Ammo a2 = new Ammo();
        Magazine magazine = new Magazine(30);
        magazine.AddAmmo(a1);
        magazine.AddAmmo(a2);
        
        Assert.Same(a2, magazine.RemoveAmmo());
        Assert.Same(a1, magazine.RemoveAmmo());
    }
}