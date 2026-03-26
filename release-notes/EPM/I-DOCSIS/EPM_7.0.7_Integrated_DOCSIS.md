---
uid: EPM_7.0.7_Integrated_DOCSIS
---

# EPM 7.0.7 Integrated DOCSIS

## Changes

### Enhancements

#### Casa Systems CCAP Platform: Improved Interfaces and Interface X polling [ID 40529]

The SNMP information retrieval process has been improved, so that users will now have access to faster and more reliable bit rate information for interfaces.

#### OFDMA IUC MER values added in OFDMA Channels dashboard [ID 40800]

In the OFDMA Channels dashboard, the MER values for each IUC code for all OFDMA channels are now displayed.

### Fixes

#### Incorrect bit rate calculation for slow interfaces [ID 40530]

In the Interface table, it could occur that incorrect error rates and bit rates were shown for slow interfaces.

#### Channels information polling issue [ID 40553]

During network congestion, it could occur that information about channels was only partially retrieved and service group mappings were lost. To resolve this, the partialSNMP option will no longer be used to poll the channels information.

#### Cisco CBR-8 CCAP Platform: Incorrect Memory Utilization values for CCAP [ID 40667]

Up to now, it could occur that the Memory Utilization values that were calculated for the CCAP by the Cisco CBR-8 CCAP Platform connector did not line up with the values that are retrieved from CLI for the CCAP. To correct this, the memory pool OIDs that are used for this calculation have been updated, so that the correct value will be shown.

These are the updated OIDs:

- cempMemPoolName 

  .1.3.6.1.4.1.9.9.221.1.1.1.1.3

  A textual name assigned to the memory pool.

- cempMemPoolHCUsed

  .1.3.6.1.4.1.9.9.221.1.1.1.1.18

  The number of bytes from the memory pool that are currently in use by applications on the physical entity. 

- cempMemPoolHCFree

  .1.3.6.1.4.1.9.9.221.1.1.1.1.20

  The number of bytes from the memory pool that are currently unused on the physical entity.

#### Cisco CBR-8 CCAP Platform: Incorrect 'Status Last Change' and 'Uptime' in Modules table [ID 40842]

In the *Modules* table of the Cisco CBR-8 CCAP Platform connector, it could occur that the *Status Last Change* and *Uptime* columns showed incorrect values. They could indicate excessively large time ranges (e.g., 12 years of uptime) that did not match the values retrieved from the CLI. A fix has now been implemented to align these values with the actual expected data from the device.
