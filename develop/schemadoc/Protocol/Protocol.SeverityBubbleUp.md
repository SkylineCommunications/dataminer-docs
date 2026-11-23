---
uid: Protocol.SeverityBubbleUp
description: "Learn how the SeverityBubbleUp element passes alarm severities through configured paths between linked protocol tables."
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

- The default alarm bubble-up behavior in recursive tables is "recursive=up", i.e., from child nodes up to parent nodes (following the foreign key in the direction it is in).<!-- RN 25349 -->
