---  
uid: Validator_1_22_12  
---

# CheckPageOrderAttribute

## ReferencedParamRTDisplayExpected

### Description

RTDisplay(true) expected on Param '{referencedPid}' referenced by the 'Protocol\/Display@pageOrder' attribute.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.22.12     |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Via the 'Protocol\/Display@pageOrder' attribute, it's possible to add pages which will link to an internet page via its URL.  
Such URL can be made dynamic by refering to parameter IDs.  
Such referenced parameters then require the RTDisplay tag to be set to true.
