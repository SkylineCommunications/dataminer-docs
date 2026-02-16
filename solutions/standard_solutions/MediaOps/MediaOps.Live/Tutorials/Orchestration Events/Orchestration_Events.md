---
uid: Tutorial_MediaOpsLive_Tutorial_IPMatrix_CreateOrchestrationEvents
---

# Create orchestration events

In this tutorial, you will learn how to create orchestration events in a MediaOps Live context.
Orchestration events are used to trigger actions in an automated and scheduled manner.

Expected duration: 30 minutes

## Prerequisites

- [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) installed on the DMA.
- [MediaOps Live Demo Package](https://catalog.dataminer.services/details/48d9d327-d21b-49b2-8958-989691cf2012) installed on the DMA.
- [Visual Studio](https://visualstudio.microsoft.com) installed on your machine.
- [DIS](https://docs.dataminer.services/develop/TOOLS/DIS/Introduction.html) extension installed in Visual Studio.

> [!NOTE]
> Install the MediaOps package before installing the MediaOps Demo Package.

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

Create a new automation script in Visual Studio, using DIS.
You can follow the steps in the [DIS documentation](https://docs.dataminer.services/develop/TOOLS/DIS/Developing/Developing_Automation_scripts_as_Visual_Studio_solutions.html#creating-a-new-script-in-a-solution) to create a new automation script.

For the name of the script, we will use `Tutorial-OrchestrationEvents`.

## Step 2: Add NuGet packages and using statements

Add the following NuGet packages to your project:

- `Skyline.DataMiner.MediaOps.Live`
- `Skyline.DataMiner.MediaOps.Live.Automation`
- `Skyline.DataMiner.Dev.Automation`
- `Skyline.DataMiner.Core.DataMinerSystem.Automation`

Now you can add the following using statements to your script:

```csharp
using Skyline.DataMiner.MediaOps.Live.API;
using Skyline.DataMiner.MediaOps.Live.Automation;
```

First, you need to get an instance of the MediaOps Live API in your script.
You can do this by using the `GetMediaOpsLiveApi` extension method on the `Engine` object.

```csharp
var api = engine.GetMediaOpsLiveApi();
```

## Step 3: Create an orchestration event

By using the MediaOps Live API, you can now create orchestration events.

First, orchestration event can only be defined in context of an orchestration job. An orchestration job is a group of events that have a shared context.
This can be useful for e.g. grouping events that orchestrate the same element or are generated from the same source.

```csharp
string jobReference = Guid.NewGuid().ToString();
OrchestrationJob orchestrationJob = api.Orchestration.GetOrCreateNewOrchestrationJob(jobReference);
```

Next, we create a basic orchestration event that will be scheduled 10 seconds in the future.

```csharp
OrchestrationEvent orchestrationEvent = new OrchestrationEvent()
{
    EventState = EventState.Draft,
    EventTime = DateTimeOffset.Now + TimeSpan.FromSeconds(10),
    EventType = EventType.Other,
    Name = "A basic event",
};
```

Finally, we add the orchestration event to the orchestration job and save it using the API.

```csharp
orchestrationJob.OrchestrationEvents.Add(orchestrationEvent);
api.Orchestration.SaveOrchestrationJob(orchestrationJob);
```

We now created our first orchestration job, which contains a single event.

## Step 4: Publish and run the script

Publish the script with DIS and run it on the DMA.
Even though the event is correctly save, nothing will happen yet since the event is saved in draft state.
This means the API will not schedule the event for execution.

## Step 5: Schedule an orchestration event

To schedule the orchestration event for execution, we need to change the event state from `Draft` to `Confirmed`.

```csharp
OrchestrationEvent orchestrationEvent = new OrchestrationEvent()
{
    EventState = EventState.Confirmed,
    EventTime = DateTimeOffset.Now + TimeSpan.FromSeconds(10),
    EventType = EventType.Other,
    Name = "A basic event",
};
```

Publish the updated script to the DMA and run it again.
The event should now be scheduled for execution in 10 seconds.
This can be confirmed by taking a look on the DataMiner Scheduler module, where a new task should have appeared for the orchestration event.
The creation of the task can also be seen in the information events on the DMA Alarm Console, where a 'Scheduled Task Created' log should be visible.

## Step 6: Add more configuration to the orchestration event

As you may have noticed, the orchestration event we created does not have any useful fields available to assign any execution logic.
The `OrchestrationEvent` and `OrchestrationJob` are very useful to quickly read out the most important information about the event, or create a quick template for an event,
but to create actual functional events, the `OrchestrationEventConfiguration` and `OrchestrationJobConfiguration` objects should be used.

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

Start by creating a very basic orchestration script. Just like this tutorial, you can use DIS for this (by adding a second script project).
Name the script `Tutorial-OrchestrationEvents-DummyScript` and let the script print a log message when executed, by adding the following line in the `RunSafe` method:

```csharp
engine.GenerateInformation($"Dummy script executed.");
```

Make sure to save the script on the DMA.

## Step 8: Add the script to the orchestration event

Now, we can update the orchestration event to execute this script when the event is triggered.

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

Publish the updated script to the DMA and run it again.
You should now see that after 10 seconds, the dummy script is executed and a log message is printed on the DMA Alarm Console.

## Step 9: Add node configuration to the orchestration event

The scripts that we executed from the orchestration event can also be executed on a node level.
This way, we can assign individual scripts to different resources that are involved in the orchestration event.

First, remove the global script from the orchestration event.

> [!IMPORTANT]
> A global script has priority over node and connection configurations.
> When a global script is defined, node and connection configurations will not automatically be configured, unless when done from the orchestration script itself.

To start, add two nodes to the orchestration event. Each node has the option to execute a script as well.
For this example, add the `Tutorial-OrchestrationEvents-DummyScript` script from the previous step to both nodes.

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

Publish the updated script to the DMA and run it again.
You should now see that after 10 seconds, the dummy script is executed once for each node.

## Step 10: Add connection configuration to the orchestration event

Finally, we can add connection configurations to the orchestration event as well.
This will automate the connections that can be done by the Control Surface app in the MediaOps.LIVE solution.

To define the connection, we need pass the VSG objects that we want to connect.
Using the API, we can retrieve the VSGs by their names.

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
> If the VSG's are already connected, feel free to disconnect them in the Control Surface app, before running the script.
> Do note that the connection made by the script will put a lock on the VSG, so you'll need to unlock it first if that is the case.

Publish the updated script to the DMA and run it again.
You should now see that after 10 seconds, a connection will be created between the specified source and destination VSGs.

## Step 11: Add level configuration to the connection

Instead of just creating a connection between two VSGs (which connects all signals between the source and destination VSG),
we can also connect specific levels between the VSGs.

The Demo package comes with 4 installed levels:
Video (0), Audio1 (1), Audio2 (2) and Data (3).

We can now update the connection definition to only connection video and audio levels.
Additionally, we will shuffle the audio levels between Audio1 and Audio2.

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

Publish the updated script to the DMA and run it again.
You should now see that after 10 seconds, a connection will be created between the specified source and destination VSGs.
Notice how only the video and audio levels are connected, and how the audio levels are shuffled.

## Step 12: Disconnect a connection

Until now, we only ran events with type `Other`. For single events, this is the only option.
Other types can be used, but then the job needs both a start (`Start`, `PrerollStart` + `PrerollStop`) and stop (`Stop` or `PostrollStart` + `PostrollStop`) event.

By design, start event will trigger a connection, while a stop event will disconnect the connection.

With this knowledge, we can now create a job with both a connect and disconnect event.

1. Change the type of the current event to `Start`.
1. Create a new orchestration event, with the same configuration as the existing event, with type `Stop`.
Set the start time of the stop event to 20 seconds in the future (10 seconds after the start event).
1. Add both events to the same orchestration job.

The following code can be copied to achieve this:

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

Publish the updated script to the DMA and run it again.
You should now see that after 10 seconds, a connection will be created between the specified source and destination VSGs.
After another 10 seconds, the connection will be disconnected and the destination VSG's will be unlinked.

## Final script

The following [repository on GitHub](https://github.com/SkylineCommunications/SLC-AS-MediaOps.LIVE-Tutorial-OrchestrationEvents) contains the complete script that you can use as a reference:

## Up next

In this tutorial, you have learned how to create orchestration events in MediaOps.LIVE using the MediaOps Live API.
You can now continue with the [Create Orchestration Scripts tutorial](xref:Tutorial_MediaOpsLive_CreateOrchestrationScripts) to learn how to create more advanced orchestration scripts that can be used in the orchestration events.
