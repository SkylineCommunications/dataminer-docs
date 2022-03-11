---
uid: Protocol.PortSettings.BusAddress
---

# BusAddress element

Allows to limit bus address settings and to define a default value.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***Sequence***|||
|&nbsp;&nbsp;[DefaultValue](xref:Protocol.PortSettings.BusAddress.DefaultValue)|[0, 1]|Specifies a default bus address value.|
|&nbsp;&nbsp;[Disabled](xref:Protocol.PortSettings.BusAddress.Disabled)|[0, 1]|Specifies whether the bus address can be modified in the DataMiner user interface.|
|&nbsp;&nbsp;[Range](xref:Protocol.PortSettings.BusAddress.Range)|[0, 1]|Defines a range of possible bus addresses.|
|&nbsp;&nbsp;[Value](xref:Protocol.PortSettings.BusAddress.Value)|[0, *]|Using one or more Value elements, you can specify the different values that users are allowed to enter.|

## Remarks

Typically, this information will correspond to the specifications received from the manufacturer.

> [!NOTE]
> For a GPIB connection, this tag relates to the Device Address field.

## Examples

```xml
<BusAddress>
    <DefaultValue>2000</DefaultValue>
    <Range>
    <From>300</From>
    <To>400</To>
    </Range>
    <Value>???</Value>
    <Value>14</Value>
    <Value>15</Value>
</BusAddress>
```
