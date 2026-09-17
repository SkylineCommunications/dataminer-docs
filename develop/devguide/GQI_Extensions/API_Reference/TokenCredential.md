---
uid: GQI_TokenCredential
description: Reference for the TokenCredential class, which contains an access token retrieved for a GQI extension.
---

# TokenCredential class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Represents a token credential returned by the [ICredentialProvider](xref:GQI_ICredentialProvider).

Available from DataMiner Web 10.5.0 [CU20]/10.6.0 [CU8]/10.6.11 and API version 1.5.0. <!-- RN 46279 -->

## Constructor

| Constructor | Description |
|--|--|
| `TokenCredential(string token)` | Creates a token credential. |

## Properties

| Property | Type | Description |
|--|--|--|
| Token | `string` | The access token. |

> [!IMPORTANT]
> Treat the token as sensitive data. Do not log or expose it in query results, error messages, or diagnostic output.
