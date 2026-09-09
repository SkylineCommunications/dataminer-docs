---
uid: GQI_UsernamePasswordCredential
---

# UsernamePasswordCredential class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Represents a username and password credential returned by the [ICredentialProvider](xref:GQI_ICredentialProvider).

Available from DataMiner 10.6.11/10.7.0 [CU0] onwards.

## Constructor

| Constructor | Description |
|--|--|
| `UsernamePasswordCredential(string username, string password)` | Creates a username and password credential. |

## Properties

| Property | Type | Description |
|--|--|--|
| Username | `string` | The username. |
| Password | `string` | The password. |

> [!IMPORTANT]
> Treat both properties as sensitive data. Do not log or expose the password in query results, error messages, or diagnostic output.
