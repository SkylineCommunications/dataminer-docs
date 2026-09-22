---
metadata_version: 1
uid: LogicActionSleep
description: "Describe the DataMiner connector development topic sleep, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
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
