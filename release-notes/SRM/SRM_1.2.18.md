---
uid: SRM_1.2.18
---

# SRM 1.2.18

## New features

#### Possibility to remove resource and node from booking \[ID_30812\]

It is now possible to remove a resource and the corresponding service definition node from a booking, even if this booking is already running. If there is a service definition compatible with the change, this will be used; otherwise a new service definition will be created and assigned to the booking.

#### Returning values from Profile Load scripts to an LSO script \[ID_30862\]

Values from Profile Load scripts can now be returned to an LSO script. For this purpose, you can use the method *ProfileParameterEntryHelper.AddOrUpdateResult(string key, string value)* in the Profile Load script to add different results with a key. In the LSO script, you can use the method *ApplyProfileWithReturn* (and similar methods for contributing resources, unmapped resources, etc.) to get the result dictionary.

> [!NOTE]
> This is not supported for unmapped contributing resources.

#### Role property to categorize usage of resources \[ID_30881\]

When a resource is assigned, the *Role* property of the *ServiceResourceUsageDefinition* object will now be set to one of the following values:

- *Mapped*: If the resource is mapped to a node in the service definition.
- *Unmapped*: If the resource is not mapped to a node in the service definition.
- *Inheritance*: If the resource is inherited from a linked resource pool.

To make sure this property is set correctly for existing bookings, you can use the migration script *SRM_SRM_MigrateServiceResourceUsageDefinitionRole*, which is now available in the SRM framework.

#### 'Lite' contributing resources \[ID_31182\]

To allow faster creation of contributing bookings, a new kind of "lite" contributing resources can now be used. These only include the essential aspects to get a contributing booking up and running as quickly as possible. When a main booking using a lite contributing resource starts, the corresponding contributing service will be available under the main booking service.

The main difference between a lite contributing resource and a regular contributing resource is that no enhanced element is generated for the former, which can greatly reduce the creation time.

To use this feature, add the *LiteContributingResource* property to your contributing configuration, with its value set to *true* or *false* depending on whether you want a lite contributing resource to be used. If the property is not specified, regular contributing resources will be created.

## Changes

### Enhancements

#### Improved performance when creating transport bookings silently \[ID_30866\]

Performance has improved when transport bookings are created in silent mode.

#### Orchestration logging enhancements \[ID_30975\]

A number of enhancements have been implemented to orchestration logging:

- If a log file is continuously locked, flushing of data to the file will time out, based on the *Retry Timeout* parameter defined in the Booking Manager.
- If an issue occurs while debug log entries are appended to a log file, flushing will fail silently.
- A log file can now be created during resource orchestration, based on the resource ID and orchestration date.

#### Booking creation/editing methods now use SrmCache object \[ID_30986\]

A number of methods to create and edit bookings can now use an *SrmCache* object as input in order to improve performance:

```csharp
public ReservationInstance CreateNewBooking(Engine engine, SrmCache srmCache, Booking bookingData, IEnumerable\<Function> functions, IEnumerable\<Event> events = null, IEnumerable\<Property> properties = null);
```

```csharp
public ReservationInstance EditBooking(Engine engine, Guid reservationId, SrmCache srmCache, Booking bookingData, IEnumerable\<Function> functions = null, IEnumerable\<Event> events = null, IEnumerable\<Property> properties = null);
```

```csharp
public static ServiceReservationInstance AssignResources(this ServiceReservationInstance reservation, Engine engine, SrmCache srmCache, params AssignResourceRequest\[\] requests)
```

```csharp
public static ServiceReservationInstance UnassignResources(this ServiceReservationInstance reservation, Engine engine, SrmCache srmCache, params AssignResourceRequest\[\] requests)
```

#### Profile instance now optional for node interfaces of transport service definition \[ID_31011\]

When a contributing booking using a custom path or a main booking making use of such a contributing booking was confirmed, it could occur that this failed if no profile instance was set on the interfaces of a transport node.

To prevent this, each defined interface will now by default have the *IsProfileInstanceOptional* property set to true.

To update existing bookings and service definitions with this change, a migration script (*SRM_MigrateTransportServiceDefinitions*) is available.

#### Logging for silent transport booking creation \[ID_31053\]

New logging entries are now added when silent bookings using transport bookings are created.

#### Silent booking creation with transport nodes adjusted \[ID_31055\]

The behavior of silent booking creation has been adjusted for bookings containing transport nodes.

- When the transport node is not configured to be optional with the *Options* property, and the *Auto Select Resource* property is set to *No*, booking creation will fail.

- When the transport node is not configured to be optional with the *Options* property, and the *Auto Select Resource* property is set to *Yes*, booking creation will only succeed if paths are available.

- When the transport node has the *Options* property set to *Optional* and the *Auto Select Resource* property is set to *No*, only the main booking will be created, and it will be possible to create the transport booking later.

The following table provides an overview of the new and old behavior.

| Options property             | Auto Select Resource property | Paths Available | Previous behavior          | New behavior               |
|------------------------------|-------------------------------|-----------------|----------------------------|----------------------------|
| No value (node is mandatory) | No                            | No              | Main created               | Creation fails             |
|                              |                               | Yes             | Main created               | Creation fails             |
|                              | Yes                           | No              | Main created               | Creation fails             |
|                              |                               | Yes             | Main and transport created | Main and transport created |
| Optional                     | No                            | No              | Main created               | Main created               |
|                              |                               | Yes             | Main and transport created | Main created               |
|                              | Yes                           | No              | Main created               | Main created               |
|                              |                               | Yes             | Main and transport created | Main and transport created |

#### Improved logging when silent editing of booking fails \[ID_31070\]

When the silent editing of a booking failed, the logging contained more data than necessary. Instead of the full serialization of the reservation object, the logging will now only mention that the previous reservation object was restored.

### Fixes

#### Exception when initializing SrmBookingConfiguration \[ID_30792\]

When the *SrmBookingConfiguration* object was initialized, it could occur that exceptions were thrown. For example:

```txt
An issue occurred while initializing logging: System.ArgumentException: Handle manager ID isn't expected to be empty
Parameter name: handlerManagerId
```

```txt
An issue occurred while initializing logging: System.ArgumentException: Handle manager ID isn't expected to be empty
Parameter name: handlerManagerId
```

#### TransportBuilder API did not take transport function parameters into account \[ID_30794\]

When the new *TransportBuilder* API was used (introduced in SRM version 1.2.14), it could occur that the parameter values of the transport function were not taken into account.

#### Resource Assignment filter did not take text capability parameters into account \[ID_30800\]

If a node was configured with the *Resource Assignment* property to filter on resource capabilities, when profiles and resources were assigned to the corresponding function, it could occur that capability parameters of type Text were not taken into account for the filter. Because of this, the profile instance selection could be unavailable, as there were no profile instances left to select.

#### Not possible to leave quarantine if contributing booking was quarantined \[ID_30803\]

When a main booking had at least one contributing booking that was quarantined, it could occur that it was not possible for the main booking to leave the quarantine after its timing had been changed.

An error similar to the following was displayed:

```txt
Reservation Action failed due to: Skyline.DataMiner.Library.Exceptions.ResourceManagerTraceDataException: Failed to remove Reservation named 'bb' from quarantine
```

#### Life cycle contributing booking changed upon change to life cycle main booking \[ID_30871\]

When the life cycle of a main booking was updated, it could occur that the life cycle of a contributing booking was also updated, even though this should not happen.

#### SRM_BookingActions script used incorrect script to apply custom action \[ID_30941\]

When a custom action, defined in a service definition, was applied to a booking, the *SRM_BookingActions* script looked for the LSO script by searching for the first action of which the name of the applied state started with the name of the script. However, this could cause an incorrect script to be executed, so now the complete script name will be looked up instead.

#### SRM_ExposedResourceState no longer stored in static variable \[ID_30985\]

Because the parameter *SRM_ExposedResourceState* was stored in a static variable up to now, if for some reason it was deleted manually, this could potentially cause issues. To prevent this, the parameter is now retrieved from DataMiner.

#### Incorrect booking creator displayed in Bookings list \[ID_31013\]

In some cases, instead of the name of the user who created a booking, the Booking Manager showed "Administrator" in the Bookings list.

This will no longer occur, and when a booking is created silently, the *CreatedBy* property will now also be added to the booking with the correct username as its value.

#### Path InputReference functionality not working correctly \[ID_31040\]

When the *InputReference* field was used in a path configuration, it could occur that no transport input reference was filled in.

#### SetParameterThread RTE when SRM Manager is stored in QAction instance \[ID_31173\]

In some cases, when SRM Managers were stored in QAction instances, the Booking Manager connector could cause SetParameterThread RTEs. To prevent this, from now on SRM Managers will be instantiated when such a QAction runs.
