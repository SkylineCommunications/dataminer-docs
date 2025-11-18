---
uid: MediaOps_1.4.3
---

# MediaOps 1.4.3 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires DataMiner 10.5.9/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Scheduling: Possible to add resource to confirmed/running job despite missing mandatory configuration parameters [ID 44145]

When a job was already confirmed or running, it was still possible to add a resource to it for which mandatory configuration parameters were missing, even though this should not be allowed.

#### Scheduling: No value visible for configuration parameters of type number discrete [ID 44147]

Up to now, for job node configuration parameters of type number discrete, no value was shown.
