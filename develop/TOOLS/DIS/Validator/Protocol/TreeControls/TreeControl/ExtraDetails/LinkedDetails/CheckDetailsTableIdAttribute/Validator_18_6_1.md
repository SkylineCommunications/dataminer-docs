---  
uid: Validator_18_6_1  
---

# CheckDetailsTableIdAttribute

## MissingAttribute

### Description

Missing attribute 'LinkedDetails@detailsTableId' in TreeControl '{treeControlPid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | TreeControl |
| Full Id      | 18.6.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

LinkedDetails@detailsTableId attribute should contain one of the following:  
\- tablePid: Extra info from that table will then be added to the TreeControl.  
\- fkColumnPid: Extra info from the table to which the FK Column belongs will then be added to the TreeControl.  
In both cases, the table containing extra details should have its RTDisplay tag set to true.
