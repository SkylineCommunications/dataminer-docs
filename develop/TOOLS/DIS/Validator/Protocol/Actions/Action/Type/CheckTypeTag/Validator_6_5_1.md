---  
uid: Validator_6_5_1  
---

# CheckTypeTag

## MissingTag

### Description

Missing tag 'Type' in Action '{actionId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Action      |
| Full Id      | 6.5.1       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The 'Action\/Type' tag is mandatory and should contain one of the following values:  
add to execute, aggregate, append, append data, change length, clear, clear length info, clear on display, close, copy, copy reverse, crc, execute, execute next, execute one, execute one top, execute one now, force execute, go, increment, length, lock, unlock, make, merge, multiply, normalize, open, pow, priority lock, priority unlock, read, read file, read stuffing, replace, replace data, reschedule, restart timer, reverse, run actions, save, set, set and get with wait, set info, set next, set with wait, sleep, start, stop, stop current group, stuffing, swap column, timeout, wmi.
