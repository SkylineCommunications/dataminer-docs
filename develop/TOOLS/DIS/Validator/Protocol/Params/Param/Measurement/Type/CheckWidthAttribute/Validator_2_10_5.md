---  
uid: Validator_2_10_5  
---

# CheckWidthAttribute

## InconsistentWidth

### Description

Inconsistent (page)buttons width on page '{pageName}'. PIDs '{paramIDs}' \- Widths '{widthValues}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.10.5      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Adjust the width of this button to the highest width value of all buttons on this page.

### Example code

```xml
<Type width="110">button</Type>
```

### Details

The recommended width for (page)buttons is 110.  
When needed, (page)buttons can exceptionally be made larger but in that case, they need to be consistent through the driver page they belong to.
