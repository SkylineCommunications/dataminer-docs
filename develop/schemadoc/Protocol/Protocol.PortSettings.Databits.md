---
metadata_version: 1
uid: Protocol.PortSettings.Databits
description: "Reference the DataMiner connector protocol schema entry for Databits element, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# Databits element

Allows you to specify the possible databits settings and to define a default value.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.Databits.DefaultValue)|[0, 1]|Specifies the default number of data bits.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.Databits.Disabled)|[0, 1]|Specifies whether the databits can be modified in the DataMiner user interface.|
|&nbsp;&nbsp;[Range](xref:Protocol.PortSettings.Databits.Range)|[0, 1]|Defines a range of possible databit settings.|
|&nbsp;&nbsp;[Value](xref:Protocol.PortSettings.Databits.Value)|[0, *]|Using one or more Value elements, you can specify the different values that users are allowed to enter.|
