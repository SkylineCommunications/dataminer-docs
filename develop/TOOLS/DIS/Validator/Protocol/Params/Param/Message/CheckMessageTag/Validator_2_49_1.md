---  
uid: Validator_2_49_1  
---

# CheckMessageTag

## MissingTag

### Description

Missing tag 'Param\/Message' in Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.49.1      |
| Severity     | BubbleUp    |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
<Message>Are you sure you want to restart the device?</Message>
```

### Details

A button executing a critical action should have a confirmation message.  
This can be done by adding a 'Param\/Message' tag.
