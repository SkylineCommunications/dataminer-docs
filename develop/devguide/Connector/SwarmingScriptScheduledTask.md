---
uid: SwarmingScriptScheduledTask
---

# Configuring a script to swarm scheduled tasks

If scheduled tasks are stored in the database ([Scheduler data storage](xref:SchedulerDataStorage)), you can use an Automation script to initiate the swarming process.

In this script, create a *SwarmingHelper* using the new hosting Agent ID along with the Scheduled Task IDs.

This can be done as follows:

```csharp
using System;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Swarming.Helper;

public class Script
{
    public void Run(Engine engine)
    {
        var newHostingAgent = 123;

        var scheduledTaskIds = new List<ScheduledTaskID>
        {
            // HostingDmaId, TaskId
            new ScheduledTaskID(..., ...),
            new ScheduledTaskID(..., ...),
        };

        var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection()).SwarmScheduledTasks(scheduledTaskIds.ToArray()).ToAgent(newHostingAgent);

        if (swarmingResults == null)
        {
            engine.ExitFail("Swarming failed: result was null");
        }

        // There should be a result for each scheduled task.
        if (swarmingResults.Length != scheduledTaskIds.Count)
        {
            var sentIds = string.Join(", ", scheduledTaskIds
                    .OrderBy(t => t.DmaId)
                    .ThenBy(t => t.TaskId)
                    .Select(t => $"{t.DmaId}/{t.TaskId}"));


            // 'ToString' of a SwarmingResult will contain the ID of the object, the message and whether swarming succeeded for the object or not.
            var results = string.Join(", ", swarmingResults.Select(s => s.ToString()));

            engine.ExitFail($"Did not receive enough swarming responses. Requested to swarm {scheduledTaskIds.Count} scheduled tasks, but got {swarmingResults.Length} responses.{Environment.NewLine}" +
                            $"Sent ids: {sentIds}{Environment.NewLine}Results: {results}");
        }

        var unsuccessfulResults = swarmingResults.Where(s => !s.Success).ToList();
        if (unsuccessfulResults.Count > 0)
        {
            var failedScheduledTasks = string.Join(", ", unsuccessfulResults.Select(s => s.ToString()));
            engine.ExitFail($"Failed to swarm some scheduled tasks. Failed results: {failedScheduledTasks}");
        }
    }
}
```

> [!NOTE]
>
> - To swarm a scheduled task, the new hosting Agent must be up and running. In case the current hosting Agent is unreachable, swarming will still take place, but an error will be logged in the *SLScheduler* log file.
> - To be able to trigger swarming for a scheduled task, you need the [Swarming](xref:DataMiner_user_permissions#modules--swarming) user permission.
