---
uid: MediaOps_1.4.3
---

# MediaOps 1.4.3

> [!NOTE]
> This version requires DataMiner 10.5.9/10.6.0 or higher. In addition, the [GQI DxM](xref:GQI_DxM) must be installed.

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### Resource Studio: Resources used in ongoing or future jobs can no longer be deprecated [ID 44213]

Up to now, it was possible to deprecate resources that were used in ongoing or future jobs. However, as this could lead to unwanted behavior, this will now no longer be possible.

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

#### Scheduling: Red hand icon still shown after providing all mandatory values when adding node to job [ID 44179]

When a new node was added to a job and all mandatory configuration values assigned to the pool had been provided, it could occur that the red hand icon continued to be shown, even though this should not be the case.

#### Resource Studio: Resource pool deprecation confirmation was ignored [ID 44212]

When you deprecate a resource pool in the Resource Studio app, a dialog asks for confirmation. Up to now, if you then did not confirm the deprecation, the resource pool was still deprecated. This has now been fixed.

#### Resource Studio: Exception when adding discrete values for configuration parameter with default value enabled [ID 44229]

When discrete values were added for a configuration parameter while the default value was enabled, it could occur that an exception was thrown.
