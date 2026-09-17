---
metadata_version: 1
uid: Protocol.PortSettings.SlowPollBase.Value
description: "Reference the DataMiner connector protocol schema entry for Value element, including its documented structure, attributes, values, and constraints."
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

# Value element

Specifies a slow poll base value.

## Type

[EnumTypePortSlowPollBase](xref:Protocol-EnumTypePortSlowPollBase)

## Parent

[SlowPollBase](xref:Protocol.PortSettings.SlowPollBase)

## Remarks

Contains on of the following predefined values.

- number: the SlowPoll setting is a number of timeouts.
- time: the SlowPoll setting is a duration (in ms).

## Examples

```xml
<SlowPollBase>
  <DefaultValue>Number</DefaultValue>
</SlowPollBase>
```

```xml
<SlowPollBase>
  <DefaultValue>Time</DefaultValue>
</SlowPollBase>
```
