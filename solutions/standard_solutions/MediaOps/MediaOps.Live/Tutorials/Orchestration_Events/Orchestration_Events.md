---
uid: Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents
---

# Creating orchestration events

In this tutorial, you will learn how to create orchestration events in a MediaOps Live context.

Orchestration events are used to trigger actions in an automated and scheduled manner.

Expected duration: 30 minutes

## Prerequisites

- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) is installed on the DMA.

- The [MediaOps Live Demo Package](https://catalog.dataminer.services/details/48d9d327-d21b-49b2-8958-989691cf2012) is installed on the DMA.
  
  > [!NOTE]
  > Install the MediaOps package before installing the MediaOps Demo Package.

- [Visual Studio](https://visualstudio.microsoft.com) is installed on your machine.

- The [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio) extension is installed in Visual Studio.

> [!TIP]
> Before starting the tutorial, confirm that the demo setup is working by going to the Control Surface app and checking if connections can be made between sources and destinations.

## Overview

- [Step 1: Create a new automation script](#step-1-create-a-new-automation-script)
- [Step 2: Add NuGet packages and using statements](#step-2-add-nuget-packages-and-using-statements)
- [Step 3: Create an orchestration event](#step-3-create-an-orchestration-event)
- [Step 4: Publish and run the script](#step-4-publish-and-run-the-script)
- [Step 5: Schedule an orchestration event](#step-5-schedule-an-orchestration-event)
- [Step 6: Add more configuration to the orchestration event](#step-6-add-more-configuration-to-the-orchestration-event)
- [Step 7: Create a script for the orchestration event](#step-7-create-a-script-for-the-orchestration-event)
- [Step 8: Add the script to the orchestration event](#step-8-add-the-script-to-the-orchestration-event)
- [Step 9: Add node configuration to the orchestration event](#step-9-add-node-configuration-to-the-orchestration-event)
- [Step 10: Add connection configuration to the orchestration event](#step-10-add-connection-configuration-to-the-orchestration-event)
- [Step 11: Add level configuration to the connection](#step-11-add-level-configuration-to-the-connection)
- [Step 12: Disconnect a connection](#step-12-disconnect-a-connection)

## Step 1: Create a new automation script

Create a new automation script in Visual Studio, using DIS. For details, refer to the [DIS documentation](xref:Developing_Automation_scripts_as_Visual_Studio_solutions#creating-a-new-script-in-a-solution).

As the name of the script, use `Tutorial-OrchestrationEvents`.

## Step 2: Add NuGet packages and using statements

1. Add the following NuGet packages to your project:

   - `Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Live`
   - `Skyline.DataMiner.Dev.Utils.Solutions.MediaOps.Live.Automation`
   - `Skyline.DataMiner.Dev.Automation`
   - `Skyline.DataMiner.Core.DataMinerSystem.Automation`

1. Add the following `using` statements to your script:

   ```csharp
   using Skyline.DataMiner.Solutions.MediaOps.Live.API;
   using Skyline.DataMiner.Solutions.MediaOps.Live.Automation;
   ```

1. Use the `GetMediaOpsLiveApi` extension method on the `Engine` object to get an instance of the MediaOps Live API in your script.

   ```csharp
   var api = engine.GetMediaOpsLiveApi();
   ```

## Step 3: Create an orchestration event

By using the MediaOps Live API, you can now create orchestration events:

1. Define an orchestration job.

   Orchestration events always have to be defined in the context of an orchestration job, i.e. a group of events that have a shared context. This for example allows you to group events that orchestrate the same element or that are generated from the same source.

   ```csharp
   string jobReference = Guid.NewGuid().ToString();
   OrchestrationJob orchestrationJob = api.Orchestration.GetOrCreateNewOrchestrationJob(jobReference);
   ```

1. Create a basic orchestration event that will be scheduled 10 seconds in the future.

   ```csharp
   OrchestrationEvent orchestrationEvent = new OrchestrationEvent()
   {
       EventState = EventState.Draft,
       EventTime = DateTimeOffset.Now + TimeSpan.FromSeconds(10),
       EventType = EventType.Other,
       Name = "A basic event",
   };
   ```

1. Add the orchestration event to the orchestration job and save it using the API.

   ```csharp
   orchestrationJob.OrchestrationEvents.Add(orchestrationEvent);
   api.Orchestration.SaveOrchestrationJob(orchestrationJob);
   ```

You have now created your first orchestration job, which contains a single event.

## Step 4: Publish and run the script

Publish the script with DIS and run it on the DMA.

Even though the event is correctly saved, at this point nothing will happen yet because the event is saved in the draft state. This means that the API will not schedule the event for execution.

## Step 5: Schedule an orchestration event

1. To schedule the orchestration event for execution, change the event state from `Draft` to `Confirmed`:

   ```csharp
   OrchestrationEvent orchestrationEvent = new OrchestrationEvent()
   {
       EventState = EventState.Confirmed,
       EventTime = DateTimeOffset.Now + TimeSpan.FromSeconds(10),
       EventType = EventType.Other,
       Name = "A basic event",
   };
   ```

1. Publish the updated script to the DMA and run it again.

   The event should now be scheduled for execution in 10 seconds.

1. To verify this, open the Scheduler module in DataMiner Cube and check if a new task is shown for the orchestration event.

   Alternatively, you can also check the information events in the Alarm Console, where a *Scheduled Task Created* log should be visible.

## Step 6: Add more configuration to the orchestration event

At this point, the orchestration event you have created does not yet have any useful fields available to assign execution logic.

To quickly read out the most important information about the event or create a quick template for an event, the `OrchestrationEvent` and `OrchestrationJob` are very useful, but to create actual functional events, the `OrchestrationEventConfiguration` and `OrchestrationJobConfiguration` objects should be used.

Update the script code to use these configuration objects instead:

```csharp
OrchestrationEventConfiguration orchestrationEvent = new OrchestrationEventConfiguration()
{
    EventState = EventState.Confirmed,
    EventTime = DateTimeOffset.Now + TimeSpan.FromSeconds(10),
    EventType = EventType.Other,
    Name = "A basic event",
};

string jobReference = Guid.NewGuid().ToString();
OrchestrationJobConfiguration orchestrationJob = api.Orchestration.GetOrCreateNewOrchestrationJobConfiguration(jobReference);
orchestrationJob.OrchestrationEvents.Add(orchestrationEvent);
api.Orchestration.SaveOrchestrationJobConfiguration(orchestrationJob);
```

## Step 7: Create a script for the orchestration event

One type of action that can be performed by an orchestration event is the execution of an orchestration script.

1. Create a basic orchestration script.

   Like for the first script you made in this tutorial, you can do so using DIS, by adding a second script project.

   Name the script `Tutorial-OrchestrationEvents-DummyScript` and let the script print a log message when executed, by adding the following line in the `RunSafe` method:

   ```csharp
   engine.GenerateInformation($"Dummy script executed.");
   ```

1. Save the script on the DMA.

## Step 8: Add the script to the orchestration event

1. Update the orchestration event to execute this script when the event is triggered:

   ```csharp
   OrchestrationEventConfiguration orchestrationEvent = new OrchestrationEventConfiguration()
   {
       EventState = EventState.Confirmed,
       EventTime = DateTimeOffset.Now + TimeSpan.FromSeconds(10),
       EventType = EventType.Other,
       Name = "A basic event",
       GlobalOrchestrationScript = "Tutorial-OrchestrationEvents-DummyScript",
   };
   ```

1. Publish the updated script to the DMA and run it again.

You should now see that after 10 seconds the dummy script is executed and a log message is shown in the Alarm Console.

## Step 9: Add node configuration to the orchestration event

Instead of executing a global script from the orchestration event, it is also possible to execute scripts on node level. This allows you to assign individual scripts to different resources involved in the orchestration event.

1. Remove the global script from the orchestration event.

   This step is necessary because a **global script gets priority** over node and connection configurations. When a global script is defined, node and connection configurations will not automatically be configured, unless this is done from the orchestration script itself.

1. Add two nodes to the orchestration event.

   Each node has the option to execute a script as well. For this example, add the `Tutorial-OrchestrationEvents-DummyScript` script from the previous step to both nodes.

   ```csharp
   orchestrationEvent.Configuration.NodeConfigurations.Add(new NodeConfiguration
   {
       NodeId = "1",
       NodeLabel = "Label 1",
       OrchestrationScriptName = "Tutorial-OrchestrationEvents-DummyScript",
   });
   orchestrationEvent.Configuration.NodeConfigurations.Add(new NodeConfiguration
   {
       NodeId = "2",
       NodeLabel = "Label 2",
       OrchestrationScriptName = "Tutorial-OrchestrationEvents-DummyScript",
   });
   ```

1. Publish the updated script to the DMA and run it again.

   You should now see that after 10 seconds the dummy script is executed once for each node.

## Step 10: Add connection configuration to the orchestration event

1. Add connection configurations to the orchestration event.

   This will automate the connections that can be done by the Control Surface app in the MediaOps Live solution.

   To define a connection, you need pass the VSG objects that you want to connect. Using the API, you can retrieve the VSGs by their names.

   ```csharp
   VirtualSignalGroup source = api.VirtualSignalGroups.Read(VirtualSignalGroupExposers.Name.Equal("SRC-000001")).FirstOrDefault();
   VirtualSignalGroup destination = api.VirtualSignalGroups.Read(VirtualSignalGroupExposers.Name.Equal("DST-000001")).FirstOrDefault();

   orchestrationEvent.Configuration.Connections.Add(new Connection
   {
       SourceNodeId = "1",
       DestinationNodeId = "2",
       SourceVsg = source,
       DestinationVsg = destination,
   });
   ```

   > [!NOTE]
   > If the VSGs are already connected, feel free to disconnect them in the Control Surface app before running the script. Do note that the connection made by the script will put a lock on the destination, so you will need to unlock it first if that is the case.

1. Publish the updated script to the DMA and run it again.

   You should now see that after 10 seconds a connection will be created between the specified source and destination VSGs.

## Step 11: Add level configuration to the connection

In this step, you will create connections between specific levels of the VSGs, instead of creating a connection between the VSGs themselves that connects all signals between the source and destination VSG. The Demo package comes with four installed levels: Video (0), Audio1 (1), Audio2 (2) and Data (3).

1. Update the connection definition to only connect video and audio levels.

   With the code below, you will also shuffle the audio levels between Audio1 and Audio2.

   ```csharp
   VirtualSignalGroup source = api.VirtualSignalGroups.Read(VirtualSignalGroupExposers.Name.Equal("SRC-000001")).FirstOrDefault();
   VirtualSignalGroup destination = api.VirtualSignalGroups.Read(VirtualSignalGroupExposers.Name.Equal("DST-000001")).FirstOrDefault();

   orchestrationEvent.Configuration.Connections.Add(new Connection
   {
       SourceNodeId = "1",
       DestinationNodeId = "2",
       SourceVsg = source,
       DestinationVsg = destination,
       LevelMappings = new List<LevelMapping>
       {
           new LevelMapping(new Level("Video", 0), new Level("Video", 0)),
           new LevelMapping(new Level("Audio1", 1), new Level("Audio2", 2)),
           new LevelMapping(new Level("Audio2", 2), new Level("Audio1", 1)),
       }
   });
   ```

1. Publish the updated script to the DMA and run it again.

   You should now see that after 10 seconds a connection will be created between the specified source and destination VSGs. Notice how only the video and audio levels are connected, and how the audio levels are shuffled.

## Step 12: Disconnect a connection

In the previous steps, you have only run events with type `Other`. For single events, this is the only option. Other types can be used, but then the job needs both a start (`Start` or `PrerollStart` and `PrerollStop`) and stop (`Stop` or `PostrollStart` and `PostrollStop`) event. By design, start events will trigger a connection, while stop events will disconnect the connection.

With this knowledge, you can now create a job with both a connect and disconnect event.

1. Change the type of the current event to `Start`.

1. Create a new orchestration event, with the same configuration as the existing event, with type `Stop`.

   - Set the start time of the stop event to 20 seconds in the future (10 seconds after the start event).

   - Add both events to the same orchestration job.

   You can copy the following code to achieve this:

   ```csharp
    private void RunSafe(IEngine engine)
   {
       var api = engine.GetMediaOpsLiveApi();

       string jobReference = Guid.NewGuid().ToString();
       OrchestrationJobConfiguration orchestrationJob = api.Orchestration.GetOrCreateNewOrchestrationJobConfiguration(jobReference);

       VirtualSignalGroup source = api.VirtualSignalGroups.Read(VirtualSignalGroupExposers.Name.Equal("SRC-000001")).FirstOrDefault();
       VirtualSignalGroup destination = api.VirtualSignalGroups.Read(VirtualSignalGroupExposers.Name.Equal("DST-000001")).FirstOrDefault();

       orchestrationJob.OrchestrationEvents.Add(CreateOrchestrationEvent(EventType.Start, EventState.Confirmed, DateTimeOffset.Now + TimeSpan.FromSeconds(10), source, destination));
       orchestrationJob.OrchestrationEvents.Add(CreateOrchestrationEvent(EventType.Stop, EventState.Confirmed, DateTimeOffset.Now + TimeSpan.FromSeconds(20), source, destination));
       api.Orchestration.SaveOrchestrationJobConfiguration(orchestrationJob);
   }

   public OrchestrationEventConfiguration CreateOrchestrationEvent(EventType type, EventState state, DateTimeOffset eventTime, VirtualSignalGroup source, VirtualSignalGroup destination)
   {
       OrchestrationEventConfiguration orchestrationEvent = new OrchestrationEventConfiguration()
       {
           EventState = state,
           EventTime = eventTime,
           EventType = type,
           Name = "A basic event",
       };

       orchestrationEvent.Configuration.NodeConfigurations.Add(new NodeConfiguration
       {
           NodeId = "1",
           NodeLabel = "Label 1",
           OrchestrationScriptName = "Tutorial-OrchestrationEvents-DummyScript",
       });
       orchestrationEvent.Configuration.NodeConfigurations.Add(new NodeConfiguration
       {
           NodeId = "2",
           NodeLabel = "Label 2",
           OrchestrationScriptName = "Tutorial-OrchestrationEvents-DummyScript",
       });

       orchestrationEvent.Configuration.Connections.Add(new Connection
       {
           SourceNodeId = "1",
           DestinationNodeId = "2",
           SourceVsg = source,
           DestinationVsg = destination,
           LevelMappings = new List<LevelMapping>
           {
               new LevelMapping(new Level("Video", 0), new Level("Video", 0)),
               new LevelMapping(new Level("Audio1", 1), new Level("Audio2", 2)),
               new LevelMapping(new Level("Audio2", 2), new Level("Audio1", 1)),
           },
       });

       return orchestrationEvent;
   }
   ```

1. Publish the updated script to the DMA and run it again.

   You should now see that after 10 seconds a connection will be created between the specified source and destination VSGs. After another 10 seconds, the connection will be disconnected and the destination VSGs will be unlinked.

> [!TIP]
> In the [SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationEvents](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationEvents) repository on GitHub, you can find the complete script that you can use as a reference.

## Up next

In this tutorial, you have learned how to create orchestration events in MediaOps Live using the MediaOps Live API. You can now continue with the tutorial [Creating orchestration scripts](xref:Tutorial_MediaOpsLive_CreateOrchestrationScripts) to learn how to create more advanced orchestration scripts that can be used in the orchestration events.
