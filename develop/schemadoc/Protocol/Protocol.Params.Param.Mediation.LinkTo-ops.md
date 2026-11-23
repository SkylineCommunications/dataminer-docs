---
uid: Protocol.Params.Param.Mediation.LinkTo-ops
description: "Use the ops attribute in a DataMiner protocol to apply semicolon-separated conversion operations between linked protocol parameters."
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
