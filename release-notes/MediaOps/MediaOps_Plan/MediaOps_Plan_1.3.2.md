---
uid: MediaOps_Plan_1.3.2
---

# MediaOps 1.3.2

> [!NOTE]
> This version requires DataMiner 10.5.7/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## Changes

### Fixes

#### Resource Studio: Capacity, capability, and property management not possible [ID 43327]

In the Resource Studio app, when an element, service, or virtual function resource had been created, it was no longer possible to adjust its capacities, capabilities, or properties.

#### People & Organization: Skills not available as capabilities in bookable team [ID 43329]

In the People & Organization app, when a team was made bookable, the skills of the members of that team did not become available as capabilities for these team members.

#### MediaOps upgrade failing because of lingering mandatory fields in DOM definitions [ID 43503]

Because DOM section definition fields that were mandatory in previous MediaOps versions had been removed, it could occur that the installation script failed when attempting to add default relations. This issue has been fixed by marking these unexpected fields as soft-deleted during the installation process.
