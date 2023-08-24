---
uid: I-DOCSIS_parameters_us_qam_ch
---

# I-DOCSIS parameters – US QAM CH

This page contains an overview of the US QAM CH parameters available in the I-DOCSIS branch of the EPM Solution.

These parameters are displayed for the Node Segment and Service Group level in the I-DOCSIS dashboards.

- **Name \[IDX]**: Direct value. The display name of the upstream channel.

  Concatenation of the CMTS Name and the US Ch Name, using "/" as a separator.

- **US Service Group Name**: Direct value. The display name of the upstream service groups associated with the upstream channel.

  Concatenation of the CMTS Name, Upstream Port, and Service Group \[Fiber Node] System Name, using "/" as a separator.

- **US Ch Name**: Direct value. The display name of the upstream channel.

  Concatenation of the Service Group \[Fiber Node] System Name, and US Channel System Name, using "/" as a separator.

- **Service Group \[Fiber Node] Name**: Direct value. The display name of the service group \[fiber node] associated with the upstream channel.

  Concatenation of the CMTS Name, Service Group \[Fiber Node] System Name, Cable Interface, and alias of the first channel associated with the cable interface, using "/" as a separator.

- **Node Segment Name**: Direct value. The display name of the node segment associated with the upstream channel.

  Concatenation of the CMTS name and the unique combination of a DS port and US port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service. There will be a node segment every time the connector detects a unique US/DS port combination serving at least one cable modem.

- **US QAM Ch Frequency**: Direct value. The US QAM Ch Frequency from any of the CM-channel relations.

  OID: 1.3.6.1.2.1.10.127.1.1.2.1.2.

- **US QAM Ch Width**: Direct value. The US QAM Ch Width from any of the CM-channel relations.

  OID: 1.3.6.1.2.1.10.127.1.1.2.1.3.

- **US QAM Ch Modulation**: Direct value. The US QAM Ch Modulation from any of the CM-channel relations.

  OID: 1.3.6.1.2.1.10.127.1.3.5.1.4.

- **US QAM Ch Rx Power**: Direct value. The average value of the US QAM Ch Rx power related to the cable modems served by the given channel.

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.3

  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.6

- **US QAM Ch Tx Power**: Direct value. The average value of the US QAM Ch Tx power related to the cable modems served by the given channel.

  - OID D3.0: 1.3.6.1.2.1.10.127.1.2.2.1.3.2.

  - OID D2.0: 1.3.6.1.4.1.4491.2.1.20.1.2.1.1.

- **US QAM Ch Power Fluctuation**: Calculated. Only available for DOCSIS 3.x. Average value of the US QAM Ch Power Fluctuation related to the cable modems served by the given channel.

  The power fluctuation is the difference between expected Rx power (OID: 1.3.6.1.4.1.4491.2.1.20.1.25.1.2) and the Rx power (OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.3).

- **US QAM Ch SNR**: Direct value. Average value of the US QAM Ch SNR related to the cable modems served by the given channel.

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.4

  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.13.

- **US QAM Ch MER**: Direct value. Only available for DOCSIS 3.x. Average value of the US QAM Ch MER related to the cable modems served by the given channel.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.24.1.1.

- **US QAM Ch Time Offset**: Direct value. The average value of the US QAM Ch Time Offset related to the cable modems served by the given channel.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.10.

- **US QAM Ch Corrected Packet Ratio**: Calculated. The average value of the US QAM Ch Corrected Packet Ratio related to the cable modems served by the given channel.

  Calculated as follows: Corrected Packet Ratio = (Corrected Difference \* 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference).

  Corrected:

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.8
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.16

  Unerrored:

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.7
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.15

  Uncorrected:

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.9
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.17

- **US QAM Ch Uncorrectable Packet Ratio**: Calculated. The average value of the US QAM Ch Uncorrectable Packet Ratio related to the cable modems served by the given channel.

  Calculated as follows: Uncorrectable Packet Ratio = (Uncorrected Difference \* 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference).

  Corrected:

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.8
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.16

  Unerrored:

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.7
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.15

  Uncorrected

  - OID D3.0: 1.3.6.1.4.1.4491.2.1.20.1.4.1.9
  - OID D2.0: 1.3.6.1.2.1.10.127.1.3.3.1.17

- **US QAM Ch Utilization**: Calculated. The average value of the US QAM Ch Utilization related to the cable modems served by the given channel.

  Calculated as follows: US QAM Ch Utilization = (Current Nº octets received - Nº octets received previously) \* 8 \* 100 / (Delta \* Interface's current bandwidth).

  - Nº octets received: OID 1.3.6.1.2.1.2.2.1.10
  - Interface's current bandwidth: OID 1.3.6.1.2.1.2.2.1.5
 
- **Reflected Power Ratio**: Direct value. The average value of the Reflected Power Ratio related to the cable modems served by the given channel.

- **US QAM Ch NMTER**: Calculated. Only available for DOCSIS 3.x. Average value of the US QAM Ch NMTER as it relates to the CMs served by the given channel.

- **US QAM Ch PreMTTER**: Calculated. Only available for DOCSIS 3.x. Average value of the US QAM Ch PreMTTER as it relates to the CMs served by the given channel.

- **US QAM Ch PostMTTER**: Calculated. Only available for DOCSIS 3.x. Average value of the US QAM Ch PostMTTER as it relates to the CMs served by the given channel.

- **US QAM Ch Reflection Distance**: Calculated. Only available for DOCSIS 3.x. Average value of the US QAM Ch Reflection Distance as it relates to the CMs served by the given channel.

- **US QAM Ch NMTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The operational status of the average US QAM Ch NMTER according to the Non-Main-Tap Energy Ratio (NMTER) Threshold.

- **US QAM Ch PreMTTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The operational status of the average US QAM Ch PreMTTER according to the Non-Pre-Main-Tap to Total Energy Ratio (Pre-MTTER) Threshold.

- **US QAM Ch PostMTTER Alarm Status**: Calculated. Only available for DOCSIS 3.x. The operational status of the average US QAM Ch PostMTTER according to the Post-Main-Tap to Total Energy Ratio (Post-MTTER) Threshold.

- **US QAM Ch Input Bitrate**: Calculated. The average value of the DS QAM Ch Input Bitrate related to the cable modems served by the given channel.

  Calculated as follows: US QAM Ch Input Bitrate = (Current Nº octets received - Nº octets received previously) / (Delta \* 1000.0).

  - Nº octets received: OID 1.3.6.1.2.1.2.2.1.10
