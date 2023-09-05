---  
uid: Validator_8_3_6  
---

# CheckKeyAttribute

## RedundantHeaderKey

### Description

Header key '{headerKey}' is typically managed automatically by DataMiner. Session ID '{sessionId}'. Connection ID '{connectionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | HTTP        |
| Full Id      | 8.3.6       |
| Severity     | Warning     |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

By default, DataMiner will add a header with key 'User\-Agent' and value 'DataMiner'.  
Therefore, specifying it in the driver is redundant unless you want\/need a more specific value to be used.
