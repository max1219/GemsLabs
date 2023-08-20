using System.Reflection;

namespace CsUnit.TesterAttributes;

[AttributeUsage(AttributeTargets.Method)]
public class FactAttribute : AbcTesterAttribute
{
    public override void TestMethod(MethodInfo method, object testClassInstance)
    {
        try
        {
            method.Invoke(testClassInstance, null);
        }
        catch (TargetParameterCountException)
        {
            throw new InvalidOperationException(
                $"Тестовый метод ({method.Name}), отмеченный атрибутом {nameof(FactAttribute)}, не должен принимать параметры");
        }

    }
}