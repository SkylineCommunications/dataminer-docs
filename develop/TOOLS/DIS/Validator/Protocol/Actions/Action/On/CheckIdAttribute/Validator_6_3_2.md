---  
uid: Validator_6_3_2  
---

# CheckIdAttribute

## EmptyAttibute

### Description

Empty attribute 'On@id' in Action '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.3.2       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@id' attribute can contain a semicolon list of unsigned number which refer to the id of an existing protocol item. The type of item is specified by the inner value of the 'Action\/On' tag.  
If the 'Action\/On@id' attribute is not present, the action will apply to all item of the type given by the value of the 'Action\/On' tag.  
Note that only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
