---
uid: SRM_1.1.0
---

# SRM 1.1.0

## New features

#### New ConvertToContributing option in Contributing Config service definition property [ID_23538]

In the *Contributing Config* property of a service definition, you can now add a *ConvertToContributing* option. If this option is specified and set to true, a checkbox is included in the Booking Wizard that can be selected to automatically convert the booking to a contributing booking.

For example:

```json
{
   "ParentSystemFunction": "b91f59c8-58f2-4422-9a28-f0a6bf815ab0",
   "ResourcePool": "Rx Sat",
   "ReservationAppendixName": "RXSAT",
   "LifeCycle": "Unlocked",
   "ConvertToContributing":"true"
}
```

#### SRM_DiscoverResources script updated [ID_23632]

The *SRM_DiscoverResources* script, which can be used to import and export resources, has been extended to support the quarantine feature and to be used in interactive mode.

The script requires the following input parameters:

- *Operation*: "Import" or "Export"

- *Input Data*: A JSON string, consisting of the *ForceUpdate* and *IsSilent* fields (both by default false).

    For example: `{"ForceUpdate":"false", "IsSilent":"true"}`

    *ForceUpdate* determines whether the script will force an update of resources even if this will cause one or more bookings to go into quarantine state. If the script is running in interactive mode and bookings need to be moved to quarantine, the user will be warned about this and will have the choice to execute the update or not.

- *File Path*: The path to the folder where the export file needs to be created or the complete path of the file to import.

    For example: `C:\Users\User\Desktop\exportedResources.xls`

    > [!NOTE]
    > The file path must contain the name of the file with the .xls or .xlsx extension.

When a successful export has been executed, the resulting Excel file will contain a row for each resource and a worksheet for each resource pool. A similar Excel file can be imported by the script, in which case every row will be converted to the corresponding resource in DataMiner. However, the following limitations apply for the Excel file:

- The maximum column length is 64 characters.
- Column names must not contain a hyphen ("-") or a period (".") character.
- The file cannot be imported while it is open.

#### New 'NoConnectivityCheck' interface property [ID_23816]

A new interface property, *NoConnectivityCheck* is now supported. If this property is not present or if it is set to any other value than "True" (not case-sensitive), disconnected interfaces are not handled.

However, if this property is set to "True", disconnected interfaces will be loaded and displayed to be configured in the Booking Wizard. This configuration will then be stored in the *ResourceUsage* configuration of the *ReservationInstance* object, so that it can be read by the end user and the corresponding values can be set in the device or system.

#### New GetSrmParametersConfiguration method [ID_23844]

In the *ProfileParameterEntryHelper* class, a new *GetSrmParametersConfiguration* method is now available. The method returns a collection of *SrmParameterConfiguration* objects, containing all the data required to proceed with the configuration of a parameter:

- *MainElement*: The main element of the selected resource.
- *ProfileParameterEntry*: The full profile parameter entry object.
- *ProfileParameterName*: The name of the parameter in the Profile Manager.
- *ProtocolParameterId*: The ID of the parameter in the protocol.
- *ResourceKey*: The resource key entry in the protocol.
- *Type*: Indicates whether the parameter is a standalone or table parameter.
- *Value*: The original parameter value to be set.

Based on this information, the user can then easily apply the retrieved configuration, without any need to request or load further data.

#### SRM_ResourceActions script: New FORCESWAP action [ID_23849]

The *SRM_ResourceActions* script now allows a new *FORCESWAP* action, which swaps a resource for a particular booking, causing other possible bookings to go into quarantine in case the resource no longer has sufficient capacity. This action can currently only be used in "silent mode", i.e. when the script is called from another script, using one of the following methods:

```csharp
BookingManager.TryForceSwapResource(Engine engine, ref ReservationInstance reservation, Guid oldResourceGuid, Guid newResourceGuid, int targetedNode)
```

```csharp
BookingManager.ForceSwapResource(Engine engine, ReservationInstance reservation, Guid oldResourceGuid, Guid newResourceGuid, int targetedNodeId)
```

Example:

```csharp
var success = this.bookingManager.TryForceSwapResource(engine, ref reservation, oldResourceGuid, newResourceGuid, nodeId);
```

#### SRM_ResourceActions script: New action to add resource to running booking [ID_23908]

A new *Add* action has been added to the *SRM_ResourceActions* script, which can be used to add a resource to a running booking.

As input parameters, it initially requires the action and the Booking Manager info, and then the name of the Booking Manager, the GUID of the booking, the GUID of the resource to be added and a label for the underlying service definition node.

To facilitate the use of this new feature, the BookingManager API will now support the following method:

```csharp
TryAddResource(Engine engine, ref ReservationInstance reservation, Guid resourceId, string nodeLabel, bool force = false).
```

#### Profile-load framework: New methods to allow easy retrieval of connected resources [ID_23984][ID_24021]

A number of methods have been added on the *SrmResourceConfiguration* class to allow easy retrieval of connected resources.

```csharp
public IEnumerable<SrmResourceConfiguration> GetConnectedResources();
```

Retrieves the resources that are connected to the current resource.

```csharp
public IEnumerable<SrmResourceConfiguration> GetConnectedResources(InterfaceType interfaceType, string interfaceName);
```

Retrieves the resources that are connected to the interface of type interfaceType and name interfaceName.

If *interfaceName* is null or whitespace, a *System.ArgumentException* is returned.

```csharp
public static IEnumerable<FunctionResource> GetConnectedResources(this Node node, ServiceDefinition serviceDefinition, ServiceReservationInstance reservation);
```

Retrieves the resources connected to a particular node in the context of a particular booking. Requires the node, service definition and reservation (i.e. booking) as input parameters.

If any of the input parameters are null, a *System.ArgumentNullException* is returned.

```csharp
public static IEnumerable<FunctionResource> GetConnectedResources(this Node node, Net.ServiceManager.Objects.ServiceDefinition serviceDefinition, ServiceReservationInstance reservation, InterfaceType interfaceType, string interfaceName);
```

Retrieves the resources connected to the node interface with type *interfaceType* and name *interfaceName*. Requires the node, service definition, reservation (i.e. booking) and the interface type and name as input parameters.

If the node, service definition or reservation are null, a *System.ArgumentNullException* is returned. If *interfaceName* is null or whitespace, a *System.ArgumentException* is returned. If no matching interface is found, an *InterfaceNotFoundException* is returned.

Examples:

```csharp
var bookingConfig = new SrmBookingConfiguration(reservation.ID, bookingManagerInfo);
var decoder = bookingConfig.GetResource("Decoder");
var allConnectedResources = decoder.GetConnectedResources().ToArray();
```

```csharp
var resourcesConnectedToOutputAsi = decoder.GetConnectedResources(InterfaceType.Out, "ASI").ToArray();
```

```csharp
var resourcesConnectedToInputSdi = decoder.GetConnectedResources(InterfaceType.In, "SDI").ToArray();
```

```csharp
var nodeId = configurationInfo.NodeId;
var node = serviceDefinition.GetNode(nodeId);
var connectedResources = node.GetConnectedResources(serviceDefinition, reservation);
```

```csharp
var resourceConnectedToInputAsi = node.GetConnectedResources(
serviceDefinition, reservation, InterfaceType.In, "ASI").SingleOrDefault();
```

## Changes

### Enhancements

#### Resource configuration methods enhanced to allow execution of profile loading script without profile instance [ID_23852]

When the methods *SrmResourceConfiguration.ApplyProfile(string profileAction)* or *SrmResourceConfiguration.ApplyServiceActionProfile(string serviceAction, string profileAction)* are called but no profile is configured, from now on a *ProfileNotFoundException* will be thrown. In the profile loading script, the class *NodeProfileConfiguration* will be filled in with *Guid.Empty* if no profile instance was selected.

#### SRM_AddDcfInterfacesAsResources script updated [ID_23933]

The *SRM_AddDcfInterfacesAsResources* script has been updated to create resources with capacity and capability parameters.

#### Capacities and capabilities now taken into account for contributing bookings [ID_23938]

Capacity en capability parameters are now taken into account for the selection of a contributing resource and for the selection of the resources of a contributing resource. This means that a quarantine can now also be triggered for contributing bookings.

As a consequence, in the path configuration, the *Capacity* attribute is now obsolete.

#### Moving a booking from Partial to Confirmed state [ID_23988]

Previously, it was not possible to move an existing booking from the *Partial* state to the *Confirmed* state using the *SRM_ReservationAction* script. This operation will now be allowed, but will only succeed if the configuration of the booking is correct.

#### Duplicate colors removed on State Colors page [ID_24029]

In the drop-down lists on the *Admin > State Colors* data page of the SRM application element, the following duplicate colors have been removed:

- Cyan (now only included as *Aqua*)
- Fuchsia (now only included as *Magenta*)

#### Skyline Booking Manager: New 'Column Configuration' parameter [ID_24032]

A new *Column Configuration* parameter has been added to the Skyline Booking Manager driver. This parameter will be used to define the properties that need to be displayed in a *ListView* component in Cube and the order in which these need to be displayed.

#### SRM_QuarantineHandling script improvements [ID_24033]

To improve performance, the Booking Manager will now execute the script *SRM_QuarantineHandling* in async mode. The script will now only check future reservations.

### Fixes

#### Not possible to create booking with same name as running booking [ID_23733]

In some cases, it could occur that it was not possible to create a booking with the same name as a running booking, even if the new booking did not conflict with the running booking.

#### Exception when retrieving interface profile parameters by name [ID_23821]

When interface profile parameters were retrieved by name, it could occur that an exception was thrown.

#### Not possible to cancel quarantined booking [ID_23989]

If a user tried to cancel a quarantined booking, an exception was thrown and the booking was not canceled.

#### Resource pool customization not applied when combined with resource filtering [ID_23999]

When a resource pool was customized for a specific node and that node was configured with the *Resource Assignment* property set to a JSON configuration to filter resources, it could occur that the pool customization was not applied.

#### Exception when changing timing of booking [ID_24024]

If the timing of a future booking was modified so that the beginning of its pre-roll phase was in the past, or if the start time of a booking was modified while the pre-roll phase had already begun, an exception was thrown and the booking life cycle was not updated.

#### 'Action when Post-Roll Ends' parameter not initialized by default [ID_24031]

In some cases, it could occur that the *Action when Post-Roll Ends* parameter was not initialized by default, which caused an exception to be thrown when bookings were executed.

#### UIOrder configuration of profile definition not applied [ID_24052]

In some cases, the *UIOrder* configuration from the *Description* field of a profile definition was not applied in the Booking Wizard.
