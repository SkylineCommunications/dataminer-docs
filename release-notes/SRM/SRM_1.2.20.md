---
uid: SRM_1.2.20
---

# SRM 1.2.20

## New features

#### New SRM_AddResourceFromPoolToBooking script \[ID_31474\]

A new *SRM_AddResourceFromPoolToBooking* script is now available, which can be used to add a resource from a pool into a booking. The Input Data requires the following JSON input:

```json
{
      "ReservationId": "X",
       "PoolId": "Y",
       "PoolName": "Z"
}
```

Where:

- X = The GUID of the booking where the resource will be added.
- Y = The ID of the Resource Pool to be selected. This has priority over "PoolName", so if this is filled in, PoolName will not be read.
- Z = The name of the Resource Pool to be selected.

#### New Contributing Booking Type parameter \[ID_31488\]

A new parameter, *Contributing Booking Type*, is now available on the *General* data pages of the Skyline Booking Manager connector. This parameter will determine whether standard or "lite" contributing resources are used by default. The default setting can still be overridden on service definition–level with the *ContributingConfig.LiteContributingResource* setting if necessary.

#### Support for applying state profile to resource used in booking \[ID_31531\]

The *SRM_ApplyProfileToResource* script now allows you to apply a state profile to a resource that is used in a booking. The script will allow you to apply a profile selected during booking creation and/or apply a specific state profile instance.

#### New script to quickly book resources from the timeline \[ID_31577\]

A new script, *SRM_BookResourcesQuickly*, is now available, which allows you to easily book resources from a custom front-end application. When you start the script for one or more resources, it will ask for the booking description and timing. When you confirm, a booking will be created that reserves the resource(s) for the specified time.

#### Import and export of Booking Manager settings \[ID_31593\]

It is now possible to import and export the settings of a Booking Manager element.

- To **export** the settings, on the *General* data page of the element, click *Export*. An export file will be created in folder *C:\\Skyline DataMiner\\Documents\\Skyline Booking Manager\\Configurations*.

- To **import** the settings, on the *General* data page of the element, click *Import*, and then select the file to import in the pop-up window. As the import feature is intended to be used to **pass settings from one DMS to another**, it does not import the parameter *DMA IDs to Store Reservations*.

- To **restore** settings, i.e. **import export files from the same DMS**, on the *General* data page of the element, click *Restore*, and then select the file to import in the pop-up window. In this case, the parameter *DMA IDs to Store Reservations* will be included in the import.

#### New ExcludeNodeExceptFirstAndLast option for transport path \[ID_31615\]

If the *ExcludeNode* option was used in the TransportLink of a transport path in order to exclude interfaces from another transport function based on their node, the option could filter out required nodes when the edge interfaces were the same. To avoid this, the filtering option *ExcludeNodeExceptFirstAndLast* is now available. This will avoid excluding the first and last node of the linked path.

## Changes

### Enhancements

#### BREAKING CHANGE: Profile instance now mandatory if profile definition has parameters to configure \[ID_31534\]

The Booking Wizard will now no longer allow booking creation if the used function profile definition has parameters to configure while there are no profile instances in the system for the function.

This is a breaking change, as previously it was possible to create a booking even if there were no profile instances in the system. This change is necessary to be able to standardize all flows related to booking creation.

If you wish to work around this new limitation in existing setups, set the property *IsProfileInstanceOptional* to *True* on the service definition nodes for which there is no profile instance.

#### LSO support for lite contributing resources \[ID_31551\]

LSO scripts now support lite contributing resources.

Note that the following properties in the *SrmParameterConfiguration* class will be null for lite contributing resources:

- MainElement
- ProtocolParameterId
- ResourceKey
- PrimaryKey

#### Debug log files in HTML format \[ID_31580\]

To make it easier for users to find any errors that could have happened during booking creation or any actions that may have been applied to a booking, debug log files are now displayed in HTML format. This way, issues can also be marked with a color to make them easier to spot.

#### Support for changes to assigned resources to make booking leave quarantine \[ID_31626\]

The *ServiceReservationInstance.AssignResources* method has been extended so that it can now be used to change a resource or profile to make a booking leave the quarantine state.

Similarly, the *ServiceReservationInstance.UnassignResources* method has been extended so that it can be used to remove a resource that is not linked to a service definition node so that a booking can leave the quarantine state.

#### Booking Friendly Reference now calculated in SLAutomation \[ID_31628\]

Previously, the Friendly Reference of a booking was calculated in the Booking Manager element. However, because this required an external parameter set from the script to the connector, this could take a long time if the system was experiencing a run-time error, and this could cause booking creation to fail. To prevent such issues, the Friendly Reference is now calculated in SLAutomation instead.

#### Improved behavior of Show Information Events setting \[ID_31680\]

When the *Show Information Events* setting is enabled in the Booking Manager app, all log messages are displayed as information events. These information events will now be generated in a background thread, so that enabling this option can no longer affect the performance of the app. In addition, the setting will now be automatically disabled after 8 hours.

### Fixes

#### Pop-up to attach to script after closing Booking Wizard \[ID_31435\]

When the Booking Wizard was closed during the Edit Properties or Filter step, it could occur that a pop-up to attach to the script *SRM_AssignProfilesAndResourcesToCustomServiceDefinition* was displayed on all clients.

#### Problem when exporting multiple Profile Load scripts for different functions \[ID_31489\]

When multiple Profile Load scripts were exported for different functions, it could occur that only the first of the scripts was exported.

#### Not possible to import Profile Load script containing system function and function \[ID_31501\]

A problem in the *SRM_ImportFunctions* script could make it impossible to import Profile Load scripts if these contained a system function and function to be imported.

#### Silent editing of booking failed when resources were assigned based on profile parameter \[ID_31539\]

When resources were assigned to a booking based on a profile parameter, and a resource with a maximum concurrency of 1 was used, it could occur that editing the booking using the Silent Booking Type "Optimized" failed.

#### SrmResourceConfiguration.ApplyContributingState method always applied initial profile instance \[ID_31546\]

A problem with the *SrmResourceConfiguration.ApplyContributingState* method caused the initial profile instance of the LSO to always be applied, even if a different state profile instance should have been applied instead.

#### Problem if several parameters existed with the same name \[ID_31621\]

Up to now, if for some reason there was more than one *Resource Type*, *ResourceInputInterfaces* or *ResourceOutputInterfaces* parameter in the system, SRM would continuously create more parameters with the same name. Now it will instead throw an InvalidOperationException with a message such as "*There are multiple parameters with name Resource Type in your system. Please remove them manually to continue.*"

#### Not possible to create booking with time-dependent capability and automatic resource selection \[ID_31624\]

When a time-dependent capability was used, no resource was provided and automatic resource selection was enabled, it could occur that no booking could be created. This only happened with the silent booking type *Optimized*.

#### Problem with BookingBuilder.AddStartAndStopEvents method \[ID_31695\]

In some rare cases, a race condition could occur with the method *BookingBuilder.AddStartAndStopEvents*, which could make it impossible to create a booking.

#### Creation optimized silent booking failed with resource of capacity zero \[ID_31739\]

When an optimized silent booking was created that requested a capacity of zero, it could occur that it was not possible to filter resources with a capacity of zero so that the booking creation failed.

#### Fast transport booking not created when edge node had to be auto-selected \[ID_31807\]

When at least one of the edge nodes had to be selected automatically, it could occur that fast transport bookings could not be created.
