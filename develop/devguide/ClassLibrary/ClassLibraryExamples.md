---
uid: ClassLibraryExamples
---

# Examples

## Creating an element

The following example creates a new element and then waits until the element is known in SLNet and the element startup is completed. Finally, it sets parameter 100 of the created element to a value of 20.

```csharp
/// <summary>
/// The QAction entry point.
/// </summary>
/// <param name="slProtocol">Link with SLProtocol process.</param>
public static void Run(SLProtocol slProtocol)
{
    try
    {
        // Get the IDMS interface.
        IDms dms = slProtocol.GetDms();

        // Get the DataMiner Agent on which this element is running.
        IDma agent = dms.GetAgent(slProtocol.DataMinerID);

        DmsElementId id = CreateElement(dms, agent);

        TimeSpan timeout = new TimeSpan(0, 1, 0);
        TimeSpan interval = new TimeSpan(0, 0, 1);

        IDmsElement element = GetElementAfterStartupComplete(slProtocol, dms, id, timeout, interval);

        if (element != null)
        {
            var parameter = element.GetStandaloneParameter<double?>(100);
            parameter.SetValue(20);
        }
        else
        {
            slProtocol.Log("QA" + slProtocol.QActionID + "|Run|Element did not start in the given time frame.", LogType.Error, LogLevel.NoLogging);
        }
    }
    catch (Exception e)
    {
        slProtocol.Log("QA" + slProtocol.QActionID + "|Run|An exception occurred:" + e.ToString(), LogType.Error, LogLevel.NoLogging);
    }
}

private static DmsElementId CreateElement(IDms dms, IDma agent)
{
    IDmsProtocol protocol = dms.GetProtocol("Class Library Example Element", "1.0.0.1");

    ElementConfiguration configuration = new ElementConfiguration(dms, "Example 1", protocol);

    return agent.CreateElement(configuration);
}

private static IDmsElement GetElementAfterStartupComplete(SLProtocol protocol, IDms dms, DmsElementId id, TimeSpan timeout, TimeSpan interval)
{
    if (timeout.TotalMinutes > 5)
    {
        throw new ArgumentException("Timeout too big.", nameof(timeout));
    }

    if (interval.TotalMinutes > 1)
    {
        throw new ArgumentException("Interval too big.", nameof(interval));
    }

    IDmsElement element = null;

    // Wait for the element to be known in SLNet.
    Stopwatch sw = new Stopwatch();
    sw.Start();

    bool elementIsKnownInSLNet = false;

    while (!elementIsKnownInSLNet && sw.Elapsed <= timeout)
    {
        try
        {
            element = dms.GetElement(id);
            elementIsKnownInSLNet = true;
        }
        catch (ElementNotFoundException)
        {
            Thread.Sleep(interval);
        }
    }

    bool elementStartupComplete = false;

    while (!elementStartupComplete && sw.Elapsed <= timeout)
    {
        elementStartupComplete = element.IsStartupComplete();

        if (!elementStartupComplete)
        {
            Thread.Sleep(interval);
        }
    }

    return element;
}
```

## Retrieving a parameter value

The following example retrieves the value of a standalone parameter of another element.

> [!NOTE]
> Using this class library, you can retrieve parameter values, tables, etc. from elements. However, it is important to note that this should only be used for obtaining values from other elements. To perform operations on the local element, it is advised to use the [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) API as this is much more efficient (This is because the operation is then performed in the SLProtocol process immediately).

```csharp
IDms dms = protocol.GetDms();

IDmsElement element = dms.GetElement(new DmsElementId(346, 530006));

IDmsStandaloneParameter<string> parameter = element.GetStandaloneParameter<string>(10);

string value = parameter.GetValue();
```

## Setting a property and renaming the element

The following example performs a rename of an element and also sets a property.

```csharp
IDms dms = protocol.GetDms();

IDmsElement element = dms.GetElement(new DmsElementId(346, 529981));


element.Name = "Renamed Element";

IWritableProperty myProperty = element.Properties["CustomProperty"] as IWritableProperty;


if (myProperty != null)
{
   myProperty.Value = "A";
}
else
{
   // "My Property" is a read-only property.
}

element.Update(); // Apply the changes.
```

The updates are only sent to DataMiner when the Update method is executed. This makes it possible to set multiple properties at once while only one message needs to be sent to DataMiner to apply all changes.

## Verifying whether a DataMiner Agent is running

The following example checks the state of a DataMiner Agent.

```csharp
IDms dms = protocol.GetDms();
IDma agent = dms.GetAgent(346);

AgentState state = agent.State;
```

> [!NOTE]
> It is advised to verify the state of the Agent that hosts the remote element before performing operations on the remote element.

## Creating, updating and retrieving HTTP connections of elements

The following diagram gives an overview of the provided interfaces:

![alt text](../../images/classlibrary1205_1.png "Connections class diagram")

The following example illustrates how to create an element with an HTTP connection:

```csharp
private static void CreateElement(SLProtocol protocol)
{
    IDms dms = protocol.GetDms();
    IDma agent = dms.GetAgent(protocol.DataMinerID);
    
    IDmsProtocol elementProtocol = dms.GetProtocol("MyProtocolName", "1.0.0.1");
    
    ITcp port = new Tcp("127.0.0.1", 8888);
    IHttpConnection myHttpConnection = new HttpConnection(port);
    
    var configuration = new ElementConfiguration(
        dms,
        "MyElementName",
        elementProtocol,
        new List<IElementConnection> { myHttpConnection });
    
    DmsElementId createdElementId = agent.CreateElement(configuration);
}
```

The following example illustrates how to update an HTTP connection of an existing element:

```csharp
private static void SetPort(SLProtocol protocol)
{
    IDms myDms = protocol.GetDms();
    
    var element = myDms.GetElement("myHttpElement");
    
    int portNumber = 8888;
    
    ElementConnectionCollection connections = element.Connections;
    
    // We assume that in this example we know the first connection is the HTTP connection.
    if (connections.Length > 0)
    {
        var httpConnection = connections[0] as IHttpConnection;
        
        if (httpConnection != null)
        {
            var currentPortNumber = httpConnection.TcpConfiguration.RemotePort;
        
            if (currentPortNumber != portNumber)
            {
                httpConnection.TcpConfiguration.RemotePort = portNumber;
            
                // Apply changes.
                element.Update();
            }
        }
    }
}
```

## Creating and deleting properties in a DataMiner System

Support has been added for creating and deleting element, view or service properties in a DataMiner System.

The following example illustrates how to create an element property:

```csharp
IDms dms = protocol.GetDms();

string propertyName = "MyCustomElementProperty";

bool isFileterEnabled = true;
bool isReadOnly = false;
bool isVisibleInSurveyor = true;

int propertyId = dms.CreateProperty(propertyName, PropertyType.Element, isFilterEnabled, isReadOnly, isVisibleInSurveyor);
```

The following example illustrates how to delete a custom property:

```csharp
IDms dms = protocol.GetDms();

var elementProperty = dms.ElementPropertyDefinitions["MyCustomElementProperty"];

dms.DeleteProperty(elementProperty.Id);
```

## Creating a service

The following example illustrates how to create a service:

```csharp
IDms myDms = protocol.GetDms();
var myAgent = myDms.GetAgents().FirstOrDefault();
var myElement = myAgent.GetElement(protocol.ElementName);


string newServiceName = Convert.ToString(protocol.Newservicename_50);
ServiceConfiguration serviceConfig = new ServiceConfiguration(myDms, newServiceName);
List<ElementParamFilterConfiguration> filter = new List<ElementParamFilterConfiguration>();
filter.Add(new ElementParamFilterConfiguration(1, String.Empty, true));

serviceConfig.AddElement(myElement.DmsElementId, filter);
serviceConfig.Views.Add(CreateSdfTestViewIfNotExists(myDms));
var createdServiceId = myAgent.CreateService(serviceConfig);
```

You can also find an example protocol “SLC SDF Services” in the Protocol Development Guide Companion Files.
