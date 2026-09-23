---
metadata_version: 1
uid: Protocol.PortSettings.TimeoutTime.DefaultValue
description: "Reference the DataMiner connector protocol schema entry for DefaultValue element, including its documented structure, attributes, values, and constraints."
---

# DefaultValue element

Specifies the default timeout value.

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***unsignedInt restriction***|||
|&nbsp;&nbsp;Min exclusive|10||
|&nbsp;&nbsp;Max exclusive|120000||

## Parent

[TimeoutTime](xref:Protocol.PortSettings.TimeoutTime)

## Remarks

The value is a number of milliseconds.

## Examples

```xml
<TimeoutTime>
    <DefaultValue>10000</DefaultValue>
</TimeoutTime>
```
