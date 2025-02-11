---
uid: D-DOCSIS_parameters_cin_interface
---

# D-DOCSIS parameters – CIN Interface

This page contains an overview of the CIN Interface parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Name**: Converted. The name of the interface for the device.

  This is a combination of the element name and the system name.

- **System Name**: Direct value. The name of the interface.

  OID: 1.3.6.1.2.1.2.2.1.2.

- **MAC**: Direct value. The interface MAC address.

  OID: 1.3.6.1.2.1.2.2.1.6.

- **Admin Status**: Converted. The interface admin status.

  This is OID 1.3.6.1.2.1.2.2.1.7 converted to the MIB equivalent value.

- **Operational Status**: Converted. The interface operational status.

  This is OID 1.3.6.1.2.1.2.2.1.8 converted to the MIB equivalent value.

- **Bandwidth**: Direct value. The bandwidth of the interface.

  OID: 1.3.6.1.2.1.2.2.1.5.

- **In Rate**: Calculated. The rate of incoming octets.

  Calculated using the difference between the input octets (OID 1.3.6.1.2.1.2.2.1.10) of a given polling cycle.

- **Out Rate**: Calculated. The rate of outgoing octets.

  Calculated using the difference between the output octets (OID 1.3.6.1.2.1.2.2.1.16) of a given polling cycle.

- **In Utilization**: Calculated. The input utilization of the bandwidth.

  Calculated using rate of input octets over the bandwidth.

- **Out Utilization**: Calculated. The output utilization of the bandwidth.

  Calculated using the rate of output octets over the bandwidth.

- **Total Utilization**: Calculated. The total interface utilization.

  This is the average of input and output utilization.

- **In Error Rate**: Calculated. The rate of incoming errors.

  Calculated using the difference between the input errors (OID 1.3.6.1.2.1.2.2.1.14) of a given polling cycle.

- **Out Error Rate**: Calculated. The rate of outgoing errors.

  Calculated using the difference between the output errors (OID 1.3.6.1.2.1.2.2.1.20) of a given polling cycle.

- **Total Error**: Calculated. The total number of errors (In Errors + Out Errors) for the given polling cycle.

- **Utilization Status**: Calculated. The status of the utilization vs. the threshold.

  Calculated if the total utilization goes over the threshold set by the user.

- **CIN Entity Name**: Direct value. The name of the CIN entity. This is the first part of the sysName (1.3.6.1.2.1.1.5.0).
