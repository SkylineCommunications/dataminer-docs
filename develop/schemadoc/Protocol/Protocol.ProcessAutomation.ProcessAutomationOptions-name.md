---
uid: Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption-name
---

# name attribute

Specifies the name of the option, which is used by the client to identify it.

## Content Type

string

## Parent

[ProcessAutomationOption](xref:Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption)

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
