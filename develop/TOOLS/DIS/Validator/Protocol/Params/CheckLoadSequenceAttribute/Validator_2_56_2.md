---  
uid: Validator_2_56_2  
---

# CheckLoadSequenceAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Params@loadSequence'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.56.2      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

'Params@loadSequence' expects a semicolon separated list of Param IDs allowing to define the order in which saved parameter values are loaded in SLElement.  
Referenced parameters are expected to:  
\- Have the save attribute set to 'true'  
\- Have the RTDisplay tag set to 'true'.
