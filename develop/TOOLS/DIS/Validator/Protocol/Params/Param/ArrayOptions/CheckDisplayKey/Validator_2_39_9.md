---  
uid: Validator_2_39_9  
---

# CheckDisplayKey

## DisplayKeyColumnMissing

### Description

Missing column with ColumnOption@type\="displaykey". Table PID {tablePid}.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.39.9      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

When defining display key format via ArrayOption\/NamingFormat tag or via naming option in the ArrayOption@options attribute and the display key format does not only consist of a single column content, it is mandatory to add a displayed column with ColumnOption@type\="displaykey" attribute value so that the full display key is available to the user.
