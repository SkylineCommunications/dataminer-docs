---
uid: Protocol.PortSettings.SlowPollBase.Value
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
