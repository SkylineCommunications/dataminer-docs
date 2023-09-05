---  
uid: Validator_2_10_2  
---

# CheckWidthAttribute

## EmptyWidth

### Description

Empty (page)button width attribute. Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.10.2      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### How to fix

Fill in Measurement.Type@width attribute with a value equal or greater than 110.

### Example code

```xml
<Type width="110">button</Type>
```

### Details

The recommended width for (page)buttons is 110.  
When needed, (page)buttons can exceptionally be made larger but in that case, they need to be consistent through the driver page they belong to.
