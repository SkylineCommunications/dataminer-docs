---  
uid: Validator_7_1_6  
---

# CheckTimeTag

## DuplicateTimer

### Description

Duplicate Timer with Time '{timerTime}'. Timer IDs '{timerIDs}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.1.6       |
| Severity     | Minor       |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Combine the timers into one.

### Details

Each timer is a thread which uses resources. Timers are there to be able to have different polling rates. It should not be used to split groups on other factors than the polling rate.
