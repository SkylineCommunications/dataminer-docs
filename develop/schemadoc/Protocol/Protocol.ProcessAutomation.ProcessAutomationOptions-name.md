---
metadata_version: 1
uid: Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption-name
description: "Reference the DataMiner connector protocol schema entry for name attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# name attribute

Specifies the name of the option, which is used by the client to identify it.

## Content Type

[ProcessAutomationOptionName](xref:Protocol-TypeProcessAutomationOptionName)

## Parent

[ProcessAutomationOption](xref:Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption)

## Examples

```xml
<ProcessAutomation>
   <ProcessAutomationOptions>
      <ProcessAutomationOption name="QueueSize" pid="557"></ProcessAutomationOption>
      <ProcessAutomationOption name="QueueSizeMax" pid="558"></ProcessAutomationOption>
   <ProcessAutomationOptions>
<ProcessAutomation>
```
