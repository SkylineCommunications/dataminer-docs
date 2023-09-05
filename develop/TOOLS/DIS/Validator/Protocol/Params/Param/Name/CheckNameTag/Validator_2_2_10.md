---  
uid: Validator_2_2_10  
---

# CheckNameTag

## RTDisplayExpectedOnContextMenu

### Description

RTDisplay(true) expected on Param '{contextMenuPid}' used as context menu for table.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.2.10      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Parameter with names ending with "\_contextmenu" are used as context menu for tables.  
Such Param requires its RTDisplay tag to be set to true.
