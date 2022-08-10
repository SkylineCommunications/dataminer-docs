---
uid: SRM_1.2.22
---

# SRM 1.2.22

> [!NOTE]
> This version requires that **DataMiner 10.1.11-11105 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### Changing assigned profile instance of resource in booking \[ID_32095\]

The *SRM_AssignProfileToResource* script now allows you to change the profile instance assigned to a resource in an existing booking.

#### SRM_UnassignResourceFromBooking script added \[ID_32229\]

A new script, *SRM_UnassignResourceFromBooking*, has been added, to make it easier to unassign resources related to a booking.

When the script is executed with a specific resource and booking ID, it will ask the user to confirm the unassign action. In case the resource has been assigned to the specified booking multiple times, the user will be asked where it should be removed.

## Changes

### Enhancements

#### Improved logging for contributing bookings \[ID_31912\]

Up to now, some of the logging for contributing bookings was added in the log file for the main booking instead of that for the contributing booking. This should no longer occur. In addition, more log entries will now be added for contributing bookings, including for transport bookings, contributing booking conversion, and booking actions on the main booking that affect the contributing booking.

#### Transport Path and Path property now public \[ID_32070\]

Because the *Path* property was not publicly available, it was difficult to know which path was being assigned. The *Transport Path* and *Path* property have therefore now been made public.

#### Logging added when profile is applied to resource \[ID_32100\]

When the *SRM_ApplyProfileToResource* script applies a profile to a resource, it will now store the corresponding logging. If the profile is applied in the context of a booking, the logging is added to the action log of that booking. To make sure the logging is stored in other contexts, add the name of the Booking Manager in the script's input parameters using *BookingManagerName* as key, for example:

```json
{ "BookingManagerName": "Name of the Booking Manager element", "ResourceId": "GUID of the resource"}
```

#### Timeout SRM_BookingActions script extended to 30 minutes \[ID_32104\]

To prevent situations where bookings enter the *Failed* state because orchestration takes longer than 10 minutes, the timeout of the *SRM_BookingActions* script has been extended to 30 minutes.

#### Uniform look and feel for SRM_ApplyProfileToResource and SRM_AddResourceFromPoolToBooking scripts \[ID_32197\]

The scripts *SRM_ApplyProfileToResource* and *SRM_AddResourceFromPoolToBooking* have been modified to have the same look and feel as much as possible.

In addition, the *Successful Message* dialog of the *SRM_ApplyProfileToResource* script will now be closed automatically after 5 seconds.

#### SRM_CustomDijkstraContributingReservation script deprecated \[ID_32206\]

The *SRM_CustomDijkstraContributingReservation* script will no longer be part of the SRM package. All logic to create transport bookings will instead make use of the optimized silent booking creation, which will result in faster creation of transport bookings.

#### SRM_ContributingReservation script deprecated \[ID_32212\]

The *SRM_ContributingReservation* script is now considered deprecated. To allow more reusability and improve performance, the code from the script has been moved to the *ContributingConverter* class.

#### Natural sorting for profile parameters in Booking Wizard \[ID_32225\]

The Booking Wizard has been adjusted to list the profile parameters using natural sorting instead of alphabetical sorting.

#### Action title always displayed in booking action window \[ID_32246\]

The window for a booking action will now always show the corresponding action title, even when an error occurs.

#### Automatic path selection in case no function is passed in silent booking \[ID_32333\]

Up to now, when a booking was created silently and no function was passed to the *CreateNewBooking* method, a path was not automatically selected. This has now been changed to be more in line with other functions. Only in case the property *Auto Select Resource* is set to *False*, will automatic path selection still not occur when no function is passed.

#### UpdateServiceReservationProperties method now always retrieves updated booking \[ID_32423\]

The UpdateServiceReservationProperties method now retrieves the updated booking regardless of whether the update was a success. Previously, this only happened in case it was a success.

### Fixes

#### Locked contributing resources and services not removed when main booking was canceled \[ID_28619\]

When a main booking was canceled, it could occur that the associated locked contributing resources and services were not removed.

#### Fast transport flow did not create SRMSettableServiceState object \[ID_31870\]

The fast transport flow did not create the *SRMSettableServiceState* object. This could cause an exception when *Orchestration* was set to *Local*, for example:

```txt
Failed to update SRM Settable Service State to state PAUSE for service 799/273293 due to:
Skyline.DataMiner.Library.Exceptions.SrmSettableServiceStateNotFoundException: The settable state for the service info 799/273293 could not be found for reservation named TestApplyContributingStateLiteResource_03_11_04_29_Transport.
   at Skyline.DataMiner.Library.Solutions.SRM.SrmUtilities.UpdateSrmSettableState(ISrmContext srmContext, ServiceID serviceId, String& newSettableState)
```

#### Remaining time displayed for permanent booking \[ID_32032\]

Depending on regional settings, it could occur that the remaining time was shown for a permanent booking in the Booking Manager Visual Overview.

#### Problem with filtering criteria caused exceptions \[ID_32072\]

Because of a problem with filtering criteria to retrieve available quarantined bookings that have not started yet, the Booking Manager could throw exceptions like the following:

```txt
2021/12/06 07:15:41.008|SLManagedScripting.exe|ManagedInterop|ERR|0|78|QA178|178|Run|Exception thrown:
System.InvalidOperationException: Sequence contains no elements
   at System.Linq.Enumerable.Min[TSource](IEnumerable\`1 source)
   at QAction.Run(SLProtocol protocol)
```

#### Capabilities and capacities were removed when using late conversion \[ID_32078\]

If the late conversion feature was used to convert a resource to a contributing resource, it could occur that capabilities and capacities were removed.

#### Not possible to create booking when DTR was used with selected parameter without value \[ID_32257\]

When Data Transfer Rules were used for a parameter that was selected in the service definition but for which no value was filled in, it could occur that no booking could be created.

#### Contributing bookings for failed booking creation process not removed \[ID_32262\]

When booking creation failed for a booking based on a service profile, it could occur that contributing bookings created during the failed process were not removed.

#### No logging for creation new booking \[ID_32306\]

In some cases, it could occur that the *SRM_CreateNewBooking* script did not create log entries when a new booking was created.
