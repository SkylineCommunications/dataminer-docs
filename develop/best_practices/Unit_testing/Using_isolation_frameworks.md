---
uid: Using_isolation_frameworks
---

# Using isolation frameworks

The [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) interface is heavily used in protocols as it acts as the interface between *SLScripting* (the process executing QActions) and *SLProtocol* (the process executing the protocol logic).

Therefore, it is very likely you will end up in a situation where you want to test a method that has a dependency on the `SLProtocol` interface. Below, you can learn how to fake `SLProtocol` so you can easily create unit tests that have a dependency on this interface.

## Faking SLProtocol using MOQ

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

This method is very similar to the method shown in [Creating unit tests using the MSTestv2 framework in Visual Studio](xref:Unit_tests_MSTestv2_framework). However, note that the method now has an additional parameter of type `SLProtocol`.

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

In some tests, you may want to verify or assert something on the fake object (e.g., whether a specific method was called). Whenever this is the case, your fake is referred to as a mock.

For example, suppose you want to create an additional unit test to ensure that the [Log](xref:Skyline.DataMiner.Scripting.SLProtocol.Log(System.String,Skyline.DataMiner.Scripting.LogType,Skyline.DataMiner.Scripting.LogLevel)) method gets called whenever "Generic" is part of the specified path. This can be done as follows:

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
    slProtocolMock.Verify(p => p.Log(It.IsAny<string>(), It.IsAny<LogType>(), It.IsAny<LogLevel>()));
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
    string expectedMessage = $"QA10|Rewrite|Path '{path}' must not contain 'Generic'. Auto-adjusting to 'SLCGeneric'.";
    // Act
    pathRewriter.Rewrite(slProtocolMock.Object, path);
    // Assert
    slProtocolMock.Verify(p => p.Log(expectedMessage, It.IsAny<LogType>(), It.IsAny<LogLevel>()));
}
```

Note the use of the `Setup` method on the mock object. This allows you to specify what should be returned when the QActionID property is called.

The use of isolation frameworks like Moq allows you to easily create stubs and mocks. It allows you to perform advanced assertions on the mock objects such as verifying the number of times a method got invoked, etc.

## Useful links

For more information on the Moq framework, see:

- [Quickstart](https://github.com/Moq/moq4/wiki/Quickstart)
