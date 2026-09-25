---
metadata_version: 1
uid: Protocol.Pairs.Pair-ping
description: "Learn how to use the ping attribute to run a pair during device timeout when slow polling is active in a DataMiner connector protocol."
---

# ping attribute

If set to true, the pair will be executed when the device is in timeout and slow polling is activated.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Pair](xref:Protocol.Pairs.Pair)

## Remarks

> [!NOTE]
> This option cannot be used in protocols of type SNMP.

## Examples

```xml
<Pair id="1" ping="true">
```
