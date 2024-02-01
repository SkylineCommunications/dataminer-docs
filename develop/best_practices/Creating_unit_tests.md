---
uid: Creating_unit_tests
---

# Creating unit tests

Below, you can find out how to create unit tests in Visual Studio in a solution-based protocol and how to use isolation frameworks, write testable code, use FluentAssertions, and use files in unit tests.

## Creating unit tests using the MSTestv2 framework in Visual Studio

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

Now you are ready to execute the test. This can be done in the *Test Explorer*, by e.g. clicking *Run All*. After a successful execution, everything should be green.

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

### Useful links

For more information, see:

- [Testing tools in Visual Studio](https://docs.microsoft.com/en-us/visualstudio/test/?view=vs-2019>)
- [Unit testing best practices with .NET Core and .NET Standard](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)

## Using isolation frameworks

The `SLProtocol` interface is heavily used in protocols as it acts as the interface between *SLScripting* (the process executing QActions) and *SLProtocol* (the process executing the protocol logic).

Therefore, it is very likely you will end up in a situation where you want to test a method that has a dependency on the `SLProtocol` interface. This article explains how to fake `SLProtocol` so you can easily create unit tests that have a dependency on this interface.

### Faking SLProtocol using MOQ

Consider, for example, the following method:

```csharp
public string Rewrite(SLProtocol protocol, string path)
{
    if(path == null)
    {
        throw new ArgumentNullException(nameof(path));
    }
    if(String.IsNullOrWhiteSpace(path))
    {
        throw new ArgumentException("Path is empty or white space.", nameof(path));
    }
    string[] pathParts = path.Split('\\');
    string[] abbreviatedPath = new string[pathParts.Length];
    for (int i = 0; i < pathParts.Length; i++)
    {
        string part = pathParts[i];
        if (part == "Generic")
        {
            abbreviatedPath[i] = "SLCGeneric";
            protocol.Log("QA" + protocol.QActionID + "|Rewrite|Path '" + path + "' must not contain 'Generic'. Auto-adjusting to 'SLCGeneric'.", LogType.Error, LogLevel.NoLogging);
            continue;
        }
        if (itemsToAbbreviate.Contains(part))
        {
            abbreviatedPath[i] = Convert.ToString(part[0]);
        }
        else
        {
            abbreviatedPath[i] = part;
        }
    }
    return String.Join(@"\", abbreviatedPath);
}
```

This method is very similar to the method shown in the previous section. However, note that the method now has an additional parameter of type *SLProtocol*.

Suppose you now want to create a unit test for this method. When calling the `Rewrite` method in the *Act* step of your test method, you should pass along something that implements *SLProtocol*.

One option is to create your own class that implements the `SLProtocol` interface. However, an easier alternative is to make use of an isolation framework.

For this, you can for example use the [Moq library](https://github.com/moq/moq4). To start using the Moq library, select your test project in the *Solution Explorer*, right-click it, and then select *Manage NuGet Packages*. Click *Browse* and type "Moq". Select the package and click the *Install* button.

![unittesting7.png](~/develop/images/unittesting7.png)

The best way to explain how this framework works is by using it through an example.

In the *Arrange* step, you create a new instance of Mock specifying *SLProtocol* for the type parameter (Note that you may need to add a reference to the *SLManagedScripting* DLL file in your test project first). Then in the *Act* step, you pass *fakeSLProtocol.Object* as the object that implements *SLProtocol*.

```csharp
[TestMethod()]
public void Rewrite_PathWithItemsToAbbreviate_ReturnsAbbreviatedPath()
{
    // Arrange
    PathRewriter pathRewriter = new PathRewriter();
    string path = @"Visios\Customers\Skyline\Protocols\Test";
    string expected = @"V\C\Skyline\P\Test";
    var fakeSlProtocol = new Mock<SLProtocol>();
    // Act
    string result = pathRewriter.Rewrite(fakeSlProtocol.Object, path);
    // Assert
    Assert.AreEqual(expected, result);
}
```

In this example, the object implementing the `SLProtocol` interface is used as a stub. I.e. it just acts as a replacement for the dependency we had. This is all it takes to create an *SLProtocol* fake.

In some tests, you may want to verify or assert something on the fake object (e.g. whether a specific method was called). Whenever this is the case, your fake is referred to as a mock.

For example, suppose you want to create an additional unit test to ensure that the `Log` method gets called whenever "Generic" is part of the specified path. This can be done as follows:

```csharp
[TestMethod()]
public void AbbreviatePath_PathContainingGeneric_CallsLogMethod()
{
    // Arrange
    PathRewriter pathRewriter = new PathRewriter();
    string path = @"Visios\Customers\Generic";
    var slProtocolMock = new Mock<SLProtocol>();
    // Act
    pathRewriter.Rewrite(slProtocolMock.Object, path);
    // Assert
    slProtocolMock.Verify(p => p.Log(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
}
```

By calling the `Verify` method on the `slProtocolMock` object, you can verify whether the `Log` method has been called. In this case, the values that were provided when the `Log` method was invoked are not important (hence the use of `It.IsAny<T>`). However, it is possible to also verify the values if this is needed. The following example verifies the message:

```csharp
[TestMethod()]
public void AbbreviatePath_PathContainingGeneric_CallsLogMethod()
{
    // Arrange
    PathRewriter pathRewriter = new PathRewriter();
    string path = @"Visios\Customers\Generic";
    var slProtocolMock = new Mock<SLProtocol>();
    slProtocolMock.Setup(p => p.QActionID).Returns(10);
    string expectedMessage = "QA10|AbbreviatePath|Path must not contain 'Generic'. Auto-adjusting to 'SLCGeneric'.";
    // Act
    pathRewriter.Rewrite(slProtocolMock.Object, path);
    // Assert
    slProtocolMock.Verify(p => p.Log(It.IsAny<int>(), It.IsAny<int>(), expectedMessage));
}
```

Note the use of the `Setup` method on the mock object. This allows you to specify what should be returned when the QActionID property is called.

The use of isolation frameworks like Moq allows you to easily create stubs and mocks. It allows you to perform advanced assertions on the mock objects such as verifying the number of times a method got invoked, etc.

Note that you may have noticed something unusual in this example: In the `Rewrite` method, we invoke the following overload of the `Log` method: `Log(string, LogType, LogLevel)`. However, the verify call in the *Assert* step looks for an invocation of the following overload of `Log`: `Log(int, int, string)`.

This is because currently the `Log(string, LogType,  LogLevel)` method is defined as an extension method. Even though this extension method extends the `SLProtocol` interface, it is not part of the interface. However, this method just calls the `Log(int, int, string)` method internally (which is defined as part of the `SLProtocol` interface). Therefore, we can verify whether the `Log(string, LogType, LogLevel)` method was called by checking whether the `Log(int, int, string)` method was called.

Currently, several extension methods on the `SLProtocol` interface are defined. For more information about these methods, see [NotifyProtocol class](xref:Skyline.DataMiner.Scripting.NotifyProtocol) and [ProtocolExtenders class](xref:Skyline.DataMiner.Scripting.ProtocolExtenders).

### Useful links

For more information on the Moq framework, see:

- [Quickstart](https://github.com/Moq/moq4/wiki/Quickstart)

## Writing testable code

Below, you can find how applying the concept of dependency injection and the use of interfaces is useful to create testable code.

### Refactoring code for better testability

Consider the following example of defining a path cache. This class allows you to add paths, and the cache will hold the rewritten paths. You can inspect the cache using the `CachedItems` property.

```csharp
public sealed class PathCache
{
    private readonly HashSet<string> cachedPaths;
    private readonly PathRewriter pathRewriter;
    public PathCache()
    {
        pathRewriter = new PathRewriter();
        cachedPaths = new HashSet<string>();
    }
    public void AddPath(string path)
    {
        string rewrittenPath = pathRewriter.RewritePath(path);
        cachedPaths.Add(rewrittenPath);
    }
    public IEnumerable<string> CachedItems
    {
        get { return cachedPaths.ToList().AsReadOnly();}
    }
}
```

Now a unit test is needed in order to verify that this class is working correctly. Suppose you write the following test:

```csharp
[TestMethod()]
public void AddPath_ValidPath_PathPresentInCache()
{
    // Arrange
    PathCache cache = new PathCache();
    string path = @"Visios\Customers\Skyline\Protocols\Test";
    string expectedPath = @"V\C\Skyline\P\Test";
    // Act
    cache.AddPath(path);
    // Assert
    CollectionAssert.Contains(cache.CachedItems.ToList(), expectedPath);
}
```

There is a problem with the test above. It is implicitly also testing the `Rewrite` method of the `PathRewriter` class. This means that in case the `Rewrite` method of the `PathRewriter` class does not work as expected, this unit test will also start to fail, even though the logic you are trying to test (which is adding items to the cache) might be implemented correctly. This is something that should be avoided.

The root cause of this problem is that there is a fixed dependency on the `PathRewriter` class. In the `PathCache` constructor, you can find the following:

```csharp
public PathCache()
{
    pathRewriter = new PathRewriter();
    cachedPaths = new HashSet<string>();
}
```

A way to overcome this is to use dependency injection. The following refactoring makes use of dependency injection through the constructor:

```csharp
public PathCache(PathRewriter rewriter)
{
    pathRewriter = rewriter;
    cachedPaths = new HashSet<string>();
}
```

Now you can provide or inject an instance of the `PathRewriter` class. However, you are still injecting the `PathRewriter` class. Ideally, you need to have more freedom on what you can pass along to avoid implicitly testing other code.

To achieve this, you can introduce an `IPathRewriter` interface (in Visual Studio, you can do this by putting your cursor over the `PathRewriter` class name, right-clicking, and selecting *Quick Actions and Refactoring* in the context menu. This will bring up another context menu where you can select *Extract interface*:

```csharp
public interface IPathRewriter
{
    string Rewrite(string path);
}
```

Now you can add the following to indicate that the `PathRewriter` class implements this interface:

```csharp
public class PathRewriter : IPathRewriter
```

Now update the `PathCache` class so it has a dependency on `IPathRewriter` instead of `PathRewriter`.

```csharp
public sealed class PathCache
{
    private readonly HashSet<string> cachedPaths;
    private readonly IPathRewriter pathRewriter;
    public PathCache(IPathRewriter rewriter)
    {
        pathRewriter = rewriter;
        cachedPaths = new HashSet<string>();
    }
    ...
}
```

These changes allow you to now create a unit test for the `PathCache` class that no longer depends on the `PathRewriter` class:

```csharp
[TestMethod()]
public void AddPath_ValidPath_PathPresentInCache()
{
    // Arrange
    string expectedPath = "rewrittenPath";
    Mock<IPathRewriter> pathRewriter = new Mock<IPathRewriter>();
    pathRewriter.Setup(p => p.Rewrite(It.IsAny<string>())).Returns(expectedPath);
    PathCache cache = new PathCache(pathRewriter.Object);
    string path = @"Visios\Customers\Skyline\Protocols\Test";
    // Act
    cache.AddPath(path);
    // Assert
    CollectionAssert.Contains(cache.CachedItems.ToList(), expectedPath);
}
```

## FluentAssertions

As mentioned earlier, the third step in a unit test is the Assert step. The section below provides some more info on assertions.

### Performing assertions on collections

When writing a unit test, it may happen that you want to perform an assertion on a collection. You can do this by using the `CollectionAssert` class.

Consider the following example where you call a method and expect a collection with items "A", "B" and "C" to be returned:

```csharp
// Arrange
List<string> expected = new List<string>() { "A", "B", "C" };
// Act
ICollection<string> returned = …
// Assert
CollectionAssert.AreEquivalent(expected, returned.ToList());
```

The example makes use of the `AreEquivalent` method, which checks whether two collections contain the same elements. In case order is important, `AreEqual` can be used. For more information on the `CollectionAssert` class, see [CollectionAssert Class](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.collectionassert?view=mstest-net-1.3.2).

Now suppose the returned collection contains "A", "B" and "D". When running the unit test, you will get the following result in test explorer:

```txt
CollectionAssert.AreEquivalent failed. The expected collection contains 1 occurrence(s) of <C>. The actual collection contains 0 occurrence(s).
```

The message indicates that an occurrence of "C" was expected.

Now suppose that the returned collection is a collection of a custom type `Path` instead of strings:

```csharp
public struct Path
{
public Path(string item)
    {
        this.Item = item;
    }
    public string Item { get; set; }
}
// Arrange
List<Path> expected = new List<Path>() { new Path("A"), new Path("B"), new Path("C") };
// Act
ICollection<Path> returned = …
// Assert
CollectionAssert.AreEquivalent(expected, returned.ToList());
```

Again, suppose the method under test returns a collection with a wrong item. In this case, the message looks like this:

```txt
CollectionAssert.AreEquivalent failed. The expected collection contains 1 occurrence(s) of <MyNamespace.Path>. The actual collection contains 0 occurrence(s).
```

Now this message is not that useful for debugging. You could solve this by overriding the implementation of the `ToString` method in the `Path` type:

```csharp
public struct Path
{
public Path(string item)
    {
        this.Item = item;
    }
    public string Item { get; set; }
    public override string ToString()
    {
        return Item;
    }
}
```

This will result in the following message:

```txt
CollectionAssert.AreEquivalent failed. The expected collection contains 1 occurrence(s) of <B>. The actual collection contains 0 occurrence(s).
```

However, this solution assumes you can change type. Alternatively, you can use *FluentAssertions*.

### Using FluentAssertions

*FluentAssertions* can help you in performing advanced assertions while keeping the assertion easy to read and understand.

*FluentAssertions* is available as a NuGet package. To start using the *FluentAssertions* library, select your test project in the *Solution Explorer*, right-click it, and select *Manage NuGet Packages*. Click *Browse* and type "FluentAssertions". Select the package and click the *Install* button.

![unittesting8.png](~/develop/images/unittesting8.png)

Using *FluentAssertions*, the assertion can be rewritten as follows:

```csharp
// Arange
List<Path> expected = new List<Path>() { new Path("A"), new Path("B"), new Path("C") };
// Act
ICollection<Path> returned = …
// Assert
returned.Should().BeEquivalentTo(expected);
```

The assertion is easy to understand, thanks to the *fluent* API. Now, when you execute this test again, the message will look like this:

```txt
Expected item[1] to be
MyNamespace.Path
{
   Item = “B”
}, but found
MyNamespace.Path
{
   Item = “D”
}.
With configuration:
– Use declared types and members
– Compare enums by value
– Include all non-private properties
– Include all non-private fields
– Match member by name (or throw)
– Without automatic conversion.
– Without automatic conversion.
– Be strict about the order of items in byte arrays
```

Now the message gives more information about what went wrong.

### Useful links

- [Introduction to FluentAssertions](https://fluentassertions.com/introduction)

## Using files in unit tests

Sometimes, tests need to be created that use one or more files as test data. To make sure the files are available in the test, some additional effort is needed. The following problems need to be overcome:

- The build output of the test project might not always be created on the same location relative to the files.
- The working directory of the test runner might change depending on the tool that is executing it.

### Ensuring that the files are copied to the build output directory

You can solve the first problem by ensuring that the files are copied to the build output directory.

1. Put the files in the directory of the test project and add them to the project via the *Add Existing Item* context menu action in the *Solution Explorer*.

   ![unittesting9.png](~/develop/images/unittesting9.png)

   You can also organize the files by adding folders to the project. To avoid confusion, it is advised that you use the same folder structure in the project directory as in the *Solution Explorer*.

1. Right-click a file in the *Solution Explorer* and select *Properties*.

   ![unittesting10.png](~/develop/images/unittesting10.png)

1. Modify the properties as follows:

   ![unittesting11.png](~/develop/images/unittesting11.png)

   Setting these properties will cause the file to be copied to the build output directory. The file will now always have the same location relative to the test assembly.

1. Repeat the steps above for any other files that need to be available.

### Ensuring that the files are copied to the correct location for each test

To deal with the second issue, the possibility that the working directory of the test runner changes depending on the tool executing it, the source code of the test must be modified a little. *MSTestv2* provides the `DeploymentItemAttribute` specifically for this problem.

Let us have a look at an example for the test class:

```csharp
[TestClass]
public class ImportTests
{
    [TestMethod]
    [DeploymentItem(@"Import Test Files\default.json")]
    public void NormalConfigTest()
    {
        // Arrange
        var expected = ...
        // Act
        QAction_1.KpiConfig.ImportFromFile("default.json");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    [TestMethod]
    [DeploymentItem(@"Import Test Files\unexpected whitespace.json")]
    public void ModifiedWithWhitespaceTest()
    {
        // Arrange
        var expected = ...
        // Act
        QAction_1.KpiConfig.ImportFromFile("unexpected whitespace.json");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
```

The attribute ensures that the files are copied to the correct location before each test starts.

You can add this attribute multiple times if your test needs multiple files.

If you need the same files for multiple tests, you can also add the attribute to the class instead:

```csharp
[TestClass]
[DeploymentItem(@"Import Test Files\default.json", "Import Test Files")]
[DeploymentItem(@"Import Test Files\unexpected whitespace.json", "Import Test Files")]
public class ImportTests
{
    [TestMethod]
    public void NormalConfigTest()
    {
        // Arrange
        var expected = ...
        // Act
        var actual = QAction_1.KpiConfig.ImportFromFile(@"Import Test Files\default.json");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    [TestMethod]
    public void ModifiedWithWhitespaceTest()
    {
        // Arrange
        var expected = ...
        // Act
        var actual = QAction_1.KpiConfig.ImportFromFile(@"Import Test Files\unexpected whitespace.json");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}
```

Note the second parameter that was added to the attribute. It creates a directory with that name and puts the file inside it. Use this when you want to separate the files in different folders in case they have the same name.

### Useful links

- [How to: Deploy Files for Tests](https://learn.microsoft.com/en-us/previous-versions/ms182475(v=vs.140))
