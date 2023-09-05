---  
uid: Validator_2_55_3  
---

# CheckMapAlarmAttribute

## RTDisplayExpected

### Description

RTDisplay(true) expected on Param '{pid}' generating alarms based on traps.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.55.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'Param\/SNMP\/TrapOID@mapAlarm' attribute of a Param starts with 'TRUE' when the param is expected to generate alarm or information event on received traps.  
Such feature requires the parameter RTDisplay tag set to 'true'.
