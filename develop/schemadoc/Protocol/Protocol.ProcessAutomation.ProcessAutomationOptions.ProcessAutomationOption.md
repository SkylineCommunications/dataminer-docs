---
uid: Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption
--

# ProcessAutomationOption Element

The additional option for the Process Automation Queue.

## Parent
[ProcessAutomationOptions](xref:Protocol.ProcessAutomation.ProcessAutomationOptions)

## Attributes
|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[name](xref:Protocol.ProcessAutomation.ProcessAutomationOptions-name)|string|Yes|Name of the option.|
|[pid](xref:Protocol.ProcessAutomation.ProcessAutomationOptions-pid)|[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)|Yes|Parameter ID of the parameter that will contain the option value.|

## Remarks

Currently only QueueSize and QueueSizeMax are supported by the client.

## Examples

```xml
<ProcessAutomation>
	<ProcessAutomationOptions>
		<ProcessAutomationOption name="QueueSize" pid="557"></ProcessAutomationOption>
        <ProcessAutomationOption name="QueueSizeMax" pid="558"></ProcessAutomationOption>
	<ProcessAutomationOptions>
<ProcessAutomation>
