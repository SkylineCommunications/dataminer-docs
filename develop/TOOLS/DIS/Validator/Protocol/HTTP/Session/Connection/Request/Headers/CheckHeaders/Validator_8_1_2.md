---  
uid: Validator_8_1_2  
---

# CheckHeaders

## DuplicateHeaderKeys

### Description

Duplicate Header '{headerKey}' in HTTP request. Session ID '{sessionId}'. Connection ID '{connectionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | HTTP        |
| Full Id      | 8.1.2       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Merge the duplicate headers into one by providing a comma separated list of values.
