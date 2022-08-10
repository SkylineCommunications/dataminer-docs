---
uid: SRM_1.2.16
---

# SRM 1.2.16

## New features

#### Running part of the Booking Wizard silently \[ID_30376\]

It is now possible to run the Booking Wizard partially silently, i.e. to have some steps hidden and some steps displayed to the user. A new method is available to configure this in a script. For example, to only show the last step of the wizard (i.e. assigning profiles and resources), use the following configuration:

```csharp
var wizardUserInteraction = new WizardUserInteraction
{
   CreateNewBooking = false,
   AssignProfilesAndResources = true,
   ManageEvents = false,
   ManageProperties = false
};

var result = this.bookingManager.TryCreateNewBooking(Engine, wizardUserInteraction, bookingData, this.functions, null, bookingProperties, out reservation);
```

#### Support for alarm monitoring of bookings on hold \[ID_30408\]

The Skyline Booking Monitoring connector now supports alarm monitoring of bookings that are in the *On Hold* state.

#### Editing start time of started partial/on-hold booking now possible \[ID_30419\]

It is now possible to change the start time of bookings in Partial or On Hold state even if their current start time is in the past.

#### User and orchestration logging in HTML format \[ID_30488\]

The user and orchestration logging for the Booking Manager app can now be consulted in HTML format.

To enable this logging, you need to define a shared network path under *Config* > *General* > *History and Logs*. In addition to the *Booking Orchestration Logging Location*, you can also configure cleanup settings there. Once this feature has been enabled, the *Action Log* button on the *Bookings* tab of the app will refer to the specified location.

## Changes

### Enhancements

#### Improved performance of SRM_BookingActions script \[ID_30308\]

Because of various enhancements, performance of the *SRM_BookingActions* script has improved. In addition, logging for this script has also been improved.

#### Skyline Bookings Monitoring: SLSRMLibrary.dll dependency removed \[ID_30327\]

The Skyline Bookings Monitoring connector no longer uses the *SLSRMLibrary.dll*.

#### BookingManager.AddResource and BookingManager.TryAddResource improvements \[ID_30350\]

The *BookingManager.AddResource* and *BookingManager.TryAddResource* methods have been improved as follows:

- Created service definitions will no longer be templates.
- Service definitions will no longer be edited.
- The label is now optional. If no label is specified, the function definition name is used.

#### SRM_LSOTemplate example script extended \[ID_30431\]

The *SRM_LSOTemplate* example script has been extended with an example of how to perform orchestration based on the service state applied to the booking.

#### Overload to run BookingManager.ApplyServiceState method synchronously \[ID_30454\]

A new overload has been added to the method *BookingManager.ApplyServiceState* so that you can indicate whether the method should run asynchronously (the standard behavior up to now) or synchronously (i.e. wait for the service state to be applied).

```csharp
public void ApplyServiceState(Engine engine, ServiceReservationInstance reservation, string state, bool isSynchronous);
```

#### Current time used as start time for added contributing transport resource \[ID_30476\]

When a network path is added to a booking that is already running, the corresponding contributing booking will now be created with the current time as its start time, instead of the main start time of the booking.

### Fixes

#### Problem when creating booking with transport path \[ID_30006\]

In some cases it could occur that a new booking with Path parameter failed to be created, with an exception similar to the one illustrated below:

```txt
Skyline.DataMiner.Library.Exceptions.ResourcePoolNotFoundException: There's no Resource Pool with name SDMN.SAT.Transport
```

The selection of a resource pool for transport resources has now been optimized to prevent this issue. The system will first look for the Path parameter configuration under the *Contributing Configuration.ResourcePool* field. Then it will look for the node property *Resource Pool*. Finally, it will look for the default resource pool with the name *\<virtual platform>.\<function name>*. Only if no resource pool is found, will an exception still be thrown.

However, note that it is important that the *IsContributing* flag is used on all contributing nodes, including transport nodes, in order for this to work.

#### Edit button not working in SRM_QuarantineInformation script \[ID_30313\]

In some cases, it could occur that the *Edit* button in the *SRM_QuarantineInformation* script did not work.

#### Booking created prematurely after user clicks Back in Service Profiles wizard \[ID_30435\]

In the Service Profiles wizard, when you selected a contributing service definition and then clicked the *Back* button, it could occur that the booking was created already.

#### Service no longer persistent after editing booking \[ID_30440\]

When a booking configured with a persistent service was edited, it could occur that it no longer had a persistent service but instead a service with an end date in the far future.

#### Unable to create booking if node/interface has IsProfileInstanceOptional set to true \[ID_30484\]

When a node or interface in a service definition had the *IsProfileInstanceOptional* property set to true, and the corresponding profile definition contained a mandatory parameter, it could occur that a booking using this service definition could not be created.

#### Resource concurrency issue for function that is included in booking multiple times \[ID_30491\]

When multiple instances of the same function were included in a booking, and a specific resource was passed for one of the function instances while for the others the resources were set to be selected automatically, the same resource could be applied to different functions even though its concurrency limit was reached.

#### Exception mentioning missing node after switching service profile definitions \[ID_30500\]

Because of an issue in the *SRM_ServiceProfileProcessing* script, when you switched from a service profile definition with unmapped nodes to one with only mapped nodes, an exception could be thrown mentioning a missing node when you created a booking. For example:

```txt
Failed to create Booking Test: Service Definition named example doesn't contain Node 15.
```
