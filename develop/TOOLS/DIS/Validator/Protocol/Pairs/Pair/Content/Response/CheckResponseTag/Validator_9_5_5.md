---  
uid: Validator_9_5_5  
---

# CheckResponseTag

## NonExistingId

### Description

Tag 'Content\/Response' references a non\-existing 'Response' with ID '{responseId}'. Pair ID '{pairId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Pair        |
| Full Id      | 9.5.5       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Content tag of pairs can contain any number of Response tags.  
Those should have as value an unsigned number and refer to the id of an existing Response.  
A given pair can't refer to the same Response more than once (including both Response and ResponseOnBadCommand tags).  
Also note that only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
