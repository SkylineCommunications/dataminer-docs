---
metadata_version: 1
uid: Protocol.Groups.Group.Content.Trigger-next
description: "Reference the DataMiner connector protocol schema entry for next attribute, including its documented structure, attributes, values, and constraints."
---

# next attribute

Specifies the number of milliseconds DataMiner has to wait before executing the next trigger.

## Content Type

unsignedInt

## Parent

[Trigger](xref:Protocol.Groups.Group.Content.Trigger)

## Remarks

If the last item in the group contains this attribute, it will also cause a delay before the next group is executed.

## Examples

```xml
<Trigger next="5000">25</Trigger>
```
