---
uid: SRM_1.2.13
---

# SRM 1.2.13

## New features

#### Improved performance when retrieving contributing bookings \[ID_29663\]

The way contributing bookings are retrieved has been optimized. For this purpose, a new *IsContributing* flag is added to the resource usage to make it easier to identify contributing bookings. This may greatly improve performance, especially in systems with a large number of contributing bookings.

> [!NOTE]
> The *IsContributing* property with value *true* must be added to contributing nodes in service definitions.

> [!WARNING]
> After you upgrade to this version of the SRM framework, you must run the script *SRM_MigrateIsContributing* to make sure that the bookings that are already in the system are supported.

#### New ChangeName action and corresponding method \[ID_29733\]

A new *ChangeName* action has been added in the *SRM_ReservationAction* script. You can use this action to easily rename a booking and its service. If the booking is a contributing booking, its resource will also be renamed, but in that case the booking resource and service will retain the suffix that was initially defined for them.

The following new method is available in the *BookingManager* class to support this:

```csharp
public bool TryChangeName(Engine engine, ref ReservationInstance reservation, ChangeNameInputData data);
```

## Changes

### Enhancements

#### Booking Manager now only shows available booking types for selection \[ID_29483\]

In the Booking Manager UI, users will now only be able to select the booking types that are allowed according to the current Booking Manager configuration. Previously, it was possible to select other values, but an exception was thrown at the end of the wizard.

A number of exceptions have also been added that indicate when a booking type configuration is selected that is not supported or not compatible with the current Booking Manager configuration.

#### Case-insensitive property names, property values and enum values \[ID_29493\]

To allow easier configuration, all property names, property values and enum values used by the SRM framework are now case-insensitive.

#### Trailing and leading spaces automatically removed from booking names \[ID_29538\]

As trailing and leading spaces are not supported in booking names, the Booking Manager will now automatically remove such spaces from the names of newly created bookings.

#### Virtual Platform property added to temporary booking during booking creation \[ID_29554\]

During the booking creation process, a temporary booking is created, which is then finalized when the Booking Wizard is completed. Now, this temporary booking will have the *Virtual Platform* property added to it, so that it can be edited or deleted in case a problem occurs that causes the Booking Wizard to fail before the booking is completed.

#### Improved handling of files with identical name during import of service definitions \[ID_29566\]

The *SRM_ServiceDefinitionImportExport* script has been updated so that if it imports a file that is identical to a previously imported file, it will add extra characters to the file name of the new imported file. This prevents exceptions from being thrown that might create the impression that the import did not succeed.

#### Review of flow when contributing conversion fails to add resource element to the right view \[ID_29575\]

Adding a resource element to the target view will now only be done once. If the action fails, the relevant objects will be cleaned up.

#### Service states now case insensitive \[ID_29584\]

Service states available in the Booking Manager app (e.g. START) are now case insensitive.

#### Booking Wizard: Transport function now expanded by default \[ID_29585\]

When a booking using a transport function is created or edited, the transport function will now be expanded by default in the Booking Wizard so that the *Select Path* button is immediately visible.

#### Booking Manager improvements related to booking end time \[ID_29616\]

A number of Booking Manager improvements have been implemented related to the booking end time:

- When a permanent booking is selected, the Adjust Time and Extend actions will no longer be displayed.
- When you finish or cancel a booking, the wizard will no longer display the end time and duration.

#### Service deletion enhancements \[ID_29720\]

Several enhancements have been implemented in the Booking Manager app with regard to the deletion of services:

- The *Delete Service* action will now only be allowed when *Persistent Service* is enabled and all bookings making use of this are canceled.
- If an issue occurs during service deletion, a message will now be displayed to inform the user that the action failed.
- When the booking creation wizard was canceled, up to now the service was always removed. Now it will only be removed if the service was created while the wizard was running.

#### AssignResources method improved \[ID_29744\]

The *AssignResources* method has been made more efficient. Previously, it included validation of the resources passed to the method, but this is unnecessary as this validation already occurs in the core SRM component.

### Fixes

#### Updating booking timing could fail without warning \[ID_29684\]

When the timing of a booking was updated, it could occur that this action failed, e.g. because of an overlapping booking with the same name, but no feedback was displayed to the user about this.

#### Persistent service removed when booking was deleted \[ID_29692\]

When *Persistent Service* was enabled, it could occur that the service was nevertheless removed when a booking was deleted.
