---  
uid: Validator_1_21_3  
---

# CheckDefaultPageAttribute

## UnexistingPage

### Description

The specified defaultPage '{pageName}' does not exist.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.21.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
<Display defaultPage="General" pageOrder="General;----------;Data Page 1;Data Page 2;----------;WebInterface#http://[Polling Ip]/" />
```

### Details

Skyline recommends the following structure for driver pages:  
\- General  
\- \-\-\-\-\-\-\-\-\-\-\-  
\- Data Page(s)  
\- \-\-\-\-\-\-\-\-\-\-\-  
\- WebInterface
