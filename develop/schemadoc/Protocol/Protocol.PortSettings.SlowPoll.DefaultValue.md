---
metadata_version: 1
uid: Protocol.PortSettings.SlowPoll.DefaultValue
description: "Learn how the DefaultValue element under SlowPoll sets the timeout count or duration used for slow polling on the main connection."
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
