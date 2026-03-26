---
uid: Test_life_cycle_attributes
---

# Test lifecycle attributes

You can create unit tests with MSTestv2 by marking a class with the *TestClass* attribute and test methods with the *TestMethod* attribute. Below, we describe some other attributes that can be used, which are often referred to as "test lifecycle" attributes.

Test lifecycle attributes can be useful in situations where some common logic must be executed before or after a test is executed (e.g., creating a connection, or doing some cleanup). This can, for instance, be the case when implementing integration tests.

MSTestV2 supports the following Initialize/Cleanup attribute pairs:

- [AssemblyInitializeAttribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assemblyinitializeattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2) and [AssemblyCleanupAttribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assemblycleanupattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2)
- [ClassInitializeAttribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.classinitializeattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2) and [ClassCleanupAttribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.classcleanupattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2)
- [TestInitializeAttribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.testinitializeattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2) and [TestCleanupAttribute](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.testcleanupattribute?view=visualstudiosdk-2022&viewFallbackFrom=mstest-net-1.3.2)

## AssemblyInitializeAttribute

The *AssemblyInitializeAttribute* attribute can be used to identify a method that should be executed before any test in the assembly runs:

- The method must be part of a class annotated with the *TestClassAttribute* attribute.
- This attribute can only be applied to one method in an assembly.
- The method to which this attribute is applied must be static and public, have a single parameter of type *TestContext*, and must not return a value (or, when using async-await, return a Task).
- This method will be executed before any method annotated with the *ClassInitializeAttribute*, *TestInitializeAttribute* or *TestMethodAttribute* attribute.

## AssemblyCleanupAttribute

This attribute can be used to identify a method that should be executed after the tests in the assembly have been executed:

- The method must be part of a class annotated with the *TestClassAttribute* attribute.
- This attribute can only be applied to one method in an assembly.
- The method to which this attribute is applied must be static and public, have no parameters, and must not return a value (or, when using async-await, return a Task).
- This method will be executed after any method annotated with the *ClassCleanupAttribute* or *TestCleanupAttribute* attribute.

## ClassInitializeAttribute

This attribute can be used to identify a method that should be executed before a test of this test class is executed:

- The method must be part of a class annotated with the *TestClass* attribute.
- This attribute can only be applied to one method per test class.
- This method will be executed before the method annotated with the *TestInitializeAttribute* attribute but after the method annotated with the *AssemblyInitializeAttribute* attribute.
- The method to which this attribute is applied must be static and public, have a single parameter of type *TestContext*, and must not return a value (or, when using async-await, return a Task).

## ClassCleanupAttribute

This attribute can be used to identify a method that should be executed after all tests of a test class have been executed:

- The method must be part of a class annotated with the *TestClassAttribute* attribute.
- This attribute can only be applied to one method per test class.
- This method will be executed after the method annotated with the *TestCleanupAttribute* attribute but before the method annotated with the *AssemblyCleanupAttribute* attribute.
- The method to which this attribute is applied must be static and public, have no parameters, and must not return a value (or, when using async-await, return a Task).

## TestInitializeAttribute

This attribute can be used to identify a method that should be executed before each test method in a test class:

- The method must be part of a class annotated with the *TestClassAttribute* attribute.
- This attribute can only be applied to one method per test class.
- The method to which this attribute is applied must be non-static and public, have no parameters, and must not return a value (or, when using async-await, return a Task).
- This method will be executed after methods marked with the *AssemblyInitialize* or *ClassInitialize* attribute.

Instead of using the *TestInitialize* attribute, you could also choose to provide initialization logic in the parameterless constructor of the class, as the test executor creates a new instance of the class for each test to be executed.

## TestCleanupAttribute

This attribute can be used to identify a method that should be executed after each test method in a test class:

- The method must be part of a class annotated with the *TestClassAttribute* attribute.
- This attribute can only be applied to one method per test class.
- The method to which this attribute is applied must be non-static and public, have no parameters, and must not return a value (or, when using async-await, return a Task).
- This method will be executed before methods marked with the *ClassCleanupAttribute* or *AssemblyCleanupAttribute* attribute.

Instead of using the *TestCleanupAttribute* attribute, you could let the test class implement the [IDisposable interface](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-5.0).

## Example

The example test class below makes use of all the attributes introduced above. This example also has a parameterless constructor and implements *IDisposable* for illustration purposes (as you would typically use either the *TestInitialize* and/or *TestCleanup* attributes or define a constructor and/or implement *IDisposable*).

```csharp
[TestClass()]
public class MyTestClass : IDisposable
{
    public MyTestClass()
    {
    }
    [TestMethod()]
    public void MyTestMethod()
    {
        // AAA
    }
    [TestMethod()]
    public void MyOtherTestMethod()
    {
        // AAA
    }
    [AssemblyInitialize]
    public static void MyAssemblyInitialize(TestContext context)
    {
    }
    [AssemblyCleanup]
    public static void MyAssemblyCleanup()
    {
    }
    [ClassInitialize]
    public static void MyClassInitialize(TestContext context)
    {
    }
    [ClassCleanup]
    public static void MyClassCleanup()
    {
    }
    [TestInitialize]
    public void MyTestInitialize()
    {
    }
    [TestCleanup]
    public void MyTestCleanup()
    {
    }
    public void Dispose()
    {
    }
}
```

The order of execution will be as follows:

1. MyAssemblyInitialize
1. MyClassInitialize
1. MyTestClass constructor
1. MyTestInitialize
1. MyTestMethod
1. MyTestCleanup
1. Dispose
1. MyTestClass constructor
1. MyTestInitialize
1. MyOtherTestMethod
1. MyTestCleanup
1. Dispose
1. MyClassCleanup
1. MyAssemblyCleanup
