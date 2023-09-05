---  
uid: Validator_9_6_2  
---

# CheckResponseOnBadCommandTag

## EmptyTag

### Description

Empty tag 'Content\/ResponseOnBadCommand' in Pair '{pairId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Pair        |
| Full Id      | 9.6.2       |
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
