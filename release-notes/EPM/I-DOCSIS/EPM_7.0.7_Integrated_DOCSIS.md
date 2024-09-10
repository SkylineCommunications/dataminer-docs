---
uid: EPM_7.0.7_Integrated_DOCSIS
---

# EPM 7.0.7 Integrated DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

\-

## Changes

### Enhancements

#### Casa Systems CCAP Platform: Improved Interfaces and Interface X polling [ID 40529]

The SNMP information retrieval process has been improved, so that users will now have access to faster and more reliable bit rate information for interfaces.

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
