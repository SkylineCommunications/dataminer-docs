---
uid: Protocol.Groups.Group.Content.Trigger-next
description: "Use the Trigger next attribute in a DataMiner protocol to set the delay before DataMiner executes the next trigger in a group."
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
