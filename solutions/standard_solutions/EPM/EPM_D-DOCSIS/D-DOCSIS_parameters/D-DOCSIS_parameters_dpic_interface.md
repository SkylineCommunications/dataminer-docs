---
uid: D-DOCSIS_parameters_dpic_interface
---

# D-DOCSIS parameters – DPIC Interface

This page contains an overview of the DPIC Interface parameters available in the D-DOCSIS branch of the EPM Solution.

- **Name**: Direct value. The description of the interface.

  MIB OID 1.3.6.1.2.1.2.2.1.2.

- **Admin Status**: Direct value. The desired state of the interface.

  MIB OID 1.3.6.1.2.1.2.2.1.7.

- **Operational Status**: Direct value. The current operational state of the interface.

  MIB OID 1.3.6.1.2.1.2.2.1.8.

- **In Rate**: Calculated. The input bit rate.

  Calculated using the change in the number of input octets - OID 1.3.6.1.2.1.2.2.1.10.

- **Out Rate**: Calculated. The output bit rate.

  Calculated using the change in the number of output octets - OID 1.3.6.1.2.1.2.2.1.10.

- **Total Error**: Calculated. The total number of errors. Calculated by adding up the In Errors and Out Errors for the given polling cycle.

  - In Errors OID: 1.3.6.1.2.1.2.2.1.14.
  - Out Errors OID: 1.3.6.1.2.1.2.2.1.20.
