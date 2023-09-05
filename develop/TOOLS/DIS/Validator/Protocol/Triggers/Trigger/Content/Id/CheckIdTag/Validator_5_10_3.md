---  
uid: Validator_5_10_3  
---

# CheckIdTag

## UntrimmedTag

### Description

Untrimmed tag 'Content\/Id' in Trigger '{triggerId}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.10.3      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The Content tag of every Trigger should contain at least one Id tag.  
Such Id tag should contain an unsigned number and refer to the id of an existing Trigger or Action depending on the 'Trigger\/Type' tag value.  
Note that only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
