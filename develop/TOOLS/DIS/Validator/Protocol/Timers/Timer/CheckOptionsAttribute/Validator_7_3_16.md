---  
uid: Validator_7_3_16  
---

# CheckOptionsAttribute

## InvalidThreadPoolOption

### Description

Invalid value for 'threadPool' option. Expected format: 'threadPool:\<size\>,\<calculationInterval\>,\<usagePid\>,\<waitingPid\>,\<maxDurationPid\>,\<avgDurationPid\>,\<counterPid\>,\<queueSize\>'. Current value '{optionValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.16      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

Expected format: 'threadPool:\<size\>,\<calculationInterval\>,\<usagePid\>,\<waitingPid\>,\<maxDurationPid\>,\<avgDurationPid\>,\<counterPid\>,\<stackSize\>', where:   
 \- \<size\> specifies the  maximum number of threads available in the thread pool.  
 \- \<calculationInterval\> specifies the thread statistics refresh interval (in s).  
 \- \<usagePid\> specifies the ID of the parameter that will display the number of threads that are in use (refreshes each \<calculationInterval\> s).  
 \- \<waitingPid\> specifies the ID of the parameter that will display the number of threads that are waiting because all the thread pool threads are in use (refreshes each \<calculationInterval\> s).  
 \- \<maxDurationPid\>: specifies the ID of the parameter that will display how long it took to execute the slowest thread during the last calculation interval (expressed in ms).  
 \- \<avgDurationPid\>: specifies the ID of the parameter that will display how long it took on average to execute a thread during the last calculation interval (expressed in ms).  
 \- \<counterPid\>: specifies the ID of the parameter that will display the number of threads that were finished during the last calculation interval.  
 \- \<queueSize\>: specifies the number of items that can be put in waiting  state. When the waiting thread pool has reached the stack size, a notice alarm is generated.
