---
uid: Protocol.PortSettings.SSH
---

# SSH element

Specifies the SSH settings.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

| Name                                                                  | Occurrences | Description                                                       |
|-----------------------------------------------------------------------|-------------|-------------------------------------------------------------------|
| ***All***                                                             |             |                                                                   |
| &nbsp;&nbsp;[Credentials](xref:Protocol.PortSettings.SSH.Credentials) | [0, 1]      | Specifies the credentials used for password-based authentication. |
| &nbsp;&nbsp;[Identity](xref:Protocol.PortSettings.SSH.Identity)       | [0, 1]      | Specifies the private key used for public key authentication.     |

## Remarks

Only applicable for serial connections of type TCP

*Feature introduced in DataMiner 9.5.9 (RN 17732).*

## Examples

```xml
<PortSettings name="SSH Connection">
    <IPport>
        <DefaultValue>22</DefaultValue>
    </IPport>
    <BusAddress>
        <Disabled>true</Disabled>
    </BusAddress>
    <PortTypeSerial>
        <Disabled>true</Disabled>
    </PortTypeSerial>
    <PortTypeUDP>
        <Disabled>true</Disabled>
    </PortTypeUDP>
    <SSH>
        <Credentials>
            <Username pid="1000"/>
            <Password pid="1002"/>
        </Credentials>
    </SSH>
</PortSettings>
```
