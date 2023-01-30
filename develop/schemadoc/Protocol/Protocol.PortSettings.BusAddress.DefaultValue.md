---
uid: Protocol.PortSettings.BusAddress.DefaultValue
---

# DefaultValue element

Specifies a default bus address value.

## Type

string

## Parent

[BusAddress](xref:Protocol.PortSettings.BusAddress)

## Remarks

Each time a user adds an element using the element wizard, the bus address will by default be set to this value.

As a bus address is not always needed, the default value can also be set to “false”. In that case, it will not be possible to specify a bus address. In case of an HTTP protocol, the default value is “bypassProxy”.

Contains

- Value of type Integer,
- False, or
- bypassProxy

> [!NOTE]
> From DataMiner 9.0.0 (RN 12883) onwards, it is no longer possible to set the default Device Address field for a GPIB connection to “false”. If you do set *DefaultValue* to “false”, this will be disregarded in that case.

## See also

- [bypassProxy](xref:ConnectionsHttpElementConfiguration)