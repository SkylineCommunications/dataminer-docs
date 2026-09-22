---
metadata_version: 1
uid: Protocol.Params.Param.Type-relativeTimers
description: "Reference the DataMiner connector protocol schema entry for relativeTimers attribute, including its documented structure, attributes, values, and constrai."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# relativeTimers attribute



## Content Type

[EnumProtocolTypeRelativeTimers](xref:Protocol-EnumProtocolTypeRelativeTimers)

## Parent

[Type](xref:Protocol.Params.Param.Type)

## Remarks

This attribute can have the following values:


|Value|Description
|--- |--- |
|true|If you change the interval in the middle of the current interval, the timer will only be fired when the interval is completely finished.|
|true with reset|If you change the interval in the middle of the current interval, the timer will be fired instantly.|



