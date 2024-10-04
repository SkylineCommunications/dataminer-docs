---
uid: EPM_7.0.8_Integrated_DOCSIS
---

# EPM 7.0.8 Integrated DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Fixes

#### Generic DOCSIS CM Collector: OOS status parameters showing 'OK' when no DS QAM channels exist [ID 40980]

In the CM Collector, when there were no CM QAM US/DS channels, the QAM Status parameters at the Cable Modem level showed *OK* instead of *N/A*.

The following parameters were affected by this issue:

- DS QAM Rx Power Status
- DS QAM SNR Status
- DS QAM Post-FEC Status
- US QAM Tx Power Status

#### Cisco CBR-8 CCAP Platform: Problem with slow polling [ID 40981]

In some cases, it could occur that the *SNMP Slow Status* parameter of the Cisco CBR-8 CCAP Platform connector got stuck in the processing stage. To resolve this, the *partialSNMP* option has been removed from the tables that were being polled for the SNMP slow groups, and logic has been added that checks the polling statuses of the connector and resets these after the time defined in the *Auto Correct Status Interval* parameter has passed (by default 24 hours).
