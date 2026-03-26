---
uid: Protocol.SeverityBubbleUp
---

# SeverityBubbleUp element

Passes alarm severities to linked tables.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Path](xref:Protocol.SeverityBubbleUp.Path)|[0, *]|Specifies the table path that needs to be followed when passing alarm severities.|

## Remarks

> [!NOTE]
> From DataMiner 10.0.6 (RN 25349) onwards, the default alarm bubble-up behavior in recursive tables has been changed to "recursive=up", i.e., from child nodes up to parent nodes (following the foreign key in the direction it is in). (Prior to DataMiner 10.0.6, the siblings on the same level can affect each other's bubble-up level).
