---
metadata_version: 1
uid: Protocol.PortSettings.SlowPoll.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
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

# DefaultValue element

Specifies the default slow poll settings.

## Type

[TypePortSlowPoll](xref:Protocol-TypePortSlowPoll)

## Parent

[SlowPoll](xref:Protocol.PortSettings.SlowPoll)

## Remarks

Contains an integer value.

- When used with SlowPollBase equal to "number", the value is seen a number of timeouts. The value must be in the range [1, 500].
- When used with SlowPollBase equal to "time", the value is seen as a number of milliseconds. The value must be in the range [1000, 300000].

## Examples

```xml
<SlowPoll>
	<DefaultValue>30000</DefaultValue>
</SlowPoll>
```
