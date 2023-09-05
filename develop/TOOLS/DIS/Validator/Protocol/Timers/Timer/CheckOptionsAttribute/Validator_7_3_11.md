---  
uid: Validator_7_3_11  
---

# CheckOptionsAttribute

## InvalidIpOption

### Description

Invalid value for 'ip' option. Expected format: 'ip:\<tablePid\>,\<columnIdx\>'. Current value '{optionValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.11      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Expected format: 'ip:\<tablePid\>,\<columnIdx\>', where \<tablePid\> specifies the table parameter ID and \<columnIdx\> specifies the zero\-based column index of the column that holds the IP address or the primary key (in case a QAction for each row of the table is executed directly from the timer).
