---
metadata_version: 1
uid: LogicActionCrc
description: "Describe the DataMiner connector development topic crc, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
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
