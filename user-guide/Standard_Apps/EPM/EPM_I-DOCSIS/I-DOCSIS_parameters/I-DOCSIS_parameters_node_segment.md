---
uid: I-DOCSIS_parameters_node_segment
keywords: I-DOCSIS parameters
---

# Integrated DOCSIS parameters – Node Segment

This page contains an overview of the Node Segment parameters available in the Integrated DOCSIS branch of the EPM Solution from version 6.1.5 onwards.

## KPIs & KQIs

- **Number CM US QAM Ch. Rx Power OOS**: Calculated. The number of cable modems associated with the node segment reporting a US Rx Power Status equal to "Out of Spec (OOS)".

- **Percentage CM US QAM Ch. Rx Power OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a US Rx Power Status equal to "Out of Spec (OOS)".

- **Number CM US QAM Ch. Rx SNR OOS**: Calculated. The number of cable modems associated with the node segment reporting a US SNR Status equal to "Out of Spec (OOS)".

- **Percentage CM US QAM Ch. Rx SNR OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a US SNR Status equal to "Out of Spec (OOS)".

- **Number CM US QAM Ch. Rx Post-FEC OOS**: Calculated. The number of cable modems associated with the node segment reporting a US Post-FEC Status equal to "Out of Spec (OOS)".

- **Percentage CM US QAM Ch. Rx Post-FEC OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a US Post-FEC Status equal to "Out of Spec (OOS)".

- **Number CM US QAM Ch. Time Offset OOS**: Calculated. The number of cable modems associated with the node segment reporting a US Time Offset Status equal to "Out of Spec (OOS)".

- **Percentage CM US QAM Ch. Time Offset OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a US Time Offset Status equal to "Out of Spec (OOS)".

- **Number CM DS QAM Ch. Rx Power OOS**: Calculated. The number of cable modems associated with the node segment reporting a DS Rx Power Status equal to "Out of Spec (OOS)".

- **Percentage CM DS QAM Ch. Rx Power OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a DS Rx Power Status equal to "Out of Spec (OOS)".

- **Number CM DS QAM Ch. Rx SNR OOS**: Calculated. The number of cable modems associated with the node segment reporting a DS SNR Status equal to "Out of Spec (OOS)".

- **Percentage CM DS QAM Ch. Rx SNR OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a DS SNR Status equal to "Out of Spec (OOS)".

- **Number CM DS QAM Ch. Rx Post-FEC OOS**: Calculated. The number of cable modems associated with the node segment reporting a DS Post-FEC Status equal to "Out of Spec (OOS)".

- **Percentage CM DS QAM Ch. Rx Post-FEC OOS**: Calculated. The percentage of cable modems associated with the node segment reporting a DS Post-FEC Status equal to "Out of Spec (OOS)".

- **Number CM Group Delay OOS**: Calculated. The number of cable modems associated with the given service group that are affected by group delay.

- **Percentage CM Group Delay OOS**: Calculated. The percentage of cable modems associated with the given service group that are affected by group delay.

- **Number CM Reflection OOS**: Calculated. The number of cable modems associated with the given service group that are affected by reflection.

- **Percentage CM Reflection OOS**: Calculated. The percentage of cable modems associated with the given service group that are affected by reflection.

- **Number CM Group Delay or Reflection OOS**: Calculated. The number of cable modems associated with the given service group that are affected by Pre-MTTER being Out of Spec(OOS) or Post-MTTER being Out of Spec (OOS).

- **Percentage CM Group Delay or Reflection OOS**: Calculated. The percentage of cable modems associated with the given service group that are affected by Pre-MTTER being Out of Spec (OOS) or Post-MTTER being Out of Spec (OOS).

  The following table provides information about the group delay and reflection status for different cable modems in a given service group. The table consists of three rows: *Group Delay Status*, *Reflection Status*, and *Group Delay or Reflection Status*. Each row represents a specific aspect of the cable modem performance.

  | Cable Modem Number | Group Delay Status | Reflection Status | Group Delay or Reflection Status |
  |--------------------|:------------------:|:-----------------:|:--------------------------------:|
  | CM 1               |         OOS        |        OK         |               OOS                |
  | CM 2               |         OK         |        OOS        |               OOS                |
  | CM 3               |         OK         |        OK         |               OK                 |
  | CM 4               |         OOS        |        OOS        |               OOS                |

  - **Group Delay Status**: This column indicates whether a cable modem has a group delay outside the specified limits ("OOS") or within the acceptable range ("OK").

  - **Reflection Status**: This column represents the reflection status for each cable modem. If reflection is outside the specified limits for a modem, it is indicated as "OOS"; if it falls within the acceptable range, it is indicated as "OK".

  - **Group Delay or Reflection Status**: This column combines the information from the previous columns. If either the Group Delay Status or the Reflection Status indicates an "OOS" condition for a specific cable modem, this column will indicate "OOS". If both the Group Delay Status and the Reflection Status are "OK", the cable modem is marked as "OK" in this column.

  This table is an example of how cable modems affected by group delay or reflection issues can be identified by referencing their respective status values. It provides a clear overview of the performance status for each cable modem in the service group.

- **Reflection Distance**: The average value of all associated CMs' average reflection distance.

- **Average Latency**: The average latency for all CMs associated with the given level.

- **Average jitter**: The average jitter for all CMs associated with the given level.

- **Average Packet Loss Rate**: The average packet loss rate for all CMs associated with the given level.

## System parameters

- **Name \[IDX]**: Direct value. The display name of the node segment.

  Concatenation of the CMTS name and the unique combination of a DS port and US port, using "/" as a separator. This entity is dynamically created by the connector logic from the perspective of the Integrated DOCSIS service. There will be a node segment every time the connector detects a unique US/DS port combination serving at least one cable modem.

- **DS Port**: Direct value. The DS port associated with the node segment.

- **US Port**: Direct value. The US port associated with the node segment.
