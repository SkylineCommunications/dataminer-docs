---  
uid: Validator_9_4_3  
---

# CheckCommandTag

## UntrimmedTag

### Description

Untrimmed tag 'Content\/Command' in Pair '{pairId}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Pair        |
| Full Id      | 9.4.3       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The Content tag of every pairs should contain one and only one Command tag which should have as value an unsigned number and refer to the id of an existing Command.  
Note that only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
