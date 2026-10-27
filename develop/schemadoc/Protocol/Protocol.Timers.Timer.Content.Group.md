---
uid: Protocol.Timers.Timer.Content.Group
description: "Use the Timer.Content.Group element in a DataMiner protocol to specify the ID of a group to execute when the timer triggers."
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
