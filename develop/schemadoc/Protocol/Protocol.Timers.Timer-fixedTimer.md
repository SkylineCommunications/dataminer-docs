---
metadata_version: 1
uid: Protocol.Timers.Timer-fixedTimer
description: "Reference the DataMiner connector protocol schema entry for fixedTimer attribute, including its documented structure, attributes, values, and constraints."
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

# fixedTimer attribute

If, in case of a relative timer protocol, this attribute is set to "true", the user will not be able to change the interval.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Timer](xref:Protocol.Timers.Timer)

## Remarks

See also: [relativeTimers](xref:Protocol.Type-relativeTimers).

## Examples

```xml
<Timer id="1" fixedTimer="true">
```
