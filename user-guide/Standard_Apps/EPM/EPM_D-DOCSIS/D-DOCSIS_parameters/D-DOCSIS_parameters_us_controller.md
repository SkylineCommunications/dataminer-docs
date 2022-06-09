---
uid: D-DOCSIS_parameters_us_controller
---

# D-DOCSIS parameters – US Controller

This page contains an overview of the US Controller parameters available in the D-DOCSIS branch of the EPM Solution.

- **Name (IDX)**: Converted. The name of the controller, including associated CCAP.

  Based on the name from the physical interfaces. Includes the CCAP name.

  - Physical Interfaces table OID: 1.3.6.1.2.1.47.1.1.1.
  - Physical Interfaces name OID: 1.3.6.1.2.1.47.1.1.1.1.7.

- **System Name**: Direct value. The name of the controller interface.

  OID 1.3.6.1.2.1.47.1.1.1.1.7.

- **DPIC Interface Name**: Calculated. The DPIC interface name, including associated CCAP.

  Calculated by getting the interface name using the numbers to match to the interface table depending on the controller name.

  Interface name OID: 1.3.6.1.2.1.2.2.1.2.
