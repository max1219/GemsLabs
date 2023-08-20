using System.Reflection;

namespace CsUnit.TesterAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class InlineDataAttribute : AbcTesterAttribute
{
    private object[] _params;

    public InlineDataAttribute(params object[] @params)
    {
        if (@params == null || @params.Length == 0)
        {
            throw new ArgumentException($"{typeof(InlineDataAttribute)} не подразумевает работу без параметров");
        }

        _params = @params;
    }

    public override void TestMethod(MethodInfo method, object testClassInstance)
    {
        try
        {
            method.Invoke(testClassInstance, _params);
        }
        catch (TargetParameterCountException)
        {
            throw new InvalidOperationException(
                $"Тестовый метод ({method.Name}), отмеченный атрибутом {nameof(InlineDataAttribute)}, должен иметь одинаковую с атрибутом сигнатуру");
        }
        catch (TargetInvocationException e) when
            (e.InnerException is AssertFailureException ex)
        {
            string newMessage = "With inline-data params: " + String.Join(", ", _params) + ". " + ex.Message;
            throw new TargetInvocationException(new AssertFailureException(newMessage));
        }
    }
}