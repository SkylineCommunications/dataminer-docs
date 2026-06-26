---
uid: GQI_GQIServiceAttribute
---

# GQIServiceAttribute class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Base class for GQI service scope attributes.

Available from DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards.<!-- RN 45635 -->

> [!TIP]
> See also: [Services in GQI extensions](xref:GQI_Extensions_Services).

## Constructors

| Constructor | Description |
|--|--|
| `GQIServiceAttribute()` | Registers and injects the service by its concrete type. |
| `GQIServiceAttribute(Type serviceType)` | Registers and injects the service by the specified contract type. The decorated class must be assignable to this type. |

## Properties

| Property | Type | Description |
|--|--|--|
| ServiceType | `Type` | The contract type under which the service is registered. When this is `null`, the service is registered by its concrete type. |
| IdleExpirationMinutes | `int` | The sliding idle expiration of the service in minutes, counted from when the service was last used. A value of `0` means that the service does not expire because it is idle. |
