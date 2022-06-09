---
uid: I-DOCSIS_parameters_cm_ds_qam_ch
---

# I-DOCSIS parameters – CM DS QAM CH

This page contains an overview of the CM DS QAM CH parameters available in the I-DOCSIS branch of the EPM Solution.

- **Name \[IDX]**: Direct value. The display name of the CM-channel relation.

  Concatenation of the CM MAC, CMTS Name, and DS Ch Name, using "/" as a separator.

- **DS Service Group Name**: Direct value. The display name of the downstream service group associated with the downstream channel.

  Concatenation of the CMTS Name, Downstream Port, and Service Group \[Fiber Node] System Name, using "/" as a separator.

- **DS Ch Name**: Direct value. The display name of the downstream channel.

  Concatenation of the Service Group \[Fiber Node] System Name and DS Channel System Name, using "/" as a separator.

- **Service Group \[Fiber Node] Name**: Direct value. The display name of the service group \[fiber node] associated with the downstream channel.

  Concatenation of the CMTS Name, Service Group \[Fiber Node] System Name, Cable Interface, and alias of the first channel associated with the cable interface, using "/" as a separator.

- **Node Segment Name**: Direct value. The display name of the node segment.

  Concatenation of the CMTS Name and the unique combination of a DS (downstream) port and US (upstream) port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the I-DOCSIS service. There will be a node segment every time the connector detects a unique combination of US/DS port serving at least one cable modem.

- **DS QAM Ch Frequency**: Direct value.

- **DS QAM Ch Width**: Direct value.

- **DS QAM Ch Modulation**: Direct value.

- **DS QAM Ch Rx Power**: Direct value. The downstream Rx (Receive) power for the given CM-channel combination as reported by the CM.

  OID: 1.3.6.1.2.1.10.127.1.1.1.1.6.

- **DS QAM Ch SNR**: Direct value. The downstream SNR for the given CM-channel combination as reported by the CM.

  OID: 1.3.6.1.2.1.10.127.1.1.4.1.5.

- **DS QAM Ch MER**: Direct value. The downstream channel MER.

  OID: 1.3.6.1.4.1.4491.2.1.20.1.24.1.1.

- **DS QAM Ch Corrected Packet Ratio**: Calculated. The Downstream Corrected Ratio for the given CM-channel combination as calculated by DataMiner.

  Calculated as follows: Corrected Ratio = (Corrected Difference * 100) / (Corrected Difference + Unerrored Difference + Uncorrected Difference).

  - Corrected: OID 1.3.6.1.2.1.10.127.1.1.4.1.9

  - Unerrored: OID 1.3.6.1.2.1.10.127.1.1.4.1.8

  - Uncorrected: OID 1.3.6.1.2.1.10.127.1.1.4.1.10

- **DS QAM Ch Uncorrectable Packet Ratio**: Calculated. The Downstream Uncorrectable Ratio for the given CM-channel combination as calculated by DataMiner.

  Calculated as follows: Uncorrectable Ratio = (Uncorrected Difference * 1000,000) / (Corrected Difference + Unerrored Difference + Uncorrected Difference).

  - Corrected: OID 1.3.6.1.2.1.10.127.1.1.4.1.9

  - Unerrored: OID 1.3.6.1.2.1.10.127.1.1.4.1.8

  - Uncorrected OID: 1.3.6.1.2.1.10.127.1.1.4.1.10

- **DS QAM Ch Utilization**
