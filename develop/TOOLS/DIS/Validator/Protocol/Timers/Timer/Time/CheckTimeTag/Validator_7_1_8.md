---  
uid: Validator_7_1_8  
---

# CheckTimeTag

## TooSimilarTimers

### Description

Timer Time values too similar. Timer IDs '{timerId}'. Time values '{timerTime}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.1.8       |
| Severity     | Minor       |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Change the timer time so that the difference between the specified time and the time of the other timers is at least 1s.
