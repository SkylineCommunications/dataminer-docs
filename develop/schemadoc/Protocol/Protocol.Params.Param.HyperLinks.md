---
metadata_version: 1
uid: Protocol.Params.Param.HyperLinks
description: "Reference the DataMiner connector protocol schema entry for HyperLinks element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# HyperLinks element

Contains the custom commands (i.e., “hyperlinks”) that have to appear on the shortcut menu when users
right-click an alarm of the parameter in question.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[HyperLink](xref:Protocol.Params.Param.HyperLinks.HyperLink)|[0, *]|Defines a custom command (i.e., “hyperlink”) that has to appear on the shortcut menu when users right-click an alarm of the parameter in question.|

## Remarks

These custom commands are often hyperlinks pointing to a webpage or an automation script.
