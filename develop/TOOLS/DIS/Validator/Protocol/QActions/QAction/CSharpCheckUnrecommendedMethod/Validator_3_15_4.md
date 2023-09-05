---  
uid: Validator_3_15_4  
---

# CSharpCheckUnrecommendedMethod

## UnrecommendedSlProtocolSetParametersIndex

### Description

Method 'SLProtocol.SetParametersIndex' is unrecommended. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.15.4      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'SLProtocol.SetParametersIndex' method is used to set the value of a specific cells in a table.  
The problem with this call is that it relies on an indexer to identify the rows for which a cells values need to be updated.  
However, the order of rows in element tables is not guaranteed.  
Meaning, using an index (row position) is not ideal.  
Instead, it is recommended to use the 'SLProtocol.SetParametersIndexByKey' method which relies on the primary key of the rows.
