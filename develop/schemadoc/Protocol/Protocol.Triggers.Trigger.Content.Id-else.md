---
metadata_version: 1
uid: Protocol.Triggers.Trigger.Content.Id-else
description: "Reference the DataMiner connector protocol schema entry for else attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# else attribute

When a condition has been added to the trigger, the action of which the ID is specified in this attribute will be executed when the condition is not met.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Id](xref:Protocol.Triggers.Trigger.Content.Id)

## Examples

```xml
<Id else="true">1</Id>
```
