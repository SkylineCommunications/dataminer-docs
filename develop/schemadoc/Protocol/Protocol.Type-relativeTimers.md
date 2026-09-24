---
metadata_version: 1
uid: Protocol.Type-relativeTimers
description: "Consult the DataMiner connector protocol schema reference for the relativeTimers attribute, which controls timer behavior when an interval changes."
---

# relativeTimers attribute

*** No documentation available yet. ***

## Content Type

[EnumProtocolTypeRelativeTimers](xref:Protocol-EnumProtocolTypeRelativeTimers)

## Parent

[Type](xref:Protocol.Type)

## Remarks

This attribute can have one of two values:

- true: If the interval is changed in the middle of the current interval, the timer will only be executed when the interval is completely finished.

  > [!NOTE]
  > If the fixedTimer attribute of /Protocol/Timers/Timer is also set to "true", then users cannot change the timer interval.

- true with reset: Each time the interval is changed the timer is executed instantly.

## Examples

```xml
<Type relativeTimers="true">smart-serial</Type>
```
