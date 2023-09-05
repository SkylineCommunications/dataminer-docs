---  
uid: Validator_7_1_7  
---

# CheckTimeTag

## TooFastTimer

### Description

Too fast Timer Time '{timerTime}'. Timer ID '{timerId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.1.7       |
| Severity     | Minor       |
| Certainty    | Uncertain   |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Increase the timer time to at least 1s.
