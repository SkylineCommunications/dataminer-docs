---  
uid: Validator_7_3_21  
---

# CheckOptionsAttribute

## InvalidPingOption

### Description

Invalid value for 'ping' option. Current value: '{optionValue}'.

### Properties

| Name         | Value       |
| ------------ | ----------- |
| Category     | Timer       |
| Full Id      | 7.3.21      |
| Severity     | Major       |
| Certainty    | Certain     |
| Source       | Validator   |
| Fix Impact   | NonBreaking |
| Has Code Fix | False       |

### Details

The following configuration options are available in the 'ping' option (multiple options are separated with a comma (',') and the option value is defined using the following format \<optionName\>\=\<optionValue\>):  
 \- rttColumn: Specifies the 1\-based column where the RTT value (in ms) should be stored. The table this column belongs to is specified in the 'ip' option.  
 \- timeoutPid: (Obsolete) Specifies the ID of the parameter that will store the key of the row that resulted in timeout.  
 \- ttl: The time to live of the packet (maximum number of hops). Default: 10.  
 \- timeout: Max time (in ms) before the ping is flagged as timeout when no response is returned. Default: 500.  
 \- timestampColumn: Specifies the 1\-based column where the timestamp should be stored when the ping has been executed. The table this column belongs to is specified in the 'ip' option.  
 \- type: Specifies the type of ping that is used: ICMP or Winsock. Default: ICMP.  
 \- size: Specifies the payload size of the packet that is used to execute the ping. Default: 0.  
 \- continueSnmpOnTimeout: Specifies whether the group should be executed when the ping is in timeout.  
 \- jitterColumn: Specifies the 1\-based column index of the column that will contain the jitter (in ms).  The table this column belongs to is specified in the 'ip' option.  
 \- latencyColumn: Specifies the 1\-based column index of the column that will contain the latency (in ms).  The table this column belongs to is specified in the 'ip' option.  
 \- packetLossRateColumn: Specifies the 1\-based column index of the column that will contain the packet loss rate (decimal value ranging from 0.01 to 1).  The table this column belongs to is specified in the 'ip' option.  
 \- amountPacketMeasurements: Specifies the number of packets that will be sent for calculating the jitter, latency and packet loss rate.  
 \- amountPacketMeasurementsPid: Specifies the ID of the parameter that holds the number of packets that will be sent for calculating the jitter, latency and packet loss rate.  
 \- amountPackets: Specifies the number of packets to be sent to the device.  
 \- amountPacketsPid: Specifies the ID of the parameter that holds the number of packets to be sent to the device.  
 \- excludeWorstResults: Specifies the percentage of worst result to exclude.   
 excludeWorstResultsPid:  Specifies the ID of the parameter that holds the percentage of worst result to exclude.
