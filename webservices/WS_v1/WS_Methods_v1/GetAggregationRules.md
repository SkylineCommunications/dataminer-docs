---
uid: GetAggregationRules
---

# GetAggregationRules

Use this method to retrieve the available aggregation rules.

## Input

| Item            | Format  | Description                                                     |
|-----------------|---------|-----------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp).            |
| ActiveRulesOnly | Boolean | Indicates whether only active rules should be retrieved or not. |

## Output

| Item                       | Format                                                                                                  | Description                      |
|----------------------------|---------------------------------------------------------------------------------------------------------|----------------------------------|
| GetAggregationRules­Result | Array of [DMAAggregationRule](xref:DMAAggregationRule) | The available aggregation rules. |
