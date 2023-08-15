namespace Lab8.Tests;

public class FirstTests
{
    [Fact]
    public void NonEmptySuccessWithCriteria()
    {
        var data = new[] { 0, 1, 2, 3, 4, 5 };

        Assert.Equal(0, data.First(i => i == 0));
        Assert.Equal(0, data.First(_ => true));
        Assert.Equal(2, data.First(i => i == 2));
        Assert.Equal(5, data.First(i => i == 5));
    }

    [Fact]
    public void NonEmptySuccessWithoutCriteria()
    {
        Assert.Null(new int?[] { null, 2 }.First());
        Assert.Equal(2, new[] { 2, 5, 4 }.First());
    }

    [Fact]
    public void EmptyCollectionThrows()
    {
        Assert.Throws<InvalidOperationException>(() => Array.Empty<int>().First());
        Assert.Throws<InvalidOperationException>(() => Array.Empty<int?>().First());
        Assert.Throws<InvalidOperationException>(() => Array.Empty<int>().First(_ => true));
    }

    [Fact]
    public void NullCollectionThrows()
    {
        int[]? a = null;
        int?[]? b = null;
        Assert.Throws<InvalidOperationException>(() => a.First());
        Assert.Throws<InvalidOperationException>(() => b.First());
        Assert.Throws<InvalidOperationException>(() => b.First(_ => true));
    }

    [Fact]
    public void WrongPredicateThrows()
    {
        var data = new[] { 0, 1, 2, 3 };
        Assert.Throws<InvalidOperationException>(() => data.First(_ => false));
    }
}