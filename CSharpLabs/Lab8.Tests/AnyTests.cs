namespace Lab8.Tests;

public class AnyTests
{
    [Fact]
    public void EmptyCollectionFalse()
    {
        Assert.False(Array.Empty<int>().Any());
        Assert.False(Array.Empty<int?>().Any());
        Assert.False(Array.Empty<int>().Any(_ => true));
    }
    
    [Fact]
    public void NonEmptyTrue()
    {
        Assert.True(new []{0, 1, 2}.Any(i => i == 1));
        Assert.True(new []{0, 1, 2}.Any());
        Assert.True(new int?[]{null, 0, 1, 2}.Any(i => i != null));
    }
    
    [Fact]
    public void NonEmptyFalse()
    {
        Assert.False(new []{0, 1, 2}.Any(i => i == 3));
        Assert.False(new int?[]{0, 1, 2}.Any(i => i == null));
    }
}