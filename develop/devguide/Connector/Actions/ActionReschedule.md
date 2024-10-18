---
uid: LogicActionReschedule
---

# reschedule

<!-- RN 9189 -->

This action can be executed on timers only.

If the timer is running, DataMiner will wait until it finishes and then add the groups to the queue. If the timer is not running, DataMiner stops waiting for the remaining time and immediately adds the groups to the queue.

## Attributes

### On@id

Specifies the ID(s) of the timer(s) on which this action needs to be executed.

## Examples

```xml
<Action id="102">
  <Name>Reschedule</Name>
  <On id="1">timer</On>
  <Type>reschedule</Type>
</Action>
```
