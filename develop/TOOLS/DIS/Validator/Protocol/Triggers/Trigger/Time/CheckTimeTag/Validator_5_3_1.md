---  
uid: Validator_5_3_1  
---

# CheckTimeTag

## MultipleAfterStartup

### Description

Multiple after startup Triggers. Trigger IDs '{triggerId}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Trigger     |
| Full Id      | 5.3.1       |
| Severity     | Warning     |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### How to fix

Multiple Trigger after Startup Triggers need to be checked and merged into one Trigger.

### Details

When defining multiple 'after startup' triggers, we have no way to know in which order those triggers will be executed. To keep things under control, it's better to have only one 'after startup' trigger.
