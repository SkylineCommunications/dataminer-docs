---
metadata_version: 1
uid: Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption
description: "Reference the DataMiner connector protocol schema entry for ProcessAutomationOption element, including its documented structure, attributes, values, and c."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
