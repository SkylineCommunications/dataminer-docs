---  
uid: Validator_2_48_4  
---

# CheckIdAttribute

## UnsupportedParam

### Description

Unsupported Param '{idAttributeValue}' reference in attribute 'SNMP\/OID@id' in Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.48.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Refer to a standalone read param.

### Details

The SNMP\/OID@id attribute needs to refer to a standalone read or bus Param and can be used in following situations:  
\- Subtables: the id should refer to a parameter that will allow to filter on the list of instances to be polled.  
\- Tables with filtered rows: each column should contain an id attribute that refers to a parameter that will allow to filter on the instances to be polled.  
\- Dynamic OID: the id should refer to a parameter that will allow to dynamically define the full OID.  
Except for subtables, the id attribute only makes sense in case a wildcard is present in the OID tag value.
