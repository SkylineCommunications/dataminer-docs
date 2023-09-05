---  
uid: Validator_6_4_2  
---

# CheckConditionTag

## NonExistingId

### Description

Tag 'Action\/Condition' references a non\-existing 'Param' with PID '{paramId}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.4.2       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A 'Action\/Condition' should always contain a statement returning a boolean.  
See DDL for more information.  
Here are a few examples of mistakes covered by this error:  
\- Empty condition.  
\- Malformed condition:  
  \- The 'id:' placeholder used to retrieve a parameter value is incorrectly defined.  
  \- The number of opening & closing parentheses is not matching.  
  \- '&&', '\|\|' is used instead of 'AND', 'OR'.  
\- Condition that is not a boolean expression.  
\- Fully hard\-coded boolean expression (No reference to any parameter value).  
\- etc.
