---
uid: Protocol.Timers
---

# Timers element

Contains all timers defined in the protocol.

## Parent

[Protocol](xref:Protocol)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[relativeTimers](xref:Protocol.Timers-relativeTimers)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If this is set to *true*, then none of the timers defined under this tag are considered fixed (unless a timer has its fixedTimer attribute set to *true*).|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Timer](xref:Protocol.Timers.Timer)|[0, *]|Specifies which groups have to be executed, and when.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of a timer must be unique. |Timer |@id |
|Unique |The name of a timer must be unique. |Timer |dis:Name |

## Remarks

Timers are used to configure recurring events (group execution, device polling, etc.). Basically, a timer defines the interval between two consecutive executions of a given event.

By default, the interval specified in a timer is a fixed interval. However, in the protocol, you can make the interval dynamic.

The interval can be modified by changing the value of the [Timer base] Parameter (ID: 65017). The value of this parameter is the factor by which the interval time is multiplied. So “1” means the original interval, “2” means twice as slow, “0.5” means twice as fast, etc.
