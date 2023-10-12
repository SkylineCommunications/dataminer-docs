---
uid: SRM_1.2.31
---

# SRM 1.2.31

> [!NOTE]
> This version requires that **DataMiner 10.3.2.0 – 12627 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### Support for parameters, capacities, and capabilities for regular resources [ID_35956]

Support has been added for parameters, capacities, and capabilities for regular resources, i.e. resources that are not (virtual) function resources. As these do not link to a profile definition, they will have a different logic from (virtual) function resources:

- Profile instances are not supported. Consequently, the *By reference* option in the Booking Wizard is also not supported.
- Interfaces are not supported.
- All parameters passed in a booking will be booked.
- If a parameter represents capacity or capability, this will be booked.

This behavior applies when new bookings are created and when resources are assigned to bookings.

> [!IMPORTANT]
> BREAKING CHANGE: The logic to assign resources for unmapped nodes has been modified so that it is now similar to the logic when creating a new booking. This means that parameters and assignment by reference are now supported for this.

## Changes

### Enhancements

#### CheckDveInconsistency BPA: Check on function definitions with same GUID in active functions file for different protocols [ID_35800]

The CheckDveInconsistency BPA test has been updated with a check to make sure function definitions do not have the same GUID in an active functions file for different protocols, as such a configuration can cause problems.

#### Unnecessary GetEligibleResources call no longer used to calculate path within same element [ID_36388]

Up to now, when calculating a path within the same element, a *GetEligibleResources* call was used to build the search graph, even though this is actually not necessary in that case. This call will no longer be used, resulting in a performance improvement.

#### External service feature enabled for transport booking when it is enabled for the main booking [ID_36413]

<!-- See Fixes for fix part of RN -->

When the main booking uses the external service feature, this feature will now also be enabled for the transport booking, so that transport services are no longer always created for such main bookings.

### Fixes

#### Service for transport booking placed in incorrect view [ID_36413]

<!-- See Enhancements for enhancement part of RN -->

In some cases, it could occur that the services for transport bookings were not placed in the correct view. For example, for a main booking in the "IP" view, the transport booking was not placed in the "IP - Contributing" view as it should have been. This issue has been resolved.

#### Problem when end time for booking was set in the past [ID_36426]

When an ongoing booking is updated, its status will first change to *Confirmed* and then to the correct status. Because of this behavior, a retry mechanism was implemented to wait for the correct status. However, this did not work correctly when the end time for a booking was set in the past.

This could for instance cause errors like in the example below:

```txt
ERROR: Skyline.DataMiner.Library.Exceptions.ResourceManagerException: Failed to get updated reservation b540a15b-e01d-43d6-b31c-e70943dfcc07 with new Status Ongoing.
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ChangeTimeAction.UpdateReservationTiming(ISrmManagersContext context, ChangeTimeInputData newTiming, Boolean forceQuarantine)
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ChangeTimeAction.UpdateMainAndLockedContributingReservationsTiming(ISrmManagersContext context, ChangeTimeInputData newTiming, Boolean forceQuarantine, Guid parentReservationId)
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ChangeTimeAction.UpdateLockedContributingReservationsTiming(ISrmManagersContext context, ChangeTimeInputData newTiming, Boolean forceQuarantine)
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ChangeTimeAction.UpdateMainAndLockedContributingReservationsTiming(ISrmManagersContext context, ChangeTimeInputData newTiming, Boolean forceQuarantine, Guid parentReservationId)
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ChangeTimeAction.UpdateLockedContributingReservationsTiming(ISrmManagersContext context, ChangeTimeInputData newTiming, Boolean forceQuarantine)
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ChangeTimeAction.UpdateMainAndLockedContributingReservationsTiming(ISrmManagersContext context, ChangeTimeInputData newTiming, Boolean forceQuarantine, Guid parentReservationId)
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ChangeTimeAction.UpdateReservationDate(Boolean forceQuarantine)
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ChangeTimeAction.Execute(Nullable`1 forceQuarantine)
   at Skyline.DataMiner.Library.Solutions.SRM.ReservationAction.ReservationActionFactory.Execute[T](Engine engine, BookingManager bookingManager, ReservationInstance reservation, SrmCache srmCache, InputData inputData, Nullable`1 forceQuarantine)
   at Skyline.DataMiner.Library.Solutions.SRM.BookingManager.Finish(Engine engine, ReservationInstance reservation)
   at Script.StopBooking(Engine engine, ServiceReservationInstance reservation, BookingManager bookingManager, SrmCache cache, ProgressDialog progress)
```

