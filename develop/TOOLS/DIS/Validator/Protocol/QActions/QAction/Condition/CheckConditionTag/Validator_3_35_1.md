---  
uid: Validator_3_35_1  
---

# CheckConditionTag

## InvalidCondition

### Description

Invalid condition '{conditionString}'. Reason '{invalidityReason}'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.35.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

A 'QAction\/Condition' should always contain a statement returning a boolean.  
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
