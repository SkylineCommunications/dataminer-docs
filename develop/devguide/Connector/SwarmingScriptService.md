---
uid: SwarmingScriptService
---

# Configuring a script to swarm services

> [!TIP]
> See also: [Swarming](xref:Swarming)

## Script with fixed info

As a first step, create a short automation script that will swarm a fixed service to a fixed destination:

1. [Create a new automation script](xref:Managing_Automation_scripts#adding-a-new-automation-script)

1. Collect the following information:

   - `[dma-id]`/`[service-id]`: DMA ID/service ID pair for the service you want to swarm. You can find this information in the service properties window in DataMiner Cube.
   - `[target-agent-id]`: ID of the target DMA. You can find this on the *System Center* > *Agents* page.

1. Add a *C# code* block with the contents below, replacing the placeholders with the values from the previous step.

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
       var service = new ServiceID([dma-id], [service-id]);
       int targetAgentId = [target-agent-id];

       var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection())
           .SwarmService(service)
           .ToAgent(targetAgentId);

       var swarmingResultForService = swarmingResults.First();

       if (!swarmingResultForService.Success)
       {
         engine.ExitFail($"Swarming failed: {swarmingResultForService?.Message}");
       }
      }
   }
   ```

1. Execute the script to launch a swarming action for the specified service to the specified target host.

## Swarming multiple services

To swarm multiple services in one call, use the *SwarmServices* method instead, passing an array of *ServiceID* objects:

```csharp
var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection())
    .SwarmServices(services)
    .ToAgent(targetAgentId);
```

### Code parts explained

Below you can find some more information about specific parts of the code in the example script above.

```csharp
using Skyline.DataMiner.Net.Swarming.Helper;
```

This line pulls in the appropriate namespace for the [SwarmingHelper](xref:Skyline.DataMiner.Net.Swarming.Helper.SwarmingHelper) type, which is used further down.

```csharp
var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection())
    .SwarmService(service)
    .ToAgent(targetAgentId);
```

The lines above communicate with SLNet to request a swarming action for a given service.

```csharp
var swarmingResultForService = swarmingResults.First();

if (!swarmingResultForService.Success)
{
  engine.ExitFail($"Swarming failed: {swarmingResultForService?.Message}");
}
```

The lines above deal with failures, if any.
