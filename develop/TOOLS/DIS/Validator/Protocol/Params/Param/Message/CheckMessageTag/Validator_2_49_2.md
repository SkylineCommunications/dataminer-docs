---  
uid: Validator_2_49_2  
---

# CheckMessageTag

## MissingTag\_Sub

### Description

Missing tag 'Param\/Message' for button with caption '{discreetDisplayValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.49.2      |
| Severity     | Minor       |
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
