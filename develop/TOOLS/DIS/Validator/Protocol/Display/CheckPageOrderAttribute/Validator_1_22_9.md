---  
uid: Validator_1_22_9  
---

# CheckPageOrderAttribute

## DuplicateEntries

### Description

Page '{pageName}' has been added more than once to the pageOrder attribute.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.22.9      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

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
