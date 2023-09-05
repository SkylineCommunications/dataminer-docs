---  
uid: Validator_3_2_6  
---

# CheckTriggersAttribute

## DuplicateId

### Description

Duplicate value '{duplicateId}' in attribute 'QAction@triggers'. QAction ID '{qactionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | QAction     |
| Full Id      | 3.2.6       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

QActions should always have the QAction@triggers defined. It should contain a 'semi\-colon' separated list of parameter IDs.  
Exceptions are to be made in following cases:  
 \- Precompiled QActions: no triggers attribute required.  
 \- QActions triggered by multi\-threaded timers: no triggers attribute required.  
 \- QAction using the options\="group": triggers required but refers to Groups instead of Params.
