---  
uid: Validator_6_7_8  
---

# CheckActionTypes

## NonExistingRefToPairOnTimeoutSetNext

### Description

Attribute 'On@nr' references a non\-existing 'Pair' with 1\-based position '{pairPosition}' in Group '{groupId}'. Action ID '{actionId}' triggered by Trigger '{triggerId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.7.8       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

For pair timeout actions, the 'Action\/On@nr' attribute should contain the 1\-based position(s) of pair(s) in related group(s).
