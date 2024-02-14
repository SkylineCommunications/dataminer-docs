---
uid: Protocol.Params.Param.Information.Includes
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
