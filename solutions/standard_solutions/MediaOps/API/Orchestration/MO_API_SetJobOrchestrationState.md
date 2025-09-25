---
uid: MO_API_SetJobOrchestrationStateAction
---

# SetJobOrchestrationStateAction

Using the `SetJobOrchestrationStateAction` class, you can set the state of specific orchestration events for a job in the MediaOps system. This is particularly useful for tracking the progress and status of various phases in a job's lifecycle, such as preroll and postroll events.

## Example
```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.MediaOps.Common.IOData.Scheduling.Scripts.JobHandler;
using Skyline.DataMiner.Utils.MediaOps.Common.IOData.Scheduling.Scripts.JobHandler.Enums;

public void SetOrchestrationState(IEngine engine) 
{
    var actionData = new SetJobOrchestrationStateAction
    {
	    DomJobId = JobId, // ID of the job you're targeting
	    Event = OrchestrationEvent.PrerollStart,
	    EventState = OrchestrationEventState.Failed,
	    Message = "Unable to configure resources", // Optional message providing context about the state change
    };

	actionData.SendToJobHandler(engine);
}
```