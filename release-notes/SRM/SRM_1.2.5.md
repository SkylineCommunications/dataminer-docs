---
uid: SRM_1.2.5
---

# SRM 1.2.5

## New features

#### Support for use of 'pool resource' in bookings \[ID_26701\]

When creating a booking, you can now select a so-called pool resource instead of a specific resource. At the start time of the booking, this pool resource will be replaced by a specific resource.

To enable this feature, the option *Pool Resource* must be enabled in the Booking Manager. In addition, the property *Allow Resource Type* must be added to the service definition node for which you want to use a pool resource. This property must have the value *PoolResource*. Finally, the resource must be created manually with the capability *Resource Type* set to the value *PoolResource*.

#### Possibility to display discrete custom property values with checkboxes in the Booking Wizard \[ID_26756\]

On the *Configuration* page of the Booking Manager, you can now configure custom properties with discrete values to be displayed with checkboxes in the Booking Wizard instead of with the usual drop-down box. To do so, in the *Type* column of the *Properties* table, select *Discreet Checkboxes* in the drop-down box for the custom property.

This way, users will be able to select multiple values for this property in the Booking Wizard. If multiple values are selected, they will be combined using a semicolon (";") as separator.

#### New parameters to determine scripts used in Booking Manager app \[ID_26883\]

On the *Config* page of the Booking Manager element, you can now configure the following parameters in order to determine which scripts are used on the *Bookings* page of the Booking Manager app:

- *Create Booking Script*: The script used to create a new booking, edit a booking or duplicate a booking. By default, this is *SRM_CreateNewBooking*.
- *Leave Quarantine Script*: The script used when a user clicks *Try Leave Quarantine*. By default, this is *SRM_LeaveQuarantine*.
- *Reservation Action Script*: The script used for various actions such as Adjust Time, Cancel, Finish, Start, Confirm, etc. By default, this is *SRM_ReservationAction*.
- *Define Booking Script*: This script is not yet used in the current version of the SRM Standard Solution. By default, this is *SRM_DefineBooking*.

Note that changing these parameters has no influence on silent booking procedures.

## Changes

### Enhancements

#### New methods to retrieve service profile data \[ID_26816\]

New methods have been added to the SLSRMLibrary to allow easy retrieval of service profile data.

In the *ServiceProfileDefinitionCrudHelperComponent* class of the *Skyline.DataMiner.Library.Solutions.SRM.Extensions.ServiceProfileDefinitionCrudHelperComponentExtensions* namespace, the following extension methods have been added:

- *GetServiceProfileDefinitionByName*: Retrieves the first service profile definition matching a specific name. If no match is found, an exception of type *ServiceProfileDefinitionNotFoundException* will be thrown.
- *GetServiceProfileDefinitionByGuid*: Retrieves the first service profile definition matching a specific GUID. If no match is found, an exception of type *ServiceProfileDefinitionNotFoundException* will be thrown.

In the *ServiceProfileInstanceCrudHelperComponent* class of the *Skyline.DataMiner.Library.Solutions.SRM.Extensions.ServiceProfileInstanceCrudHelperComponentExtensions* namespace, the following extension methods have been added:

- *GetServiceProfileInstanceByName*: Retrieves the first service profile instance matching a specific name. If no match is found, an exception of type *ServiceProfileInstanceNotFoundException* will be thrown.
- *GetServiceProfileInstanceByGuid*: Retrieves the first service profile instance matching a specific GUID. If no match is found, an exception of type *ServiceProfileInstanceNotFoundException* will be thrown.

In *Skyline.DataMiner.Library.Solutions.SRM.Extensions.ServiceProfileDefinitionExtensions*, the following methods have been added:

- *GetApplicableServiceDefinitions*: Retrieves the service definitions applicable to a specific service profile definition.
- *GetApplicableServiceProfileInstances*: Retrieves the service profile instance applicable to the service profile definition.

#### New method and constructor to support service profile integration \[ID_26842\]

A new method has been added to the *BookingManager* class in order to allow users to create bookings based on service profiles:

```csharp
BookingManager.TryCreateNewBooking(Engine engine, Model.DefineBooking.InputData inputData, out ReservationInstance reservationInstance);
```

The *InputData* class represents the data a user can select when executing the *SRM_DefineBooking* script.

A new constructor for *Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBooking.InputData* has also been added:

```csharp
public InputData(ServiceProfileProcessingInfo mainBookingServiceProfileInfo);
```

This constructor receives an instance of *ServiceProfileProcessingInfo* and automatically searches for all default contributing data, so that a user only needs to select a service profile instance. To have the service profile instance properly configured, a *Profile Instance* property must be assigned to all service definition nodes and mapped to a service profile instance. Note that a service profile instance can be applicable for multiple service definitions, but in this case the first of these service definitions that is encountered will be used.

#### SRM_DiscoverResources script now allows concurrency and multiple resource pool configuration \[ID_27018\]

The *SRM_DiscoverResources* script now allows users to set the concurrency of resources. When a file is exported, it now contains a *Concurrency* column, in which you can specify the resource concurrency value.

In addition, the script now supports multiple resource pools. Previously, it would use the sheet name as the resource pool. While this behavior is still supported, you can now specify the resource pools in the *Resource Pools* column instead, using a comma-separated list of resource pool names.

#### SRM_DiscoverResources script no longer stops upon encountering unlinked resources \[ID_27021\]

If the *SRM_DiscoverResources* script encounters multiple unlinked resources, it will now no longer stop running. It will instead skip the unlinked resources but continue to handle any linked resources.

### Fixes

#### Inconsistent behavior of GetResourceUsage(int nodeId) method \[ID_26560\]

When no resource was assigned to a node, it could occur that the *GetResourceUsage(int nodeId)* method nevertheless returned an *SrmResourceUsageConfiguration*. This behavior was inconsistent compared to the *GetResourceUsages()* method, which filters out resource usages without assigned resource.

#### Renaming booking failed \[ID_26563\]

When a booking was edited and renamed, it could occur that it still kept the old booking name.

#### Booking status not updated correctly \[ID_26679\]

In some cases, it could occur that the status of a booking was not updated correctly by the *SRM_BookingActions* script.

#### Problem when duplicating booking with resource pool inheritance \[ID_26732\]

If a booking using resource pool inheritance was duplicated, an error could occur, which could make it impossible to edit the duplicated booking.

#### Problem with Shrink Post-Roll feature \[ID_26738\]

In some cases, it could occur that the "Shrink Post-Roll" feature did not function correctly, causing the Stop event of a booking to be rescheduled.

#### Problem when updating value of empty parameter from profile instance \[ID_26753\]

In some cases, it could occur that the value of empty parameters from profile instances could not be updated after the initial set.

#### Canceling contributing booking did not remove corresponding DataMiner objects \[ID_26754\]

When a contributing booking was canceled, it could occur that the associated DataMiner service, enhanced element and resource were not removed.

#### Various issues with booking creation \[ID_26789\]

The following issues have been resolved:

- In some cases, if you connected to the DMS via a different DMA than the one hosting the Booking Manager, it could occur that creating a new booking failed.
- When a contributing booking was created, the wizard did not wait until the corresponding protocol existed before it tried to create the contributing resource, which could potentially cause issues.

#### Booking duration displayed incorrectly if client used 12-hour format \[ID_26864\]

If the client computer used a 12-hour format, it could occur that the booking duration was not displayed correctly.

#### Not possible to disable Booking Start Failure Script parameter \[ID_26867\]

When a script had been assigned to the *Booking Start Failure Script* parameter in the Booking Manager, it was not possible to set this parameter back to having no script assigned.

#### Bookings page not sorted correctly by time \[ID_26875\]

It could occur that the Bookings table of the Booking Manager could not be sorted correctly by time.

#### UI Row configuration for custom properties/events not applied in Booking Wizard \[ID_26878\]

When custom properties or events were configured in the Booking Manager, the order that was specified in the *UI Row* column for the properties or events was not taken into account in the Booking Wizard.

#### Contributing booking used by several main bookings finished incorrectly \[ID_26881\]

When a contributing booking was used by several running main bookings, it could occur that the contributing booking was also finished when one of the main bookings was finished, while the other main bookings were still running.

#### Booking Manager visual overview contained two Post-Roll columns \[ID_27007\]

In the Booking Manager visual overview, it could occur that the *Created At* column had the header *Post-Roll* instead, so that there seemed to be two *Post-Roll* columns.
