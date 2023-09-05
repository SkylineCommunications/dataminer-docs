---  
uid: Validator_2_56_6  
---

# CheckLoadSequenceAttribute

## ReferencedParamRTDisplayExpected

### Description

RTDisplay(true) expected on Param '{referencedPid}' referenced by 'Params@loadSequence' attribute.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.56.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'Params@loadSequence' expects a semicolon separated list of Param IDs allowing to define the order in which saved parameter values are loaded in SLElement.  
Referenced parameters are expected to:  
\- Have the save attribute set to 'true'  
\- Have the RTDisplay tag set to 'true'.
