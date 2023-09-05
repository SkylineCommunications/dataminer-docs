---  
uid: Validator_1_22_10  
---

# CheckPageOrderAttribute

## MissingPage\_Sub

### Description

Param with ID '{pid}' is positioned on page '{pageName}' which is not ordered via 'Protocol\/Display@pageOrder' attribute.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.22.10     |
| Severity     | Warning     |
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
