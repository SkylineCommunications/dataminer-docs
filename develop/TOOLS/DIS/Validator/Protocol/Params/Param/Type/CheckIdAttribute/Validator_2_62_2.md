---  
uid: Validator_2_62_2  
---

# CheckIdAttribute

## UntrimmedAttribute

### Description

Untrimmed attribute 'Type@id' in Param '{pid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.62.2      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

Depending on the Param.Type tag value, this attribute should refer to an existing protocol items:  
\- read bit: ID of the corresponding group param (mandatory).  
\- write bit: ID of the corresponding group param (mandatory).  
\- response: ID of the response responsible to further parse the value of this param (mandatory).  
\- array: Semi\-column list of column Param IDs (optional: depends on the type of table and the presence of ArrayOptions\/ColumnOptions tags).
