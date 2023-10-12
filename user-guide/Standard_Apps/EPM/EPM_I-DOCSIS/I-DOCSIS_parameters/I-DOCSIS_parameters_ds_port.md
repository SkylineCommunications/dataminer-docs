---
uid: I-DOCSIS_parameters_ds_port
---

# I-DOCSIS parameters – DS Port

This page contains an overview of the DS Port parameters available in the I-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Number CM**: Calculated. The number of CMs served by the DS port.

  Calculated by aggregating the number of CMs associated with the DS port.

- **Number CM Offline**: Calculated. The number of offline CMs associated with the DS port, from the CCAP perspective.

  Calculated by aggregating the number of CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (1 Other = Offline, 8 Operational = Online, any other value = Initializing).

- **Percentage CM Offline**: Calculated. The percentage of offline CMs associated with the DS port, from the CCAP perspective.

  Calculated based on the CMs reported as offline by the CCAP (OID: 1.3.6.1.4.1.4491.2.1.20.1.3.1.6) (1 Other = Offline, 8 Operational = Online, any other value = Initializing).

- **Number [2.0, 3.0, 3.1] CM**: Calculated. The number of CMs served by the DS port for the relevant DOCSIS version.

  Calculated by aggregating the number of CMs according to the DOCSIS version as reported by the CM MIBs (OID: 1.3.6.1.2.1.10.127.1.1.5).

- **Number Other CM**: Calculated. The number of CMs served by the DS port for the other DOCSIS versions.

  Calculated by adding up the number of CMs with an unknown DOCSIS version that are served by the DS port.

- **Number CM Ping Unreachable**: Calculated. The number of CMs associated with the DS port that are reporting the ping status "Unreachable".

  Calculated by aggregating the number of CMs with ping status "Unreachable".

- **Percentage CM Ping Unreachable**: Calculated. The percentage of CMs associated with the DS port that are reporting the ping status "Unreachable".

- **CH Utilization**: Calculated. The average utilization of all DS channels associated with the DS port.

- **Average Latency**: Calculated. The average latency for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

- **Average Jitter**: Calculated. The average jitter for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.

- **Average Packet Loss Rate**: Calculated. The average packet loss rate for all CMs associated with the given level. Only CMs that present valid values count towards this KPI.
