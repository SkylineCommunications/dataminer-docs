---
metadata_version: 1
uid: Protocol.Params.Param.CRC.Type-off
description: "Reference the DataMiner connector protocol schema entry for off attribute, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# off attribute

Specifies an offset value to be added to the calculated CRC.

## Content Type

int

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Remarks

Only valid if the CRC type is set to one of the following values:

- LSB after sum
- LSB after subtract
- Rest
- Subtract
- Sum

> [!NOTE]
> The off attribute is executed before the mod attribute. See also: [Internal calculation sequence](xref:Protocol.Params.Param.CRC.Type#internal-calculation-sequence).

## Examples

```xml
<Param>
	<CRC>
		<Type off="128">REST</Type>
        ...
```
