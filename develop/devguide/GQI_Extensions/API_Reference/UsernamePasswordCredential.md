---
uid: GQI_UsernamePasswordCredential
description: "API reference for the UsernamePasswordCredential class, which represents username and password credentials retrieved for a GQI extension."
---

# UsernamePasswordCredential class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Represents a set of username and password credentials returned by the [ICredentialProvider](xref:GQI_ICredentialProvider).

Available starting from DataMiner Web 10.5.0 [CU20]/10.6.0 [CU8]/10.6.11 and API version 1.5.0. <!-- RN 46279 -->

## Constructor

| Constructor | Description |
|--|--|
| `UsernamePasswordCredential(string username, string password)` | Creates a set of username and password credentials. |

## Properties

| Property | Type | Description |
|--|--|--|
| Username | `string` | The username. |
| Password | `string` | The password. |

> [!IMPORTANT]
> Treat both properties as sensitive data. Do not log or expose either property in query results, error messages, or diagnostic output.
