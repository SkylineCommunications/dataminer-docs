---
metadata_version: 1
uid: LogicActionSleep
description: "Use the sleep action to pause connector protocol execution for a configured number of milliseconds, subject to the minimum supported delay."
---

# sleep

This action must be executed on protocol.

This action waits for the specified amount of time.

## Attributes

### Type@value

(optional): Specifies the time to sleep (in ms). The minimum usable value is 15 ms.

Default: 5000 ms.

## Examples

```xml
<Action id="1">
   <On>protocol</On>
   <Type value="1000">sleep</Type>
</Action>
```
