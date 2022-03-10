---
uid: Protocol.PortSettings.TimeoutTimeElement.DefaultValue
---

# DefaultValue element

Specifies the default element timeout value (in ms).

## Type

|Item|Facet value|Description|
|--- |--- |--- |
|***unsignedInt restriction***|||
|&nbsp;&nbsp;Min exclusive|1000||
|&nbsp;&nbsp;Max exclusive|120000||
|&nbsp;&nbsp;Pattern|`^\d+000$`||

## Parent

[TimeoutTimeElement](xref:Protocol.PortSettings.TimeoutTimeElement)

## Remarks

An integer value in the range [1000,120000]. The value should be a multiple of 1000 as the resolution is in seconds.

## Examples

```xml
<TimeoutTimeElement>
    <DefaultValue>666000</DefaultValue>
</TimeoutTimeElement>
```
