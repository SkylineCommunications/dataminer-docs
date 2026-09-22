---
metadata_version: 1
uid: Protocol.Timers.Timer.Content.Group
description: "Reference the DataMiner connector protocol schema entry for Group element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Group element

Specifies the ID of the group to be included.

## Type

[TypeTimerContentGroup](xref:Protocol-TypeTimerContentGroup)

## Parent

[Content](xref:Protocol.Timers.Timer.Content)

## Examples

```xml
<Group>5</Group>
```

In the following example, the group specified in the column with 0-based index 69 will be executed. Otherwise group 2:

```xml
<Group>col:69:2</Group>
```
