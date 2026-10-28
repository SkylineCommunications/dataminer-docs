---
uid: ClassLibraryExamples
keywords: class library
---

# Examples

## Creating an element

The following example creates a new element and then waits until the element is known in SLNet and the element startup is completed. Finally, it sets parameter 100 of the created element to a value of 20.

```csharp
/// <summary>
/// The QAction entry point.
/// </summary>
/// <param name="protocol">Link with SLProtocol process.</param>
public static void Run(SLProtocol protocol)
{
    try
    {
        // Get the IDMS interface.
        IDms dms = protocol.GetDms();

        // Get the DataMiner Agent on which this element is running.
        IDma agent = dms.GetAgent(protocol.DataMinerID);

        DmsElementId id = CreateElement(dms, agent);

        TimeSpan timeout = new TimeSpan(0, 1, 0);
        TimeSpan interval = new TimeSpan(0, 0, 1);

        IDmsElement element = GetElementAfterStartupComplete(protocol, dms, id, timeout, interval);

        if (element != null)
        {
            var parameter = element.GetStandaloneParameter<double?>(100);
            parameter.SetValue(20);
        }
        else
        {
            protocol.Log($"QA{protocol.QActionID}|Run|Element did not start in the given time frame.", LogType.Error, LogLevel.NoLogging);
        }
    }
    catch (Exception ex)
    {
        protocol.Log($"QA{protocol.QActionID}|{protocol.GetTriggerParameter()}|Run|Exception thrown:{Environment.NewLine}{ex}", LogType.Error, LogLevel.NoLogging);
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

    bool isElementKnownInSLNet = false;
    while (!isElementKnownInSLNet && sw.Elapsed <= timeout)
    {
        try
        {
            element = dms.GetElement(id);
            isElementKnownInSLNet = true;
        }
        catch (ElementNotFoundException)
        {
            Thread.Sleep(interval);
        }
    }

    bool isElementStartupComplete = false;
    while (!isElementStartupComplete && sw.Elapsed <= timeout)
    {
        isElementStartupComplete = element.IsStartupComplete();

        if (!isElementStartupComplete)
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
> Using the DataMinerSystem library, you can retrieve parameter values, tables, etc. from elements. However, it is important to note that this should only be used for obtaining values from other elements. To perform operations on the local element, it is advised to use the [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) API as this is much more efficient (This is because the operation is then performed in the SLProtocol process immediately).

```csharp
IDms dms = protocol.GetDms();

IDmsElement element = dms.GetElement(new DmsElementId(346, 530006));

IDmsStandaloneParameter<string> parameter = element.GetStandaloneParameter<string>(10);

string value = parameter.GetValue();
```

## Verifying whether a DataMiner Agent is running

The following example checks the state of a DataMiner Agent.

```csharp
IDms dms = protocol.GetDms();
IDma agent = dms.GetAgent(346);

AgentState state = agent.State;
```

> [!NOTE]
> It is advised to verify the state of the Agent that hosts the remote element before performing operations on the remote element.

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
var serviceConfig = new ServiceConfiguration(myDms, newServiceName);
var filter = new List<ElementParamFilterConfiguration>();
filter.Add(new ElementParamFilterConfiguration(1, String.Empty, true));

serviceConfig.AddElement(myElement.DmsElementId, filter);
serviceConfig.Views.Add(CreateSdfTestViewIfNotExists(myDms));
var createdServiceId = myAgent.CreateService(serviceConfig);
```

You can also find an example protocol “SLC SDF Services” in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).
