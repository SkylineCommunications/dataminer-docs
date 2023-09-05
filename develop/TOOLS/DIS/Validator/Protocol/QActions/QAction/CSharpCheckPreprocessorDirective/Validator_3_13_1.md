---  
uid: Validator_3_13_1  
---

# CSharpCheckPreprocessorDirective

## ObsoleteDcfV1

### Description

Obsolete preprocessor directive 'DCFv1' used in QAction. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.13.1      |
| Severity     | Minor       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

DCFv1 preprocessor directive was used in the past in order to support older DM versions that didn't support DCF yet.  
However, by now, our minimum DM supported version already has DCF support so this DCFv1 preprocessor directive is of no use anymore.  
Moreover, in some cases, such preprocessor directive makes it harder to pinpoint issues so we highly recommend to fully remove the now useless DCFv1 directives (even commented out ones) from all protocols.
