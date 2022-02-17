---
uid: LogicActionCrc
---

# crc

Can be executed on commands and responses.

## On command

This action calculates the CRC of the command as defined in the CRC parameter of the command.

### Attributes

#### On@id

Specifies the ID(s) of the command(s) for which the CRC needs to be calculated.


## On response

This action calculates the CRC of the response as defined in the CRC parameter of the response. DataMiner will then compare this calculated value with the value sent in the response of the device. When the two values differ, a CRC error will be generated, and the command will be resent.

### Attributes

#### On@id

Specifies the ID(s) of the response(s) for which the CRC needs to be calculated.

## Examples

```xml
<Action id="1">
  <On id="1">command</On>
  <Type>crc</Type>
</Action>
```

```xml
<Action id="1">
  <On id="1">response</On>
  <Type>crc</Type>
</Action>
```
