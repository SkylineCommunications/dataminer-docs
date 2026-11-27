---
uid: Using_isolation_frameworks
description: Learn how to isolate SLProtocol dependencies in connector unit tests using the Unit Testing Framework or Moq.
---

# Using isolation frameworks

The [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) interface connects QActions to protocol logic. To unit test code that depends on `SLProtocol` without a running element, you can replace that dependency with a fake.

## Faking SLProtocol with Moq

An isolation framework such as [Moq](https://github.com/moq/moq4) can create a fake implementation of `SLProtocol`. Configure the methods your test needs, pass the fake to the code under test, and check the result.

Add the Moq NuGet package to your test project. You may also need a reference to the *SLManagedScripting* DLL.

![Moq selected in the NuGet Package Manager for a test project in Visual Studio](~/develop/images/unittesting7.png)

For example, consider a method that reads a status parameter:

```csharp
public static object GetStatus(SLProtocol protocol)
{
    return protocol.GetParameter(100);
}
```

The following test configures `GetParameter` to return a value and passes the fake `SLProtocol` through the mock's `Object` property:

```csharp
[TestMethod]
public void GetStatus_ParameterIsOnline_ReturnsOnline()
{
    // Arrange
    var mock = new Mock<SLProtocol>();
    mock.Setup(protocol => protocol.GetParameter(100)).Returns("Online");

    // Act
    object result = GetStatus(mock.Object);

    // Assert
    Assert.AreEqual("Online", result);
}
```

Moq can also verify calls to a mock, for example to check whether a method was invoked. See the [Moq quickstart](https://github.com/Moq/moq4/wiki/Quickstart) for more examples.

## Using the Unit Testing Framework

For connector tests that use parameter or table data, the recommended approach is to use the Unit Testing Framework. Its `SLProtocolMock` provides a ready-made alternative to configuring each `SLProtocol` call with Moq. Its in-memory models store data based on the connector's *protocol.xml*, so tests can arrange and check state. Use the `Skyline.DataMiner.Utils.UnitTestingFramework.Protocol` package in your test project.

By default, `SLProtocolMock` finds the solution directory from the current working directory and loads the *protocol.xml* file from that directory. If the file is in a different location or the solution directory cannot be found, pass the path explicitly:

```csharp
var protocolMock = new SLProtocolMock(@"C:\MyConnector\protocol.xml");
```

For example, the following method reads a parameter and updates a table row:

```csharp
public static void UpdateStreamName(SLProtocol protocol)
{
    object name = protocol.GetParameter(150);
    protocol.SetParameterIndexByKey(1000, "PK1", 2, name);
}
```

The test below assumes *protocol.xml* defines standalone parameter 150 and table 1000, with a primary key and a stream name as its first two columns:

```csharp
[TestMethod]
public void UpdateStreamName_ExistingRow_UpdatesName()
{
    // Arrange
    var protocolMock = new SLProtocolMock();
    protocolMock.GetParameter(150).Update("New name");
    protocolMock.GetTable(1000).SetRow(new object[] { "PK1", "Old name" });

    // Act
    UpdateStreamName(protocolMock.Object);

    // Assert
    Assert.AreEqual("New name", protocolMock.GetTable(1000).GetRow("PK1")[1]);
}
```

Pass `protocolMock.Object` to the code under test. You can also use its `SLProtocol` methods to arrange or inspect data. For code that depends on `SLProtocolExt`, use `SLProtocolMock<ConcreteSLProtocolExt>` with the generated `ConcreteSLProtocolExt` type.

For an overview of the available packages, see [Unit Testing Framework](xref:Unit_Testing_Framework).
