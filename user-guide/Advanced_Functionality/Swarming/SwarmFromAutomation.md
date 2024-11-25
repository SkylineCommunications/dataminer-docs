---
uid: TutorialSwarmingFromAutomation
---
# Tutorial: Swarm an element from Automation

This tutorial lesson demonstrates how you can create an automation script that can swarm an element from one agent to another.

## Prerequisites

- A system with [Swarming enabled](xref:SwarmingEnable)

## Overview

- [Step 1: Script with fixed info](#step-1-script-with-fixed-info)
- [Step 2: Updated script with input parameters](#step-2-updated-script-with-input-parameters)

## Step 1: Script with fixed info

As a fist step, you will create a short automation script that will swarm a fixed element to a fixed destination:

1. [Create a new automation script](xref:Managing_Automation_scripts#adding-a-new-automation-script)

1. Collect the following information

   - `[element-key]`: dmaid/eid pair for the element you want to swarm. You can find this information in the element properties window in DataMiner Cube.
   - `[target-agent-id]`: ID of the target agent. Can be found on the *System Center > Agents* page.

1. Add a *C# code* block with the contents below, filling out the placeholders with the collected values from above.

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
    ElementID element = ElementID.FromString("[element-key]");
    int targetAgentId = [target-agent-id];

    var swarmingResults = SwarmingHelper.Create(Engine.SLNetRaw)
        .SwarmElement(element)
        .ToAgent(targetAgentId);

    var swarmingResultForElement = swarmingResults.First();  

    if (!swarmingResultForElement.Success)
    {
      engine.ExitFail($"Swarming failed: {swarmingResultForElement?.Message}");
    }
   }
}
```

When executed, this script will launch a swarming action for the specified element to the specified target host.

### Code parts explained

```csharp
using Skyline.DataMiner.Net.Swarming.Helper;
```

This line pulls in the appropriate namespace for the `SwarmingHelper` type which is used further down.

```csharp
var swarmingResults = SwarmingHelper.Create(Engine.SLNetRaw)
    .SwarmElement(element)
    .ToAgent(targetAgentId);
```

The lines above communicates with SLNet to request a swarm action to be launched for a given element. As part of this action, the element will first be unloaded on the agent where the element was previously hosted and then loaded on the new host.

```csharp
var swarmingResultForElement = swarmingResults.First();  

if (!swarmingResultForElement.Success)
{
  engine.ExitFail($"Swarming failed: {swarmingResultForElement?.Message}");
}
```

The lines above deal with failures, if any.

## Step 2: Updated script with input parameters

You will now be extending the script above to use input variables instead of specifying a fixed element and target agent. This will make the script re-usable for all element swarm actions.

1. Add two [script input parameters](xref:Script_variables#creating-a-parameter) to the Automation script created in the previous step.

    - One named `Element Key`

    - One named `Target Agent ID`

1. Find the following code lines in your script

    ```csharp
    ElementID element = ElementID.FromString("[element-key]");
    int targetAgentId = [target-agent-id];
    ```

    and replace these by

    ```csharp
    var element = ElementID.FromString(engine.GetScriptParam("Element Key").Value);
    int targetAgentId = Int32.Parse(engine.GetScriptParam("Target Agent ID").Value);
    ```

You now have a script that can be invoked from anywhere, specifying an element and target DataMiner Agent.

The full script C# code now looks like this:

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
    var element = ElementID.FromString(engine.GetScriptParam("Element Key").Value);
    int targetAgentId = Int32.Parse(engine.GetScriptParam("Target Agent ID").Value);
    
    var swarmingResults = SwarmingHelper.Create(Engine.SLNetRaw)
        .SwarmElement(element)
        .ToAgent(targetAgentId);

    var swarmingResultForElement = swarmingResults.First();  

    if (!swarmingResultForElement.Success)
    {
      engine.ExitFail($"Swarming failed: {swarmingResultForElement?.Message}");
    }
  }
}
```

## Next steps

Now that you have an automation script that can swarm an element, this script can be referenced from other locations in DataMiner to create experiences.
