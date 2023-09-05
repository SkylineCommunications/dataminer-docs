---  
uid: Validator_2_10_7  
---

# CheckWidthAttribute

## UnrecommendedWidth

### Description

Unrecommended (page)button width '{widthValue}'. Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.10.7      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Example code

```xml
<Type width="110">button</Type>
```

### Details

The recommended width for (page)buttons is 110.  
When needed, (page)buttons can exceptionally be made larger but in that case, they need to be consistent through the driver page they belong to.
