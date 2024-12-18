---
uid: I-DOCSIS_parameters_ptp
keywords: I-DOCSIS parameters
---

# Integrated DOCSIS parameters – PTP

These parameters are only available in elements running the Harmonic CableOS connector, on the PTP page.

Currently, these parameters are not shown on the topology chains available in Integrated DOCSIS. However, you can access this information using a dashboard, low-code app, or custom visual overview.

- **CCAP PTP Clock State**: Direct value. This attribute represents the current state of the clock.

  OID: 1.3.6.1.4.1.4491.2.1.32.1.1.2.1.1

- **RPD Port PTP Status Table**

  - **IP address type**: Direct value. This attribute represents the IP address type of the PTP master clock source that is currently being used.

    OID: 1.3.6.1.4.1.4491.2.1.32.1.1.4.1.6

  - **IP Address SNMP**: This attribute reports the IP address of the PTP master clock source that is currently being used.

    OID: 1.3.6.1.4.1.4491.2.1.32.1.1.4.1.7

- **RPD PTP Clock Status Table**

  - **Clock State**: Direct value. This attribute represents the current state of the clock for the instance.

    OID: 1.3.6.1.4.1.4491.2.1.32.1.1.2.1.1

> [!NOTE]
> These KPIs are aimed at a distributed architecture (D-DOCSIS). They have been added to the connector because this connector will also be used in the D-DOCSIS Solution.
