using Xunit;
using Lab5.Entities;

namespace Lab5.Tests;

public class AmmoTests
{
    [Fact]
    public void WasUsed_Use_ThrowsInvalidOperation()
    {
        Ammo ammo = new Ammo();
        ammo.Use();
        Assert.Throws<InvalidOperationException>(()=>ammo.Use());
    }

    [Fact]
    public void CheckUsedAtBothStates()
    {
        Ammo ammo = new Ammo();
        Assert.False(ammo.Used);
        ammo.Use();
        Assert.True(ammo.Used);
    }
    

}