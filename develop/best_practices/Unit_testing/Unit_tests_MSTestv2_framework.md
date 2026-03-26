---
uid: Unit_tests_MSTestv2_framework
---

# Creating unit tests using the MSTestv2 framework in Visual Studio

Suppose you are working on a protocol, and you are creating a precompile QAction that contains functionality that will be used by other QActions. To ensure that the functionality provided by this precompile QAction is correct, you want to create unit tests.

In the following example, a precompile QAction with ID 1 was created that, among other things, provides a `PathRewriter` class. The `PathRewriter` class defines a method `Rewrite` for which a unit test is needed.

In Visual Studio, you can easily generate a unit test: Put the cursor on the method, right-click, and select *Create Unit Tests* in the context menu.

![unittesting1.png](~/develop/images/unittesting1.png)

This will open a window where you can configure things such as the test framework to use, the name format of the test class, etc. As all the default settings are OK for now, simply click *OK* to continue.

![unittesting2.png](~/develop/images/unittesting2.png)

After clicking *OK*, you will see that a new project has been added to the solution, in this case "QAction_1Tests".

![unittesting3.png](~/develop/images/unittesting3.png)

This project contains a file *PathRewriterTests.cs* that defines a test class `PathRewriterTests`:

```csharp
[TestClass()]
public class PathRewriterTests
{
    [TestMethod()]
    public void RewriteTest()
    {
        Assert.Fail();
    }
}
```

The `PathRewriterTests` class has been annotated with a `TestClass` attribute. This attribute indicates that this class contains test methods. The `RewriteTest` method has been annotated with the `TestMethod` attribute to indicate that it is a test method.

These attributes are defined by the MSTest framework (in the namespace *Microsoft.VisualStudio.TestTools.UnitTesting*). Other useful attributes are:

- **AssemblyInitializeAttribute** and **AssemblyCleanupAttribute**: These identify the method that contains code to be executed before or after all tests in the assembly have run, respectively.
- **ClassInitializeAttribute** and **ClassCleanupAttribute**: These identify the method that contains code to be executed before or after all tests in this test class have run, respectively.
- **TestInitializeAttribute** and **TestCleanupAttribute**: These identify the method that contains code that must be executed before or after each test in this test class, respectively.
- **IgnoreAttribute**: Used to indicate that a specific test should not run.
- **DescriptionAttribute**: Used to provide a description for the test.
- **TestCategoryAttribute**: Specifies a category for the unit test.
- **TimeoutAttribute**: Provides a timeout for the test.
- **DataTestMethodAttribute**: Used to specify a data-driven test where data can be specified inline.
- **DataRowAttribute**: Defines inline data for a test method.
- **ExpectedExceptionAttribute**: Specifies the type of exception this test is expected to throw.

For more information about these attributes and a complete overview of all attributes that can be used, see [Microsoft.VisualStudio.TestTools.UnitTesting Namespace](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting?view=mstest-net-1.3.2).

Visual Studio also provides a *Test Explorer*, which gives an overview of all your tests in the solution. To open the *Test Explorer* in Visual Studio, in the menu bar, go to *Test > Windows > Test Explorer*.

![unittesting4.png](~/develop/images/unittesting4.png)

From the Test Explorer, you can easily run a specific test, run all tests, create a playlist of tests, etc.

For more information on the *Test Explorer*, see:

- [Run unit tests with Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019)
- [Debug and analyze unit tests with Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/debug-unit-tests-with-test-explorer?view=vs-2019)
- [Visual Studio Test Explorer FAQ](https://docs.microsoft.com/en-us/visualstudio/test/test-explorer-faq?view=vs-2019)

At this point, Visual Studio has created the test class and method, but it is up to you to implement the test method.

To implement a test method, typically the **triple A (AAA) pattern** is used. This means that the method body consists of three separate parts:

- **Arrange**: The setup of everything you need to perform the tests.
- **Act**: Performing the action that you want to test.
- **Assert**: Verifying whether the result is what you expected.

In the current example, the *Arrange* step consists of creating an instance of the class, the *Act* step is invoking the `Rewrite` method on that instance, and the *Assert* step is verifying whether the actual output matches the expected output.

```csharp
[TestMethod()]
public void Rewrite_PathWithItemsToAbbreviate_ReturnsAbbreviatedPath()
{
    // Arrange
    PathRewriter pathRewriter = new PathRewriter();
    string path = @"Visios\Customers\Skyline\Protocols\Test";
    string expected = @"V\C\Skyline\P\Test";
    // Act
    string result = pathRewriter.Rewrite(path);
    // Assert
    Assert.AreEqual(expected, result);
}
```

The `Assert` class defines multiple methods such as `AreEqual`, `IsFalse`, `IsTrue`, etc. that can be used to make assertions. For more information on the `Assert` class, see [Assert Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=mstest-net-1.3.2).

Now you are ready to execute the test. This can be done in the *Test Explorer*, by e.g., clicking *Run All*. After a successful execution, everything should be green.

![unittesting5.png](~/develop/images/unittesting5.png)

In case a test fails, a red X will be displayed. Clicking the line that represents the test in the *Test Explorer* will provide more information about what failed.

![unittesting6.png](~/develop/images/unittesting6.png)

When writing unit tests, you typically want to provide tests for different scenarios. For example, you could also want to write an additional test to verify whether an `ArgumentNullException` is thrown in case the `Rewrite` method is invoked with a null reference as parameter value.

This can be done as follows: The `ExpectedException` attribute can be used to indicate the type of exception that you expect.

```csharp
[TestMethod()]
[ExpectedException(typeof(ArgumentNullException))]
public void Rewrite_NullPath_ThrowsArgumentNullException()
{
    // Arrange
    PathRewriter pathRewriter = new PathRewriter();
    // Act
    pathRewriter.Rewrite(null);
    // Assert
    Assert.Fail("No ArgumentNullException thrown.");
}
```

Note that the pattern used for the test method names consists of three parts separated by an underscore. The parts define the following:

- The name of the method that is being tested.
- The condition or scenario you want to test.
- The expected result.

This allows you to know what it tested, the tested scenario and the expected result, just from the test method name.

In some cases, you may want to execute the same test but with different input. In such cases, the `DataRowAttribute` attribute can be used:

```csharp
[DataTestMethod()]
[DataRow("pattern 1")]
[DataRow("pattern 2")]
public void ValidatePattern_ValidInput_ReturnsTrue(string input)
{
// Arrange
var myClass = new MyClass();
    
// Act
    bool isValid = myClass.ValidatePattern(input);
    // Assert
    Assert.IsTrue(isValid);
}
```

## Useful links

For more information, see:

- [Testing tools in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/test/?view=vs-2019>)
- [Unit testing best practices with .NET Core and .NET Standard](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
