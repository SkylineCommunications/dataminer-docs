---
uid: Protocol.Params.Param.Description
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
