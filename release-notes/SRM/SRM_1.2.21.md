---
uid: SRM_1.2.21
---

# SRM 1.2.21

> [!NOTE]
> This version requires that **DataMiner 10.1.10-10897 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### Automatic resource selection disabled during editing \[ID_31937\]

To avoid unexpected changes when an existing booking is edited, automatic selection of resources is by default disabled during editing. To nevertheless enable this feature during editing, you can now set the service definition node property *Resource Auto Selection* to *Always*.

#### Profile Load Script Tester connector added \[ID_31950\]

To help with the testing of several use cases, a new *Profile Load Script Tester* connector and associated Automation scripts have been added.

#### Option to enable/disable automatic resource selection \[ID_31975\]

Automatic resource selection can now be enabled or disabled in the resource pool inheritance JSON configuration. By default, this is enabled.

For example:

```json
{
   "Link": "RESOURCEPOOL",
   "PoolName": "The name of the resource pool",
   "ShouldAutoSelectResource": false
}
```

In the Booking Wizard, if the resource is not automatically selected, the box listing all available resources will also contain the option *No Resource*.

#### New Booking Logging Max File Size parameter \[ID_31984\]

It is now possible to configure the maximum size of the SRM log files. For this purpose, a new *Booking Logging Max File Size* parameter has been added on the *General* > *Logging Settings* data page of the Booking Manager.

## Changes

### Enhancements

#### Improved message when booking timing could not be adjusted \[ID_31637\]

When it was not possible to adjust the start and finish time of a booking, up to now, a message was displayed that could be confusing: "*Failed: Booking will start/finish soon*".

This message has been improved to be more clear. It will no longer mention "Failed" and will include the time when the booking will start or finish.

#### BREAKING CHANGE: SRM_CustomProperty deprecated \[ID_31746\]

The script *SRM_CustomProperty* is now considered deprecated, as it only allows the updating of one property at a time. For the same reason, the methods *AddOrUpdateCustomProperty* and *TryAddOrUpdateCustomProperty* (available in *Skyline.DataMiner.Library.Solutions.SRM.ReservationInstanceExtensions*) have become obsolete.

Instead, we recommend to use *UpdateServiceReservationProperties* (available in *Skyline.DataMiner.Library.Reservation.ServiceReservationInstanceExtensions*).

#### Booking actions reviewed to improve performance \[ID_31816\]

To improve performance, a script will no longer be triggered when the methods of the Booking Manager class are executed to perform one of the following actions:

- Confirm
- Change time
- Start
- Finish
- Extend
- Cancel
- Delete
- Change name
- On hold
- Take ownership
- Release ownership
- Leave quarantine
- Leave interrupted

#### Revised order of activities when booking starts \[ID_31817\]

The order of activities when a booking starts has been revised to prevent possible issues in case the orchestration takes too long. Now DVEs that are part of the service will be added as soon as the service is created, before LSO is started. The *Monitoring* property of the booking will also be added before LSO is started.

#### Support for displaying group filtering screen when booking is created partially silently \[ID_31868\]

A new *AssignFilterToFunctionResources* option is now available in the *WizardUserInteraction* class, which will make it possible to display the group filtering screen when a booking is created partially silently.

In addition, the following two new methods are available in the *Booking Manager* class so that this screen can be displayed with its values already filled in:

```csharp
public ReservationInstance CreateNewBooking(
   Engine engine,
   WizardUserInteraction wizardUserInteraction,
   Booking bookingData,
   IEnumerable<Function> functions,
   IEnumerable<Event> events,
   IEnumerable<Property> properties,
   IEnumerable<Group> groups)
```

```csharp
public bool TryCreateNewBooking(
   Engine engine,
   WizardUserInteraction wizardUserInteraction,
   Booking bookingData, IEnumerable<Function> functions,
   IEnumerable<Event> events,
   IEnumerable<Property> properties,
   IEnumerable<Group> groups,
   out ReservationInstance reservationInstance)
```

#### SRM_BookResourcesQuickly script adjusted to take local time into account \[ID_31890\]

The *SRM_BookResourcesQuickly* script has been adjusted to take the local time of the DMA client into account.

#### ServiceResources field of SrmServiceInfo object no longer populated \[ID_31933\]

To improve performance, the *ServiceResources* field of *SrmServiceInfo* object will no longer be populated, as this field is no longer used.

> [!NOTE]
> In existing setups, we recommend that you run the migration script *SRM_MigrateSrmServiceInfo* to adjust these objects.

#### Possible to edit booking start time during pre-roll stage \[ID_31946\]

When a pending booking was edited while it was in the pre-roll stage, up to now the existing start time of the booking, including the pre-roll time, was always kept. This behavior has now been modified, so that the start time can be changed if the pre-roll stage has already started.

#### API extended to specify log level/type when logging a message \[ID_31988\]

The API has been extended to make it possible to specify the log type and level of a logged message. For this purpose, you can use *BufferActionMessage* and *BufferDebugMessage*. The latter allows you to set the log level of a debug log message. *LogActionMessage* and *LogDebugMessage* have also been added to allow the message to be immediately written to the log file.

An example is available in the *SRM_LSOTemplate* Automation script:

```csharp
// Add information about the Service State that was Orchestrated and the amount of the (non)configured Resource.
// Add as Critical when some resources weren't configure, otherwise as Normal.
srmBookingConfig.Logger.BufferActionMessage($"Orchestrated service state '{enhancedAction.ServiceState}' (configured {nonConfiguredResources - configuredResources}/{configuredResources})", nonConfiguredResources > 0 ? LogEntryType.Critical : LogEntryType.Normal);
```

#### New methods to allow semi-silent booking editing \[ID_32000\]

Two new methods have been added to the Booking Manager class to allow the editing of bookings in semi-silent mode.

```csharp
public ReservationInstance EditBooking(
   Engine engine,
   WizardUserInteraction wizardUserInteraction,
   Guid reservationId,
   Booking bookingData,
   IEnumerable<Function> functions = null,
   IEnumerable<Event> events = null,
   IEnumerable<Property> properties = null,
   IEnumerable<Group> groups = null)
```

```csharp
public bool TryEditBooking(
   Engine engine,
   WizardUserInteraction wizardUserInteraction,
   Guid reservationId,
   Booking bookingData,
   IEnumerable<Function> functions,
   IEnumerable<Event> events,
   IEnumerable<Property> properties,
   IEnumerable<Group> groups,
   out ReservationInstance reservationInstance)
```

### Fixes

#### DTR not triggered when transport resource changed \[ID_31887\]

When a transport resource changed, it could occur that data transfer rules (DTR) were not triggered.

#### Not possible to rename booking in cluster setup \[ID_31930\]

In a DataMiner cluster setup, when multiple DMAs were configured to store bookings, it could occur that the service for a booking was created on a different DMA than the one where the booking was stored. When the booking was renamed, this caused an exception to be thrown because the service could not be found on the DMA.

#### Not possible to find matching contributing resources when creating permanent booking based on service profile \[ID_31989\]

In systems with a negative time zone, when a booking with permanent service was created based on a service profile, it could occur that matching contributing resources could not be found.
