---
metadata_version: 1
uid: Protocol.ProcessAutomation.ProcessAutomationOptions.ProcessAutomationOption-pid
description: "Reference the DataMiner connector protocol schema entry for pid attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# pid attribute

Specifies the parameter ID of the parameter that will contain the option value.

## Content Type

[TypeNonLeadingZeroUnsignedInt](xref:Protocol-TypeNonLeadingZeroUnsignedInt)

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
