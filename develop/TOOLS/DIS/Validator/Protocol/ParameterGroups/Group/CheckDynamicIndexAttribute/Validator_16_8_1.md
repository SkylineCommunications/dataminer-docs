---  
uid: Validator_16_8_1  
---

# CheckDynamicIndexAttribute

## MissingDynamicIdAttribute

### Description

Filtering via 'Group@dynamicIndex' attribute requires a 'Group@dynamicId' attribute. ParameterGroup ID '{parameterGroupId}'.

### Properties

| Name         | Value          |
| ------------ | -------------- |
| Category     | ParameterGroup |
| Full Id      | 16.8.1         |
| Severity     | Major          |
| Certainty    | Certain        |
| Source       | Validator      |
| Fix Impact   | NonBreaking    |
| Has Code Fix | False          |

### Details

'Group@dynamicIndex' attribute allows to filter on Display Keys before creating dynamic DCF interfaces.  
Such filter is applied on the table referred to via the 'Group@dynamicId' attribute.  
This means that the presence of a 'Group@dynamicIndex' attribute while there is no 'Group@dynamicIndex' doesn't make sense.
