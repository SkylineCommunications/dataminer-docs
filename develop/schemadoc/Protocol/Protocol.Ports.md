---
uid: Protocol.Ports
---

# Ports element

Groups the PortSettings elements for the additional protocol connections.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[PortSettings](xref:Protocol.Ports.PortSettings)|[0, *]|Specifies the port settings for any additional protocol type specified in Protocol.Type.|

## Remarks

For every protocol, you have to specify its type in Protocol.Type, and its port settings in Protocol.PortSettings (see [PortSettings](xref:Protocol.PortSettings)).

In case of a multitype protocol, the Protocol.Type@advanced attribute is used to define any additional protocol types. The port settings for those additional protocol types then have to be specified in a Protocol.Ports.PortSettings element in which the name attribute contains the name of the additional type as specified in the Protocol.Type@advanced attribute.

## Examples

```xml
<Protocol>
  ...
  <Type advanced="serial:Type1">SNMP</Type>
  ...
  <PortSettings>
     Portsettings for main protocol type (SNMP)
     ...
  </PortSettings>
  ...
  <Ports>
     <PortSettings name="Type1">
        Portsettings for additional protocol type (SERIAL)
        ...
     </PortSettings>
  </Ports>
  ...
</Protocol>
```
