namespace Lab8.Tests;

public class FirstOrDefaultTests
{
    [Fact]
    public void NonEmptySuccessWithCriteria()
    {
        var data = new[] { 0, 1, 2, 3, 4, 5 };
        
        Assert.Equal(0, data.FirstOrDefault(i => i == 0));
        Assert.Equal(0, data.FirstOrDefault(_ => true));
        Assert.Equal(2, data.FirstOrDefault(i => i == 2));
        Assert.Equal(5, data.FirstOrDefault(i => i == 5));
    }
    
    [Fact]
    public void NonEmptySuccessWithoutCriteria()
    {
        Assert.Null(new int?[] {null, 2}.FirstOrDefault());
        Assert.Equal(2, new [] {2, 5, 4}.FirstOrDefault());
    }

    [Fact]
    public void EmptyCollectionDefault()
    {
        Assert.Equal(0, Array.Empty<int>().FirstOrDefault());
        Assert.Null(Array.Empty<int?>().FirstOrDefault(_ =>  false));
        Assert.Null(Array.Empty<int?>().FirstOrDefault());
    }

    [Fact]
    public void NullCollectionDefault()
    {
        int[]? a = null;
        int?[]? b = null;
        Assert.Equal(0, a.FirstOrDefault());
        Assert.Null(b.FirstOrDefault());
        Assert.Null(b.FirstOrDefault(_ =>  false));
    }

    [Fact]
    public void WrongPredicateDefault()
    {
        Assert.Equal(0, new[] { 1, 2, 3 }.FirstOrDefault(_ =>  false));
        Assert.Null(new int?[] { 1, 2, 3 }.FirstOrDefault(_ =>  false));
    }

}