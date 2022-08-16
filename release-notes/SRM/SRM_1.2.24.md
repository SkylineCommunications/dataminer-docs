---
uid: SRM_1.2.24
---

# SRM 1.2.24

> [!NOTE]
> This version requires that **DataMiner 10.2.5.0-11681 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### Profile Load scripts now support profile value converter \[ID_32713\]

Parameter values in Profile Load scripts will now be converted to the device value based on the converter defined in a profile parameter's links.

For example, this extract shows how to retrieve the converted value:

```csharp
var parametersConfiguration = helper.GetNodeSrmParametersConfiguration(configurationInfo, nodeProfileConfiguration).ToArray();
var parameter = parametersConfiguration.SingleOrDefault(x => string.Equals(x.ProfileParameterName, "Convertible"));

// If a converter is defined, the value will get converted based on the Profile value. Otherwise the Profile value will be returned.
// If the conversion would fail, an error will be thrown (MediationConversionException).
var convertedValue = parameter.Value;

// To access the ID of the converter defined of the Profile Parameter's Link
var mediationSnippetId = parameter.MediationSnippetId;
```

#### SRM_ResourceManagement script now supports multiple resources as input \[ID_32886\]

The *SRM_ResourceManagement* script now supports multiple resources as input. For this purpose, a new field *ExtraResourceIds* has been added to the *Input Data* parameter. This field consists of a list of comma-separated resource IDs, representing the resources that should be added.

For example:

```json
{
    "BookingManagerElement": "1.1 - Bookings - SDMN Satellite Downlink",
    "ExtraResourceIds": "d54bc60d-b97a-4c70-9a8a-c4a28239ab7a, e98f8682-3fe6-4f03-9c73-d4e6ac7985b9, 9eafbb63-af95-4692-92d1-d3a8ba7126b4"
}
```

#### Support for immediate finishing of booking during post-roll \[ID_33337\]

Up to now, it was not possible to finish a booking immediately during post-roll. this is now supported. For this purpose, the Finish and ChangeTime actions have been adjusted so that the post-roll phase can be shortened while the booking is in post-roll.

## Changes

### Enhancements

#### Improved performance of SRM_AddDcfInterfacesAsResources script \[ID_32024\]

Performance of the *SRM_AddDcfInterfacesAsResources* script, which is used to add resources per DCF interface, has been improved. The script will now cache some calls and perform the adding or updating of resources and profiles in bulk.

#### Locked contributing bookings scheduled to finish when main booking is canceled \[ID_32419\]

Locked contributing bookings that are only used by a single main booking will now be scheduled to finish when that main booking is canceled. If they are used by multiple main bookings, the behavior remains the same as before.

#### 'Auto Select Resource' property now taken into account when booking is duplicated \[ID_32771\]

Up to now, when no resource was selected for a booking, and this booking was duplicated using the Booking Wizard, a resource was automatically selected. This has now been changed to be in line with regular booking creation behavior. The property *Auto Select Resource* will determine whether a resource is automatically selected.

#### Improved logging when booking is quarantined \[ID_32784\]

When a booking is quarantined, the debug log file will now contain more information on the reason for the quarantine.

#### Final page SRM_BookResourceQuickly script improved \[ID_32815\]

The final page of the *SRM_BookResourceQuickly* script has been enhanced so that it is more clear to the user when the booking has been created successfully.

#### NetworkPathSelectionHelper class updated \[ID_32834\]

The *NetworkPathSelectionHelper* class has been adjusted to make sure it no longer relies on *ISrmManagersContext*. For this reason, the class now has the following new constructors:

```csharp
public NetworkPathSelectionHelper(
         Element sourceNode,
         Element destinationNode,
         List<ResourceCapabilityUsage> capabilities,
         List<MultiResourceCapacityUsage> capacities,
         PathConfig pathConfig,
         FilteringOptions filteringOptions,
         TimeRange timeRange,
         IReadOnlyList<Path> selectedPaths)
```

```csharp
public NetworkPathSelectionHelper(
         Element sourceNode,
         Element destinationNode,
         List<ResourceCapabilityUsage> capabilities,
         List<MultiResourceCapacityUsage> capacities,
         PathConfig pathConfig,
         FilteringOptions filteringOptions,
         TimeRange timeRange,
         IReadOnlyList<Path> selectedPaths,
         SrmCache srmCache,
         ILogger logger)
```

#### Improved support for long script duration \[ID_32934\]

To better support LSO scripts that take a very long time, the *SrmManagers* class will now store the user connection instead of the *Engine* object, so that it can still interact with DataMiner to update a booking when a script times out.

#### LSO and PLS debug logging added \[ID_33080\]

Debug logging has been added to LSO and PLS in the context of bookings. This will make it easier to debug issues that might occur during service orchestration.

#### Profile-Load Script Tester: Support for black theme \[ID_33095\]

The visual overview for the Profile-Load Script Tester is now compatible with the black theme in DataMiner Cube.

#### Booking life cycle enters failed state when LSO fails \[ID_33121\]

When an LSO script fails, the booking life cycle now enters the failed state. Previously, it only entered the failed state if a booking failed to start or start events were not triggered.

#### EngineExtensionMethods.SynchronousAddService method now skips read-only properties \[ID_33352\]

The method *EngineExtensionMethods.SynchronousAddService*, which checks if properties have already been updated, will now skip read-only properties such as *Last Modified*.

### Fixes

#### Base profile not applied when combined profile was applied to resource while no state profile instance was defined \[ID_32720\]

When a combined profile was applied to a resource, if no state profile instance was defined, it could occur that the base profile instance was not applied. In some cases, the service action profile was applied instead.

#### Problem creating paths with ExcludeEdgeResource=true \[ID_32804\]

When the flag *ExcludeEdgeResource* was set to true, a problem could occur that prevented paths from being created.

#### Required capacities and capabilities not taken into account when profile instance was assigned by value \[ID_32844\]

When a booking was created based on a profile instance referenced by value, and no overridden parameters were passed, it could occur that only values were taken into account, but not the required capacities and capabilities.

#### Not possible to create transport booking when nodes were not connected in service definition \[ID_32937\]

When the source and destination nodes in a service definition were not connected to the transport node, it could occur that it was not possible to create transport bookings using that service definition. From now on, the source and destination node will be retrieved from the information in the Path parameter so that this will no longer occur.

#### Problem during booking creation/editing when value with ReferenceValue is cloned \[ID_33046\]

When a booking was created or edited using the optimized flow where a profile instance has a value with a ReferenceValue, it could occur that cloning that value failed, causing the booking creation or editing to fail as well.

#### Not possible to change booking timing for booking stored on non-master DMA \[ID_33224\]

When a booking instance was stored on a DMA in the system other than the one used as the master DMA for SRM, it could occur that changing its timing did not work.

#### DTR parameter overrides for transport node not set in booking \[ID_33237\]

When Data Transfer Rules were used that set parameters on a transport node, it could occur that those overridden parameters were not actually set in the booking.

#### ChangeTime, Finish, Start, and Extend actions could cause unnecessary timing update \[ID_33296\]

When ChangeTime, Finish, Start, or Extend actions were used, the SRM framework tried to update the time of the booking even when this was not necessary, which could cause errors to be thrown.

#### Skyline Booking Monitoring connector could not display name with non-alphabetic characters \[ID_33351\]

If a booking name contained non-alphabetic characters, it could occur that the Skyline Booking Monitoring connector could not display the name.
