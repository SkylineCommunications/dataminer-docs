---
uid: Protocol.PortSettings.SSH.Credentials
---

# Credentials element

Specifies the SSH credentials.

## Parent

[SSH](xref:Protocol.PortSettings.SSH)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Username](xref:Protocol.PortSettings.SSH.Credentials.Username)||Specifies the user name.|
|&nbsp;&nbsp;[Password](xref:Protocol.PortSettings.SSH.Credentials.Password)||Specifies the password.|

## Examples

```xml
<SSH>
    <Credentials>
        <Username pid="1000"/>
        <Password pid="1002"/>
    </Credentials>
</SSH>
```
