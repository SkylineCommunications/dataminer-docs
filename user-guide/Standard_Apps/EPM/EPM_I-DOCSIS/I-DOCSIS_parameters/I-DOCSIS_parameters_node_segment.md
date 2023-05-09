---
uid: I-DOCSIS_parameters_node_segment
---

# I-DOCSIS parameters – Node Segment

This page contains an overview of the Node Segment parameters available in the I-DOCSIS branch of the EPM Solution from version 6.1.5 onwards.

## KPIs & KQIs

- **Number CM**: Calculated. The number of cable modems associated with the node segment.

- **Number CM Offline**: Calculated. The number of cable modems associated with the node segment that are reporting a status other than "Operational".

- **Percentage CM Offline**: Calculated. The percentage of cable modems associated with the node segment that are reporting a status other than "Operational".

- **Number CM DOCSIS 1.x**: Calculated. The number of cable modems associated with the node segment that report their DOCSIS version as a version within the 1.x range. Any version within the 1.x range is included. A regular expression is applied to carry out the aggregation.

- **Number CM DOCSIS 2.0**: Calculated. The number of cable modems associated with the node segment that report their DOCSIS version as 2.0.

- **Number CM DOCSIS 3.0**: Calculated. The number of cable modems associated with the node segment that report their DOCSIS version as 3.0.

- **Number CM DOCSIS 3.1**: Calculated. The number of cable modems associated with the node segment that report their DOCSIS version as 3.1.

- **Number CM Ping Unreachable**: Calculated. The number of cable modems associated with the node segment that are not reachable via ping from the hosting DataMiner Agent.

  Calculated based on the number of cable modems associated with the node segment that report an RTT equal to "Timeout" or "Wrong IP Format".

- **Percentage CM Ping Unreachable**: Calculated. The percentage of cable modems associated with the node segment that are not reachable via ping from the hosting DataMiner Agent.

  Calculated based on the number of cable modems associated with the node segment that report an RTT equal to "Timeout" or "Wrong IP Format".

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

- **Reflection Distance**: The average reflection distance for all associated CMs.

- **Average Latency**: The average latency for all CMs associated with the given level.

- **Average jitter**: The average jitter for all CMs associated with the given level.

- **Average Packet Loss Rate**: The average packet loss rate for all CMs associated with the given level.

- **US Utilization**: The percentage US utilization of the channels associated with the port.

- **DS Utilization**: The percentage DS utilization of the channels associated with the port.

## System parameters

- **Name \[IDX]**: Direct value. The display name of the node segment.

  Concatenation of the CMTS name and the unique combination of a DS port and US port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service. There will be a node segment every time the connector detects a unique US/DS port combination serving at least one cable modem.

- **DS Port**: Direct value. The DS port associated with the node segment.

- **US Port**: Direct value. The US port associated with the node segment.
