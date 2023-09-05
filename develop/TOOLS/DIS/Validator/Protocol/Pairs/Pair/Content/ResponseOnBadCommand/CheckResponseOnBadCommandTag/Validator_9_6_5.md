---  
uid: Validator_9_6_5  
---

# CheckResponseOnBadCommandTag

## NonExistingId

### Description

Tag 'Content\/ResponseOnBadCommand' references a non\-existing 'Response' with ID '{responseId}'. Pair ID '{pairId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Pair        |
| Full Id      | 9.6.5       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Content tag of a pairs can contain maximum one ResponseOnBadCommand tag.  
It should have as value an unsigned number and refer to the id of an existing Response.  
A given pair can't refer to the same Response more than once (including both Response and ResponseOnBadCommand tags).  
Also note that only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
