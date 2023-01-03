---
uid: SRM_1.2.14
---

# SRM 1.2.14

## New features

#### Service profile booking creation with persistent service \[ID_29864\]

It is now possible to create bookings based on service profiles using the persistent service feature. When the persistent service is selected during booking creation, the service definition selection will be fixed, so that it can no longer be modified.

#### Support for automatically assigned alarm and trend template for generated service \[ID_29890\]

In addition to an enhanced service protocol, you can now assign an alarm and/or trend template to a newly generated booking service, using the service definition property *Enhanced Protocol*.

JSON example of the property value:

```json
{
    "ProtocolName" : "Name of the protocol",
    "ProtocolVersion": "Version to use",
    "AlarmTemplate": "Name of the alarm template",
    "TrendTemplate": "Name of the tend template"
}
```

#### Extra isSilent parameter for Booking Manager methods \[ID_29937\]

To make it possible to hide specific steps in the wizard to create a new booking, a number of methods in the Booking Manager class now have an extra *isSilent* parameter.

If this parameter is set to false, the step is shown in the Booking Wizard; if it is set to true, the method is executed silently:

```csharp
public ReservationInstance CreateNewBooking(Engine engine, BookingManagerInfo bookingManagerInfo, Booking bookingData, IEnumerable<Function> functions, IEnumerable<Event> events, IEnumerable<Property> properties, IEnumerable<Group> groups, bool isSilent = true)

public ReservationInstance CreateNewBooking(Engine engine, Booking bookingData, IEnumerable<Function> functions = null, IEnumerable<Event> events = null, IEnumerable<Property> properties = null, IEnumerable<Group> groups = null, bool isSilent = true)

public ReservationInstance CreateNewBookingWithResourceFilters(Engine engine, Booking bookingData, IEnumerable<Function> functions = null, IEnumerable<Event> events = null, IEnumerable<Property> properties = null, Dictionary<string, List<ResourceCapabilityUsage>> resourceFilters = null, bool isSilent = true)

public bool TryCreateNewBooking(Engine engine, BookingManagerInfo bookingManagerInfo, Booking bookingData, IEnumerable<Function> functions, IEnumerable<Event> events, IEnumerable<Property> properties, IEnumerable<Group> groups, out ReservationInstance reservationInstance, bool isSilent = true)

public bool TryCreateNewBooking(Engine engine, Booking bookingData, IEnumerable<Function> functions, IEnumerable<Event> events, IEnumerable<Property> properties, IEnumerable<Group> groups, out ReservationInstance reservationInstance, bool isSilent = true)
```

#### Skyline Booking Monitoring protocol integration \[ID_29955\]

The *Skyline Booking Monitoring* protocol, which allows additional monitoring of bookings, can now be integrated with the Booking Manager app. For this purpose, the following two parameters can be configured on the *Config* > *General* tab of the app:

- *Bookings Monitoring Element*: The name of the element using the *Skyline Booking Monitoring* protocol.
- *Bookings Monitoring Mode*: Can be set to the following modes:

  - *None*: The monitoring element is not used.
  - *Non-Nominal*: The monitoring element only features failed, quarantined and interrupted bookings.
  - *Nominal*: The monitoring element features all bookings that have started.

#### New network path configuration options \[ID_29963\]

Two new configuration options have been added to the *TransportLink* field of a network path configuration.

##### ExcludedNode

To begin with, it is now possible to exclude interfaces from a network path based on the node where they reside. This can be useful to further improve reliability in case of failover.

To configure this, in the path configuration, set the *Option* property of the *TransportLink* field to *ExcludeNode*. If the *Strictly* property of the *TransportLink* field is set to *true*, only paths that do not share the same nodes will then be returned. If it is set to *false*, paths that do not share the same nodes will be preferred, and nodes that do not share the same interfaces will be preferred for fallback.

##### Weighted

In addition, it is now possible to apply a weighted order to the paths with the new *Weighted* property in the *TransportLink* field. If this property is set to *true*, it is only taken into account if *Strictly* is also *true*. The behavior then depends on the value of the *Options* property:

- *ExcludeNode*: Paths will be ordered in ascending order based on the number of nodes they share with the linked path, and after that based on the number of interfaces they share.

- *Exclude*: Paths will be ordered in ascending order based on the number of interfaces they share with the linked path.
- *Include*: Paths will be ordered in descending order based on the number of interfaces they share with the linked path.

    > [!NOTE]
    > The *NrOfSuggestions* field of the network path configuration limits the number of paths before filtering is applied. If more paths are available, the preferred path may not be included.

##### Example

```json
"TransportLink": {
    "Function": "Main Transport",
    "Option": "ExcludeNode",
    "Strictly": false,
    "Weighted": true,
}
```

#### New TransportBuilder API \[ID_29984\]

A new *TransportBuilder* API is available that allows you to select and assign a path to a contributing transport function. For an existing booking, it will select a transport function and get the paths available for the selection, so that a path can be assigned to the function.

Example:

```csharp
var logger = SrmLogHandler.Create(engine, bookingManager, mainReservation);

// Initialize the helper
var transportBuilder = Skyline.DataMiner.Library.Solutions.SRM.Routing.TransportBuilder
    .Create(engine, bookingManager, logger, mainReservation);

// Select the transport function that needs assigning
var transportFunction =
    transportBuilder.TransportFunctions
        .Single(f => string.Equals(f.Label, "Transport"));

// Select a path
var path = transportFunction
    .GetPaths()
    .FirstOrDefault();

if (path != null)
{
    // Assign the path to the function
    path.Assign(out var contributingResource);

    logger.LogMessage($"Path '{path}' was assigned to '{transportFunction.Label}' (Resource ID: {contributingResource.ID})", LogFileType.Debug);
}
```

## Changes

### Enhancements

#### Support for pool inheritance on unconnected interfaces \[ID_29779\]

Previously, it was not possible to use the pool inheritance feature on unconnected interfaces if the selected pool item was not booked. Now this will be supported if the property *NoConnectivityCheck* of these interfaces is set to *True*.

#### Possible to finish unlocked contributing booking that is in use \[ID_29809\]

Previously, it was never possible to finish an unlocked contributing booking that was in use in a main active booking. Now this will be possible as long as the timing of the bookings remains compatible.

#### Additional validation when booking is confirmed \[ID_29810\]

Additional validation has been added to ensure that all profiles and resources in a booking are in order when it is confirmed.

#### Possible to skip assigning profile instance if node is marked as optional \[ID_29820\]

When assigning profiles and resources to a custom service definition in the booking wizard, it is now possible to skip assigning a profile instance for a transport node that is marked as optional for this (with the *IsProfileInstanceOptional* property).

#### Possible booking actions restricted in case user is not the booking owner \[ID_29825\]

The Booking Manager app will now no longer allow you to confirm a booking if it is owned by a different user. In case a booking is owned by a different user, the Confirm, Extend, Cancel, Finish, Change Time, On Hold, Delete, Delete Service, Start and Change Name actions will now also be hidden in the Booking Manager.

#### Improved silent editing of bookings \[ID_29867\]

Editing bookings without user interaction has been made more efficient, which will result in improved performance.

#### Improvement to service definitions with custom Dijkstra contributing booking \[ID_30104\]

The following improvements have been implemented to the way a service definition is built when a custom Dijkstra contributing booking is added:

- The *IsProfileInstanceOptional* of each node is now set to true.
- The interface IDs are now retrieved from the function definition. The ID of the first input or output interface is defined and connected.

In addition, a migration script *SRM_MigrateTransportServiceDefinitions* is now available that allows you to update your current custom transport service definitions and their bookings, so that these also contain these improvements.

### Fixes

#### Icon View Name for custom booking actions could not be set to root view \[ID_29749\]

When you set the *Icon View Name* in the custom booking action table to the root view of the DMS, this view was incorrectly considered invalid.

#### Capacities not defined in profile instance included when retrieving available resources \[ID_29764\]

When the list of available resources was requested, the SRM framework would include all capacities defined in the profile definition, even if they were in fact not defined in the selected profile instance.

#### Problem loading profile definitions \[ID_29789\]

In some cases, it could occur that profile parameters were not displayed in the Booking Wizard step where resources and profiles are assigned. This depended on the description used for the profile definition.

#### DST change not taken into account \[ID_29838\]

In the Booking Wizard and Service Profile Wizard, it could occur that the change to or from Daylight Saving Time was not taken into account.

#### Transition to service state not possible for contributing booking with orchestration type "Main" \[ID_29909\]

When a contributing booking was configured with "OrchestrationType" set to "Main", it could occur that it could not transition to a different service state.

#### Custom booking block not updated with changed booking name \[ID_29923\]

When a booking was renamed, it could occur that the information in the corresponding custom booking block on the Booking Manager timeline was not updated.

#### Problem adding Visio file for enhanced protocol of contributing resource \[ID_29997\]

It could occur that the following exception was displayed in the logging for a contributing resource booking, even though the Visio file specified in the contributing configuration of the service definition was correct:

```txt
Could not add the enhanced protocol's visio: (Code: 0x80040239)
```

To prevent this issue, the contributing protocol creation logic in the script *SRM_CustomDijkstraContributingReservation* has been aligned with that of other scripts. This means that this script will now only set the Visio drawing when a new protocol is created.
