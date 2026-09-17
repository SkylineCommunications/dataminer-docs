---
metadata_version: 1
uid: Protocol.Timers.Timer.Time-dataDisplay
description: "Reference the DataMiner connector protocol schema entry for dataDisplay attribute, including its documented structure, attributes, values, and constraints."
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

# dataDisplay attribute

Specifies the execution frequency of the included groups when a Data Display has been opened.

## Content Type

unsignedInt

## Parent

[Time](xref:Protocol.Timers.Timer.Time)

## Remarks

It is good practice to set this interval to 30000 (30 seconds).

> [!NOTE]
> If you set this attribute to “loop”, the included groups will be executed as frequently as possible. In some cases, that could affect overall DataMiner performance.

## Examples

```xml
<Time dataDisplay="loop">loop</Time>
```
