---  
uid: Validator_9_6_3  
---

# CheckResponseOnBadCommandTag

## UntrimmedTag

### Description

Untrimmed tag 'Content\/ResponseOnBadCommand' in Pair '{pairId}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Pair        |
| Full Id      | 9.6.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The Content tag of a pairs can contain maximum one ResponseOnBadCommand tag.  
It should have as value an unsigned number and refer to the id of an existing Response.  
A given pair can't refer to the same Response more than once (including both Response and ResponseOnBadCommand tags).  
Also note that only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
