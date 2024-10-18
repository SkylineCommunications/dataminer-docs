---
uid: LogicActionRestartTimer
---

# restart timer

<!-- RN 9189 -->

This action can be executed on timers only.

This action will finish the group that is being executed and then remove remaining groups of this timer from the queue. It will NOT stop and start the timer. The groups from the timer will be executed again when the timer time is met.

## Attributes

### On@id

Specifies the ID of the timer on which this action needs to be executed

### Type@reschedule

(Optional.) If this attribute is set to "true", the timer will immediately start again.

Default: false

## Examples

```xml
<Action id="101">
  <Name>Restart with reschedule</Name>
  <On id="1">timer</On>
  <Type reschedule="true">restart timer</Type>
</Action>
```
