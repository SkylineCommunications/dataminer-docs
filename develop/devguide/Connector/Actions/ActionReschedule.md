---
uid: LogicActionReschedule
---

# reschedule

This action can be executed on timers only.

If the timer is running, we wait until it finishes and then add the groups to the queue. If the timer is not running, we stop waiting for the remaining time and immediately add the groups to the queue.

*Feature introduced in DataMiner 8.5.4 (RN 9189).*

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
