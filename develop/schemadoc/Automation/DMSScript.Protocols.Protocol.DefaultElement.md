---
metadata_version: 1
uid: DMSScript.Protocols.Protocol.DefaultElement
description: "Reference the DataMiner Automation script schema entry for DefaultElement element, including its documented structure, attributes, values, and constraints."
---

# DefaultElement element

Specifies the default element.

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***Union***|||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Max length|0||
|&nbsp;&nbsp;***string restriction***|||
|&nbsp;&nbsp;&nbsp;&nbsp;Pattern|`^[0-9]+/[0-9]+$`||

## Parent

[Protocol](xref:DMSScript.Protocols.Protocol)

## Remarks

Format: "Agent ID/Element ID" (e.g., 200/160).
