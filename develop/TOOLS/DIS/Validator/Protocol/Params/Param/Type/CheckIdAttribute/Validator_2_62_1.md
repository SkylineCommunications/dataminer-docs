---  
uid: Validator_2_62_1  
---

# CheckIdAttribute

## EmptyAttribute

### Description

Empty attribute 'Type@id' in Param '{pid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.62.1      |
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
