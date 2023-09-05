---  
uid: Validator_4_2_4  
---

# CheckParamTag

## InvalidParamSuffix

### Description

Invalid suffix '{suffix}' in 'Group\/Content\/Param' element. Group ID '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Group       |
| Full Id      | 4.2.4       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Example code

```xml
<Param>100:tablev2</Param>
```

### Details

Within 'Group\/Content\/Param' element, following suffixes are allowed:  
 \- Single: If ":single" is appended after the parameter ID, this parameter will be retrieved via a separate SNMP Get request.  
 \- Instance: Indicates that this parameter holds the instance value. The following parameters in the group will use the value retrieved by this parameter as the instance.  
 \- table: (Deprecated) Indicates that the requested parameter represents a table. Use tablev2 instead.  
 \- tablev2: Indicates that the requested parameter represents a table.  
 \- getnext: Performs a GetNext request.  
Note that all those are meant to poll data via a multi\-threaded timer so a group containing such suffixes can only be called from multi\-threaded timers.
