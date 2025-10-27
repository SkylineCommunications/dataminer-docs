---
uid: Protocol.Timers.Timer.Content
---

# Content element

Contains all the groups that have to be executed when the timer is triggered.

## Parent

[Timer](xref:Protocol.Timers.Timer)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Group](xref:Protocol.Timers.Timer.Content.Group)|[0, *]|Specifies the ID of the group to be included.|

## Remarks

> [!IMPORTANT]
> Make sure the content of a timer can realistically be fully executed within the defined [Group/Time](xref:Protocol.Timers.Timer.Time). Aside from this, there is not really any limit regarding the number of groups that can be included within a timer. On the contrary, each timer you add results in the creation of an extra thread, causing higher resource consumption. This means that it is better to have few timers with plenty of groups than many timers with few groups. Typically, new timers should only be created when different timings are required (see [Group/Time tag](xref:Protocol.Timers.Timer.Time)).
