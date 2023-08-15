using System.Linq;

namespace Lab8.Tests;

public class WhereTests
{
    [Fact]
    public void NonEmptySuccessWithCriteria()
    {
        var data = new[] {-2, -1, 0, 1, 2, 3, 4, 5 };
        var expected = new[] {1, 2, 3, 4, 5 };

        Assert.Equal(expected, data.Where(i => i > 0));
        Assert.Equal(Array.Empty<int>(), data.Where(_ => false));
        Assert.Equal(data, data.Where(_ => true));
    }

    [Fact]
    public void NonEmptySuccessWithoutCriteria()
    {
        var data1 = new int[] { 1, 2, 3 };
        var data2 = new int?[] { 1, null, 2, 3 };
        Assert.Equal(data1, data1.Where());
    }

    [Fact]
    public void EmptyCollection()
    {
        Assert.Equal(Array.Empty<int>(), Array.Empty<int>().Where(_ => true));
        Assert.Equal(Array.Empty<int>(), Array.Empty<int>().Where());
        Assert.Equal(Array.Empty<int?>(), Array.Empty<int?>().Where());
    }

    [Fact]
    public void NullCollection()
    {
        int[]? a = null;
        int?[]? b = null;
        Assert.Null(a.Where());
        Assert.Null(b.Where());
        Assert.Null(b.Where(_ => false));
    }

}