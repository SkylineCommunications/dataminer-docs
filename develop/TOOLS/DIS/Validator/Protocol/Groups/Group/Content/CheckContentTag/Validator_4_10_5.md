---  
uid: Validator_4_10_5  
---

# CheckContentTag

## MissingTag

### Description

Missing tag 'Content' in Group '{groupId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Group       |
| Full Id      | 4.10.5      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Typically, a non\-empty 'Group\/Content' is mandatory on groups except for the following exceptional cases where the Content tag should be ommitted:  
\- Multi\-threaded groups  
\- When the protocol doesn't have any group at all. In that case, it is needed to add a Group without any content.
