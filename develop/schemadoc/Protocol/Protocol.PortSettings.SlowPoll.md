---
metadata_version: 1
uid: Protocol.PortSettings.SlowPoll
description: "Learn how the SlowPoll element configures slow polling defaults and whether users can modify them for the main connection."
---

# SlowPoll element

Specifies the slow poll configuration.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.SlowPoll.DefaultValue)|[0, 1]|Specifies the default slow poll settings.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.SlowPoll.Disabled)|[0, 1]|Specifies whether the slow poll settings can be modified in the DataMiner user interface.|

## Remarks

> [!NOTE]
> Only applicable for the main connection.