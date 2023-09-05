---  
uid: Validator_1_9_13  
---

# CheckOptionsAttribute

## ReferencedParamExpectingRTDisplay

### Description

RTDisplay(true) expected on DVE Table. Table PID '{dveTablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Protocol    |
| Full Id      | 1.9.13      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Within the 'Protocol\/Type@options' attribute, the 'exportProtocol' option allows to define which DVE protocols should be made and based on what parameter DVE elements should be created.  
The exportProtocol option is expected to have the following format: "exportProtocol:\[protocolName\]:\[DveTablePid\]" optionally followed by ":noElementPrefix" where:  
\- \[protocolName\] should be the name of the DVE protocol to be created.  
    \- Note that we recommend the DVE protocol name to start with: "\[DveParentProtocolName\] \- "  
\- \[DveTablePid\] should be the PID of the table responsible for creating DVE elements. The referred Param is expected to:  
    \- Be of type 'array'.  
    \- Have its RTDisplay tag set to true.
