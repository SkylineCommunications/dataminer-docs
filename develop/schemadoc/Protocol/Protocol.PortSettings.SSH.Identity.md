---
uid: Protocol.PortSettings.SSH.Identity
---

# Identity element

Specifies the ID of the parameter that holds the path to the private key used for public key authentication.

It should be formatted like this: `key=C:\Users\User\.ssh\my_key_rsa`

> [!NOTE]
>
> - If the private key is protected by a passphrase, it must be appended to the file path, separated by a semicolon. It should be formatted like this: `key=C:\Users\User\.ssh\my_key_rsa;pass=passphrase`
> - When you authenticate with a key through a private/public key pair, you must still specify the user. See also: [Defining an SSH connection in a protocol](xref:ConnectionsSerialSecureShell#defining-an-ssh-connection-in-a-protocol).

## Parent

[SSH](xref:Protocol.PortSettings.SSH)

## Attributes

| Name                                               | Type        | Required | Description                                                               |
|----------------------------------------------------|-------------|----------|---------------------------------------------------------------------------|
| [pid](xref:Protocol.PortSettings.SSH.Identity-pid) | unsignedInt | Yes      | Specifies the ID of the parameter that holds the path to the private key. |

## Examples

```xml
<SSH>
    <Identity pid="1004" />
</SSH>
```
