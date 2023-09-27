---
uid: DMAServiceInfoGroupDefinition
---

# DMAServiceInfoGroupDefinition

| Item | Format | Description |
|--|--|--|
| ExcludeTriggers | Array of DMATriggerCombination | The triggers determining whether the group is excluded. These DMATriggerCombination objects consists of the following fields:<br> - *TriggerID*: The ID of the trigger.<br> - *CombinationType*: A combination type such as "And", "Not", etc. |
| IncludeTriggers | Array of DMATriggerCombination | The triggers determining whether the group is included. These DMATriggerCombination objects consists of the following fields:<br> - *TriggerID*: The ID of the trigger.<br> - *CombinationType*: A combination type such as "And", "Not", etc. |
| NotUsedTriggers | Array of DMATriggerCombination | The triggers determining whether the group is used. These DMATriggerCombination objects consists of the following fields:<br> - *TriggerID*: The ID of the trigger.<br> - *CombinationType*: A combination type such as "And", "Not", etc. |
| IncludedCapped | String | The maximum severity for elements in the group when it is included: *Critical*, *Major*, *Minor*, *Warning* or *Normal*. |
| NotUsedCapped | String | The maximum severity for elements in the group when it is not used: *Critical*, *Major*, *Minor*, *Warning* or *Normal*. |
| ParentGroupID | Integer | The ID of the parent group, if any. |
| Name | String | The name of the group. |
