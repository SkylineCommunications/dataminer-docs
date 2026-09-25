---
metadata_version: 1
uid: Protocol.Params.Param-id
description: "Learn how to use the id attribute to assign a stable parameter ID within the supported normal or spectrum range in a DataMiner connector protocol."
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
