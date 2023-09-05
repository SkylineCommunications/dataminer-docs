---  
uid: Validator_7_3_22  
---

# CheckOptionsAttribute

## UnknownOption

### Description

Unknown option '{optionName}' detected.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.22      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The timer options are formatted as follows: \<optionName\>:\<optionValue\> where \<optionName\> should be one of the following:  
\- each  
\- dynamicThreadPool  
\- ignoreIf  
\- instance  
\- ip  
\- ping  
\- pollingRate  
\- qaction  
\- qactionBefore  
\- qactionAfter  
\- threadPool  
Options should be separated using semicolons (';').
