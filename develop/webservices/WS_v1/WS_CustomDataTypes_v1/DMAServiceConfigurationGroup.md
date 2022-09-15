---
uid: DMAServiceConfigurationGroup
---

# DMAServiceConfigurationGroup

| Item                          | Format  | Description                                                                 |
|-------------------------------|---------|-----------------------------------------------------------------------------|
| Name                          | String  | The name of the group.                                                      |
| GroupID                       | Integer | The ID of the group.                                                        |
| ParentGroupID                 | Integer | The ID of the parent group.                                                 |
| IsExcluded                    | Boolean | Indicates whether the group is always included in the service or not.       |
| MaxSeverityOnIncludedElement | String  | The maximum severity that an included element can have.                     |
| MaxSeverityOnElementNotUsed  | String  | The maximum severity that a “not used” element can have.                    |
| ExcludeTriggers               | String  | The triggers that determine whether the group is excluded from the service. |
| IncludeTriggers               | String  | The triggers that determine whether the group is included in the service.   |
| NotUsedTriggers               | String  | The triggers that determine whether the group is considered in use.         |
