---  
uid: Validator_7_3_24  
---

# CheckOptionsAttribute

## UnknownOptionInPingOption

### Description

 Unknown option '{optionName}' detected in 'ping' option.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.24      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The timer options are formatted as follows: \<optionName\>\=\<optionValue\> where \<optionName\> should be one of the following:  
 \- rttColumn  
 \- timeoutPid  
 \- ttl  
 \- timeout  
 \- timestampColumn  
 \- type  
 \- size  
 \- continueSnmpOnTimeout  
 \- jitterColumn  
 \- latencyColumn  
 \- packetLossRateColumn  
 \- amountPacketsMeasurements  
 \- amountPacketsMeasurementsPid  
 \- amountPackets  
 \- amountPacketsPid  
 \- excludeWorstResults  
 \- excludeWorstResultsPid  
Options should be separated by a comma (',').
