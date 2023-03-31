---
uid: SRM_1.2.29
---

# SRM 1.2.29

> [!NOTE]
> This version requires that **DataMiner 10.2.7.0-11922 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### New Leave Failure action [ID_34656]

If for some reason orchestration fails, and an operator manually configures a device to fix the issue, it is now possible to make the booking leave the Failure state to reflect this.

#### New script to force transition to a service state [ID_34923]

A new script, *SRM_ForceStateTransition*, is now available, which will allow users to select and run one of the past actions defined in the service definition of a booking. This way they can force the transition to a specific service state while a booking is running.

## Changes

### Enhancements

#### Improved About file for better reporting to CDMR [ID_34566]

The About file for SRM has been adjusted to be more in line with DataMiner PTP and IDP. Both its name and format are now consistent with other such files, making it possible for the Watchdog process to report the names and versions of all DataMiner Standard Apps, Frameworks, and Solutions to CDMR.

#### Additional checks in CheckDveInconsistency BPA test [ID_34676]

The *CheckDveInconsistency* BPA test will now also check for the following things:

- Duplicate DVE names in the Generic DVE Table
- Duplicate resource function instance names
- An existing element using the same `<root element name>.<function name>` combination

#### Improved LSO script performance in case booking contains multiple instances of same resource [ID_34677]

Performance of LSO scripts has improved in case a booking contains the same resource multiple times. Previously, the LSO scripts fetched the resource from the server multiple times in such a case. Now they will instead make use of the cache as much as possible.

#### Methods retrieving resources without filter element marked as obsolete [ID_34729]

Methods exposing *GetResources* without filter element have now been marked as obsolete in the ResourceManager helper, as these will take longer than others and may even yield incorrect results.

#### Improved error handling for ​BookingBuilder.CreateBooking and EngineExtensionMethods.SynchronousAddService [ID_34756]

*​BookingBuilder.CreateBooking* will now throw a *ServiceAlreadyExistsException* when it is used to create a new service with the same name as a service that already exists.

In addition, in case invalid data is provided to the *EngineExtensionMethods.SynchronousAddService* method, it will now throw a *ServiceInvalidDataException* with details about the unexpected data.

#### SRMSettableServiceState objects no longer used [ID_34788]

To improve performance, the SRM framework no longer creates and updates *SRMSettableServiceState* objects during booking execution. Previously, these objects were only used for logging purposes.

#### Superfluous ValidateContributingResource method removed [ID_34826]

The *ValidateContributingResource* method in the *AssignResourceRequest* class has been removed. This method was developed as a workaround for an issue that was fixed in DataMiner 10.1.8/10.2.0 and is consequently superfluous now.

#### Extended Booking Failure script now used whenever LSO action fails [ID_34848]

When an LSO action fails, the Extended Booking Failure script will now be called. Up to now, this was only called when a booking failed to start.

The error data in the script will hold a new value of LsoFailed for these new cases.

The example script *SRM_BookingStartFailureTemplate* has been updated accordingly.

#### 'DMA IDs to Store Reservations' renamed to 'Hosting DMA IDs to Orchestrate Reservation' [ID_34882]

In the Booking Manager app, the parameter *DMA IDs to Store Reservations* has been renamed to *Hosting DMA IDs to Orchestrate Reservation*.

#### SrmServiceInfo object now has name of service instead of booking [ID_34951]

When a booking is created, either silently or with the Booking Wizard, it is possible to define the name for a persistent service. From now on, the corresponding *SrmServiceInfo* object will also be created with that service name. Previously, the name of the booking was used instead.

#### SLA improvements [ID_34976]

To prevent possible issues and add several improvements, the SLA implementation in the SRM framework has been reviewed.

- Problems with an SLA element can now no longer cause orchestration to fail.
- Logging has been improved.
- A possible issue has been resolved where SRM incorrectly thought an SLA element had not been created.
- SLA elements will now only be created when a booking starts.

### Fixes

#### Booking Manager: Rescue button displayed when not relevant [ID_34618]

In the Booking Manager app, it could occur that the *Rescue* button was also displayed for bookings that were not in an interrupted state.

#### AddResource not adding resources to service of active booking [ID_34628]

When a resource was added via the *AddResource* method to a booking that had not started yet, it could occur that when the booking started, the other assigned resources were not added to the service. This only happened when the service was created in advance or for contributing bookings. To resolve this issue, the resource will now only be added when the booking is started.

In addition, it could occur that the *Force Swap* resource action did not update the service. This issue has also been resolved.

#### Custom properties and 'Copy to Service' feature could cause booking creation failure [ID_34718]

When custom properties were used with the "Copy to Service" feature, it could occur that booking creation failed when another thread added properties to the booking while the properties were being checked in order to add them to the service.

#### Custom booking events not taken into account when booking was finished [ID_34843] [ID_34990]

When the Finish action was executed on a booking, it could occur that custom events in the booking were not taken into account. This issue has been resolved, and the Change Time, Start, and Extend actions have also been reviewed to make sure that custom events are correctly added to a booking.

#### Exception when exporting profile instances without profile definition [ID_34887]

When profile instances that did not have a profile definition were exported, the *PFM_ProfileInstancesImportExport* script threw a null reference exception. This issue has been resolved, and the script has been reviewed to ignore volatile profile instances.

#### Error in Booking Wizard when duplicating booking and returning to first screen [ID_35197]

When a user duplicated a booking and then returned to the first screen of the Booking Wizard, an error could occur in the wizard. The following error message would be displayed:

```txt
System.NullReferenceException: Object reference not set to an instance of an object.
   at SRM.CreateNewBooking.View.BookingScreen.RunNextScripts(IAS ias, Engine engine)
   at SRM.CreateNewBooking.View.BookingScreen.Event_ButtonNext(IAS ias, Engine engine)
   at SRM.CreateNewBooking.Controller.IAS.Events(Engine engine)
   at SRM.CreateNewBooking.Controller.Script.RunWizard(Engine engine, IAS ias)
   at SRM.CreateNewBooking.Controller.Script.Run(Engine engine)
```
