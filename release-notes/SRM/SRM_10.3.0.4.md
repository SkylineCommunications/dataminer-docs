---
uid: SRM_10.3.0.4
---

# SRM 10.3.0.4

> [!NOTE]
> This version requires that **DataMiner 10.3.0 [CU0] or higher** is installed. The DataMiner Feature Release track is not supported.

## Enhancements

#### Skyline Booking Monitoring: Failed states added [ID 38271]

The following Failed states have been added to the Skyline Booking Monitoring connector so that it is up to date with the Skyline Booking Manager connector: Failed Service Pre-Roll, Failed Service Active, Failed Service Post-Roll, and Failed Complete.

#### BookingManager.AddResource now skips service definition checks when user provides service definition [ID 38346]

The method *BookingManager.AddResource* now skips service definition checks when the service definition is provided by the user. This way, the user has better control over service definition properties and diagram order. However, as no validation is done, it is now up to the user to make sure the service definition is compatible with the assigned resources. If the user selects the wrong service definition, this may lead to unwanted behavior.

## Fixes

#### Package installation error because of profile instance [ID 38363]

In case a profile instance had a parameter value with a ReferenceValue that was explicitly equal to null, an error could occur when installing an SRM package. In the logging, an exception similar to the example below would be included:

`Exception encountered during installation: Newtonsoft.Json.JsonReaderException: Error reading JObject from JsonReader. Current JsonReader item is not an object: Null. Path 'Values[0].ReferenceValue', line 21, position 28.`

#### Deleting contributing booking caused deactivation of functions file [ID 38532]

When a contributing booking had a non-template service definition assigned, and this contributing booking was deleted, it could occur that the contributing functions file was deactivated, while this should not happen.

#### Triggering PLS failed after change of DVE version [ID 38598]

When a Profile Load Script was triggered, it could occur that this script failed to run if the SRM resource DVE version had changed. The DVE element object was cached, and when the version was changed, the cache still contained the previous value instead of the updated one. To resolve this issue, this cache is no longer used.
