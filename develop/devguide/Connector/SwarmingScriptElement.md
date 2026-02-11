---
uid: SwarmingScriptElement
---

# Configuring a script to swarm elements

> [!TIP]
> See also: [Swarming](xref:Swarming)

## Script with fixed info

As a first step, create a short Automation script that will swarm a fixed element to a fixed destination:

1. [Create a new Automation script](xref:Managing_Automation_scripts#adding-a-new-automation-script)

1. Collect the following information:

   - `[element-key]`: DMA ID/element ID pair for the element you want to swarm. You can find this information in the element properties window in DataMiner Cube.
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
       ElementID element = ElementID.FromString("[element-key]");
       int targetAgentId = [target-agent-id];

       var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection())
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

1. Execute the script to launch a swarming action for the specified element to the specified target host.

### Code parts explained

Below you can find some more information about specific parts of the code in the example script above.

```csharp
using Skyline.DataMiner.Net.Swarming.Helper;
```

This line pulls in the appropriate namespace for the [SwarmingHelper](xref:Skyline.DataMiner.Net.Swarming.Helper.SwarmingHelper) type, which is used further down.

```csharp
var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection())
    .SwarmElement(element)
    .ToAgent(targetAgentId);
```

The lines above communicate with SLNet to request a swarming action for a given element. As part of this action, the element will first be unloaded from the Agent where it was previously hosted and then loaded onto the new host.

```csharp
var swarmingResultForElement = swarmingResults.First();  

if (!swarmingResultForElement.Success)
{
  engine.ExitFail($"Swarming failed: {swarmingResultForElement?.Message}");
}
```

The lines above deal with failures, if any.

## Script with input parameters

In the example below, the script above is updated to use input variables instead of a fixed element and target Agent. This will make the script reusable for all element swarming actions.

1. Add the following two [script input parameters](xref:Script_variables#creating-a-parameter) to the automation script mentioned above:

    - `Element Key`
    - `Target Agent ID`

1. Find the following code lines in the script:

    ```csharp
    ElementID element = ElementID.FromString("[element-key]");
    int targetAgentId = [target-agent-id];
    ```

1. Replace these lines with the following lines:

    ```csharp
    var element = ElementID.FromString(engine.GetScriptParam("Element Key").Value);
    int targetAgentId = Int32.Parse(engine.GetScriptParam("Target Agent ID").Value);
    ```

You now have a script that can be invoked from anywhere, specifying an element and target DataMiner Agent.

The full script C# code should now look like this:

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
    
    var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection())
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
