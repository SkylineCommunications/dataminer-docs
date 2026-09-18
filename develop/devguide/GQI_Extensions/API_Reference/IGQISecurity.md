---
uid: GQI_IGQISecurity
---

# IGQISecurity interface

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Provides access to the security context.

Available from DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards.<!-- RN 45635 -->

This type can be used to inject the security context via the constructor of a GQI extension or GQI service when using the [GQI DxM](xref:GQI_DxM).

> [!TIP]
> See also: [Services in GQI extensions](xref:GQI_Extensions_Services).

## Properties

| Property | Type | Description |
|--|--|--|
| SecurityKey | `string` | The security key that identifies the current security context. Users with a matching security key have the same permissions and access rights. |
