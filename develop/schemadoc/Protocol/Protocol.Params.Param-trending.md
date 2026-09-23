---
metadata_version: 1
uid: Protocol.Params.Param-trending
description: "Reference the DataMiner connector protocol schema entry for trending attribute, including its documented structure, attributes, values, and constraints."
---

# trending attribute

Specifies whether the parameter supports trending.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Default: true.

> [!NOTE]
>
> - This attribute is only applicable for parameters that have RTDisplay set to "true".
> - This attribute is not applicable for parameters of type "write" or "write bit".

## Examples

```xml
<Param id="1" trending="true">
```

## See also

- [Trending](xref:MonitoringTrending)
- [Protocol Trending Guidelines](xref:Trending1)
