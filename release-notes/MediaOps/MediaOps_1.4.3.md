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

#### Resource Studio: Configuration parameters of type text included in capabilities overview [ID 44153]

In the capabilities overview, configuration parameters were shown if they were of type text, even though this should not be the case.

#### Scheduling: Default values not saved for configuration parameters of type discrete [ID 44175]

For configuration parameters of type discrete (number or text), the default value was not saved unless users first changed the value to something else and then changed it to the default value again.

#### Resource Studio: Configuration overview showed raw value for parameters of type discrete [ID 44177]

When the default value was provided for a configuration parameter of type discrete (number or text), the raw default value was shown in the configuration overview instead of the display value.
