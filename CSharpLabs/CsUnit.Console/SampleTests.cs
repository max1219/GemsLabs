using CsUnit.TesterAttributes;

namespace CsUnit.Console;

public class SampleTests
{
    [Fact]
    public void SuccessTests()
    {
        Assert.Equals(1, 1);
        Assert.True(true);
        Assert.False(false);
        Assert.Throws<HttpRequestException>(() => throw new HttpRequestException());
    }

    [Fact]
    public void FailEqualsTest()
    {
        Assert.Equals(1, 2);
    }

    [Fact]
    public void FailTrueTest()
    {
        Assert.True(false);
    }

    [Fact]
    public void FailFalseTest()
    {
        Assert.False(true);
    }


    [Fact]
    public void FailThrowsTest()
    {
        Assert.Throws<HttpRequestException>(() => 2);
    }

    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void InlineDataSuccessTest(int i)
    {
        Assert.Equals(i, i);
    }


    [InlineData(2, 1)]
    [InlineData(1, 2)]
    [InlineData(3, 2)]
    [InlineData(4, 2)]
    [InlineData(4, 5)]
    [InlineData(6, 5)]
    public void InlineDataFailTest(int a, int b)
    {
        Assert.True(a > b);
    }
}