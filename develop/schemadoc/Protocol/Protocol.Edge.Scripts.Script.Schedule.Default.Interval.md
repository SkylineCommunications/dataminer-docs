---
uid: Protocol.Edge.Scripts.Script.Schedule.Default.Interval
description: "Use the Interval element in a DataMiner protocol to schedule an Edge script to run repeatedly at a fixed interval."
---

# Interval element

Specifies that the script has to be executed repeatedly, started at a fixed interval.

## Parent

[Default](xref:Protocol.Edge.Scripts.Script.Schedule.Default)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[period](xref:Protocol.Edge.Scripts.Script.Schedule.Default.Interval-period)|[TypePositiveDuration](xref:Protocol-TypePositiveDuration)|Yes|Specifies the interval at which the script has to be executed, expressed as an ISO 8601 duration (e.g., "PT5M" for every 5 minutes).|
