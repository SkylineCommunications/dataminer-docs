---  
uid: Validator_2_65_1  
---

# CheckNamingFormatTag

## EmptyTag

### Description

Empty tag 'ArrayOptions\/NamingFormat' in Table '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.65.1      |
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
