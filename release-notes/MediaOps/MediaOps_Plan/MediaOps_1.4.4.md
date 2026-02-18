---
uid: MediaOps_Plan_1.4.4
---

# MediaOps 1.4.4 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires DataMiner 10.5.11/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### People & Organization: Exception when updating team skills after teams had been created without team email or description [ID 44299]

When teams had been created through code with a null value for the "Team email" or "Team description", an exception was thrown when you tried to update the skills of a team in the People & Organization app.
