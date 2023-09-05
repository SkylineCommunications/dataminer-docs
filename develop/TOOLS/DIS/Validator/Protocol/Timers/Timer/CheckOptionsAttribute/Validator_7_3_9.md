---  
uid: Validator_7_3_9  
---

# CheckOptionsAttribute

## InvalidDynamicThreadPoolOption

### Description

Invalid value for 'dynamicThreadPool' option. Expected format: 'dynamicThreadPool:\<threadPoolSizeMonitorPid\>'. Current value '{optionValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.9       |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Expected format: 'dynamicThreadPool:\<threadPoolSizeMonitorPid\>', where \<threadPoolSizeMonitorPid\> specifies the ID of the parameter that will be used to show the current size of the thread pool.
