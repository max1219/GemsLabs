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
        bool isPass = true;
        bool isTest = false;
        foreach (var attribute in method.GetCustomAttributes())
        {
            if (attribute is AbcTesterAttribute testerAttribute)
            {
                isTest = true;
                try
                {
                    testerAttribute.TestMethod(method, testClassInstance);
                }
                catch (TargetInvocationException e) when
                    (e.InnerException is AssertFailureException ex)
                {
                    isPass = false;
                    string message = ex.Message;
                    OnTestFailure?.Invoke($"{testClassInstance.GetType().Name}.{method.Name}", message);
                }
            }
        }

        if (isTest && isPass)
        {
            OnTestPass?.Invoke($"{testClassInstance.GetType().Name}.{method.Name}");
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