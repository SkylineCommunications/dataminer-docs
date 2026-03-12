---
uid: MediaOpsLive_OrchestrationScript
---

# Orchestration scripts

An orchestration script is any custom script that will be used by orchestration events created in the MediaOps Live Orchestration module. These scripts are used to perform custom actions when an event is triggered, on event level or on node level.

Orchestration scripts need to inherit from the `OrchestrationScript` base class. This abstract base class provides base methods that have no or limited base logic, but that are otherwise fully functional. These methods also allow easy access to data inside the script context. To attach custom logic to any of the methods, the derived class should override these methods.

> [!NOTE]
> The `OrchestrationScript` class is part of the *Skyline.DataMiner.MediaOps.Live* NuGet package.

## GetParameters()

The `GetParameters` method allows the connection handler script to indicate which parameters are required for orchestration. These parameters are an alternative to standard script parameters. By defining the parameters within the script, it is easier to test the script manually, for example, after development or to debug an issue.

Currently, two types of parameters are supported:

- A **profile definition** can be referenced with the name of a profile definition in the DataMiner Profiles module.

  When a definition is added, the script will require a value for each parameter in the definition.

- **Profile parameters** can be added independently from a definition.

  This is also done by referencing the name of a parameter in the DataMiner Profiles module.

```csharp
public override IEnumerable<IOrchestrationParameters> GetParameters()
{
    return new IOrchestrationParameters[]
    {
        new OrchestrationProfileParameter("OrchestrationHelperExample - Bit rate"),
        new OrchestrationProfileDefinition(
            "OrchestrationHelperExample - Test Definition"),
    };
}
```

If necessary, a friendly name can be provided as a second parameter to the constructors of both `OrchestrationProfileParameter` and `OrchestrationProfileDefinition`. The friendly name can then be used in the rest of the orchestration logic and will also be shown when these required parameters are requested from the orchestration API.

```csharp
public override IEnumerable<IOrchestrationParameters> GetParameters()
{
    return new IOrchestrationParameters[]
    {
        new OrchestrationProfileParameter("OrchestrationHelperExample - Bit rate", "Bit Rate"),
        new OrchestrationProfileDefinition(
            "OrchestrationHelperExample - Test Definition",
            new Dictionary<string, string>
            {
                { "OrchestrationHelperExample - RF Symbol Rate", "Symbol Rate" },
                { "OrchestrationHelperExample - RF Roll Off", "Roll Off" },
                { "OrchestrationHelperExample - RF Frequency", "Frequency" },
                { "OrchestrationHelperExample - RF Modulation", "Modulation" },
            }),
    };
}
```

## Orchestrate(IEngine engine)

In the `Orchestrate` method, all orchestration logic can be added. This includes any logic that can be done from a normal Automation script. Additionally, the values provided for the required parameters in the `GetParameters` method can be retrieved.

```csharp
public override void Orchestrate(IEngine engine)
{
    object bitRate = this.GetParameterValue("OrchestrationHelperExample - Bit rate");
    object frequency = this.GetParameterValue("OrchestrationHelperExample - RF Frequency");

    // ...
}
```

In case friendly names were provided in the `GetParameters` method, these friendly names can be used to retrieve the parameter values.

```csharp
public override void Orchestrate(IEngine engine)
{
    object bitRate = this.GetParameterValue("Bit Rate");
    object frequency = this.GetParameterValue("Frequency");

    // Do something with the parameters
}
```

## SetupService(IEngine engine)

During orchestration, a user might want to create a service to monitor a set of elements and/or parameters. The `SetupService` method can be implemented to create a custom service. This method only gets triggered by the starting event of a group of events. There is no fixed manner to create a service; this is fully up to the user. By returning the service ID object of the created service, the orchestration process will attach the service to all linked events.

```csharp
public override DmsServiceId SetupService(IEngine engine)
{
    IDms dms = engine.GetDms();
    IDmsView view = dms.GetView("Orchestration Services");

    IDma dma = dms.GetAgent(123); // Get DMA by Agent ID.

    return dma.CreateService(new ServiceConfiguration(dms, "Example Orchestration Service")
    {
        Views = { view },
    });
}
```

## TearDownService(IEngine engine)

The `TearDownService` method can be implemented to remove the service created with the `SetupService` method. This method only gets triggered by the ending event of a group of events.

> [!NOTE]
> By default, if a service is not removed during an ending event, it will be deleted by the orchestration. This means that it may not be necessary to implement this method, unless custom logic is needed to remove the service.

```csharp
    public override void TearDownService(IEngine engine)
    {
        IDms dms = engine.GetDms();
        if (dms.ServiceExists("Example Orchestration Service"))
        {
            dms.GetService("Example Orchestration Service").Delete();
        }
    }
```

## GetEventMonitoringService()

The `GetEventMonitoringService` method can retrieve the ID of the monitoring service for the event. An empty ID is returned if no service is created for the event.

## GetParameterValue(string paramName)

This method retrieves the value provided for one of the parameters defined in the `GetParameters` method.

## TryGetMetaDataValue(string metadataParam, out string metadataValue)

This method retrieves the value of a metadata parameter that is provided to the script. As metadata parameters are optional, this method returns a boolean indicating whether the parameter was found.

## TryGetNodeConfiguration(string nodeLabel, out NodeConfiguration nodeConfiguration)

This method retrieves the configuration for a specific node in the event.

## OrchestrateNode(NodeConfiguration nodeConfiguration)

As events with global orchestration script do not execute node configuration (script and/or connections), the node configuration can be triggered from the orchestration script via the `OrchestrateNode` method.

## OrchestrateAllConnections()

As events with global orchestration script do not execute node configuration (script and/or connections), connections configured in the event can be triggered from the orchestration script via the `OrchestrateAllConnections` method.
