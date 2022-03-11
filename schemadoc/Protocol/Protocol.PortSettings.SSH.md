---
uid: Protocol.PortSettings.SSH
---

# SSH element

Specifies the SSH settings.

## Parent

[PortSettings](xref:Protocol.PortSettings)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Credentials](xref:Protocol.PortSettings.SSH.Credentials)|[0, 1]|Specifies the SSH credentials.|
|&nbsp;&nbsp;[Identity](xref:Protocol.PortSettings.SSH.Identity)|[0, 1]|Specifies the identity settings.|

## Remarks

Only applicable for serial connections of type TCP

By default, SSH connections are established on port 22. Use this syntax to specify that the SSH connection should be established on the specified port.

*Feature introduced in DataMiner 9.5.9 (RN 17732).*

## Examples

```xml
<SSH>
    <Credentials>
        <Username pid="1000"/>
        <Password pid="1002"/>
    </Credentials>
</SSH>
```
