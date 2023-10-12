---
uid: SRM_1.2.30_CU4
---

# SRM 1.2.30 CU4

> [!NOTE]
> This version requires that **DataMiner 10.3.2 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## Enhancements

#### SRM_DiscoverResources: Support for multiple resources linked to element without entry point [ID_36163]

The *SRM_DiscoverResources* script now supports multiple function resources from the same element without entry point.

## Fixes

#### Milliseconds incorrectly taken into account when updating booking time [ID_36247]

When bookings created prior to SRM 1.2.30 were updated and only a millisecond value changed, this could cause delays or possibly even errors.

If the timing of a booking is updated and only the milliseconds change, this update will now be discarded, as the milliseconds are no longer taken into account for the booking time from SRM 1.2.30 onwards.
