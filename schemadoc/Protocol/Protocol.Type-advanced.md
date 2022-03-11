---
uid: Protocol.Type-advanced
---

# advanced attribute

Specifies additional connections.

## Content Type

string

## Parent

[Type](xref:Protocol.Type)

## Remarks

This allows you to create, for example, a serial protocol containing some SNMP commands, or a protocol that is capable of communicating with multiple ports.

Protocol types have to be separated by semicolon (”;”).

For more information on ports, see:

- Protocol.[Ports](xref:Protocol.Ports)
- Protocol.[PortSettings](xref:Protocol.Ports.PortSettings)

## Examples

If you have a protocol of type SNMP+Serial, you should always make SNMP the primary type and Serial the secondary type. See the following example:

```xml
<Type advanced="serial">snmp</Type>
```

It is also possible to specify a name for the additional type. To specify a name, the following format must be used: [type]:[name]

For example:

```xml
<Type advanced="serial:Name">snmp</Type>
```

The name is displayed in the element wizard and is also used to link port settings with the additional type.
