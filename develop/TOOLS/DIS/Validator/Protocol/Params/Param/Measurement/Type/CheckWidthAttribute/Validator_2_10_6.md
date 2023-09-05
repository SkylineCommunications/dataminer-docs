---  
uid: Validator_2_10_6  
---

# CheckWidthAttribute

## UnsupportedAttribute

### Description

The width attribute is not supported for '{measurementType}'. Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.10.6      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Remove the Measurement.Type@width attribute.

### Details

Measurement.Type@width attribute is only supported for (page)button parameters.
