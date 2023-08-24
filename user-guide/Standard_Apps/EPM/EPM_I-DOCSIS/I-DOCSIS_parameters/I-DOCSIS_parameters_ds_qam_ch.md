---
uid: I-DOCSIS_parameters_ds_qam_ch
---

# I-DOCSIS parameters – DS QAM CH

This page contains an overview of the DS QAM CH parameters available in the I-DOCSIS branch of the EPM Solution.

These parameters are displayed for the Node Segment and Service Group levels in the I-DOCSIS dashboards.

- **Name \[IDX]**: Direct value. The display name of the downstream channel.

  Concatenation of the CMTS name and the DS channel name, using "/" as a separator.

- **DS Service Group Name**: Direct value. The display name of the downstream service groups associated with the downstream channel.

  Concatenation of the CMTS name, downstream port, and service group \[fiber node] system name, using "/" as a separator.

- **DS Ch Name**: Direct value. The display name of the downstream channel.

  Concatenation of the service group \[fiber node] system name and DS channel system name, using "/" as a separator.

- **Service Group \[Fiber Node] Name**: Direct value. The display name of the service group \[fiber node] associated with the downstream channel.

  Concatenation of the CMTS name, service group \[fiber node] system name, cable interface, and alias of the first channel associated with the cable interface, using "/" as a separator.

- **Node Segment Name**: Direct value. The display name of the node segment.

  Concatenation of the CMTS name and the unique combination of a DS port and US port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service. There will be a node segment every time the connector detects a unique US/DS port combination serving at least one cable modem.

- **DS QAM Ch Frequency**: Direct value. The DS QAM Ch Frequency from any of the CM-channel relations.

  OID: 1.3.6.1.2.1.10.127.1.1.1.1.2.

- **DS QAM Ch Width**: Direct value. The DS QAM Ch Width from any of the CM-channel relations.

  OID: 1.3.6.1.2.1.10.127.1.1.1.1.3.

- **DS QAM Ch Modulation**: Direct value. The DS QAM Ch Modulation from any of the CM-channel relations. Possible Values: *Unknown*, *Other*, *QAM64*, *QAM256*.

  OID: 1.3.6.1.2.1.10.127.1.1.1.1.4.

- **DS QAM Ch Rx Power**: Calculated. Average value of the DS QAM Ch Rx power related to the cable modems served by the given channel.

  OID: 1.3.6.1.2.1.10.127.1.1.1.1.6.

- **DS QAM Ch SNR**: Calculated. Average value of the DS QAM Ch SNR related to the cable modems served by the given channel.

  OID: 1.3.6.1.2.1.10.127.1.1.4.1.5.

- **DS QAM Ch MER**: Calculated. Average value of the DS QAM Ch MER related to the cable modems served by the given channel.

  OID:1.3.6.1.4.1.4491.2.1.20.1.24.1.1.

- **DS QAM Ch Corrected Packet Ratio**: Calculated. The average value of the DS QAM Ch Corrected Packet Ratio related to the cable modems served by the given channel.

  Calculated as follows: Corrected Ratio = (Corrected Difference \* 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference).

  - Corrected: OID 1.3.6.1.2.1.10.127.1.1.4.1.9

  - Unerrored: OID 1.3.6.1.2.1.10.127.1.1.4.1.8

  - Uncorrected: OID 1.3.6.1.2.1.10.127.1.1.4.1.11

- **DS QAM Ch Uncorrectable Packet Ratio**: Calculated. The average value of the DS QAM Ch Uncorrectable Packet Ratio related to the cable modems served by the given channel.

  Calculated as follows: Uncorrectable Ratio = (Uncorrected Difference \* 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference).

  - Corrected: OID 1.3.6.1.2.1.10.127.1.1.4.1.9

  - Unerrored: OID 1.3.6.1.2.1.10.127.1.1.4.1.8

  - Uncorrected: OID 1.3.6.1.2.1.10.127.1.1.4.1.11

- **DS QAM Ch Utilization**: Calculated. The average value of the DS QAM Ch Utilization related to the cable modems served by the given channel.

  Calculated as follows: DS QAM Ch Utilization = (Current Nº octets transmitted - Nº octets transmitted previously) \* 8 \* 100 / (Delta \* Interface's current bandwidth).

  - Nº octets transmitted: OID 1.3.6.1.2.1.2.2.1.16

  - Interface's current bandwidth: OID 1.3.6.1.2.1.2.2.1.5

- **DS QAM Ch Output Bitrate**: Calculated. The average value of the DS QAM Ch Output Bitrate related to the cable modems served by the given channel.

  Calculated as follows: DS QAM Ch Output Bitrate = (Current Nº octets transmitted - Nº octets transmitted previously) / (Delta \* 1000.0).

  - Nº octets transmitted: OID 1.3.6.1.2.1.2.2.1.16
