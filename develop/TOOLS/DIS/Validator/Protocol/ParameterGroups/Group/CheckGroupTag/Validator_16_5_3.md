---  
uid: Validator_16_5_3  
---

# CheckGroupTag

## IncompatibleParamReferences

### Description

Incompatible links to parameters via 'Group@dynamicId' attribute and 'Group\/Params' element. ParameterGroup ID '{parameterGroupId}'.

### Properties

| Name         | Value          |
| ------------ | -------------- |
| Category     | ParameterGroup |
| Full Id      | 16.5.3         |
| Severity     | Major          |
| Certainty    | Certain        |
| Source       | Validator      |
| Fix Impact   | NonBreaking    |
| Has Code Fix | False          |

### Details

Different type of DCF interfaces can be created:  
  \- Standalone interface: without 'Group@dynamicId' attribute  
      \- Without alarm linking: without 'Group\/Params' element  
      \- With alarm linking: with 'Group\/Params\/Param' element(s)  
  \- Dynamic interfaces: with 'Group@dynamicId' and 'Group@dynamicIndex' attributes.
