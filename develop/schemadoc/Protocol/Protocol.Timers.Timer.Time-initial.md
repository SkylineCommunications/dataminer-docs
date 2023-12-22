---
uid: Protocol.Timers.Timer.Time-initial
---

# initial attribute

Specifies whether the timer should be started when the element is started.

## Content Type

string

## Parent

[Time](xref:Protocol.Timers.Timer.Time)

## Remarks

|Options|Description
|--- |--- |
|true|The timer will be started when the element is started.|
|false|The timer will not be started when the element is started. This allows you to dynamically start the timer by performing an action.|
|random=startvalue:endvalue|Use this option to avoid that all timers are started simultaneously. In this case, the timer will be started a random number of seconds after the start of the element. The random value will be a value between startvalue and endvalue, for example random=0:300.Note: When multiple timers in the same protocol have the same random value, they will all start at the same random time. If you do not want this, use non-overlapping random times. The seed of the random function is elementId * getTickCount() and the wait is (Rand()%(to-from)+from.|

By default, this attribute is omitted. As a consequence, the groups will be executed the moment the element is started.

> [!NOTE]
> Any timer with a “random” time will have its random start disregarded if the element card is open in a client. The random option should therefore not be used to try to enforce timer startup order.

## Examples

In the following example, the timer will be started within 300 seconds (depending on the random number) every 60000 milliseconds:

```xml
<Time initial="random=0:300">60000</Time>
```
