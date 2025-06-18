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
>
> - There is not really any limit regarding the number of groups that can be included within a timer (other than the below remark). On the contrary, each timer you add results in an extra thread to be created causing higher resource consumption. So it is better to have few timers with plenty of groups than many timers with few groups. In fact, we should typically only create new timers when we actualy require different timings (See [Group/Time tag](xref:Protocol.Timers.Timer.Time)).
> - Make sure the content of a timer can realistically be fully executed within the defined [Group/Time](xref:Protocol.Timers.Timer.Time).
