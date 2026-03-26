---
uid: Protocol.PortSettings.Flowcontrol.DefaultValue
---

# DefaultValue element

Specifies the default flow control value.

## Type

[EnumPortSettingsFlowControl](xref:Protocol-EnumPortSettingsFlowControl)

## Parent

[Flowcontrol](xref:Protocol.PortSettings.Flowcontrol)

## Remarks

Each time a user adds an element using the element wizard, the flow control setting will by default be set to this value.

> [!NOTE]
> For an SNMPv3 connection, this tag can be used to specify the default encryption algorithm (e.g., "AES128").
>
> The following encryption algorithms are supported:
>
> - DES
> - AES128
> - AES192<!-- RN 23586 -->
> - AES256<!-- RN 23586 -->
>
> If no default value is specified, the most secure option will be the default.
