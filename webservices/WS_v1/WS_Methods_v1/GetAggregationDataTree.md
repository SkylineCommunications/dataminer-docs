---
uid: GetAggregationDataTree
---

# GetAggregationDataTree

Use this method to retrieve the data of a number of specified aggregation rules.

## Input

| Item       | Format         | Description                                                                                |
|------------|----------------|--------------------------------------------------------------------------------------------|
| Connection | String         | The connection ID. See [ConnectApp](xref:ConnectApp).                                       |
| RuleIDs    | Array of GUIDs | The aggregation rule GUIDs.                                                                |
| RootViewID | Integer        | The view for which results are returned. To retrieve all aggregation data, specify -1. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAggregation­DataTreeResult | Array of DMAAggrega­tionTableColumn (see [DMAAggregationTableColumn](xref:DMAAggregationTableColumn)) | The data of the specified aggregation rules. |
