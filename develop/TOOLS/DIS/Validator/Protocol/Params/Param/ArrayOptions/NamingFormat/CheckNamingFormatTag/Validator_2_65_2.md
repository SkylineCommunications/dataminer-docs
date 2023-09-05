---  
uid: Validator_2_65_2  
---

# CheckNamingFormatTag

## UntrimmedTag

### Description

Untrimmed tag 'ArrayOptions\/NamingFormat' in Table '{tablePid}'. Current value '{untrimmedValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.65.2      |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | True        |

### Details

'ArrayOptions\/NamingFormat' tag should start by a separator followed by a separated list of display key parts.  
\- Numeric parts will be considered as dynamic display key parts and should refer to an existing Param.  
\- Non\-Numeric parts will be considered as hard\-coded display key parts.  
NamingFormat should contain, at least, 1 dynamic part.
