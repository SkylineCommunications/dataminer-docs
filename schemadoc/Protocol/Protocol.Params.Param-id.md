---
uid: Protocol.Params.Param-id
---

# id attribute

Specifies the ID of the parameter.

## Content Type

[TypeParamId](xref:Protocol-TypeParamId)

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Normal parameters should have an ID in the following range: 1-64000. Spectrum parameters should have an ID in the following range: 1-50000.

> [!CAUTION]
> Never change parameter IDs in existing protocols. This would severely affect alarms, trend displays, Visio files, etc.
