---
uid: SRM_1.2.30
---

# SRM 1.2.30

> [!NOTE]
> This version requires that **DataMiner 10.3.2 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### New Automation script to detect and clean up corrupted profile instances [ID_35326]

A new interactive Automation script, *SRM_IAS_CorruptProfileInstances*, has been added, which can be used to detect and clean up corrupted profile instances, i.e. profile instances that still include deleted parameters. The script will list all the corrupted profile instances it has detected, and you can then click *Cleanup* to remove the deleted parameters from the profile instances.

#### Support for bulk creation of non-function resources [ID_35458]

The *SRM_DiscoverResources* script now supports non-function resources, so that it is now possible to create non-function resources in bulk.

When the existing resources are exported, they will now be placed in sheets according to their resource pools. These can then be edited and extended like you could already do with function resources previously.

For a non-function resource, the columns *Element Name (read-only)*, *Function ID (read-only)*, and *Function Instance Name* must have the value *None (Non Function Resource)*.

#### Possibility to add resources to existing booking [ID_35494]

The *SRM_BookResourcesQuickly* script has been extended to make it possible to add one or more resources to an existing booking.

For this purpose, a new property, *ReservationId*, has been added to the *Input Data* input parameter. This property indicates the booking instance that should be extended with the resources.

For example:

```json
{
   "AssignCapacityType": "Request",
   "ReservationId": "32e9ce8d-d279-4049-8233-ea63773f7588",
   "BookingManagerElement": "1.1 - Bookings - SDMN Satellite Downlink",
   "ResourceIds": "3e3332ef-156e-4da4-8ef6-0b466d3779a4",
}
```

#### New parameter to configure how long booking attachments are kept [ID_35625]

Up to now, when a booking was complete, any booking attachments for that booking were deleted. However, as it may be needed to keep the attachments for a longer period of time, they will now no longer be deleted immediately. Instead, you can configure the new *Booking Attachments Retention Period* setting in order to determine how long after the end of the booking they get deleted.

#### Leaving Failed Completed state now possible [ID_35636]

When a booking fails to be completed and goes into the "Failed Completed" state, it is now possible for a user to make the booking leave that state. This can for instance be useful in case the user knows their service is not actually affected by any failure.

## Changes

### Enhancements

#### SRM Function Resources Consistency BPA test improvements [ID_35117] [ID_35372] [ID_35471] [ID_35662]

Several improvements have been implemented to the *SRM Function Resources Consistency* BPA test, which is included with the SRM framework:

- Previously, when an element generating resources was stopped, the BPA test returned an error stating that the *[Generic DVE Table]* was empty. Now a warning will be returned instead, stating that the resources linked to the element could not be checked because the element is stopped.
- If function resources have no linker table entry while the linked function has entry points, a warning will now be generated.
- When a function resource refers to a function definition that is not part of an active functions file, an error will now be generated. The error will recommend checking the active functions file.
- If a DVE is disabled and its element state is "Deleted", the BPA test will now ignore it. This prevents an issue where a deleted DVE is indicated as a problem because DataMiner still returns an *ElementInfoEventMessage* for it.
- The BPA test now checks for elements with the same DataMiner ID and element ID, as these could cause problems. It will generate an error if any function resources are affected by such elements, listing these function resources. If no function resources are affected, it will generate a warning when it detects such elements.

#### Milliseconds excluded from booking start/end properties [ID_35145]

To prevent possible issues, the SRM framework will no longer take the millisecond part of a DateTime component into account for start and end properties.

#### Log collector configuration file added [ID_35339]

To make it easier to analyze possible SRM issues, the Booking Manager app will now add a log collector configuration file. This file will include:

- The booking log files for each Booking Manager element and from all DMAs in the cluster.
- The *SRM_Solution_About* file, which contains details about the SRM solution version.

#### Contributing transport bookings adjusted to be similar to regular contributing bookings [ID_35432]

Up to now, when a contributing transport booking was created, custom code was used that did not have all the features of regular contributing bookings. Now the same logic will be used for contributing transport bookings, so that the same features are available.

This also resolves a possible issue where the TransportLink feature did not work for a silent booking.

#### SRM statistics feature no longer available [ID_35452]

The SRM statistics feature, which could be used to keep track of statistics for the purpose of diagnostics but could affect performance, is now no longer available.

#### SRM framework no longer relies on obsolete Capacity property [ID_35585]

As the *Capacity* property is longer initialized on new resources from DataMiner 10.3.0/10.3.2 onwards, the SRM framework has been reviewed to no longer rely on this property. Instead, the capacities list is used when needed.

#### Silent Booking Type option removed from Booking Manager [ID_35598]

The Silent Booking Type option has been removed from the Booking Manager connector. Now it will only be able to create silent bookings using the "Optimized" value.

#### [PathJSON] property no longer created [ID_35730]

Up to now, the SRM framework created a booking property named "[PathJSON] {transport function name} {parameter name}", which had a serialized version of the transport path as its value. However, as this could be a very long value, this could have a negative impact on system performance. This property will therefore no longer be created.

If you want to retrieve the selected path, you can instead do so by retrieving the contributing booking and checking its resources.

### Fixes

#### Exception when changing booking name with BookingManager.ChangeName via external service management [ID_35669]

If the BookingManager.ChangeName method was used to change the name of a booking via external service management, an exception could be thrown.

For example:

```txt
Failed to execute reservation action ChangeNameAction due to:
(Code: 0xC00402D0) Skyline.DataMiner.Net.Exceptions.DataMinerException: Service with ID 665/410676 is unavailable.
```

#### Pre-roll time could not be edited during pre-roll phase [ID_35726]

In some cases, it was not possible to change the pre-roll time of a booking during its pre-roll phase. The wizard instead tried to change the start time of the booking.

Now changing the pre-roll time during the pre-roll phase will be possible as long as it is not set to be in the past and it does not exceed the end time of the booking (i.e. the start of the post-roll phase).

#### Booking did not end when finished with Shrink Post-Roll enabled [ID_35746]

When Shrink Post-Roll was enabled and a user finished a booking, it could occur that the booking did not end correctly.
