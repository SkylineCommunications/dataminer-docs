---
uid: Protocol.PortSettings.TimeoutTime.DefaultValue
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
