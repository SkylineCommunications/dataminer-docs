---
metadata_version: 1
uid: Protocol.Params.Param.Description
description: "Learn how the Description element provides a common parameter label distinct from its technical name in a DataMiner connector protocol."
---

# Description element

Specifies the description of the parameter.

## Type

string

## Parent

[Param](xref:Protocol.Params.Param)

## Remarks

Typically, the parameter name refers to the technical name of the parameter, while the parameter description provides a more common name or description.

> [!NOTE]
> Preferably, the value of this tag should be unique throughout the protocol. Some special characters like single quotes (') or backslashes (\\) are allowed.

## Examples

```xml
<Description>RF Output</Description>
```
