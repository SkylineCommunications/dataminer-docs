---
uid: I-DOCSIS_KPIs
---

# Available KPIs in I-DOCSIS

This section lists the available KPIs for each topology level in the I-DOCSIS branch of the EPM Solution.

## Network

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

## Market

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

## Hub

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

## CCAP Core (CMTS)

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
- **CMTS State**: Set to "OK" if the CMTS is reachable or "Timeout" if the CMTS is unreachable.

## Linecard

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

## DS Port

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

## US Service Group

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

## Service Group (Fiber Node)

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

## Node Segment

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

## CM DS QAM CH

- **DS QAM Ch Rx Power**: The downstream Rx (Receive) power for the given CM-channel combination as reported by the CM (OID: 1.3.6.1.2.1.10.127.1.1.1.1.6).
- **DS QAM Ch SNR**: The downstream SNR for the given CM-channel combination as reported by the CM (OID: 1.3.6.1.2.1.10.127.1.1.4.1.5).
- **DS QAM Ch MER**: The downstream channel MER (OID: 1.3.6.1.4.1.4491.2.1.20.1.24.1.1).
- **DS QAM Ch Corrected Packet Ratio**: The Downstream Corrected Ratio for the given CM-channel combination as calculated by DataMiner. Corrected Ratio = (Corrected Difference * 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.9; Unerrored – OID: 1.3.6.1.2.1.10.127.1.1.4.1.8; Uncorrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.10.
- **DS QAM Ch Uncorrectable Packet Ratio**: The Downstream Uncorrectable Ratio for the given CM-channel combination as calculated by DataMiner. Uncorrectable Ratio = (Uncorrected Difference * 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference). Corrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.9; Unerrored – OID: 1.3.6.1.2.1.10.127.1.1.4.1.8; Uncorrected – OID: 1.3.6.1.2.1.10.127.1.1.4.1.10.

## DS QAM CH

- **Name**: The display name of the downstream channel. Concatenation of the CMTS name and the DS channel name. Uses "/" as a separator.
- DS Service Group Name
- DS Ch Name
- Service Group [Fiber Node] Name
- Node Segment Name
- DS QAM Ch Frequency
- DS QAM Ch Width
- DS QAM Ch Modulation
- DS QAM Ch Rx Power
- DS QAM Ch SNR
- DS QAM Ch MER
- DS QAM Ch Corrected Packet Ratio
- DS QAM Ch Uncorrectable Packet Ratio
- DS QAM Ch Utilization

## CM US QAM CH

- US QAM Ch Tx Power
- US QAM Ch NMTER
- US QAM Ch PreMTTER
- US QAM Ch PostMTTER
- US QAM Ch Reflection Distance
- US QAM Ch NMTER Alarm Status
- US QAM Ch PreMTTER Alarm Status
- US QAM Ch PostMTTER Alarm Status
- US QAM Ch MTC
- US QAM Ch D3.0 PNM Problem Type

## US QAM CH

- Name
- US Service Group Name
- US Ch Name
- Service Group [Fiber Node] Name
- Node Segment Name
- US QAM Ch Frequency
- US QAM Ch Width
- US QAM Ch Modulation
- US QAM Ch Rx Power
- US QAM Ch Power Fluctuation
- US QAM Ch SNR
- US QAM Ch MER
- US QAM Ch Time Offset
- US QAM Ch Corrected Packet Ratio
- US QAM Ch Uncorrectable Packet Ratio
- US QAM Ch Utilization

## DS OFDM CH

- Ch ID
- OFDM Lower Freq.
- OFDM Upper Freq.
- OFDM Channel Width
- OFDM Number of Subcarriers
- OFDM Rx DS Power
- OFDM Corrected Ratio
- OFDM Uncorrectable Ratio
- OFDM PNM RX MER Mean

## US OFDMA CH

- Ch ID
- OFDMA Lower Freq.
- OFDMA Upper Freq.
- OFDMA Subcarrier Spacing
- OFDMA Rx US Power
- OFDMA Tx US Power
- OFDMA US Mean Rx MER
- OFDMA Rx US Power Fluctuations
- OFDMA Corrected Ratio
- OFDMA Uncorrectable Ratio
- OFDMA Channel Width
- OFDMA Max Number of Subcarriers
- OFDMA Microreflections
- OFDMA US Mean StdDev Rx MER
- OFDMA US T4timeouts

## Cable Modem

### CM Info

- MAC
- Interface
- Vendor
- Model Number
- System Name
- DOCSIS Version
- Hardware Version
- Software Version
- Boot ROM Version
- Memory Size
- Software Operational Status
- Processor Utilization
- Memory Utilization
- Uptime

### CM Status

- Last Successful CMTS Poll
- Status
- Last Registration Time

### Subscriber

- IPv4 Address
- Latitude
- Longitude

### Parent Entities

- CCAP Core Name
- Node Segment Name
- Service Group [Fiber Node] Name
- Optical Node Name

### US QAM

- US QAM Rx Power Status
- US QAM Tx Power Status
- US QAM SNR Status
- US QAM Post-FEC Status
- US Time Offset Status

### DS QAM

- DS QAM Rx Power Status
- DS QAM SNR Status
- DS QAM Post-FEC Status

### D3.0 PNM

- Group Delay Status
- Reflection Status
- Average Reflection Distance
- Group Delay or Reflection Status

### Ping Stats

- RTT
- Jitter
- Latency
- Packet Loss Rate

## Thresholds

### Upstream QAM Channel Thresholds

- Upstream Maximum Timing Offset
- Upstream Channel Minimum Rx Power Level
- Upstream Channel Maximum Rx Power Level
- Upstream Channel Minimum Tx Power Level
- Upstream Channel Maximum Tx Power Level
- Upstream Channel Minimum SNR
- Upstream Channel Post-FEC Maximum Uncorrectable Error Ratio

### Downstream QAM Channel Thresholds

- Dowstream Channel Minimum Rx Power Level
- Dowstream Channel Maximum Rx Power Level
- Dowstream Channel Minimum SNR
- Dowstream Channel Post-FEC Maximum Uncorrectable Error Ratio

### D3.0 PNM Thresholds

- Non-Main-Tap Energy Ratio (NMTER) Threshold
- Pre-Main-Tap to Total Energy Ratio (Pre-MTTER) Threshold
- Post-Main-Tap to Total Energy Ratio (Post-MTTER) Threshold
