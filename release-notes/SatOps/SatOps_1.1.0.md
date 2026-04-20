---
uid: SatOps_1.1.0
---

# SatOps 1.1.0

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher, as well as DataMiner Web 10.6.2 or higher.
> - [MediaOps Plan 1.5.1](xref:MediaOps_Plan_1.5.1) or higher.

## New features

#### Satellite Scheduling: Read and edit mode for managing transponder jobs [ID 44879]

The Satellite Scheduling view now supports both a read and an edit mode for managing transponder jobs. Read mode provides a static overview of job details, while edit mode allows you to create and modify jobs directly from the Scheduling interface. All changes are handled through MediaOps jobs in the background, ensuring full consistency.

#### Satellite Inventory: Duplication of transponders [ID 44950]

It is now possible to create a transponder based on an existing transponder. This will speed up the initial creation of multiple transponders for the same satellite.

#### Satellite Inventory: Duplication of transponder plans [ID 45329]

It is now possible to create a transponder plan based on an existing one, enabling faster configuration of multiple similar plans within the same transponder. A duplicate option is available in the context menu, allowing you to efficiently copy and adapt existing plans as needed.

#### Satellite Scheduling: Direct navigation to Scheduling app from transponder timeline and slot picker [ID 45330]

In the Satellite Scheduling app, a new context menu action for the transponder timeline allows you to open the Scheduling app with the relevant instance panel preselected. Additionally, the slot picker now includes a shortcut link that opens the Scheduling app with the selected resource and slot inserted, enabling faster navigation between the applications.

## Changes

### Enhancements

#### Satellite Scheduling: Transponder timeline design enhancements [ID 44949]

The transponder timeline has been improved to better accommodate longer transponder and slot names, with refined alignment for improved readability and overall UI consistency. New filters by satellite and job name have been added to enhance navigation. In addition, the timeline now fully supports both read and edit mode, enabling both overview and direct management of transponder jobs.
