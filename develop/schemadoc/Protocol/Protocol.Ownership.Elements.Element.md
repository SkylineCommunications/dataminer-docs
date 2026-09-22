---
metadata_version: 1
uid: Protocol.Ownership.Elements.Element
description: "Reference the DataMiner connector protocol schema entry for Element element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Element element

Declares ownership of specific DataMiner elements.

## Parent

[Elements](xref:Protocol.Ownership.Elements)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Protocol](xref:Protocol.Ownership.Elements.Element.Protocol)||Declares ownership of DataMiner elements running the specified protocol. Supported wildcard characters: '*' and '?'.|
|&nbsp;&nbsp;[Description](xref:Protocol.Ownership.Elements.Element.Description)|[0, 1]|Declares ownership of the element description.|
|&nbsp;&nbsp;[Properties](xref:Protocol.Ownership.Elements.Element.Properties)|[0, 1]|Groups ownership declarations of element properties.|
|&nbsp;&nbsp;[AlarmTemplate](xref:Protocol.Ownership.Elements.Element.AlarmTemplate)|[0, 1]|Declares ownership of the alarm template.|
|&nbsp;&nbsp;[TrendTemplate](xref:Protocol.Ownership.Elements.Element.TrendTemplate)|[0, 1]|Declares ownership of the trend template.|
