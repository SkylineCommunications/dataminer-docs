---  
uid: Validator_2_62_6  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Type@id' due to 'Param\/Type' '{paramType}'. Param ID '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.62.6      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Depending on the Param.Type tag value, this attribute should refer to an existing protocol items:  
\- read bit: ID of the corresponding group param (mandatory).  
\- write bit: ID of the corresponding group param (mandatory).  
\- response: ID of the response responsible to further parse the value of this param (mandatory).  
\- array: Semi\-column list of column Param IDs (optional: depends on the type of table and the presence of ArrayOptions\/ColumnOptions tags).
