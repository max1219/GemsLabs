using System.Reflection;
using CsUnit.TesterAttributes;

namespace CsUnit;

public static class TestRunner
{
    public static event TestRunEventHandler? OnTestPass;
    public static event TestRunEventHandler? OnTestFailure;

    public static void TestClass(Type sourceType)
    {
        object instance = CreateInstance(sourceType);
        
        MethodInfo[] methodInfos = sourceType.GetMethods();
        foreach (var method in methodInfos)
        {
            TestMethod(method, instance);
        }
    }

    private static void TestMethod(MethodInfo method, object testClassInstance)
    {
        foreach (var attribute in method.GetCustomAttributes())
        {
            if (attribute is AbcTesterAttribute testerAttribute)
            {
                string methodName = $"{testClassInstance.GetType().Name}.{method.Name}";
                try
                {
                    testerAttribute.TestMethod(method, testClassInstance);
                    OnTestPass?.Invoke(methodName);
                }
                catch (TargetInvocationException e) when
                    (e.InnerException is AssertFailureException ex)
                {
                    string message = ex.Message;
                    OnTestFailure?.Invoke(methodName, message);
                }
            }
        }
    }

    private static object CreateInstance(Type sourceType)
    {
        if (!sourceType.GetConstructors().Any(o => o.GetParameters().Length == 0))
        {
            throw new InvalidOperationException(
                $"В типе {sourceType.FullName} необходим конструктор без параметров");
        }

        return Activator.CreateInstance(sourceType)!;
    }
}