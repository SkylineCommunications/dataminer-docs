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
> - Do not include too many groups in one timer.
> - Take polling time into account. Make different timers at different times instead of one fast timer that retrieves everything.
