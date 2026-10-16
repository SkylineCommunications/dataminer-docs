---
uid: Protocol.Params.Param-trending
description: "Use the trending attribute in a DataMiner protocol to enable or disable trending support for an eligible displayed parameter."
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
