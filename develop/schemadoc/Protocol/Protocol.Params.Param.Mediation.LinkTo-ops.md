---
uid: Protocol.Params.Param.Mediation.LinkTo-ops
---

# ops attribute

Specifies one or more conversion operations separated by semicolons (`;`).

## Content Type

string

## Parent

[LinkTo](xref:Protocol.Params.Param.Mediation.LinkTo)

## Remarks

Supported operations:

| Operation | Description |
|-----------|-------------|
| *         | Factor      |
| /         | Devision    |
| -         | Minus       |
| +         | Offset      |
| %         | Remainder   |

## Examples

```xml
<LinkTo pid="176" protocol="Philips DVS3810" ops="*:1024;+:5" />
```
