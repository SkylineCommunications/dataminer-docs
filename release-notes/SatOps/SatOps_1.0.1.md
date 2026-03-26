---
uid: SatOps_1.0.1
---

# SatOps 1.0.1

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher, as well as DataMiner Web 10.6.2 or higher.
> - [MediaOps Plan 1.5.1](xref:MediaOps_Plan_1.5.1) or higher.

## Fixes

#### Satellite Scheduling: Deprecated and draft plans taken into account for scheduling transponder slots [ID 45153]

Previously, deprecated and draft plans were also taken into account for schedule transponder slots on the transponder timeline of the Satellite Scheduling view. This is no longer the case. The behavior has been corrected, and only active plans are taken into account.

#### Satellite Inventory: Transponders could have the same name [ID 45154]

Up to now, it was possible to create transponders with the same name. This will now be prevented. When you try to insert a transponder with a name that already exists, a dialog will help you to add another suffix. This way, transponder resources will never have the same name in Resource Studio, as this is something that is not allowed in MediaOps.Plan.
