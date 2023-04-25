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

*No enhancements have been added to this release yet.*

### Fixes

#### Incorrect -1 values in Nodes, Amplifier Overview, and Subscribers Overview tables [ID_36197]

In the Nodes, Amplifier Overview, and Subscribers Overview tables, it could occur that the Node ID, Amplifiers ID, and Subscribers ID columns displayed the value "-1" where they were supposed to show "N/A".

#### Huawei 5688-5800 CCAP Platform: Incorrect Percentage DS and US values [ID_36248]

In the Interface table, it could occur that values above 100% were shown for the utilization percentage. To correct this, a new way to calculate the bitrate has been implemented.

With this new implementation, the following columns are no longer needed in the Interface Extended Overview and Interfaces tables: InUtilization, OutUtilization, and TotalUtilization. The latter will be renamed to Utilization.
