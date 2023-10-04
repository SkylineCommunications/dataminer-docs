---
uid: Protocol.PortSettings.SSH.Credentials
---

# Credentials element

Specifies the username and password for password-based authentication.

## Parent

[SSH](xref:Protocol.PortSettings.SSH)

## Children

| Name                                                                        | Occurrences | Description                                                |
|-----------------------------------------------------------------------------|-------------|------------------------------------------------------------|
| ***All***                                                                   |             |                                                            |
| &nbsp;&nbsp;[Username](xref:Protocol.PortSettings.SSH.Credentials.Username) |             | Specifies the ID of the parameter that holds the username. |
| &nbsp;&nbsp;[Password](xref:Protocol.PortSettings.SSH.Credentials.Password) |             | Specifies the ID of the parameter that holds the password. |

## Examples

```xml
<SSH>
    <Credentials>
        <Username pid="1000"/>
        <Password pid="1002"/>
    </Credentials>
</SSH>
```
