namespace CsUnit;

public class AssertFailureException : Exception
{
    public AssertFailureException(string? message) : base(message)
    {
    }
}