---  
uid: Validator_7_3_7  
---

# CheckOptionsAttribute

## InvalidIgnoreIfOption

### Description

Invalid value for 'ignoreIf' option. Expected format: 'ignoreIf:\<columnIdx\>,\<value\>'. Current value '{ignoreIfValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.7       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Expected format: "ignoreIf:\<columnIdx\>,\<value\>", where \<columnIdx\> specifies the zero\-based column index of a column of the table specified in the "ip" option, which holds the value to be compared with the value specified in \<value\>.
