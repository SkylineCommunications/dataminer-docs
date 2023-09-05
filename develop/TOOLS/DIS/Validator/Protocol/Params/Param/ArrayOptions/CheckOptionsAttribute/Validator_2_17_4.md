---  
uid: Validator_2_17_4  
---

# CheckOptionsAttribute

## NamingRefersToNonExistingParam

### Description

Option 'naming' in attribute 'ArrayOptions@options' references a non\-existing 'Param' with ID '{referencedPid}'. Table PID '{tablePid}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Param       |
| Full Id      | 2.17.4      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The naming option in the ArrayOptions@options attribute should contain a list of PIDs referencing existing parameters.
