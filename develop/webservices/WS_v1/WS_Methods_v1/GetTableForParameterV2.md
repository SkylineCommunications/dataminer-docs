---
uid: GetTableForParameterV2
---

# GetTableForParameterV2

Use this method as an alternative to the [GetTableForParameter](xref:GetTableForParameter) method, in order to retrieve all rows from a table parameter as a DMAParameterTable object instead of an array of DMAParameterTableRow objects.

<!-- Available from DataMiner 9.5.3 onwards. -->

## Input

| Item        | Format           | Description             |
|-------------|------------------|-------------------------|
| connection  | String           | The connection ID.      |
| dmaID       | Integer          | The DataMiner Agent ID. |
| elementID   | Integer          | The element ID.         |
| parameterID | Integer          | The parameter ID.       |
| filters     | Array of strings | One or more filters, separated by semicolons (";").<br>For more information, see [Filters](#filters) below. |

### Filters

The following filters can be specified in the input for this method:

| Filter | Description |
|--|--|
| columns=pid1,pid2,... | In this filter, you can list the columns to be retrieved. |
| hide-cells | If this filter is added, the array of [DMAParameterTableRowV2](xref:DMAParameterTableRowV2) objects returned by the method will contain only a primary key column and a display key column. |
| as-kpi | Supported from DataMiner 10.0.0 onwards. Allows you to filter based on the following table column KPI options:<br>- KPIHideWrite<br>- HideKPI<br>- HideKPIWhenNotInitialized<br>- KPIShowDisplayKey<br>- KPIShowPrimaryKey<br>- DisableHistogram |

In addition, you can specify all filters available for the [GetTableForParameterFiltered](xref:GetTableForParameterFiltered) method. See [Filters](xref:GetTableForParameterFiltered#filters).

## Output

| Item | Format | Description |
|--|--|--|
| GetTableForParameterV2Result | [DMAParameterTable](xref:DMAParameterTable) | An array of column objects and row objects, with the page count and current page. |
