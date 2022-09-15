---
uid: GetAggregationRules
---

# GetAggregationRules

Use this method to retrieve the available aggregation rules.

## Input

| Item            | Format  | Description                                                     |
|-----------------|---------|-----------------------------------------------------------------|
| connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).            |
| activeRulesOnly | Boolean | Indicates whether only active rules should be retrieved or not. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAggregationRulesResult | Array of [DMAAggregationRule](xref:DMAAggregationRule) | The available aggregation rules. |
