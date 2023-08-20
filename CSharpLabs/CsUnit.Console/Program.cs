
using CsUnit;
using CsUnit.Console;

Type sourceType = typeof(SampleTests);
TestRunner.OnTestPass += (name, message) => Console.WriteLine($"{name} pass.");
TestRunner.OnTestFailure += (name, message) => Console.WriteLine($"{name} failure, {message}.");
TestRunner.TestClass(sourceType);