---
uid: LogicActionRestartTimer
---

# restart timer

This action can be executed on timers only.

This action will finish the group that is being executed and then remove remaining groups of this timer from the queue. It will NOT stop and start the timer. The groups from the timer will be executed again when the timer time is met.

*Feature introduced in DataMiner 8.5.4 (RN 9189).*

## Attributes

### On@id

Specifies the ID of the timer on which this action needs to be executed

### Type@reschedule

If this attribute is set to "true", the timer will immediately start again.

## Examples

```xml
<Action id="101">
  <Name>Restart with reschedule</Name>
  <On id="1">timer</On>
  <Type reschedule="true">restart timer</Type>
</Action>
```
