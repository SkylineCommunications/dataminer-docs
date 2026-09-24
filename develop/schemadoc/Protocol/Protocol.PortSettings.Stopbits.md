---
metadata_version: 1
uid: Protocol.PortSettings.Stopbits
description: "Learn how the Stopbits element defines the default and selectable stop bit counts for an element connection."
---

# Stopbits element

Specifies the stop bits settings.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.Stopbits.DefaultValue)|[0, 1]|Specifies the default number of stop bits.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.Stopbits.Disabled)|[0, 1]|Specifies whether the number of stop bits can be modified in the DataMiner user interface.|
|&nbsp;&nbsp;[Value](xref:Protocol.PortSettings.Stopbits.Value)|[0, *]|Using one or more Value elements, you can specify the different values that users are allowed to enter.|
