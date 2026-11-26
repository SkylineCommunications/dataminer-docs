---
uid: Unit_Testing_Framework
description: Choose a Unit Testing Framework package for testing DataMiner code with in-memory mocks and supporting models.
---

# Unit Testing Framework

The Unit Testing Framework (UTF) provides in-memory mocks for testing code that uses DataMiner APIs without a running DataMiner System. Choose the package that matches the interfaces used by your code:

- **Protocol** for connector code that uses `SLProtocol` or `SLProtocolExt`.
- **DataMinerSystem.Common** for code that uses `IDms` and related DataMiner System interfaces.
- **SLNetTypes** for code that sends SLNet messages, including DataMiner Object Model (DOM) interactions.

Add the package you need to your test project, together with a test framework and a reference to the project containing the code under test. Supporting dependencies, such as the Shared package for protocol definitions and parameter and table models, are restored with the package. Package availability and supported APIs can differ between versions. The examples below use .NET Framework 4.8 and MSTest.

## Testing connector code

The `Skyline.DataMiner.Utils.UnitTestingFramework.Protocol` package provides `SLProtocolMock` for testing connector code. The mock loads *protocol.xml* and stores parameter and table data in memory. Pass its `Object` property to the QAction or other code under test.

For example, the following test assumes that the protocol defines parameters 100 and 101, and that the QAction copies the value of parameter 100 to parameter 101:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyline.DataMiner.Utils.UnitTestingFramework.Protocol;

[TestClass]
public class QActionTests
{
    [TestMethod]
    public void Run_ValidInput_UpdatesStatus()
    {
        // Arrange
        var mock = new SLProtocolMock();
        mock.Object.SetParameter(100, "Online");

        // Act
        QAction.Run(mock.Object);

        // Assert
        Assert.AreEqual("Online", mock.Object.GetParameter(101));
    }
}
```

For more information about locating *protocol.xml* and testing tables, see [Using isolation frameworks](xref:Using_isolation_frameworks).

## Testing DataMiner System interfaces

The `Skyline.DataMiner.Utils.UnitTestingFramework.DataMinerSystem.Common` package supports code that uses `IDms` and related interfaces for Agents, elements, parameters, tables, services, and views. Use `DmsMockBuilder` to configure the objects needed by the test.

In the following example, `IsElementActive` represents code that checks the state of an element:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyline.DataMiner.Core.DataMinerSystem.Common;
using Skyline.DataMiner.Utils.UnitTestingFramework.DataMinerSystem.Common;

[TestClass]
public class ElementStatusTests
{
    [TestMethod]
    public void IsElementActive_ActiveElement_ReturnsTrue()
    {
        // Arrange
        var dmsMock = new DmsMockBuilder()
            .WithProtocol(name: "ExampleProtocol", configure: protocol => { })
            .WithDma(id: 1, configure: agent => agent
                .WithElement(id: 33, name: "Example element", protocolName: "ExampleProtocol"))
            .Build();

        // Act
        bool result = IsElementActive(dmsMock.Object);

        // Assert
        Assert.IsTrue(result);
    }

    private static bool IsElementActive(IDms dms)
    {
        return dms.GetAgent(1).GetElement("Example element").State == ElementState.Active;
    }
}
```

The builder registers a protocol and creates an Agent with an element that uses that protocol. The test passes the mock's `Object` to the method and checks its result.

## Testing DOM interactions

The `Skyline.DataMiner.Utils.UnitTestingFramework.SLNetTypes` package provides `ConnectionMock` for code that sends SLNet messages. For example, you can test DOM interactions in automation scripts or GQI ad hoc data sources by attaching a `DomCache` to the mock. Pass the mock's `HandleMessages` method to a `DomHelper`, then inspect the cache or the results returned by the helper.

The following MSTest example adds a DOM instance to the cache and checks that it can be retrieved through `DomHelper`:

```csharp
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Utils.UnitTestingFramework.SLNetTypes;
using Skyline.DataMiner.Utils.UnitTestingFramework.SLNetTypes.Dom;

[TestClass]
public class DomTests
{
    [TestMethod]
    public void ReadInstances_ExistingInstance_ReturnsInstance()
    {
        // Arrange
        const string moduleId = "TestModule";
        var instanceId = Guid.NewGuid();
        var connection = new ConnectionMock();
        var cache = new DomCache();
        cache.CreateDomModule(moduleId);
        cache.CreateOrUpdateDomInstance(moduleId, new DomInstance { ID = new DomInstanceId(instanceId) });
        cache.AttachTo(connection);
        var helper = new DomHelper(connection.Object.HandleMessages, moduleId);

        // Act
        var instances = helper.DomInstances.Read(DomInstanceExposers.Id.Equal(instanceId));

        // Assert
        Assert.IsTrue(instances.Any(instance => instance.ID.Id == instanceId));
    }
}
```

For other SLNet messages, you can register handlers on `ConnectionMock` to supply the behavior required by your test. Only supported or explicitly configured behavior is simulated.

## Scope

Create a fresh mock for each test and arrange only the data the test needs. UTF mocks implement selected DataMiner interfaces and behavior; they do not reproduce the entire DataMiner runtime. Use integration tests when you need to verify behavior on a running DataMiner System.

For feedback about UTF, contact [The Pioneers](mailto:squad.deploy-the.pioneers@skyline.be).
