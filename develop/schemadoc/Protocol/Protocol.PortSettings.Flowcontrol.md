---
metadata_version: 1
uid: Protocol.PortSettings.Flowcontrol
description: "Reference the DataMiner connector protocol schema entry for Flowcontrol element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Flowcontrol element

Allows to limit flow control settings and to define a default value.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.Flowcontrol.DefaultValue)|[0, 1]|Specifies the default flow control value.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.Flowcontrol.Disabled)|[0, 1]|Specifies whether the flow control can be modified in the DataMiner user interface.|
|&nbsp;&nbsp;[Range](xref:Protocol.PortSettings.Flowcontrol.Range)|[0, 1]|Defines the range of possible flow control values.|
|&nbsp;&nbsp;[Value](xref:Protocol.PortSettings.Flowcontrol.Value)|[0, *]|Using one or more Value elements, you can specify the different values that users are allowed to enter.|
