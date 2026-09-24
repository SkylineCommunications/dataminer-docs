---
metadata_version: 1
uid: LogicActionOpen
description: "Use the open action to open a serial connector port, selecting the target connection by its number when the main connection is not used."
---

# open

This action must be executed on protocol.

This action opens the port of which the connection number is specified in the nr attribute of the Type tag.

> [!NOTE]
> Only applicable to serial connectors.

## Attributes

### Type@nr

(optional): Specifies the connection number.

Default: 0.

## Examples

```xml
<Action id="40001">
  <On>protocol</On>
  <Type nr="1">open</Type>
</Action>
```
