---
uid: GQI_GQIWorkerServiceAttribute
---

# GQIWorkerServiceAttribute class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Indicates that the decorated class is a worker-scoped service. A single instance is shared across all users and all queries in the extension worker process.

Available from DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards.<!-- RN 45635 -->

> [!TIP]
> See also: [Services in GQI extensions](xref:GQI_Extensions_Services).

## Constructors

| Constructor | Description |
|--|--|
| `GQIWorkerServiceAttribute()` | Registers and injects the service by its concrete type. |
| `GQIWorkerServiceAttribute(Type serviceType)` | Registers and injects the service by the specified contract type. The decorated class must be assignable to this type. |

## Properties

| Property | Type | Description |
|--|--|--|
| ServiceType | `Type` | Inherited from [GQIServiceAttribute](xref:GQI_GQIServiceAttribute). |
| IdleExpirationMinutes | `int` | Inherited from [GQIServiceAttribute](xref:GQI_GQIServiceAttribute). The default value is `0`, which means that worker-scoped services do not expire because they are idle. |
