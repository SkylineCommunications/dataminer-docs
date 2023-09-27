---
uid: DMAServiceConfigurationParameter
---

# DMAServiceConfigurationParameter

| Item | Format | Description |
|--|--|--|
| Alias | Integer | The alias of the service child item. |
| DataMinerID | Integer | The DataMiner Agent ID of the service child item. |
| ElementID | Integer | The element ID of the service child item. |
| GroupID | Integer | The group ID of the service child item. |
| IsService | Boolean | Indicates whether the service child item is a service. |
| IsExcluded | Boolean | Indicates whether the child item is always included in the service or not. |
| MaxSeverityOnIncludedElement | String | The maximum severity that an included element can have. |
| MaxSeverityOnElementNotUsed | String | The maximum severity that a “not used” element can have. |
| ExcludeTriggers | String | The triggers that determine whether the child item is excluded from the service. |
| IncludeTriggers | String | The triggers that determine whether the child item is included in the service. |
| NotUsedTriggers | String | The triggers that determine whether the child item is considered in use. |
| ParameterFilters | Array of DMAServiceConfigurationParameterFilter | If not all parameters of a child element are included in the service, this array indicates the filters that determine which parameters are included. |
