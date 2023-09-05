---  
uid: Validator_9_4_1  
---

# CheckCommandTag

## MissingTag

### Description

Missing tag 'Content\/Command' in Pair '{pairId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Pair        |
| Full Id      | 9.4.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The Content tag of every pairs should contain one and only one Command tag which should have as value an unsigned number and refer to the id of an existing Command.  
Note that only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
