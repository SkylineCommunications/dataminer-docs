---
metadata_version: 1
uid: Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption-name
description: "Learn how the name attribute identifies a Process Automation queue option for clients, such as QueueSize or QueueSizeMax."
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
