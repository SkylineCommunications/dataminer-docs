---
uid: EPM_7.0.8_Integrated_DOCSIS
---

# EPM 7.0.8 Integrated DOCSIS

## Changes

### Enhancements

#### CISCO CBR-8 CCAP Platform: CCAP video data added [ID 41139]

Two new tables are now available in the CISCO CBR-8 element: the *Video QAM Channel* table (OID 1.3.6.1.4.1.5591.1.11.5.3.1.1.1) and the *MPEG Output Streams* table (OID 1.3.6.1.4.1.5591.1.11.5.4.1.1.2.3). These tables are shown on the *Video Data* page of the element. You can also visualize data from these tables in a dashboard or low-code app. By default, these tables are not polled. To enable or disable polling, use the parameter *Poll Video Data Tables* on the *Configuration* page.

#### New OFDMA + LowSplitSCQAM column added in US FN Peak dashboard [ID 41311]

In the US FN Peak dashboard, a new column, *OFDMA + LowSplitSCQAM*, has been added. The values in this column are calculated by adding the highest peak at the same timestamp for the Low Split SCQAM and OFDMA Utilization for a user-defined time period. Note that the Peak OFDMA Utilization used in this calculation is different from the Peak OFDMA Utilization displayed on the dashboard. It is the highest peak in a 24-hour period, without taking the 3 highest peaks like the parameter shown in the dashboard.

#### Harmonic CableOS: Kafka integration [ID 41428]

The Harmonic CableOS connector can now parse Kafka stream data related to its system and CMTS metrics. It currently retrieves the metrics for CPU and memory utilization of the CCAP. When you open the CCAP in the EPM Topology app, these are displayed in the CCAP Overview table.

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

#### Problem with CM channel mapping for DOCSIS versions below 3.0 [ID 41140]

Because previously the CM channels mapping used a table that was only meant for CMs running DOCSIS 3.0 or higher, for any CMs using a lower DOCSIS versions, no channels were shown. The mapping has now been corrected so that channels will now also be shown for such CMs.
