---
uid: SRM_1.2.27
---

# SRM 1.2.27

> [!NOTE]
> This version requires that **DataMiner 10.2.7.0-11922 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### Improved resource orchestration wizard [ID_33819]

The resource orchestration wizard has been reviewed in order to simplify its usage. The input parameter will now accept the following fields in JSON format:

- *BookingManagerElement*: Provides information about the Booking Manager application.
- *ReservationId*: Optional. Provides the reservation ID in case a booking is being edited.
- *ResourceIds*: Optional. A list of comma-separated resource IDs to be added to the booking
- *Timing*: Optional. Information about the timing of a booking in case a new booking is being created. For example: `{"StartDate":"28/06/2022 16:00", "PreRoll":"00:01", "PostRoll":"00:01", "EndDate":"29/06/2022 16:00"}`

This way, the script can be used to create a booking or update a booking that has not started yet. It will allow the user to select the node and interface profile instance for each resource.

#### Finishing or canceling a failed booking [ID_34034]

The *Finish*, *Extend*, and *Change End Time* buttons will now be enabled for bookings in the Failed state.

The following behavior now applies:

- If a booking is in the "Failed" state, you can cancel it, as the booking never started.
- If a booking is in the "Failed Service Pre-Roll", "Failed Service Active", or "Failed Service Post-Roll" state, you can finish the booking, as it has already started.
- If a booking is in the "Failed Completed" state, nothing can be done, as the booking is already finished.

## Changes

### Enhancements

#### New BookingId property [ID_33950]

When the *TryCreateNewBooking* method was used to create a new booking, but the creation failed, up to now there was no way to know which log file was created. To make this possible, the *Booking* class now has a new *BookingId* property indicating the ID of a booking that will be created, so that users can know the ID of the booking they are trying to create.

#### Improved exception in case Booking Manager is in error state [ID_34068]

When an error happened to a Booking Manager element and you tried to access the element, a null reference exception was thrown. To make debugging easier, in such a case now a *BookingManagerConfigurationException* is thrown that indicates that there is a problem with the element.

#### Support for service definition node (interface) properties in SRM configuration import/export [ID_34085]

When you import or export a full SRM configuration, this now includes service definition node and service definition node interface properties. If no property config file is found, a property will be registered as a string.

#### Support for service profile definitions and instances in SRM configuration import/export [ID_34134]

When you import or export a full SRM configuration, this now includes service profile definitions and service profile instances.

#### SRM_LSOTemplate example script no longer includes exception stack trace in user log when failing to configure a resource [ID_34178]

The *SRM_LSOTemplate* example script no longer includes the exception stack trace in the user log when it fails to configure a resource. The user log will only contain the exception message, while the full exception can be found in the debug log.

Note that this is just an example script, so you will need to implement this in your own LSO scripts if you want to follow this example. However, this is not mandatory, as you can handle exceptions differently depending on what best suits your setup.

### Fixes

#### Duplicated events when creating booking with wizard [ID_33794]

When a booking was created using the Create New Booking wizard, and the user clicked *Back* in the last screen and then changed the timing in the first screen, it could occur that duplicate events were created.

#### ResourceCapacityInvalid error when copying capacity to network node  with DTR [ID_34028]

When a capacity was copied to a network node with a data transfer rule and the capacity was not passed in the function array, a *ResourceCapacityInvalid* error could be thrown.

#### Various issues [ID_34046]

The following issues have been fixed:

- In the *Service State Transitions* table, it was possible to add empty entries or update existing entries to empty entries.
- When the Booking Manager was first configured, a problem could occur in the wizard because the *Application Services* view did not have the view containing the element as its default value.
- The context menu of the *SLA Tracking States* table created items with default values instead of asking for values.
- The message when the *Block Info Table* was cleared was not correct.

#### Not possible to filter on capability when using resource inheritance [ID_34051]

Parameters of a virtual function resource can be filtered based on resource capability. However, when resource inheritance was used, it could occur that this feature did not work.

#### Not possible to create permanent booking [ID_34055]

A problem in the script *SRM_DefineBookingMainInfo* could make it impossible to create permanent bookings. The following exception was thrown:

```txt
Skyline.DataMiner.Automation.ScriptAbortException: failed creating new booking: Skyline.DataMiner.Library.Exceptions.InvalidBookingDataException: Duration can't be defined when PermanentService flag is set to true
```

#### Bookings not displayed after Booking Manager restart if Virtual Platform was set to white space [ID_34065]

If the *Virtual Platform* parameter was set to a white space, it could occur that bookings were no longer displayed in the timeline after a Booking Manager restart. This was caused by the white space being reset to an empty string during the restart.

#### Configuration export failed when started on other DMA than the one running the Booking Manager [ID_34103]

When an SRM full configuration export was started from a different DMA than the one running the Booking Manager element, it could occur that the export failed.

#### Problem when booking capacity on parameter without step size [ID_34181]

A problem could occur in the *SRM_BookResourcesQuickly* script when capacity was booked on a parameter that had no step size defined.
