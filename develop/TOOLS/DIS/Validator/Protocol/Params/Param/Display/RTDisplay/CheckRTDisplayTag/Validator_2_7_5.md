---  
uid: Validator_2_7_5  
---

# CheckRTDisplayTag

## RTDisplayUnexpected

### Description

Unexpected RTDisplay(true) on Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.7.5       |
| Severity     | Minor       |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Double check if this Param requires RTDisplay for reasons that are outside the scope of this driver (Visios, automation scripts, etc).  
\- If so, suppress this result and explain why RTDisplay is required via the suppression comment.  
\- If not, remove the full Display tag containing this RTDisplay tag.

### Details

This protocol doesn't contain anything that would justify the need of the RTDisplay tag being true.
