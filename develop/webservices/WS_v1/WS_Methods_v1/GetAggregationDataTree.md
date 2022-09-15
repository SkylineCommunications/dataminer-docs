---
uid: GetAggregationDataTree
---

# GetAggregationDataTree

Use this method to retrieve the data of a number of specified aggregation rules.

## Input

| Item       | Format         | Description                                                                                |
|------------|----------------|--------------------------------------------------------------------------------------------|
| connection | String         | The connection ID. See [ConnectApp](xref:ConnectApp).                                       |
| ruleIDs    | Array of GUIDs | The aggregation rule GUIDs.                                                                |
| rootViewID | Integer        | The view for which results are returned. To retrieve all aggregation data, specify -1. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAggregationDataTreeResult | Array of [DMAAggregationTableColumn](xref:DMAAggregationTableColumn) | The data of the specified aggregation rules. |
