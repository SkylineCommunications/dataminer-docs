---
uid: Protocol.Params.Param.HyperLinks
description: "Learn about the deprecated HyperLinks element in a DataMiner protocol, which was used to group custom command hyperlinks."
---

# HyperLinks element

Deprecated. Contains the custom commands (i.e., "hyperlinks") that have to appear on the shortcut menu when users right-click an alarm of the parameter in question.

This is not supported in DataMiner Cube. Instead, a separate [Hyperlinks.xml](xref:Hyperlinks_xml) file is used.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[HyperLink](xref:Protocol.Params.Param.HyperLinks.HyperLink)|[0, *]|Defines a custom command (i.e., “hyperlink”) that has to appear on the shortcut menu when users right-click an alarm of the parameter in question.|

## Remarks

These custom commands are often hyperlinks pointing to a webpage or an automation script.
