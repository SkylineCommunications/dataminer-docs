---
uid: GQI_GQILazyT
---

# GQILazy\<T\> class

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Provides deferred resolution of a GQI service. Add a constructor parameter of type `GQILazy<T>` to a GQI extension or GQI service to have the underlying service resolved on first access instead of during construction.

Available from DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards.<!-- RN 45635 -->

> [!TIP]
> See also: [Services in GQI extensions](xref:GQI_Extensions_Services).

## Type parameters

- `T`: The type of the service to resolve.

## Constructors

| Constructor | Description |
|--|--|
| `GQILazy(Func<T> valueFactory)` | Creates a lazy service wrapper with an explicit value factory. This is typically used when unit testing an extension that depends on `GQILazy<T>`. |

## Properties

| Property | Type | Description |
|--|--|--|
| Value | `T` | The service instance. The service is resolved the first time this property is accessed. |
