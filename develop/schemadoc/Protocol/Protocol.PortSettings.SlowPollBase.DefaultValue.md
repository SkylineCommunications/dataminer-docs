---
uid: Protocol.PortSettings.SlowPollBase.DefaultValue
description: "Use the DefaultValue element in a DataMiner protocol to set whether slow polling is based on a timeout count or duration by default."
---

# DefaultValue element

Specifies the default slow poll base.

## Type

[EnumTypePortSlowPollBase](xref:Protocol-EnumTypePortSlowPollBase)

## Parent

[SlowPollBase](xref:Protocol.PortSettings.SlowPollBase)

## Remarks

Contains one of the following predefined values.

- `number`: The SlowPoll setting is a number of timeouts.
- `time`: The SlowPoll setting is a duration (in ms).

## Examples

```xml
<SlowPollBase>
  <DefaultValue>number</DefaultValue>
</SlowPollBase>
```

```xml
<SlowPollBase>
  <DefaultValue>time</DefaultValue>
</SlowPollBase>
```
