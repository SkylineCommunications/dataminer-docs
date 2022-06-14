---
uid: D-DOCSIS_parameters_dpic
---

# D-DOCSIS parameters – DPIC

This page contains an overview of the DPIC parameters available in the D-DOCSIS branch of the EPM Solution.

- **Name (IDX)**: Direct value. The name of the interface.

  Retrieved by mapping the physical interface name to the primary key of the module table.

  - Physical Interfaces table OID: 1.3.6.1.2.1.47.1.1.1.
  - Physical interface name: OID 1.3.6.1.2.1.47.1.1.1.1.7.

- **Description**: Direct value. The description of the device.

  Retrieved by mapping the physical interface description to the primary key of the module table.

  - Physical Interfaces table OID: 1.3.6.1.2.1.47.1.1.1.
  - Physical interface name OID: 1.3.6.1.2.1.47.1.1.1.1.2.

- **Admin Status**: Direct value. The admin status of the module.

  OID 1.3.6.1.4.1.9.9.117.1.2.1.1.1.

- **Operational Status**: Direct value. The operational status of the module.

  OID 1.3.6.1.4.1.9.9.117.1.2.1.1.2.

- **Reset Reason**: Direct value. The reason for the last reset.

  OID 1.3.6.1.4.1.9.9.117.1.2.1.1.3.

- **Status Last Change Time**: Direct value. The value of sysUpTime at the time the status is changed.

  MIB OID 1.3.6.1.4.1.9.9.117.1.2.1.1.4.

- **Up Time**: Direct value. The uptime of the module since it was last re-initialized.

  MIB OID 1.3.6.1.4.1.9.9.117.1.2.1.1.8.

- **Bandwidth**: Direct value. An estimate of the interface's current bandwidth.

  MIB OID 1.3.6.1.2.1.31.1.1.1.15.

- **Utilization**: Calculated. The total module bandwidth utilization.

  Calculated by using the interface (Bitrate/Bandwidth) \* 100.
