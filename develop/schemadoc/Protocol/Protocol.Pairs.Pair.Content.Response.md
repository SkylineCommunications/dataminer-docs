---
metadata_version: 1
uid: Protocol.Pairs.Pair.Content.Response
description: "Reference the DataMiner connector protocol schema entry for Response element, including its documented structure, attributes, values, and constraints."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Response element

Specifies the ID of an expected response.

## Type

unsignedInt

## Parent

[Content](xref:Protocol.Pairs.Pair.Content)

## Remarks

> [!NOTE]
> By default, the number of retries in case of an invalid response is set to 3. This setting can be changed when adding or editing the device in DataMiner Cube.

## Examples

```xml
<Response>3</Response>
```
