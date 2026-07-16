---
uid: Unit_tests
---

# Creating unit tests

Suppose you are working on a protocol, and you are creating a precompile QAction that contains functionality that will be used by other QActions. To ensure that the functionality provided by this precompile QAction is correct, you want to create unit tests.

In the following example, a precompile QAction with ID 1 was created that, among other things, provides a `PathRewriter` class. The `PathRewriter` class defines a method `Rewrite` for which a unit test is needed.

## [Using GitHub Copilot](#tab/test-creation-1)

Using GitHub Copilot, there are multiple ways to generate unit tests:

- Type `@Test` followed by a target or prompt (see below) in the Copilot Chat window.
- From the editor, right-click and select *Copilot Actions > Generate Tests* from the context menu.
- In a new Copilot Chat thread, select *Write unit tests* from the Copilot Chat icebreaker suggestions.

### Prompt syntax

You can choose between two prompting methods to create unit tests using Copilot: freeform or structured syntax:

- **Freeform**: With freeform prompts, you describe in text for what a test needs to be created. E.g., `@Test class PathRewriter`
- **Structured syntax**: With structured syntax, you use the following syntax to specify for what tests need to be generated: `@Test #<target>`. `#<target>` then denotes for example a class (e.g., `#PathRewriter`) or a git diff (`#git_changes`).

## [Manual](#tab/test-creation-2)

A unit test is defined in a test project. During scaffolding of the Visual Studio solution, the connector template creates a *Tests* folder where you can place your test projects.

1. In Solution Explorer, select the *Tests* folder and select *Add* > *New Project* in the context menu.

   Alternatively, in the *File* menu, select *Add* > *New Project*.

  This opens the *Add a new project* window.

1. From the *All languages* dropdown, select *C#*.

1. From the *All project types* dropdown, select *Test*.

   This filters the list to only show available test project types for C#.

   ![unit_tests_test_project_creation.png](~/develop/images/unit_tests_test_project_creation.png)

   Different projects are listed for different test frameworks such as MSTest, NUnit or xUnit.

1. Select *MSTest Test Project* and click *Next*.

1. Give the project a name, e.g., `QAction_1Tests` and click *Next*.

1. In the *Additional information* window, in the *Framework* dropdown, select *.NET Framework 4.8*.

1. In the *Test runner* dropdown, select *Microsoft.Testing.Platform*, and click *Create*.

   ![unit_tests_test_project_creation_additional_information.png](~/develop/images/unit_tests_test_project_creation_additional_information.png)

   A new project will be added to the solution, in this case *QAction_1Tests*.

   ![unit_tests_test_project_solution_explorer.png](~/develop/images/unit_tests_test_project_solution_explorer.png)

1. Rename the file *Test1.cs* to *PathRewriterTests.cs* and replace the contents with the following:

   ```cs
   namespace QAction_1Tests
   {
       [TestClass()]
       public class PathRewriterTests
       {
           [TestMethod()]
           public void RewriteTest()
           {
               Assert.Fail();
           }
       }
   }
   ```

***

## Test attributes

The `PathRewriterTests` class is annotated with a `TestClass` attribute. This attribute indicates that this class contains test methods. The `RewriteTest` method is annotated with the `TestMethod` attribute to indicate that it is a test method.

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
- **RetryAttribute**: Used to set a retry count on a test method in case of failure.
- **OSConditionAttribute**: Used to ignore a test class or a test method, with an optional message.
- **CIConditionAttribute**: Used to control whether a test class or method will run or be ignored when the test executes in a CI environment.

For more information about these attributes and a complete overview of all attributes that can be used, see [Microsoft.VisualStudio.TestTools.UnitTesting Namespace](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting?view=mstest-netfx-4.3).

## Implementing a test method

At this point, Visual Studio has created the test class and method, but it is up to you to implement the test method.

To implement a test method, typically the **triple A (AAA) pattern** is used. This means that the method body consists of three separate parts:

- **Arrange**: The setup of everything you need to perform the tests.
- **Act**: Performing the action that you want to test.
- **Assert**: Verifying whether the result is what you expected.

In the example below, the *Arrange* step consists of creating an instance of the class, the *Act* step is invoking the `Rewrite` method on that instance, and the *Assert* step is verifying whether the actual output matches the expected output.

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

The `Assert` class defines multiple methods such as `AreEqual`, `IsFalse`, `IsTrue`, etc. that can be used to make assertions. For more information on the `Assert` class, see [Assert Class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=mstest-net-4.2).

Note that the pattern used for the test method name consists of three parts separated by an underscore. The parts define the following:

- The name of the method that is being tested.
- The condition or scenario you want to test.
- The expected result.

This allows you to know what it tested, the tested scenario and the expected result, just from the test method name.

## Testing whether an exception is thrown

When writing unit tests, you typically want to provide tests for different scenarios. For example, you could also want to write an additional test to verify whether an `ArgumentNullException` is thrown in case the `Rewrite` method is invoked with a null reference as parameter value.

This can be done as follows:

```csharp
[TestMethod()]
public void Rewrite_NullPath_ThrowsArgumentNullException()
{
    // Arrange
    PathRewriter pathRewriter = new PathRewriter();

    // Act & Assert
    Assert.ThrowsExactly<ArgumentNullException>(() => pathRewriter.Rewrite(null));
}
```

> [!NOTE]
> The Assert class provides different methods for verifying that an exception was thrown such as `Throws<T>`, `ThrowsExactly<T>`, `ThrowsAsync<T>`, `ThrowsExactlyAsync<T>`.

## Testing with different input data

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

## Test Explorer

Once the unit test has been implemented, it is ready for execution. Execution can be triggered via *Test Explorer*, which gives an overview of all your tests in the solution. To open the *Test Explorer* in Visual Studio, in the menu bar, go to *Test > Windows > Test Explorer*.

![unit_tests_test_explorer.png](~/develop/images/unit_tests_test_explorer.png)

From the Test Explorer, you can easily run a specific test, run all tests, create a playlist of tests, etc. After a successful execution, everything should be green.

![unit_tests_test_explorer_successful_run.png](~/develop/images/unit_tests_test_explorer_successful_run.png)

In case a test fails, a red X will be displayed. Clicking the line that represents the test in the *Test Explorer* will provide more information about what failed.

For more information on the *Test Explorer*, see:

- [Run unit tests with Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019)
- [Debug and analyze unit tests with Test Explorer](https://docs.microsoft.com/en-us/visualstudio/test/debug-unit-tests-with-test-explorer?view=vs-2019)
- [Visual Studio Test Explorer FAQ](https://docs.microsoft.com/en-us/visualstudio/test/test-explorer-faq?view=vs-2019)

## Useful links

For more information, see:

- [Testing tools in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/test/?view=vs-2019>)
- [Unit testing best practices with .NET Core and .NET Standard](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
- [Generate and run unit tests using GitHub Copilot testing for .NET](https://learn.microsoft.com/en-us/visualstudio/test/unit-testing-with-github-copilot-test-dotnet?view=visualstudio)
- [Create and run unit tests for .NET](https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=visualstudio)
