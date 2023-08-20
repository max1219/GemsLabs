using System.Reflection;

namespace CsUnit.TesterAttributes;

public abstract class AbcTesterAttribute: Attribute
{
    public abstract void TestMethod(MethodInfo method, object testClassInstance);
}