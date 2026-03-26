---
uid: SatOps_1.0.2
---

# SatOps 1.0.2 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher, as well as DataMiner Web 10.6.2 or higher.
> - [MediaOps Plan 1.5.1](xref:MediaOps_Plan_1.5.1) or higher.

## Fixes

#### Satellite Scheduling: Canceled jobs shown on timeline [ID 45155]

On the Satellite Scheduling timeline, canceled jobs were still shown, making the associated resources appear occupied even though they were available. The scheduling visualization now correctly filters out canceled jobs based on their status, ensuring that the timeline only displays active bookings.

#### Satellite Scheduling: Available slot overlapping with existing job because of time zone conversion issue [ID 45156]

Because time zones on the slot picker page were not correctly taken into account, it was possible that an available slot overlapped with an existing job. This has now been fixed.

#### Satellite Inventory: Filter not working as expected [ID 45157]

On the Satellite Inventory pages for satellites, transponders, and beams, the filter did not work as expected. These pages have now been updated to support full filtering across the satellite inventory, based on dedicated ad hoc data sources with proper input arguments.

Additionally, the filter input now displays a label clarifying that it filters by satellite name only, preventing confusion when users enter values like hemisphere names or states, which are not supported as filter criteria.
