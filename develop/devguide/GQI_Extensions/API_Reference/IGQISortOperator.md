---
uid: GQI_IGQISortOperator
---

# IGQISortOperator interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface.Operators`  
- Assembly: `SLAnalyticsTypes.dll`

Represents a **sort operator** in the core framework. See [IGQICoreOperator](xref:GQI_IGQICoreOperator#derived-types) for a list of available core operators.

Available from DataMiner 10.4.0/10.4.1 onwards.<!-- RN 37806 -->

```csharp
public interface IGQISortOperator : IGQICoreOperator
```

## Properties

| Name | Type | Description |
| ---- | ---- | ----------- |
| Fields | IReadOnlyList<[IGQISortField](xref:GQI_IGQISortField)> | The sort fields that define the individual columns to sort on. |

> [!NOTE]
>
> - An instance can be created via the [CreateSortOperator](xref:GQI_IGQIFactory#igqisortoperator-createsortoperatorparams-igqisortfield) factory method.
> - Use the [IsSortOperator](xref:GQI_IGQICoreBlock#bool-issortoperatorout-igqisortoperator-sortoperator) method to determine if a core operator is actually a sort operator.
