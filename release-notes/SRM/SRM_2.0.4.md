---
uid: SRM_2.0.4
---

# SRM 2.0.4

> [!NOTE]
> This version requires that **DataMiner 10.4.9.0 – 14794 or higher** is installed. The DataMiner Main Release track is not supported.

## Enhancements

### Changes

#### Improved performance when automatically selecting resources [ID 43900]

Performance has improved when resources are automatically selected. This improvement will be especially noticeable in systems containing a large number of resources within the same resource pool.

### Fixes

#### Not possible to edit contribution booking before late conversion [ID 43831]

Previously, when a contributing booking was created with the "late conversion" option, it could not be edited until it was converted and a DataMiner service had been generated.

This issue has been resolved. From now on, contributing bookings can be edited even if they have not yet been converted.
