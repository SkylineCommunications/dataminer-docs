---  
uid: Validator_1_18_1  
---

# CheckXMLDeclaration

## InvalidDeclaration

### Description

Invalid XML encoding '{currentEncoding}'. Possible values '{possibleValues}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.18.1      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### How to fix

Remove the XML declaration if not set to UTF\-8.
