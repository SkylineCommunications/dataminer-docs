---
uid: Protocol.Timers.Timer
---

# Timer element

Specifies which groups have to be executed, and when.

## Parent

[Timers](xref:Protocol.Timers)

## Attributes

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Type|Required|Description|
|--- |--- |--- |--- |
|[id](xref:Protocol.Timers.Timer-id)|[TypeObjectId](xref:Protocol-TypeObjectId)|Yes|Specifies the unique timer ID.|
|[fixedTimer](xref:Protocol.Timers.Timer-fixedTimer)|[EnumTrueFalse](xref:Protocol-EnumTrueFalse)||If, in case of a relative timer protocol, this attribute is set to "true", the user will not be able to change the interval.|
|[options](xref:Protocol.Timers.Timer-options)|string||Specifies a number of options.|

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Condition](xref:Protocol.Timers.Timer.Condition)|[0, 1]|Specifies a condition that must be met in order for the timer to execute.|
|&nbsp;&nbsp;[Name](xref:Protocol.Timers.Timer.Name)|[0, 1]|Specifies the timer name.|
|&nbsp;&nbsp;[Content](xref:Protocol.Timers.Timer.Content)||Contains all the groups that have to be executed when the timer is triggered.|
|&nbsp;&nbsp;[Interval](xref:Protocol.Timers.Timer.Interval)||Specifies the interval (in milliseconds) between consecutive executions.|
|&nbsp;&nbsp;[Time](xref:Protocol.Timers.Timer.Time)||Specifies how frequently the included groups will be executed.|

## Remarks

It is recommended to define multiple timers. That way, you can separate the important groups (which will be polled more frequently) from the less important groups (which will be polled less frequently).

## Examples

In the following example, QAction 800 is executed for every row in table 800:

```xml
<Timer id="1" fixedTimer="true" options="ip:800,1;each:10000;pollingRate:30,5,5;qaction:800">
```

In the following example, a ping is executed for every row in table 1000 using IP found in columns idx 30:

```xml
<Timer id="4" options="ip:1000,30;each:3600000;pollingRate:15,3,3;threadPool:100;ping:rttColumn=28,timestampColumn=29,size=0,ttl=250,timeout=3000,type=icmp,continueSnmpOnTimeout=false;qactionBefore:14">
```
