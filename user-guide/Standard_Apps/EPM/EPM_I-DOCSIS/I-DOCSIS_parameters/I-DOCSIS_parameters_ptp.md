---
uid: I-DOCSIS_parameters_ptp
---

# I-DOCSIS parameters – PTP

These parameters are only available in elements running the Harmonic CableOS connector.

Currently, those parameters are not shown on the topology chains available in I-DOCSIS. However, the user can access to the information by using dasboard, LCA, GQI Queries, Ad-hoc data source and visio components.

## PTP Page

- **CCAP PTP Clock State**: Direct value. This attribute represents the current state of the clock.

  - OID: 1.3.6.1.4.1.4491.2.1.32.1.1.2.1.1

- **RPD Port PTP Status Table** 
    - **IP address type**: Direct value. This attribute represents IP address type of the PTP Master clock source currently being used.
        - OID: 1.3.6.1.4.1.4491.2.1.32.1.1.4.1.6
    
    - **IP Address SNMP**: This attribute reports the IP address of the PTP Master clock source currently being used.
        - OID: 1.3.6.1.4.1.4491.2.1.32.1.1.4.1.7

- **RPD PTP Clock Status Table** 
    - **Clock State**: Direct value. This attribute represents the current state of the clock for the instance.
        - OID: 1.3.6.1.4.1.4491.2.1.32.1.1.2.1.1