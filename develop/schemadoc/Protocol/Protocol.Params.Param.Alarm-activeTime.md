---
uid: Protocol.Params.Param.Alarm-activeTime
---

# activeTime attribute

Specifies how long an alarm must be active before it automatically gets cleared by DataMiner.

## Content Type

unsignedInt

## Parent

[Alarm](xref:Protocol.Params.Param.Alarm)

## Remarks

Specified in ms. Should be a multiple of 1000 as the resolution is in s.

## Examples

In the following example, the alarm will automatically be cleared after 10 seconds:

```xml
<Alarm activeTime="10000">true</Alarm>
```
