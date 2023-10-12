---
uid: LogicActionOpen
---

# open

This action must be executed on protocol.

This action opens the port of which the connection number is specified in the nr attribute of the Type tag.

> [!NOTE]
> Only applicable to serial drivers.

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
