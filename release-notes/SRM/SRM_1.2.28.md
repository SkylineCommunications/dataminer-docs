---
uid: SRM_1.2.28
---

# SRM 1.2.28

> [!NOTE]
> This version requires that **DataMiner 10.2.7.0-11922 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### Minimum log level added to Booking Manager app [ID_34336]

In the Booking Manager app, a new *Booking Minimum Logging Level* parameter is now available, which will control the minimum level of the logging. The following levels can be selected:

- Verbose
- Debug (default)
- Information
- Warning
- Error

The higher levels include all the information of the lower levels. For example, if *Information* is selected, Warning and Error entries will also be logged.

All Manager call entries are now logged with the level *Verbose*, so that they are not logged by default. This will make debugging easier by reducing the number of log entries.

## Changes

### Enhancements

#### Booking SLA element deleted when booking is deleted [ID_34220]

Up to now, a booking SLA element was only deleted when the booking finished. Now such an element will be deleted when the corresponding booking is deleted.

#### Information about conflicting bookings in quarantine info window [ID_34377]

When you change the timing of a booking so that other bookings will need to be put into quarantine, now information will be displayed about the conflicting bookings. Previously, only the bookings that would be quarantined were shown.

For example, in the image below, the bookings 0004, 0006, and 0007 use the same resources. When a user tries to start 0007 early, the message below appears and informs them of the conflict with booking 0004 and 0006.

![Conflicting bookings](~/release-notes/images/RN34377.png)

#### Support for methods to update parameters in LSO scripts [ID_34408]

Up to now, the *SrmResourceConfiguration.SetParameter* and *SrmResourceConfiguration.SetProfileInstance* methods could not be used in LSO scripts because these did not update the *Reservation* object. These methods have now been extended with the *forceSave* boolean. If this is set to true, the *Reservation* object will be saved, so that these methods can be used in LSO scripts.

For example:

```csharp
resource.SetParameter(TestSystemIds.ProfileParameters.Video_State, "Test Video State", true);
   resource.SetParameter(TestSystemProfileParameters.Vendor.Name, "VendorB", true);

   resource.SetParameter(InterfaceType.In, "ASI", TestSystemIds.ProfileParameters.Bitrate, 55, true);
   resource.SetParameter(1, TestSystemProfileParameters.Active_ASI_Interface.Name, "SDI", true);
   resource.SetParameter(InterfaceType.In, 1, TestSystemProfileParameters.Active_ASI_Interface_Port.ID, 99, true);

   resource.SetProfileInstance(TestSystemProfileInstances.Decoding_VendorB.ID, true);
   resource.SetProfileInstance(TestSystemProfileInstances.ASI_Profile_2.ID, 1, true);
```

#### Support for SelectedTimeRange variable in SRM_BookResourceQuickly and SRM_ResourceManagement scripts [ID_34454]

The *SRM_BookResourceQuickly* and *SRM_ResourceManagement* scripts now support the *SelectedTimeRange* Visual Overview variable. By default, this variable provides a semicolon-separated list with the start and stop dates in binary format. When Visual Overview calls the script, it uses a semicolon as a separator for the input string, so the semicolon should be replaced by `$` using the *RegexReplace* option. For example: `"TimeRange":"[RegexReplace:;,[cardvar:SelectedTimeRange],$]"`. The scripts support the characters "`;`", "`,`", and "`$`" as separators.

### Fixes

#### Problem when extending booking with pre-roll that had already started [ID_34226]

When a booking with pre-roll stage that had already started was extended, it could occur that the start events were rescheduled and the corresponding LSO ran again.

#### Existing resource properties not included when contributing resource was converted [ID_34317]

If the late conversion feature was used to convert a contributing resource, it could occur that existing custom properties on that resource were not included in the conversion.

#### Change to booking by Created Booking Action script not implemented [ID_34394]

When a booking was edited by a Created Booking Action script, it could occur that this change was not taken into account.

#### Booking not starting because default start and stop events were missing [ID_34464]

In some cases, it could occur that a booking remained in the Confirmed state when it was supposed to be starting. This happened when default SRM start and stop events were missing on the booking.

Now validation has been added to check if these events are still available. If they are not, the booking is deemed invalid and the user will get a suggestion to cancel it. The booking can then be duplicated or recreated.

> [!NOTE]
> Up to now, contributing transport bookings did not have the start event that gets triggered when a failure occurs, but this will now be added to new bookings of this type. However, **as existing contributing transport bookings do not have the event set, it will no longer be possible to confirm them**. Use the new migration script *SRM_MigrateReservationSetOnStartActionsFailureEvent* to resolve this issue. This script will add the missing event to existing planned bookings in the Pending or Confirmed state.

#### Booking Manager app: 'Duplicate' button shown while no booking is selected [ID_34519]

Up to now, the Booking Manager app also showed the *Duplicate* button when no booking was selected. Now the conditions to show and hide the button have been adjusted so that it is only shown when a booking is selected.

#### Problem when reverting booking going into quarantine [ID_34562]

When you try to start a booking early and some of its resources are already in use, a quarantine window is shown. Up to now, canceling the starting of the booking at this point could cause a main booking to be reverted before its contributing booking was reverted, which caused a *ContributingResourceNotAvailable* error.

#### Try Leave Quarantine not working if booking had multiple unmapped resources [ID_34574]

When the Try Leave Quarantine action was executed on a booking with multiple unmapped resources, it could occur that this action did not work.

#### Try Leave Quarantine not working correctly if booking had multiple unmapped resources with the same capacities [ID_34579]

When the Try Leave Quarantine action was executed on a booking with multiple unmapped resources with the same capacities, it could occur that the booking could not leave the quarantine correctly.
