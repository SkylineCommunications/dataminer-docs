---  
uid: Validator_6_3_1  
---

# CheckIdAttribute

## MissingAttribute

### Description

Missing attribute 'Action\/On@id' due to 'Action\/Type' '{actionType}'. Action ID '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.3.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/On@id' attribute is mandatory if 'Action\/Type' is set to one of the following values:  
add to execute, aggregate, append, append data, change length, clear, clear length info, clear on display, copy, copy reverse, crc, execute, execute next, execute one, execute one now, execute one top, force execute, go, increment, length, make, multiply, normalize, pow, read, read file, read stuffing, replace, replace data, reschedule, restart timer, reverse, run actions, save, set and get with wait, set next, set with wait, start, stop, stuffing, timeout.
