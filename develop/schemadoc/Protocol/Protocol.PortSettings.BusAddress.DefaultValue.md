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

As a bus address is not always needed, the default value can also be set to "false". In that case, it will not be possible to specify a bus address. In case of an HTTP protocol, the default value is "bypassProxy".

Contains

- Value of type Integer,
- `false`, or
- `bypassProxy`

> [!NOTE]
> If you set the default Device Address field for a GPIB connection to "false", this will be ignored.<!-- RN 12883 -->

## See also

- [bypassProxy](xref:ConnectionsHttpElementConfiguration)