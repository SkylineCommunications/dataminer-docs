---
uid: I-DOCSIS_parameters
---

# Available parameters in I-DOCSIS

This section lists the available parameters for each topology level in the I-DOCSIS branch of the EPM Solution.

## Network

### Network KPIs & KQIs

- **Number Market**
- **Number Hub**
- **Number CCAP Core**
- **Number Service Group**
- **Number CM**
- **Number CM Offline**
- **Percentage CM Offline**
- **Number CM DOCSIS 2.0**
- **Number CM DOCSIS 3.0**
- **Number CM DOCSIS 3.1**
- **Number CM Ping OK**
- **Percentage CM Ping OK**
- **Number CM Ping Unreachable**
- **Percentage CM Ping Unreachable**
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

### Network system parameters

- **ID**
- **Name**
- **Network**

## Market

### Market KPIs & KQIs

- **Number Hub**
- **Number CCAP Core**
- **Number Service Group**
- **Number CM**
- **Number CM Offline**
- **Percentage CM Offline**
- **Number CM DOCSIS 2.0**
- **Number CM DOCSIS 3.0**
- **Number CM DOCSIS 3.1**
- **Number CM Ping OK**
- **Percentage CM Ping OK**
- **Number CM Ping Unreachable**
- **Percentage CM Ping Unreachable**
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

### Market system parameters

- **ID**
- **Name**
- **Network**

## Hub

### Hub KPIs & KQIs

- **Number CCAP Core**
- **Number Service Group**
- **Number CM**
- **Number CM Offline**
- **Percentage CM Offline**
- **Number CM DOCSIS 2.0**
- **Number CM DOCSIS 3.0**
- **Number CM DOCSIS 3.1**
- **Number CM Ping OK**
- **Percentage CM Ping OK**
- **Number CM Ping Unreachable**
- **Percentage CM Ping Unreachable**
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

### Hub system parameters

- **ID**
- **Name**
- **Network**

## CCAP Core (CMTS)

### CCAP Core (CMTS) KPIs & KQIs

- **Number Service Group**
- **Number CM**
- **Number CM Offline**
- **Percentage CM Offline**
- **Number CM DOCSIS 2.0**
- **Number CM DOCSIS 3.0**
- **Number CM DOCSIS 3.1**
- **Number CM Ping OK**
- **Percentage CM Ping OK**
- **Number CM Ping Unreachable**
- **Percentage CM Ping Unreachable**
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **CMTS State**: Direct value. Possible values: *OK* if the CMTS is reachable, and *Timeout* if the CMTS is not reachable.

### CCAP Core (CMTS) system parameters

- **Name**
- **System Name**
- **Device Type**
- **Serial Number**
- **Model**
- **IPv4**
- **City**
- **Site**
- **Software Version**
- **Network Name**
- **Market Name**
- **Hub Name**

## Linecard

### Linecard KPIs & KQIs

- **Number CM**
- **Number CM Offline**
- **Percentage CM Offline**
- **Number CM Online**
- **Percentage CM Online**
- **Number CM DOCSIS 2.0**
- **Number CM DOCSIS 3.0**
- **Number CM DOCSIS 3.1**
- **Number CM Ping OK**
- **Percentage CM Ping OK**
- **Number CM Ping Unreachable**
- **Percentage CM Ping Unreachable**
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

### Linecard system parameters

- **ID**
- **Name**
- **CCAP Core Name**

## DS Port

### DS Port KPIS & KQIs

- **Number CM**: The number of CMs served by the DS port. Calculated by aggregating the number of CMs associated with the DS port.
- **Number CM Offline**: The number of offline CMs associated with the DS port, from the CCAP perspective. Calculated by aggregating the number of CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (1 Other = Offline, 8 Operational = Online, any other value = Initializing).
- **Percentage CM Offline**: The percentage of offline CMs associated with the DS port, from the CCAP perspective. Calculated based on the CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (1 Other = Offline, 8 Operational = Online, any other value = Initializing).
- **Number [2.0, 3.0, 3.1] CM**: The number of CMs served by the DS port for the relevant DOCSIS version. Calculated by aggregating the number of CMs according to the DOCSIS version as reported by the CM MIBs (OID: 1.3.6.1.2.1.10.127.1.1.5).
- **Number CM Ping Status OK**: Calculated. The number of CMs associated with the DS port that are reporting Ping Status OK.
- **Percentage CM Ping OK**: Calculated. The percentage of CMs associated with the DS port that are reporting Ping Status OK.
- **Number CM Ping Unreachable**: Calculated. The number of CMs associated with the DS port that are reporting Ping Status Unreachable.
- **Percentage CM Ping Unreachable**: Calculated. The percentage of CMs associated with the DS port that are reporting Ping Status Unreachable.
- **CH Utilization**: Calculated. The average utilization of all DS channels associated with the DS port.
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

## US Port

### US Port KPIS & KQIs

- **Number CM**: The number of CMs served by the US port. Calculated by aggregating the number of CMs associated with the US port.
- **Number CM Offline**: The number of offline CMs associated with the US port, from the CCAP perspective. Calculated by aggregating the number of CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (1 Other = Offline, 8 Operational = Online, any other value = Initializing).
- **Percentage CM Offline**: The percentage of offline CMs associated with the US port, from the CCAP perspective. Calculated based on the CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (1 Other = Offline, 8 Operational = Online, any other value = Initializing).
- **Number [2.0, 3.0, 3.1] CM**: The number of CMs served by the US port for the relevant DOCSIS version. Calculated by aggregating the number of CMs according to the DOCSIS version as reported by the CM MIBs (OID: 1.3.6.1.2.1.10.127.1.1.5).
- **Number CM Ping OK**: Calculated. The number of CMs associated with the US port that are reporting Ping Status OK.
- **Percentage CM Ping OK**: Calculated. The percentage of CMs associated with the US port that are reporting Ping Status OK.
- **Number CM Ping Unreachable**: Calculated. The number of CMs associated with the US port that are reporting Ping Status Unreachable.
- **Percentage CM Ping Unreachable**: Calculated. The percentage of CMs associated with the US port that are reporting Ping Status Unreachable.
- **CH Utilization**: Calculated. The average utilization of all US channels associated with the US port.
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

## DS Service Group

### DS Service Group KPIS & KQIs

- **Number CM**
- **Number CM Offline**
- **Percentage CM Offline**
- **Number CM Online**
- **Percentage CM Online**
- **Number CM DS SNR OOS**
- **Percentage CM DS SNR OOS**
- **Number CM DS Power OOS**
- **Percentage CM DS Power OOS**
- **Number CM DS Post-FEC OOS**
- **Percentage CM DS Post-FEC OOS**
- **Number CM DOCSIS 2.0**
- **Number CM DOCSIS 3.0**
- **Number CM DOCSIS 3.1**
- **Number CM Ping OK**
- **Percentage CM Ping OK**
- **Number CM Ping Unreachable**
- **Percentage CM Ping Unreachable**
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

### DS Service Group system parameters

- **Name**
- **FN Name**
- **Linecard Name**

## US Service Group

### US Service Group KPIS & KQIs

- **Number CM**
- **Number CM Offline**
- **Percentage CM Offline**
- **Number CM Online**
- **Percentage CM Online**
- **Number CM US SNR OOS**
- **Percentage CM US SNR OOS**
- **Number CM US Power OOS**
- **Percentage CM US Power OOS**
- **Number CM US Post-FEC OOS**
- **Percentage CM US Post-FEC OOS**
- **Number CM DOCSIS 2.0**
- **Number CM DOCSIS 3.0**
- **Number CM DOCSIS 3.1**
- **Number CM Ping OK**
- **Percentage CM Ping OK**
- **Number CM Ping Unreachable**
- **Percentage CM Ping Unreachable**
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

### US Service Group system parameters

- **Name**
- **FN Name**
- **Linecard Name**

## Service Group (Fiber Node)

### Service Group (Fiber Node) KPIS & KQIs

- **Number CM**
- **Number CM Offline**
- **Percentage CM Offline**
- **Number CM US SNR OOS**
- **Percentage CM US SNR OOS**
- **Number CM US Time Offset OOS**
- **Percentage CM US Time Offset OOS**
- **Number CM US Power OOS**
- **Percentage CM US Power OOS**
- **Number CM US Post-FEC OOS**
- **Percentage CM US Post-FEC OOS**
- **Number CM DS SNR OOS**
- **Percentage CM DS SNR OOS**
- **Number CM DS Power OOS**
- **Percentage CM DS Power OOS**
- **Number CM DS Post-FEC OOS**
- **Percentage CM DS Post-FEC OOS**
- **Number CM DOCSIS 2.0**
- **Number CM DOCSIS 3.0**
- **Number CM DOCSIS 3.1**
- **Number CM Ping OK**
- **Percentage CM Ping OK**
- **Number CM Ping Unreachable**
- **Percentage CM Ping Unreachable**
- **DS CH Utilization**: Calculated. The average utilization of all DS channels associated with the fiber node.
- **US CH Utilization**: Calculated. The average utilization of all US channels associated with the fiber node.
- **Number CM Group Delay OOS**: Calculated. The number of CMs associated with the given service group that are affected by group delay.
- **Percentage CM Group Delay OOS**: Calculated. The percentage of CMs associated with the given service group that are affected by group delay.
- **Number CM Reflection OOS**: Calculated. The number of CMs associated with the given service group that are affected by reflection.
- **Percentage CM Reflection OOS**: Calculated. The percentage of CMs associated with the given service group that are affected by reflection.
- **Number CM Group Delay or Reflection OOS**: Calculated. The number of CMs associated with the given service group that are affected by NMTER being out of spec (OOS).
- **Percentage CM Group Delay or Reflection OOS**: Calculated. The percentage of CMs associated with the given service group that are affected by NMTER being out of spec (OOS).
- **Average Reflection Distance**: Calculated. The average reflection distance for the CMs associated with the given service group.
- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

### Service Group (Fiber Node) system parameters

- **Name**
- **MAC Domain**
- **Cable Interface**
- **DS SG Name**
- **US SG Name**

## Node Segment

### Node segment KPIs & KQIs

- **Number CM**: Calculated. The number of cable modems associated with the node segment.
- **Number CM Offline**: Calculated. The number of cable modems associated with the node segment that are reporting a status other than Operational.
- **Percentage CM Offline**: Calculated. The percentage of cable modems associated with the node segment that are reporting a status other than Operational.
- **Number CM DOCSIS 1.x**: Calculated. The number of cable modems associated with the node segment that report their DOCSIS version as a version within the 1.x range. Any version within the 1.x range is included. A regular expression is applied to carry out the aggregation.
- **Number CM DOCSIS 2.0**: Calculated. The number of cable modems associated with the node segment that report their DOCSIS version as 2.0.
- **Number CM DOCSIS 3.0**: Calculated. The number of cable modems associated with the node segment that report their DOCSIS version as 3.0.
- **Number CM DOCSIS 3.1**: Calculated. The number of cable modems associated with the node segment that report their DOCSIS version as 3.1.
- **Number CM Ping Unreachable**: The number of cable modems associated with the node segment that are not reachable via ping from the hosting DataMiner Agent. Calculated based on the number of cable modems associated with the Node segment that report an RTT equal to Timeout or Wrong IP Format.
- **Percentage CM Ping Unreachable**: The percentage of cable modems associated with the node segment that are not reachable via ping from the hosting DataMiner Agent. Calculated based on the number of cable modems associated with the Node segment that report an RTT equal to Timeout or Wrong IP Format.
- **Number US QAM Ch.**: Calculated. The number of US (upstream) QAM channels associated with the node segment. This is the same number of channels as associated with the corresponding US port.
- **Number CM US QAM Ch. Rx Power OOS**: Calculated. The number of cable modems associated with the node segment reporting a US Rx Power Status equal to "OOS".
- **Percentage CM US QAM Ch. Rx Power OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a US Rx Power Status equal to "OOS".
- **Number CM US QAM Ch. Rx SNR OOS**: Calculated. The number of cable modems associated with the node segment reporting a US SNR Status equal to "OOS".
- **Percentage CM US QAM Ch. Rx SNR OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a US SNR Status equal to "OOS".
- **Number CM US QAM Ch. Rx Post-FEC OOS**: Calculated. The number of cable modems associated with the node segment reporting a US Post-FEC Status equal to "OOS".
- **Percentage CM US QAM Ch. Rx Post-FEC OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a US Post-FEC Status equal to "OOS".
- **Number CM US QAM Ch. Time Offset OOS**: Calculated. The number of cable modems associated with the node segment reporting a US Time Offset Status equal to "OOS".
- **Percentage CM US QAM Ch. Time Offset OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a US Time Offset Status equal to "OOS".
- **Number DS QAM Ch.**: Calculated. The number of DS (downstream) QAM channels associated with the node segment. This is the same number of channels as associated with the corresponding DS port.
- **Number CM DS QAM Ch. Rx Power OOS**: Calculated. The number of cable modems associated with the node segment reporting a DS Rx Power Status equal to "OOS".
- **Percentage CM DS QAM Ch. Rx Power OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a DS Rx Power Status equal to "OOS".
- **Number CM DS QAM Ch. Rx SNR OOS**: Calculated. The number of cable modems associated with the node segment reporting a DS SNR Status equal to "OOS".
- **Percentage CM DS QAM Ch. Rx SNR OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a DS SNR Status equal to "OOS".
- **Number CM DS QAM Ch. Rx Post-FEC OOS**: Calculated. The number of cable modems associated with the node segment reporting a DS Post-FEC Status equal to "OOS".
- **Percentage CM DS QAM Ch. Rx Post-FEC OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a DS Post-FEC Status equal to "OOS".
- **Number CM Group Delay OOS**: Calculated. The number of cable modems associated with the given service group that are affected by group delay.
- **Percentage CM Group Delay OOS**: Calculated. The percentage of cable modems associated with the given service group that are affected by group delay.
- **Number CM Reflection OOS**: Calculated. The number of cable modems associated with the given service group that are affected by reflection.
- **Percentage CM Reflection OOS**: Calculated. The percentage of cable modems associated with the given service group that are affected by reflection.
- **Number CM Group Delay or Reflection OOS**: Calculated. The number of cable modems associated with the given service group that are affected by NMTER being out of spec (OOS).
- **Percentage CM Group Delay or Reflection OOS**: Calculated. The percentage of cable modems associated with the given service group that are affected by NMTER being out of spec (OOS).

### Node segment system parameters

- **Name**: Direct value. Concatenation of the CMTS name and the unique combination of a DS port and US port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service. There will be a node segment every time the connector detects a unique US/DS port combination serving at least one cable modem.
- **DS Port**: Direct value. The DS port associated with the node segment.
- **US Port**: Direct value. The US port associated with the node segment.

## CM DS QAM CH

- **DS QAM Ch Rx Power**: Direct value. The downstream Rx (Receive) power for the given CM-channel combination as reported by the CM (OID: 1.3.6.1.2.1.10.127.1.1.1.1.6).
- **DS QAM Ch SNR**: Direct value. The downstream SNR for the given CM-channel combination as reported by the CM (OID: 1.3.6.1.2.1.10.127.1.1.4.1.5).
- **DS QAM Ch MER**: Direct value. The downstream channel MER (OID: 1.3.6.1.4.1.4491.2.1.20.1.24.1.1).
- **DS QAM Ch Corrected Packet Ratio**: The Downstream Corrected Ratio for the given CM-channel combination as calculated by DataMiner. Calculated as follows: Corrected Ratio = (Corrected Difference * 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.9; Unerrored – OID: 1.3.6.1.2.1.10.127.1.1.4.1.8; Uncorrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.10.
- **DS QAM Ch Uncorrectable Packet Ratio**: The Downstream Uncorrectable Ratio for the given CM-channel combination as calculated by DataMiner. Calculated as follows: Uncorrectable Ratio = (Uncorrected Difference * 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.9; Unerrored – OID: 1.3.6.1.2.1.10.127.1.1.4.1.8; Uncorrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.10.

## DS QAM CH

- **Name**: Direct value. The display name of the downstream channel. Concatenation of the CMTS name and the DS channel name, using "/" as a separator.
- **DS Service Group Name**: Direct value. The display name of the downstream service groups associated with the downstream channel. Concatenation of the CMTS name, downstream port, and service group \[fiber node] system name, using "/" as a separator.
- **DS Ch Name**: Direct value. The display name of the downstream channel. Concatenation of the service group \[fiber node] system name and DS channel system name, using "/" as a separator.
- **Service Group \[Fiber Node] Name**: Direct value. The display name of the service group \[fiber node] associated with the downstream channel. Concatenation of the CMTS name, service group \[fiber node] system name, cable interface, and alias of the first channel associated with the cable interface, using "/" as a separator.
- **Node Segment Name**: Direct value. The display name of the node segment. Concatenation of the CMTS name and the unique combination of a DS port and US port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service. There will be a node segment every time the connector detects a unique US/DS port combination serving at least one cable modem.
- **DS QAM Ch Frequency**: Direct value. The DS QAM Ch Frequency (OID: 1.3.6.1.2.1.10.127.1.1.1.1.2) from any of the CM-channel relations.
- **DS QAM Ch Width**: Direct value. The DS QAM Ch Width (OID: 1.3.6.1.2.1.10.127.1.1.1.1.3) from any of the CM-channel relations.
- **DS QAM Ch Modulation**: Direct value. The DS QAM Ch Modulation (OID: 1.3.6.1.2.1.10.127.1.1.1.1.4) from any of the CM-channel relations. Possible Values: *Unknown*, *Other*, *QAM64*, *QAM256*.
- **DS QAM Ch Rx Power**: Calculated. Average value of the DS QAM Ch Rx power (OID: 1.3.6.1.2.1.10.127.1.1.1.1.6) related to the cable modems served by the given channel.
- **DS QAM Ch SNR**: Calculated. Average value of the DS QAM Ch SNR (OID: 1.3.6.1.2.1.10.127.1.1.4.1.5) related to the cable modems served by the given channel.
- **DS QAM Ch MER**: Calculated. Average value of the DS QAM Ch MER (OID:1.3.6.1.4.1.4491.2.1.20.1.24.1.1) related to the cable modems served by the given channel.
- **DS QAM Ch Corrected Packet Ratio**: The average value of the DS QAM Ch Corrected Packet Ratio related to the cable modems served by the given channel. Calculated as follows: Corrected Ratio = (Corrected Difference \* 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.9; Unerrored – OID: 1.3.6.1.2.1.10.127.1.1.4.1.8; Uncorrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.11.
- **DS QAM Ch Uncorrectable Packet Ratio**: The average value of the DS QAM Ch Uncorrectable Packet Ratio related to the cable modems served by the given channel. Calculated as follows: Uncorrectable Ratio = (Uncorrected Difference \* 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.9; Unerrored – OID: 1.3.6.1.2.1.10.127.1.1.4.1.8; Uncorrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.11.
- **DS QAM Ch Utilization**: The average value of the DS QAM Ch Utilization related to the cable modems served by the given channel. Calculated as follows: DS QAM Ch Utilization = (Current Nº octets transmitted - Nº octets transmitted previously) \* 8 \* 100 / (Delta \* Interface's current bandwidth). Nº octets transmitted – OID: 1.3.6.1.2.1.2.2.1.16; Interface's current bandwidth – OID: 1.3.6.1.2.1.2.2.1.5.

## CM US QAM CH

- **US QAM Ch Tx Power**: Direct value. The US Tx (transmit) power for the given CM-channel combination as reported by the cable modem. OID (D3.0): 1.3.6.1.2.1.10.127.1.2.2.1.3.2. OID (D2.0): 1.3.6.1.4.1.4491.2.1.20.1.2.1.1.
- **US QAM Ch NMTER**: The NMTER value of the channel. Only available for DOCSIS 3.x. Calculated based on the values of the Post-Main tap, Pre-Main tap and Main tap. All three of these values are contained in pre-equalization data (OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6).
- **US QAM Ch PreMTTER**: The PreMTTER value of the channel. Only available for DOCSIS 3.x. Calculated based on the values of the Pre-Main tap and the sum of the Main tap, Pre-Main tap, and Post-Main tap. These last three values are contained in pre-equalization data (OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6).
- **US QAM Ch PostMTTER**: The PostMTTER value of the channel. Only available for DOCSIS 3.x. Calculated based on the values of the Post-Main tap and the sum of the Main tap, Pre-Main tap, and Post-Main tap. These last three values are contained in pre-equalization data (OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6).
- **US QAM Ch Reflection Distance**: Calculated. Only available for DOCSIS 3.x. The reflection distance of the associated US channel.
- **US QAM Ch NMTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The NMTER alarm status. Possible values: *OOS* and *OK*. This alarm is based on the NMTER value being above or below the NMTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.
- **US QAM Ch PreMTTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The PreMTTER alarm status. Possible values: *OOS* and *OK*. This alarm is based on the PreMTTER value being above or below the PreMTTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.
- **US QAM Ch PostMTTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The PostMTTER alarm status. Possible values: *OOS* and *OK*. This alarm is based on the PostMTTER value being above or below the PostMTTER threshold. If the value is above the threshold, the alarm value is *OOS*, otherwise it is *OK*.
- **US QAM Ch MTC**: Only available for DOCSIS 3.x. The MTC value of a channel. Calculated as follows: MTC = (Main Tap + Pre-Main Tap + Post-Main Tap) / Main Tap. All values in this formula are contained in pre-equalization data (OID: 1.3.6.1.4.1.4491.2.1.20.1.2.1.6).
- **US QAM Ch D3.0 PNM Problem Type**: Calculated. Only available for DOCSIS 3.x. The PNM problem type. Possible values: *No Problem*, *Group Delay*, *Micro-Reflection*, *Group Delay and Micro-Reflection*. This problem type is obtained depending on several conditions:

  - If the NMTER value is lower than the NMTER threshold, the problem type is *No Problem*.
  - If (PreMTTER - PostMTTER) > 0, the problem type is *Group Delay*.
  - If the PostMTTER value is higher than or equal to the PostMTTER threshold, the problem type is *Micro-Reflection*.
  - If both of the conditions above apply, the problem type is *Group Delay and Micro-Reflection*.

## US QAM CH

- **Name**: Direct value. The display name of the upstream channel. Concatenation of the CMTS name and the US channel name, using "/" as a separator.
- **US Service Group Name**: Direct value. The display name of the upstream service groups associated with the upstream channel. Concatenation of the CMTS name, upstream port, and service group \[fiber node] system name, using "/" as a separator.
- **US Ch Name**: Direct value. The display name of the upstream channel. Concatenation of the service group \[fiber node] system name and US channel system name, using "/" as a separator.
- **Service Group \[Fiber Node] Name**: Direct value. The display name of the service group \[fiber node] associated with the upstream channel. Concatenation of the CMTS name, service group \[fiber node] system name, cable interface, and alias of the first channel associated with the cable interface, using "/" as a separator.
- **Node Segment Name**: Direct value. The display name of the node segment associated with the upstream channel. Concatenation of the CMTS name and the unique combination of a DS port and US port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service. There will be a node segment every time the connector detects a unique US/DS port combination serving at least one cable modem.
- **US QAM Ch Frequency**: Direct value. The US QAM Ch Frequency (OID: 1.3.6.1.2.1.10.127.1.1.2.1.2) from any of the CM-channel relations.
- **US QAM Ch Width**: Direct value. The US QAM Ch Width (OID: 1.3.6.1.2.1.10.127.1.1.2.1.3) from any of the CM-channel relations.
- **US QAM Ch Modulation**: Direct value. The US QAM Ch Modulation (OID: 1.3.6.1.2.1.10.127.1.3.5.1.4) from any of the CM-channel relations.
- **US QAM Ch Rx Power**: Direct value. The average value of the US QAM Ch Rx power related to the cable modems served by the given channel. OID (D3.0): 1.3.6.1.4.1.4491.2.1.20.1.4.1.3. OID (D2.0): 1.3.6.1.2.1.10.127.1.3.3.1.6.
- **US QAM Ch Power Fluctuation**: Calculated. Only available for DOCSIS 3.x. Average value of the US QAM Ch Power Fluctuation related to the cable modems served by the given channel. The power fluctuation is the difference between expected Rx power (OID: 1.3.6.1.4.1.4491.2.1.20.1.25.1.2) and the Rx power (OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.3).
- **US QAM Ch SNR**: Direct value. Average value of the US QAM Ch SNR related to the cable modems served by the given channel. OID (D3.0): 1.3.6.1.4.1.4491.2.1.20.1.4.1.4. OID (D2.0): 1.3.6.1.2.1.10.127.1.3.3.1.13.
- **US QAM Ch MER**: Direct value. Only available for DOCSIS 3.x. Average value of the US QAM Ch MER related to the cable modems served by the given channel. OID: 1.3.6.1.4.1.4491.2.1.20.1.24.1.1.
- **US QAM Ch Time Offset**: Direct value. The average value of the US QAM Ch Time Offset related to the cable modems served by the given channel. OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.10.
- **US QAM Ch Corrected Packet Ratio**: The average value of the US QAM Ch Corrected Packet Ratio related to the cable modems served by the given channel. Calculated as follows: Corrected Packet Ratio = (Corrected Difference \* 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.8 – OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.16; Unerrored – OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.7 – OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.15; Uncorrected – OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.9 – OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.17.
- **US QAM Ch Uncorrectable Packet Ratio**: The average value of the US QAM Ch Uncorrectable Packet Ratio related to the cable modems served by the given channel. Calculated as follows: Uncorrectable Packet Ratio = (Uncorrected Difference \* 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.8 – OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.16; Unerrored – OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.7 – OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.15; Uncorrected – OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.9 – OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.17.
- **US QAM Ch Utilization**: The average value of the US QAM Ch Utilization related to the cable modems served by the given channel. Calculated as follows: US QAM Ch Utilization = (Current Nº octets received - Nº octets received previously) \* 8 \* 100 / (Delta \* Interface's current bandwidth). Nº octets received – OID: 1.3.6.1.2.1.2.2.1.10; Interface's current bandwidth – OID: 1.3.6.1.2.1.2.2.1.5.

## DS OFDM CH

## DS OFDM CH KPIs & KQIs

- **Ch ID**
- **OFDM Lower Freq.**: Direct value. Represents either the lower boundary frequency of the lower guardband or, if no guardband is defined, the lower boundary frequency of the lowest active subcarrier of the OFDM downstream channel.
- **OFDM Upper Freq.**: Direct value. Represents either the upper boundary frequency of the upper guardband or, if no guardband is defined, the upper boundary frequency of the highest active subcarrier of the OFDM downstream channel.
- **OFDM Channel Width**: Direct value.
- **OFDM Number of Subcarriers**
- **OFDM Rx DS Power**
- **OFDM Corrected Ratio**
- **OFDM Uncorrectable Ratio**
- **OFDM PNM RX MER Mean**

## US OFDMA CH

### US OFDMA CH KPIs & KQIs

- **Ch ID**
- **OFDMA Lower Freq.**
- **OFDMA Upper Freq.**
- **OFDMA Subcarrier Spacing**
- **OFDMA Rx US Power**
- **OFDMA Tx US Power**
- **OFDMA US Mean Rx MER**
- **OFDMA Rx US Power Fluctuations**
- **OFDMA Corrected Ratio**
- **OFDMA Uncorrectable Ratio**
- **OFDMA Channel Width**
- **OFDMA Max Number of Subcarriers**
- **OFDMA Microreflections**
- **OFDMA US Mean StdDev Rx MER**
- **OFDMA US T4timeouts**

### US OFDMA CH system parameters

- **ID**
- **Frequency**
- **Width**
- **Modulation**

## Cable Modem

### CM Info

- **MAC**: Direct value. The MAC address of the cable modem. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.2.
- **Interface**: Direct value. The interface of the cable modem. OID: 1.3.6.1.2.1.2.2.1.2.
- **Vendor**: Direct value. The vendor of the cable modem. Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).
- **Model Number**: Direct value. The model number of the cable modem. Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).
- **System Name**: Direct value. The administratively assigned name of the cable modem. OID: 1.3.6.1.2.1.1.5.0.
- **DOCSIS Version**: Direct value. The DOCSIS capability of the device. Possible Values: *DOCSIS 1.x*, *DOCSIS 2.0*, *DOCSIS 3.0*, and *DOCSIS 3.1*. OID: 1.3.6.1.2.1.10.127.1.1.5.
- **Hardware Version**: Direct value. The hardware version of the cable modem. Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).
- **Software Version**: Direct value. The software version of the cable modem. Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).
- **Boot ROM Version**: Direct value. The boot ROM version of the cable modem. Retrieved from the system description (OID: 1.3.6.1.2.1.1.1.0).
- **Memory Size**: The memory size of the cable modem. Calculated as follows: Total Memory Size = (MemorySize * MemoryUnits) / 1648576. Memory Size – OID: 1.3.6.1.2.1.25.2.3.1.5. MemoryUnits – OID: 1.3.6.1.2.1.25.2.3.1.4.
- **Software Operational Status**: Direct value. The software operational status of the cable modem. Possible Values: *In Progress*, *Complete From Provisioning*, *Complete From Management*, *Failed*, *Other*, and *Not Available*. OID: 1.3.6.1.2.1.69.1.3.4.0.
- **Processor Utilization**: Direct value. The processor utilization of the cable modem.
- **Memory Utilization**: The memory utilization of the cable modem. Calculated by dividing the memory used (OID: 1.3.6.1.2.1.25.2.3.1.6) by the memory size (OID: 1.3.6.1.2.1.25.2.3.1.5).
- **Uptime**: Direct value. The uptime of the cable modem. OID: 1.3.6.1.2.1.1.3.0.

### CM Status

- **Last Successful CMTS Poll**: Calculated. The date and time of the last successful polling cycle based on Status, Last Registration Time, and System ID returning valid data.
- **Status**: Direct value. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6.
- **Last Registration Time**: Direct value. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.14.

### Subscriber

- **IPv4 Address**: Direct value. The IPV4 address of the cable modem. OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.5.
- **Latitude**: Direct value. The subscriber position latitude.
- **Longitude**: Direct value.

### Parent Entities

- **CCAP Core Name**: Direct value. The CMTS core device associated with the cable modem. The EPM engine makes this association via import operation.
- **Node Segment Name**: Direct value. The node segment is the unique combination of a DS (downstream) port and US (upstream) port. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service.
- **Service Group \[Fiber Node] Name**: Direct value. The EPM engine makes this association via import operation.
- **Optical Node Name**: Direct value. The optical node associated with the subscriber. The EPM engine makes this association via import operation.

### US QAM

- **US QAM Rx Power Status**: Calculated. The CM US Rx Power Status based on operational thresholds. This is based on the existence of at least one associated upstream QAM channel reporting valid US Rx Power values, which are put through the Upstream Channel Minimum/Maximum Rx Power Level thresholds logic. Users will be able to set the thresholds that will be used to determine the US Rx Power Status. Possible values: *OK* if all US channels report US Rx Power within thresholds, and *OOS* if at least one US channel reports US Rx Power outside thresholds.
- **US QAM Tx Power Status**: Calculated. The CM US Tx Power Status based on operational thresholds. This is based on the existence of at least one associated upstream QAM channel reporting valid US Tx Power values, which are put through the Upstream Channel Minimum/Maximum Tx Power Level thresholds logic. Users will be able to set the thresholds that will be used to determine the US Tx Power Status. Possible values: *OK* if all US channels report US Tx Power within thresholds, and *OOS* if at least one US channel reports US Tx Power outside thresholds.
- **US QAM SNR Status**: Calculated. The CM US SNR Status based on operational thresholds. This is based on the existence of at least one associated upstream QAM channel reporting valid SNR values, which are put through the Upstream Channel Minimum SNR threshold logic. Users will be able to set the threshold that will be used to determine the SNR Status. Possible values: *OK* if all US channels report US SNR at or above the threshold, and *OOS* if at least one US channel reports US SNR below the threshold.
- **US QAM Post-FEC Status**: Calculated. The US Post-FEC Status based on operational thresholds. This is based on the existence of at least one associated upstream QAM channel reporting valid Uncorrectable Ratio values, which are put through the Upstream Channel Post-FEC Maximum Uncorrectable Error Ratio threshold logic. Users will be able to set the threshold that will be used to determine the US Post-FEC Status. Possible values: *OK* if all US channels report an Uncorrectable Ratio below or at the threshold, and *OOS* if at least one US channel reports an Uncorrectable Ratio above the threshold.
- **US Time Offset Status**: Calculated. The CM US Time Offset Status based on operational thresholds. This is based on the existence of at least one associated upstream QAM channel reporting valid US Time Offset values, which are put through the Upstream Maximum Timing Offset threshold logic. Users will be able to set the threshold that will be used to determine the US Time Offset Status. Possible values: *OK* if all US channels report a US Time Offset at or below the threshold, and *OOS* if at least one US channel reports a US Time Offset above the threshold.

### DS QAM

- **DS QAM Rx Power Status**: Calculated. The CM DS Rx Power Status based on operational thresholds. This is based on the existence of at least one associated downstream QAM channel reporting valid DS Rx Power values, which are put through the Downstream Channel Minimum/Maximum Rx Power Level thresholds logic. Users will be able to set the thresholds that will be used to determine the DS Rx Power Status. Possible values: *OK* if all DS channels report DS Rx Power within thresholds, and *OOS* if at least one DS channel reports DS Rx Power outside thresholds.
- **DS QAM SNR Status**: Calculated. The CM DS SNR Status based on operational thresholds. This is based on the existence of at least one associated downstream QAM channel reporting valid SNR values, which are put through the Downstream Channel Minimum SNR threshold logic. Users will be able to set the threshold that will be used to determine the SNR Status. Possible values: *OK* if all DS channels report DS SNR at or above the threshold, and *OOS* if at least one DS channel reports DS SNR below the threshold.
- **DS QAM Post-FEC Status**: Calculated. The DS Post-FEC Status based on operational thresholds. This is based on the existence of at least one associated downstream QAM channel reporting valid Uncorrectable Ratio values, which are put through the Downstream Channel Post-FEC Maximum Uncorrectable Error Ratio threshold logic. Users will be able to set the threshold that will be used to determine the DS Post-FEC Status. Possible values: *OK* if all DS channels report an Uncorrectable Ratio below or at the threshold, and *OOS* if at least one DS channel reports an Uncorrectable Ratio above the threshold.

### D3.0 PNM

- **Group Delay Status**: Calculated. The group delay status of the cable modem according to the PreMTTER values reported by the associated US channels. Possible values: *OK* if all associated US channels are operating within acceptable PreMTTER thresholds, and *OOS* (Out of Spec) if at least one US channel is operating outside acceptable PreMTTER thresholds.
- **Reflection Status**: Calculated. The reflection status of the cable modem according to the PostMTTER values reported by the associated US channels. Possible values: *OK* if all associated US channels are operating within acceptable PostMTTER thresholds, and *OOS* (Out of Spec) if at least one US channel is operating outside acceptable PostMTTER thresholds.
- **Average Reflection Distance**: Calculated. The average reflection distance of the associated US channels.
- **Group Delay or Reflection Status**: Calculated. The presence of group delay or reflection, based on the reported NMTER values of US channels associated with the cable modem. Possible values: *OK* if all associated US channels are operating within acceptable NMTER thresholds, and *OOS* (Out of Spec) if at least one US channel is operating outside acceptable NMTER thresholds.

### Ping Stats

- **RTT**: Direct value. The average round trip time of the ping messages between DataMiner and the cable modem.
- **Jitter**: Direct value. The average fluctuation or variation of ping messages latency.
- **Latency**: Direct value. The average time it takes for the ping messages to travel from the DataMiner Agent to the cable modem.
- **Packet Loss Rate**: Direct value. The percentage of packets reported as lost from ping messages between the DataMiner Agent and the cable modem.

## Thresholds

### Upstream QAM Channel Thresholds

- **Upstream Maximum Timing Offset**: Calculated. The upper boundary for acceptable upstream (US) timing offset from the CMTS perspective. Targets the CM US Time Offset Status parameter using the US QAM Ch Time Offset for the underlying business logic. US QAM Ch Time Offset values above this threshold will set the CM US Time Offset Status to Out of Spec (OOS).
- **Upstream Channel Minimum Rx Power Level**: Calculated. The lower boundary for acceptable upstream (US) receive (Rx) power from the CMTS perspective. Targets the CM US QAM Rx Power Status parameter using the US QAM Ch Rx Power for the underlying business logic. US QAM Ch Rx Power values below this threshold will set the CM US QAM Rx Power Status to Out of Spec (OOS).
- **Upstream Channel Maximum Rx Power Level**: Calculated. The upper boundary for acceptable upstream (US) receive (Rx) power from the CMTS perspective. Targets the CM US QAM Rx Power Status parameter using the US QAM Ch Rx Power for the underlying business logic. US QAM Ch Rx Power values above this threshold will set the CM US QAM Rx Power Status to Out of Spec (OOS).
- **Upstream Channel Minimum Tx Power Level**: Calculated. The lower boundary for acceptable upstream (US) transmit (Tx) power from the cable modem (CM) perspective. Targets the CM US QAM Tx Power Status parameter using the US QAM Ch Tx Power for the underlying business logic. US QAM Ch Tx Power values below this threshold will set the CM US Tx Power Status to Out of Spec (OOS).
- **Upstream Channel Maximum Tx Power Level**: Calculated. The upper boundary for acceptable upstream (US) transmit (Tx) power from the cable modem (CM) perspective. Targets the CM US QAM Tx Power Status parameter using the US QAM Ch Tx Power for the underlying business logic. US QAM Ch Tx Power values above this threshold will set the CM US Tx Power Status to Out of Spec (OOS).
- **Upstream Channel Minimum SNR**: Calculated. The lower boundary for acceptable upstream (US) SNR from the CMTS perspective. Targets the CM US QAM SNR Status parameter using the US QAM Ch SNR for the underlying business logic. US QAM Ch SNR values below this threshold will set the CM US QAM SNR Status to Out of Spec (OOS).
- **Upstream Channel Post-FEC Maximum Uncorrectable Error Ratio**: Calculated. The upper boundary for acceptable upstream (US) Uncorrectable Ratio from the CMTS perspective. Targets the CM US QAM Post-FEC Status parameter using the US QAM Ch Uncorrectable Packet Ratio for the underlying business logic. US QAM Ch Uncorrectable Packet Ratio values above this threshold will set the CM US QAM Post-FEC Status to Out of Spec (OOS).

### Downstream QAM Channel Thresholds

- **Downstream Channel Minimum Rx Power Level**: Calculated. The lower boundary for acceptable downstream (DS) receive (Rx) power from the cable modem (CM) perspective. Targets the CM DS QAM Rx Power Status parameter using the DS QAM Ch Rx Power for the underlying business logic. DS QAM Ch Rx Power values below this threshold will set the CM DS QAM Rx Power Status to Out of Spec (OOS).
- **Downstream Channel Maximum Rx Power Level**: Calculated. The upper boundary for acceptable downstream (DS) receive (Rx) power from the cable modem (CM) perspective. Targets the CM DS QAM Rx Power Status parameter using the DS QAM Ch Rx Power for the underlying business logic. DS QAM Ch Rx Power values above this threshold will set the CM DS QAM Rx Power Status to Out of Spec (OOS).
- **Downstream Channel Minimum SNR**: Calculated. The lower boundary for acceptable downstream (DS) SNR from the cable modem (CM) perspective. Targets the CM DS QAM SNR Status parameter using the DS QAM Ch SNR for the underlying business logic. DS QAM Ch SNR values below this threshold will set the CM DS QAM SNR Status to Out of Spec (OOS).
- **Downstream Channel Post-FEC Maximum Uncorrectable Error Ratio**: Calculated. The upper boundary for acceptable downstream (DS) Uncorrectable Packet Ratio from the cable modem (CM) perspective. Targets the CM DS QAM Post-FEC Status parameter using the DS QAM Ch Uncorrectable Packet Ratio for the underlying business logic. DS QAM Ch Uncorrectable Packet Ratio values above this threshold will set the CM DS QAM Post-FEC Status to Out of Spec (OOS).

### D3.0 PNM Thresholds

- **Non-Main-Tap Energy Ratio (NMTER) Threshold**: Calculated. The upper boundary for acceptable NMTER from the cable modem perspective in relation to its upstream (US) channels. Targets the CM Group Delay or Reflection Status parameter using the US QAM Ch NMTER Alarm Status for the underlying business logic. US QAM Ch NMTER values above this threshold will set the US QAM Ch NMTER Alarm Status to Out of Spec (OOS). If at least one associated US channel reports its US QAM Ch NMTER Alarm Status as OOS, the CM Group Delay or Reflection Status will be set to OOS.
- **Pre-Main-Tap to Total Energy Ratio (Pre-MTTER) Threshold**: Calculated. The upper boundary for acceptable PreMTTER from the cable modem perspective in relation to its upstream (US) channels. Targets the CM Group Delay Status parameter using the US QAM Ch PreMTTER Alarm Status for the underlying business logic. US QAM Ch PreMTTER values above this threshold will set the US QAM Ch PreMTTER Alarm Status to Out of Spec (OOS). If at least one associated US Channel reports its US QAM Ch PreMTTER Alarm Status as OOS, the CM Group Delay Status will be set to OOS.
- **Post-Main-Tap to Total Energy Ratio (Post-MTTER) Threshold**: Calculated. The upper boundary for acceptable PostMTTER from the cable modem perspective in relation to its upstream (US) channels. Targets the CM Reflection Status parameter using the US QAM Ch PostMTTER Alarm Status for the underlying business logic. US QAM Ch PostMTTER values above this threshold will set the US QAM Ch PostMTTER Alarm Status to Out of Spec (OOS). If at least one associated US Channel reports its US QAM Ch PostMTTER Alarm Status as OOS, the CM Reflection Status will be set to OOS.
