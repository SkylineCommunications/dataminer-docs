---
uid: EPM_6.1.8_I-DOCSIS
---

# EPM 6.1.8 I-DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### EPM front end removed from passive logic workflow [ID_36356]

To improve performance, the EPM front-end element is no longer involved in retrieving the passive data in the system.

### Fixes

#### Huawei 5688-5800 CCAP Platform: Incorrect Percentage DS and US values [ID_36248]

In the Interface table, it could occur that values above 100% were shown for the utilization percentage. To correct this, a new way to calculate the bitrate has been implemented, which uses the [SLC SDF Bitrate calculations library](xref:ConnectionsSnmpBitRateCalculations).

With this new implementation, the following columns are no longer needed in the Interface Extended Overview and Interfaces tables: InUtilization, OutUtilization, and TotalUtilization. The latter will be renamed to Utilization.
