---
metadata_version: 1
uid: Protocol.Params.Param.Mediation.LinkTo-ops
description: "Reference the DataMiner connector protocol schema entry for ops attribute, including its documented structure, attributes, values, and constraints."
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
