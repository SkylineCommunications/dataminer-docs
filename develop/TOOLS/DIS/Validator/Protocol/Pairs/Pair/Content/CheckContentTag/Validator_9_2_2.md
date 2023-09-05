---  
uid: Validator_9_2_2  
---

# CheckContentTag

## MissingClearResponseRoutine\_Sub

### Description

Missing clear response '{responseIdToClear}' routine after response '{responseIdOnWhichToTrigger}'.

### Properties

| Name         | Value     |
| ------------ | --------- |
| Category     | Pair      |
| Full Id      | 9.2.2     |
| Severity     | Major     |
| Certainty    | Certain   |
| Source       | Validator |
| Fix Impact   | Breaking  |
| Has Code Fix | False     |

### Details

Typically when a pair contains multiple responses, a clear response routine needs to be implemented in order to make sure parameters gets updated correctly.  
There are 2 possible ways to implement the clear routine.  
However, the first one is recommended as it is more efficient.  
    \- Recommended way: After response X, clear all other responses present in the same pair.  
    \- Alternative way: After response X, clear response X.
