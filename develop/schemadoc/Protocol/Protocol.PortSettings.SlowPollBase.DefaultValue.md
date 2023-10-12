---
uid: Protocol.PortSettings.SlowPollBase.DefaultValue
---

# DefaultValue element

Specifies the default slow poll base.

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
  <DefaultValue>number</DefaultValue>
</SlowPollBase>
```

```xml
<SlowPollBase>
  <DefaultValue>time</DefaultValue>
</SlowPollBase>
```
