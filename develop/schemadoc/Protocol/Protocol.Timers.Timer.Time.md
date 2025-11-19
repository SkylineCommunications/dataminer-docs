---
uid: Protocol.Timers.Timer.Time
---

# Time element

Specifies how frequently the included groups will be executed.

## Type

[TimerTime](xref:Protocol-TimerTime)

## Parent

[Timer](xref:Protocol.Timers.Timer)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[dataDisplay](xref:Protocol.Timers.Timer.Time-dataDisplay)|unsignedInt||Specifies the execution frequency of the included groups when a Data Display has been opened.|
|[initial](xref:Protocol.Timers.Timer.Time-initial)|string||Specifies whether the timer should be started when the element is started.|

## Remarks

Contains either

- **loop**

  The included groups will be executed over and over again.

- **value > 0**

  The included groups will be executed every X milliseconds.

  It is good practice to use the following intervals:

  - Slow interval (in case of static data): 3600000 (1 hour)
  - Medium interval: 60000 (1 minute)
  - Fast interval (for example in case of alarm info): 10000 (10 seconds)

> [!NOTE]
> The maximum time a timer can be set to is 24 days (2073600000). In case a larger value is specified, the following message will be logged, "Invalid (too large) time-range specified for timer [x] [set value]. (Defaulting to 24 days)", and the time will be set to 24 days instead.<!-- RN 14392 -->

## Examples

```xml
<Time>loop</Time>
```
