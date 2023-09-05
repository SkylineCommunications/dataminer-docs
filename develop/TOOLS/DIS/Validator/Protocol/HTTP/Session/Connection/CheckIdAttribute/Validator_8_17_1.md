---  
uid: Validator_8_17_1  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Connection@id' in HTTP Session '{sessionId}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | HTTP      |
| Full Id      | 8.17.1    |
| Severity     | Critical  |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

The id attribute is used internally as the identifier for each connection within a session.  
It is therefore mandatory and needs to follow a number of rules:  
\- Each connection within a session should have a unique id.  
\- Should be an unsigned integer.  
\- Only plain numbers are allowed (no leading signs, no leading zeros, no scientific notation, etc).
