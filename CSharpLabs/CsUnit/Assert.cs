namespace CsUnit;

public static class Assert
{
    public new static void Equals(object expected, object actual)
    {
        if (!expected.Equals(actual))
        {
            throw new AssertFailureException($"Fail assert equals. Expected: {expected}, actual: {actual}");
        }
    }

    public static void True(bool b)
    {
        if (!b)
        {
            throw new AssertFailureException($"Fail assert true");
        }
    }

    public static void False(bool b)
    {
        if (b)
        {
            throw new AssertFailureException($"Fail assert false");
        }
    }

    public static void Throws<T>(Func<object?> func) where T : Exception
    {
        try
        {
            func.Invoke();
        }
        catch (T e)
        {
            return;
        }

        throw new AssertFailureException($"Fail assert throws. Expected type: {typeof(T)}");
    }
}