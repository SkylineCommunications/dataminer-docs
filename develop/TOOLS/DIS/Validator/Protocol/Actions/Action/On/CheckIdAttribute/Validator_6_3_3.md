---  
uid: Validator_6_3_3  
---

# CheckIdAttribute

## UntrimmedValueInAttribute

### Description

Untrimmed value '{untrimmedValue}' in attribute 'On@id'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.3.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The 'Action\/On@id' attribute can contain a semicolon list of unsigned number which refer to the id of an existing protocol item. The type of item is specified by the inner value of the 'Action\/On' tag.  
If the 'Action\/On@id' attribute is not present, the action will apply to all item of the type given by the value of the 'Action\/On' tag.  
Note that only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
