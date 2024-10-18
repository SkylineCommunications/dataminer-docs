---
uid: LogicActionClose
---

# close

This action must be executed on protocol.

This action either closes the port of which the connection number is specified in the nr attribute of the Type tag or (smart-serial only) disconnects a connected client (specified in Type@id).

> [!NOTE]
> Only applicable to serial connectors.

## Attributes

### Type@nr

(Optional.) Specifies the connection number. Default: 0.

### Type@id

(Optional.) Applicable for smart IP only. Specifies the ID of the parameter that holds the client IP and port (IP:port).

## Examples

```xml
<Action id="8">
   <On>protocol</On>
   <Type nr="1">close</Type>
</Action>
```

Example of closing a connected client:

```xml
<Action id="8">
   <On>protocol</On>
   <Type id="4102">close</Type>
</Action>
```
