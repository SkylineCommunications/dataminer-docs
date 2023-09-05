---  
uid: Validator_1_29_1  
---

# CheckWideColumnPagesAttribute

## EmptyAttribute

### Description

Empty attribute 'Protocol\/Display@wideColumnPage'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.29.1      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

The Protocol\/Display@wideColumnPages allows to define a semicolon list of pages that should take the whole width available even if it only contains 1 column.  
It should refer to pages that are present in the Protocol\/Display@pageOrder attribute and on which at least one parameter is displayed.
