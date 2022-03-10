---
uid: Protocol.Timers.Timer.Time-dataDisplay
---

# dataDisplay attribute

Specifies the execution frequency of the included groups when a Data Display has been opened.

## Content Type

unsignedInt

## Parent

[Time](xref:Protocol.Timers.Timer.Time)

## Remarks

It is good practice to set this interval to 30000 (30 seconds).

> [!NOTE]
> If you set this attribute to “loop”, the included groups will be executed as frequently as possible. In some cases, that could affect overall DataMiner performance.

## Examples

```xml
<Time dataDisplay="loop">loop</Time>
```
