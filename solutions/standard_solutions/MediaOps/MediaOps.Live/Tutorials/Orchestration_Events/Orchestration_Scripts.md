---
uid: Tutorial_MediaOpsLive_CreateOrchestrationScripts
---

# Creating orchestration scripts

As the sequel to the tutorial [Creating orchestration events](xref:Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents), this tutorial will show you how to create orchestration scripts that can be used by orchestration events to perform custom actions when the events are triggered.

An orchestration script is a dedicated type of script supporting interaction with the event itself and providing easy access to event data and configuration parameters.

Expected duration: 30 minutes

## Prerequisites

To follow this tutorial, you first need to complete the tutorial [Creating orchestration events](xref:Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents). You will need to have the same prerequisites installed as for that tutorial.

## Overview

- [Step 1: Create a new automation script](#step-1-create-a-new-automation-script)
- [Step 2: Add NuGet packages and using statements](#step-2-add-nuget-packages-and-using-statements)
- [Step 3: Make the script inherit from the orchestration script base class](#step-3-make-the-script-inherit-from-the-orchestrationscript-base-class)
- [Step 4: Implement the Orchestrate and GetParameters methods](#step-4-implement-the-orchestrate-and-getparameters-methods)
- [Step 5: Add the orchestration script to an orchestration event](#step-5-add-the-orchestration-script-to-an-orchestration-event)
- [Step 6: Execute the node configuration from the orchestration script](#step-6-execute-the-node-configuration-from-the-orchestration-script)
- [Step 7: Execute the connections from the orchestration script](#step-7-execute-the-connections-from-the-orchestration-script)
- [Step 8: Pass dynamic metadata to the orchestration script](#step-8-pass-dynamic-metadata-to-the-orchestration-script)
- [Step 9: Generate a service from the orchestration script](#step-9-generate-a-service-from-the-orchestration-script)
- [Step 10: Retrieve and/or delete the linked service](#step-10-retrieve-andor-delete-the-linked-service)

## Step 1: Create a new automation script

Create a new automation script in Visual Studio, using DIS. For details, refer to the [DIS documentation](xref:Developing_Automation_scripts_as_Visual_Studio_solutions#creating-a-new-script-in-a-solution).

Name your script `Tutorial-OrchestrationEvents-DummyOrchestrationScript` and add it in the folder `MediaOps/OrchestrationScripts`. This folder is used by MediaOps Live to identify orchestration scripts.

## Step 2: Add NuGet packages and using statements

1. Add the following NuGet packages to your project:

   - `Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Live`
   - `Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Live.Automation`
   - `Skyline.DataMiner.Dev.Automation`
   - `Skyline.DataMiner.Core.DataMinerSystem.Automation`

1. Add the following `using` statements to your script:

   ```csharp
   using System.Collections.Generic;
   using Skyline.DataMiner.Automation;
   using Skyline.DataMiner.Solutions.MediaOps.Live.API.Objects.Orchestration;
   using Skyline.DataMiner.Solutions.MediaOps.Live.Automation.Orchestration.Script;
   using Skyline.DataMiner.Solutions.MediaOps.Live.Automation.Orchestration.Script.Objects;
   ```

## Step 3: Make the script inherit from the OrchestrationScript base class

Next, you need to make the script inherit from the `OrchestrationScript` base class. The `Run` and `RunSafe` methods are no longer needed, as the base class already implements these, so you can remove them.

The base class will call the appropriate methods that you will implement in the next steps.

```csharp
public class Script : OrchestrationScript
{

}
```

## Step 4: Implement the Orchestrate and GetParameters methods

Now you can implement the required methods in your script. Each serves a different purpose when interacting with the mediation layer. For now, both methods can be left empty.

The `Orchestrate` method will be called when the orchestration event triggers the script. For now, you will start with a simple log message to indicate that the script was executed.

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

1. Go back to the `Tutorial-OrchestrationEvents` script that was created in the previous tutorial.

   Alternatively, you can also retrieve the script from the [SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationEvents](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationEvents) GitHub repository.

1. Update all script references to the newly created orchestration script (from `Tutorial-OrchestrationEvents-DummyScript` to `Tutorial-OrchestrationEvents-DummyOrchestrationScript`) and make sure to [add the orchestration script to the orchestration event as a global script](xref:Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents#step-8-add-the-script-to-the-orchestration-event).

1. Publish and run the event creation script.

   You should see the log message from the orchestration script in the event log when the event is triggered.

   Any other scripts on a node configuration will not print any messages and the connections will not be handled either. Adding a global script has full priority over any other configuration. This means that the node configuration and connections configured in the event will not be handled automatically by a running event. However, these can now be triggered from the orchestration script instead.

## Step 6: Execute the node configuration from the orchestration script

The orchestration script class exposes methods to execute the node configuration and connections configured in the event. These can be called from within the `Orchestrate` method. This allows full control over when and how these configurations are executed.

1. To execute the node configuration, retrieve the configuration for the nodes you want to orchestrate. You can use the `TryGetNodeConfiguration` method for this.

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

1. Save and publish the orchestration script and run the tutorial script that creates the events.

   You will see that the log message is shown twice for the start event and twice for the stop event. The first line is called by the global script execution, while the second line is called by orchestrating the node (with the same script) from that script.

> [!NOTE]
> Node orchestration cannot be called on node level. This prevents infinite loops when a node configuration script would call itself or other nodes.

## Step 7: Execute the connections from the orchestration script

1. Add the `OrchestrateAllConnections` line to the `Orchestrate` method to also execute the connections configured in the event.

   ```csharp
   engine.GenerateInformation("Orchestration script triggered.");

   if (TryGetNodeConfiguration("Label 1", out NodeConfiguration configuration))
   {
       OrchestrateNode(configuration);
   }

   OrchestrateAllConnections();
   ```

1. Save and publish the orchestration script and run the tutorial script that creates the events.

   Next to the log messages from the script being executed, you should also see that the connection defined in the event is now being created.

> [!NOTE]
> Similarly to node orchestration, a connection cannot be called on node level. This prevents the connection from unnecessarily being made multiple times.

## Step 8: Pass dynamic metadata to the orchestration script

To pass data to an orchestration script, usually input parameters are added to the script. This has the disadvantage that you have to provide a value for each parameter for each execution of the script. Additionally, the number of parameters can grow quickly if you want to pass a lot of data. To solve this, orchestration scripts support passing dynamic metadata to the script. You configure this without changing the way the script is called.

1. In the `Tutorial-OrchestrationEvents` script, add a few metadata parameters as input to the orchestration script.

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

1. To retrieve these values inside the orchestration script, add the `TryGetMetadataValue` method to the `Orchestrate` method.

   This method looks for a certain metadata parameter and provides you with the value.

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

1. Save and publish both the orchestration script and the tutorial script and run the tutorial script to create the events.

   Next to the previous logic, you should now see a log message for both the values of metadata 1 and 2. As metadata 3 does not exist as part of the event, there is no log message for that.

## Step 9: Generate a service from the orchestration script

Between events, it could be useful to create a service to monitor certain parameters, related to the connections or nodes that you are configuring. By default, no service is created. Service creation logic needs to be customized in the orchestration script.

1. To create a service that is linked to your event, implement the `SetupService` method.

   This method needs to return the service ID of the created service.

   Within the `SetupService` method, create an empty service with the name `OrchestrationTutorialService` and return the resulting ID.

   ```csharp
   public override DmsServiceId SetupService(IEngine engine)
   {
       IDms dms = engine.GetDms();
       IDma dma = dms.GetAgents().First();
       return dma.CreateService(new ServiceConfiguration(dms, "OrchestrationTutorialService"));
   }
   ```

   > [!IMPORTANT]
   > This method is automatically called by the script for events of type `Start` or `PrerollStart` (usually the first event of a chain of events). This means the method should NOT be called separately in the `Orchestrate` method.

1. Save and publish the orchestration script and run the tutorial script that creates the events.

   You will notice that the service is created during the first event and automatically removed during the last event. By default, the last event of a job context will remove the service that goes with that job. This prevents lingering services that have become unnecessary.

## Step 10: Retrieve and/or delete the linked service

At any point in the script, you can retrieve the currently linked service using the `GetEventMonitoringService` method. This will return the service ID of the service. Any further lookup can be implemented by custom logic from there.

If you do not want the automatic service deletion used in the previous step because a more managed deletion of the event is required, you can use the `TearDownService` method to implement custom deletion of the service.

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
> Implementing the `TearDownService` method does not prevent the default logic that tries to check and/or delete the service afterwards. This ensures that the service is deleted. However, the `TearDownService` method will always execute first to allow the user to refine the deletion process.
>
> This method is **automatically called** by the script for events with `Stop` or `PrerollStop` type (usually the last event of a chain of events). This means the method **should NOT be called separately** in the `Orchestrate` method.

> [!TIP]
> In the [SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationScripts](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationScripts) repository on GitHub, you can find the complete script that you can use as a reference.
