---
uid: DMAServiceConfigurationTrigger
---

# DMAServiceConfigurationTrigger

| Item | Format | Description |
|------|--------|-------------|
| TriggerID      | Integer | The ID of the trigger. |
| DataMinerID    | Integer | The DataMiner Agent ID. |
| ElementID      | Integer | The element ID. |
| ParameterID    | Integer | The parameter ID. |
| TableIndex     | String  | The parameter table index (in case of a table parameter). |
| Delay          | Integer | The delay (in ms) that is applied before the trigger takes effect. |
| Type           | String  | The type of trigger: "Correlation", "Alarm", "ElementState", "Parameter", "Manual", "Property" or "Connectivity". |
| Value          | String  | The value of the trigger. For example, if "Type" is set to "Alarm", this could be "Critical". |
| ValueCondition | String  | The condition operator for the trigger: "equal", "not equal", "exists row", "more", "less", "more or equal" or "less or equal". |
