---
uid: Tutorial_MediaOpsLive_CreateOrchestrationScripts
---

# Create orchestration scripts

In this tutorial, we follow up on the [create orchestration events tutorial](xref:Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents) by creating orchestration scripts that can be used by orchestration events.
We learned that scripts can be attached to orchestration events to perform custom actions when the event is triggered.
Orchestration scripts are a dedicated type of script supporting interaction with the event itself and provide easy access to event data and configuration parameters.

Expected duration: 30 minutes

## Prerequisites

- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) installed on the DMA.
- [MediaOps Live Demo Package](https://catalog.dataminer.services/details/48d9d327-d21b-49b2-8958-989691cf2012) installed on the DMA.
- [Visual Studio](https://visualstudio.microsoft.com) installed on your machine.
- [DIS](https://docs.dataminer.services/develop/TOOLS/DIS/Introduction.html) extension installed in Visual Studio.
- Completion of the [create orchestration events tutorial](xref:Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents) tutorial.

## Overview

- [Step 1: Create a new automation script](#step-1-create-a-new-automation-script)
- [Step 2: Add NuGet packages and using statements](#step-2-add-nuget-packages-and-using-statements)
- [Step 3: Inherit from the orchestration script base class](#step-3-inherit-from-the-orchestrationscript-base-class)
- [Step 4: Implement the Orchestrate and GetParameters methods](#step-4-implement-orchestrate-and-getparameters)
- [Step 5: Add the orchestration script to an orchestration event](#step-5-add-the-orchestration-script-to-an-orchestration-event)
- [Step 6: Execute the node configuration from the orchestration script](#step-6-execute-node-configuration-from-the-orchestration-script)
- [Step 7: Execute the connections from the orchestration script](#step-7-execute-connections-from-the-orchestration-script)
- [Step 8: Pass dynamic metadata to the orchestration script](#step-8-pass-dynamic-metadata-to-the-orchestration-script)
- [Step 9: Generate a DMA service from the orchestration script](#step-9-generate-a-service-from-the-orchestration-script)
- [Step 10: Retrieve and/or delete the linked service](#step-10-retrieve-andor-delete-the-linked-service)

## Step 1: Create a new automation script

Create a new automation script in Visual Studio, using DIS. You can follow the steps in the [DIS documentation](https://docs.dataminer.services/develop/TOOLS/DIS/Developing/Developing_Automation_scripts_as_Visual_Studio_solutions.html#creating-a-new-script-in-a-solution) to create a new automation script.

Make sure to configured folder for the script is 'MediaOps/OrchestrationScripts'. This folder is used by MediaOps Live to identify orchestration scripts.

For this tutorial, we will use the name `Tutorial-OrchestrationEvents-DummyOrchestrationScript` for the script.

## Step 2: Add NuGet packages and using statements

Add the following NuGet packages to your project:

- `Skyline.DataMiner.MediaOps.Live`
- `Skyline.DataMiner.MediaOps.Live.Automation`
- `Skyline.DataMiner.Dev.Automation`
- `Skyline.DataMiner.Core.DataMinerSystem.Automation`

Now you can add the following using statements to your script:

```csharp
using System.Collections.Generic;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.MediaOps.Live.API.Objects.Orchestration;
using Skyline.DataMiner.MediaOps.Live.Automation.Orchestration.Script;
using Skyline.DataMiner.MediaOps.Live.Automation.Orchestration.Script.Objects;
```

## Step 3: Inherit from the OrchestrationScript base class

Let the script inherit from the `OrchestrationScript` base class. The `Run` and `RunSafe` method are not needed anymore, as the base class already implements it, so you can remove it.
The base class will call the appropriate methods that you will implement in the next steps.

```csharp
public class Script : OrchestrationScript
{

}
```

## Step 4: Implement `Orchestrate` and `GetParameters`

Now you can implement the required methods in your script. Each serves a different purpose when interacting with the mediation layer.
For now, both methods can be left empty.

The `Orchestrate` method is called when the orchestration event triggers the script.
For now, we will start with a simple log message to indicate that the script was executed.

The `GetParameters` method can return an empty array for now.

```csharp
public override void Orchestrate(IEngine engine)
{
    engine.GenerateInformation("Orchestration script triggered.");
}

public override IEnumerable<IOrchestrationParameters> GetParameters()
{
    return new IOrchestrationParameters[]
    {
    };
}
```

The script is now valid and can be published to the DataMiner System.

## Step 5: Add the orchestration script to an orchestration event

Go back to the `Tutorial-OrchestrationEvents` script that was created in the previous tutorial.
The script can also be retrieved from the following [GitHub repository](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationEvents).

Update all script references to the newly created orchestration script (from `Tutorial-OrchestrationEvents-DummyScript` to `Tutorial-OrchestrationEvents-DummyOrchestrationScript`)
and make sure to [add the orchestration script to the orchestration event as a global script](xref:Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents#step-8-add-the-script-to-the-orchestration-event).

You can now publish and run the event creation script.

You should see the log message from the orchestration script in the event log when the event is triggered.
Any other scripts on a node configuration will not print any messages and the connections will not be handled as well.

As explained in the previous tutorial, adding a global script has full priority over any other configuration.
This means the node configuration and connections configured in the event will not be handled automatically by a running event.

However, these can now be triggered from the orchestration script instead.

## Step 6: Execute node configuration from the orchestration script

The orchestration script class exposes methods to execute the node configuration and connections configured in the event.
These can be called from within the `Orchestrate` method. This allows full control over when and how these configurations are executed.

To execute the node configuration, you first need to retrieve the configuration for the node(s) you want to orchestrate.
To do this, you can use the `TryGetNodeConfiguration` method.
After that, the `OrchestrateNode` method can be used to execute the configuration.

```csharp
public override void Orchestrate(IEngine engine)
{
    engine.GenerateInformation("Orchestration script triggered.");

    if (TryGetNodeConfiguration("Label 1", out NodeConfiguration configuration))
    {
        OrchestrateNode(configuration);
    }
}
```

Save and publish the orchestration script and run the tutorial script that creates the events.

> [!NOTE]
> A node orchestration cannot be called on node level.
> This prevents infinite loops when a node configuration script would call itself or other nodes.

Notice how the log message is shown twice for the start event and twice for the stop event.
The first line is called by the global script execution, while the second line is done by orchestrating the node (with the same script) from that script.

## Step 7: Execute connections from the orchestration script

Add the `OrchestrateAllConnections` line to the `Orchestrate` method to also execute the connections configured in the event.

```csharp
engine.GenerateInformation("Orchestration script triggered.");

if (TryGetNodeConfiguration("Label 1", out NodeConfiguration configuration))
{
    OrchestrateNode(configuration);
}

OrchestrateAllConnections();
```

> [!NOTE]
> Similarly to node orchestration, a connection can not be called on node level.
> This prevents the connection from being made multiple times, which is not needed.

Save and publish the orchestration script and run the tutorial script that creates the events.

Next to the log messages from the script being executed, you should also see that the connection defined in the event is now being created.

## Step 8: Pass dynamic metadata to the orchestration script

When passing data to an orchestration script, usually we add input parameters to the script.

A big drawback of this is that you have to provide a value for each parameter, for each execution of the script.
Additionally, the amount of parameters can grow quickly if you want to pass a lot of data.

To solve this, orchestration scripts support dynamic metadata that can be passed to the script.
This is done without changing the way the script is called.

In the `Tutorial-OrchestrationEvents` script, add a few metadata parameters as input to the orchestration script.

```csharp
OrchestrationEventConfiguration orchestrationEvent = new OrchestrationEventConfiguration()
{
    EventState = state,
    EventTime = eventTime,
    EventType = type,
    Name = "A basic event",
    GlobalOrchestrationScript = "Tutorial-OrchestrationEvents-DummyOrchestrationScript",
    GlobalOrchestrationScriptArguments = new List<OrchestrationScriptArgument>
    {
        new OrchestrationScriptArgument(OrchestrationScriptArgumentType.Metadata, "Metadata 1", "Value 1"),
        new OrchestrationScriptArgument(OrchestrationScriptArgumentType.Metadata, "Metadata 2", "Value 2"),
    },
};
```

To retrieve these values inside the orchestration script, add the `TryGetMetadataValue` method to the `Orchestrate` method. This method looks for a certain metadata parameter and provides you with the value.
Add this method for both parameters that were added to the event. Also add a metadata lookup for an non-existing metadata object.

```csharp
engine.GenerateInformation("Orchestration script triggered.");

if (TryGetNodeConfiguration("Label 1", out NodeConfiguration configuration))
{
    OrchestrateNode(configuration);
}

OrchestrateAllConnections();

if (TryGetMetadataValue("Metadata 1", out string value1))
{
    engine.GenerateInformation($"Value for metadata 1 is { value1 }");
}

if (TryGetMetadataValue("Metadata 2", out string value2))
{
    engine.GenerateInformation($"Value for metadata 2 is { value2 }");
}

if (TryGetMetadataValue("Metadata 3", out string value3))
{
    engine.GenerateInformation($"Value for metadata 3 is { value3 }");
}
```

Save and publish both the orchestration script and the tutorial script and run the tutorial script to create the events.
Next to the previous logic, you should now see a log message for both the values of metadata 1 and 2.
Since metadata 3 does not exist as part of the event, there is no log message for that.

## Step 9: Generate a service from the orchestration script

In the duration between events, it could be very useful to create a service to monitor certain parameters,
related to the connections or nodes that you are configuring.

By default, no service is created. Service creation logic needs to be customized in the orchestration script.
To create a service that's linked to you event, the `SetupService` method needs to be implemented.
This method needs to return the service ID of the created service.
Inside the `SetupService` method, create an empty service with the name `OrchestrationTutorialService` an return the resulting ID.

```csharp
public override DmsServiceId SetupService(IEngine engine)
{
    IDms dms = engine.GetDms();
    IDma dma = dms.GetAgents().First();
    return dma.CreateService(new ServiceConfiguration(dms, "OrchestrationTutorialService"));
}
```

> [!IMPORTANT]
> This method is automatically called by the script for events with `Start` or `PrerollStart` type (usually the first event of a chain of events).
> This means the method should NOT be called separately in the `Orchestrate` method.

Save and publish the orchestration script and run the tutorial script that creates the events.

Notice how the service is created during the first event.
You should also see that the service is automatically removed during the last event.
By default, the last event of a job context will remove the service that goes with that job.
This is to prevent leftover services from existing.

## Step 10: Retrieve and/or delete the linked service

At any point in the script, the currently linked service can be retrieved by the `GetEventMonitoringService` method.
This will return the service ID of the service. Any further lookup can be implemented by custom logic from there.

Contrarily to the previous step, which had automatic service deletion, if there is a need for a more managed deletion of the event, the `TearDownService` method can be used.
By using this method, custom deletion of the service can be implemented.

```csharp
public override void TearDownService(IEngine engine)
{
    engine.GenerateInformation("Delete orchestration service");
    var serviceId = GetEventMonitoringService();

    IDms dms = engine.GetDms();
    IDmsService service = dms.GetService(serviceId);
    service.Delete();
    engine.GenerateInformation("Orchestration service deleted");
}
```

> [!NOTE]
> Implementing the `TearDownService` method does not prevent the default logic that tries to check and/or delete the service afterwards.
> This is to make sure the service is deleted.
> However, the `TearDownService` method will always execute first to allow the user to refine the deletion process.

> [!IMPORTANT]
> This method is automatically called by the script for events with `Stop` or `PrerollStop` type (usually the last event of a chain of events).
> This means the method should NOT be called separately in the `Orchestrate` method.

## Final script

The following [repository on GitHub](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationScripts) contains the complete script that you can use as a reference.
