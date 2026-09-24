---
metadata_version: 1
uid: Protocol.Timers.Timer-fixedTimer
description: "Learn how the fixedTimer attribute prevents users from changing a timer interval within a relative timer protocol."
---

# fixedTimer attribute

If, in case of a relative timer protocol, this attribute is set to "true", the user will not be able to change the interval.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Timer](xref:Protocol.Timers.Timer)

## Remarks

See also: [relativeTimers](xref:Protocol.Type-relativeTimers).

## Examples

```xml
<Timer id="1" fixedTimer="true">
```
