---
metadata_version: 1
uid: Protocol.Pairs.Pair.Content.Command
description: "Reference the DataMiner connector protocol schema entry for Command element, including its documented structure, attributes, values, and constraints."
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

# Command element

Specifies the ID of the command that will be sent when the pair is executed.

## Type

unsignedInt

## Parent

[Content](xref:Protocol.Pairs.Pair.Content)

## Remarks

In a pair, you can specify only one command.



## Examples


```xml
<Command>3</Command>
```



