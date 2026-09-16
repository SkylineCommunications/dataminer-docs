---
uid: GQI_IGQIFactory
---

# IGQIFactory interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

This interface provides various methods to create objects that can be used to communicate with the core GQI framework. An implementation of this interface can be obtained via the [Factory property](xref:GQI_OnInitInputArgs#properties) on the *OnInitInputArgs* passed in the [OnInit](xref:GQI_IGQIOnInit#oninitoutputargs-oninitoninitinputargs-args) lifecycle method.

Available from DataMiner 10.4.5/10.5.0 onwards.<!-- RN 39136 -->

> [!NOTE]
> From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!-- RN 45635 -->, when using the `Skyline.DataMiner.Core.GQI.Extensions` API and the [GQI DxM](xref:GQI_DxM), this type can be used to inject a factory via the constructor of a GQI extension or GQI service. In earlier versions, use the [Factory](xref:GQI_OnInitInputArgs#properties) property of [OnInitInputArgs](xref:GQI_OnInitInputArgs).

## Methods

### IGQISortField CreateSortField(IGQIColumn, GQISortDirection = GQISortDirection.Ascending)

Creates an [IGQISortField](xref:GQI_IGQISortField) that defines a column to sort on, along with a sort direction. One or more of these sort fields can be used to [construct an IGQISortOperator](#igqisortoperator-createsortoperatorparams-igqisortfield).

#### Parameters

- [IGQIColumn](xref:GQI_IGQIColumn) `column`: The column to sort on.
- [GQISortDirection](xref:GQI_GQISortDirection) `direction`: Optional. Whether to sort values from smallest to largest or the other way around. By default, `GQISortDirection.Ascending` is used.

#### Returns

An implementation of [IGQISortField](xref:GQI_IGQISortField) that represents a sort operation on the given column with the given sort direction.

### IGQISortOperator CreateSortOperator(params IGQISortField[])

Creates an [IGQISortOperator](xref:GQI_IGQISortOperator) that defines a sort operation on one or more [sort fields](xref:GQI_IGQISortField). Can be used to implement custom sort behaviors during the [Optimize](xref:GQI_IGQIOptimizableOperator#igqiquerynode-optimizeigqioperatornode-currentnode-igqicoreoperator-nextoperator) lifecycle method.

#### Parameters

- [IGQISortField](xref:GQI_IGQISortField)[] `fields`: The sort fields that define the individual columns to sort on.

#### Returns

An implementation of [IGQISortOperator](xref:GQI_IGQISortOperator) that represents a sort operation on the given sort fields, or null when there are no sort fields.
