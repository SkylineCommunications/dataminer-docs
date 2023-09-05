---  
uid: Validator_2_39_1  
---

# CheckDisplayKey

## DuplicateDisplayKeyDefinition

### Description

Table with ID '{tableId}' has multiple display key definitions.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.39.1      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### How to fix

Only keep the most recent syntax of defining the display key.

### Details

When defining the display key via multiple syntaxes, only the most recent syntax is actually used. List of syntaxes from most recent to oldest:  
 \- NamingFormat tag  
 \- Naming option (ex: options\=;naming\=\/101)  
 \- displayColumn attribute
