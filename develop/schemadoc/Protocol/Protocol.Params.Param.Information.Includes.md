---
metadata_version: 1
uid: Protocol.Params.Param.Information.Includes
description: "Reference the DataMiner connector protocol schema entry for Includes element [obsolete], including its documented structure, attributes, values, and const."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Includes element [obsolete]

Contains one or more Protocol.Params.Param.Information.Include tags to indicate that you want additional information to be displayed in the tooltip.

## Parent

[Information](xref:Protocol.Params.Param.Information)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Include](xref:Protocol.Params.Param.Information.Includes.Include)|[0, *]|Specifies additional information to be displayed in the tooltip.|

## Examples

```xml
<Includes>
	<Include>range</Include>
	<Include>units</Include>
	<Include>steps</Include>
	<Include>time</Include>
</Includes>
```
