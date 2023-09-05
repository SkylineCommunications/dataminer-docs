---  
uid: Validator_2_65_3  
---

# CheckNamingFormatTag

## NonExistingParam

### Description

Tag 'ArrayOptions\/NamingFormat' references a non\-existing 'Param' with ID '{referencedPid}'. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.65.3      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

'ArrayOptions\/NamingFormat' tag should start by a separator followed by a separated list of display key parts.  
\- Numeric parts will be considered as dynamic display key parts and should refer to an existing Param.  
\- Non\-Numeric parts will be considered as hard\-coded display key parts.  
NamingFormat should contain, at least, 1 dynamic part.
