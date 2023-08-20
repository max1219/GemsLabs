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
        Assert.Throws(typeof(HttpRequestException), () => throw new HttpRequestException());
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
        Assert.Throws(typeof(HttpRequestException), () => 2);
    }



}