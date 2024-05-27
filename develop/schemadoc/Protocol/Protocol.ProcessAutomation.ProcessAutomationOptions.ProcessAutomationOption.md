---
uid: Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption
---

# ProcessAutomationOption element

The additional option for the Process Automation queue.

## Parent

[ProcessAutomationOptions](xref:Protocol.ProcessAutomation.ProcessAutomationOptions)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[name](xref:Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption-name)|string|Yes|Name of the option.|
|[pid](xref:Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption-pid)|[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)|Yes|Parameter ID of the parameter that will contain the option value.|

## Remarks

Currently, only the names QueueSize and QueueSizeMax are supported by the client.

## Examples

```xml
<ProcessAutomation>
   <ProcessAutomationOptions>
      <ProcessAutomationOption name="QueueSize" pid="557"></ProcessAutomationOption>
      <ProcessAutomationOption name="QueueSizeMax" pid="558"></ProcessAutomationOption>
   <ProcessAutomationOptions>
<ProcessAutomation>
```
