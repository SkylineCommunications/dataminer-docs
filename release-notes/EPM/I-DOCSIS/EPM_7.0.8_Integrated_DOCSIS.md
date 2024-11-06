---
uid: EPM_7.0.8_Integrated_DOCSIS
---

# EPM 7.0.8 Integrated DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be added, modified, or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### CISCO CBR-8 CCAP Platform: CCAP TV data added [ID 41139]

Two new tables are now available in the CISCO CBR-8 element: the *Video QAM Channel* table and the *MPEG Output Streams* table. These tables are shown on the *Video Data* page of the element. You can also retrieve the data from these tables in a dashboard or low-code app. If you do not need this TV data for your implementation, leave the *Poll Video Data Tables* parameter set to its default setting *Disabled*, so that this data will not be polled.

#### New OFDMA + LowSplitSCQAM column added in US FN Peak dashboard [ID 41311]

In the US FN Peak dashboard, a new column, *OFDMA + LowSplitSCQAM*, has been added. The values in this column are calculated by adding the highest peak at the same timestamp for the Low Split SCQAM and OFDMA Utilization for a user-defined time period. Note that the Peak OFDMA Utilization used in this calculation is different than the Peak OFDMA Utilization displayed on the dashboard. It is the highest peak in a 24-hour period, without taking the 3 highest peaks like the parameter shown in the dashboard.

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
