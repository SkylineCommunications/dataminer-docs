---
uid: SRM_1.2.8
---

# SRM 1.2.8

## New features

#### Back button available in wizard to create booking based on service profiles \[ID_27883\]

On the second screen of the wizard to create a new booking based on service profiles, a *Back* button is now available.

#### Possibility to customize main booking info screen in booking wizard \[ID_27946\]

It is now possible to customize the title of main booking info screen in the booking wizard. To do so, run the *SRM_DefineBookingMainInfo* script by providing a *defaultValue* dictionary that contains the *Title* as key, for example:

```csharp
mainBookingInfoInputData.DefaultValues.Add(Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBookingMainInfo.MainBookingInfoEditableFields.Title, "Custom Title");
```

#### Possibility to hide Start Date With Pre-Roll and Stop Date With Post-Roll fields in booking wizard \[ID_27973\]

The *SRM_DefineBookingMainInfo* script can now be customized to hide the *Start Date With Pre-Roll* and *Stop Date With Post-Roll* fields. To do so, add the enum of the relevant field on the HashSet FieldsToHide of the InputData object.

For example:

```csharp
var mainBookingInfoInputData = new MainBookingInfoInputData();
mainBookingInfoInputData.FieldsToHide.Add(Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBookingMainInfo.MainBookingInfoEditableFields.EndDateWithPostRoll);
mainBookingInfoInputData.FieldsToHide.Add(Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBookingMainInfo.MainBookingInfoEditableFields.StartDateWithPreRoll);
inputData.MainBookingInfo = this.bookingManager.FetchMainBookingInfo(engine, mainBookingInfoInputData);
```

#### Finishing locked contributing bookings \[ID_28045\]

Locked contributing bookings can now be finished in specific cases:

- If an ongoing locked contributing booking is not used by any booking, it can be finished like a regular booking.
- If the end time of a locked contributing booking is later than the end time of one or more main bookings using it, finishing the contributing booking will reduce its end time to that of the last main booking using it.
- If an event scheduling delay has been configured that is greater than the time between the current time and the last end time of the main bookings making use of the contributing booking that is being finished, the end time of the contributing booking will be set to the current time plus the event scheduling delay.

#### Finishing a booking in pre-roll state \[ID_28046\]

It is now possible to finish a booking while it is in pre-roll state. In this case, the end of the booking will be rescheduled to the current time plus the event rescheduling delay. If post-roll is enabled, the post-roll time is also added to this.

#### Support for optional Dijkstra path nodes \[ID_28061\]

Dijkstra path nodes can now be configured to be optional. Previously, these were always mandatory.

#### Booking Wizard: Convert to Contributing checkbox automatically selected for contributing bookings \[ID_28069\]

The Booking Wizard has been adjusted so that the *Convert to Contributing* checkbox can be automatically selected for a contributing booking. This is determined based on the *ConvertToContributing* JSON property, which is included in the *Contributing Config* service definition JSON property. If this property is present and set to "true", the checkbox is automatically selected.

#### SRM_DefineBookingMainInfo script: Support for custom text labels \[ID_28117\]

It is now possible to customize the text labels displayed in the UI of the *SRM_DefineBookingMainInfo* script. For this purpose, a new *OverrideFieldLabels* dictionary (Dictionary\<MainBookingInfoEditableFields, string>) was introduced in the class *Skyline.DataMiner.Library.Solutions.SRM.Model.DefineBookingMainInfo.InputDate*.

If a value is not specified in this dictionary, the default value will be used.

Code example:

```csharp
mainBookingInfoInputData.OverrideFieldLabels.Add( MainBookingInfoEditableFields.BouquetViewName, "A Different Bouquet View Name" );
```

## Changes

### Enhancements

#### No more upper limit for new service duration \[ID_27945\]

The duration field in the wizard to create a new booking now no longer has an upper limit.

#### Improved user interface of booking wizard scripts \[ID_27956\]

The user interface of different scripts used in the booking wizard has been improved in order to increase consistency between the scripts. Among others, the casing has been adjusted so that title casing is now used for all fields.

#### Booking Wizard: Improved pop-up messages \[ID_28002\]

Pop-up messages in the Booking Wizard have been improved so that they always display the booking name instead of a GUID.

#### Booking Wizard improvements \[ID_28024\]

The pre-roll and post-roll controls in the Booking Wizard have been adjusted so that these can now only be set in the format hh:mm. Adjusting the pre-roll time will no longer be able to cause the booking start to be in the past. In addition, if the start date of a booking is set in the past, the booking will be rescheduled to run immediately, as soon as the configured event rescheduling delay has elapsed. Finally, if a booking that is already running is edited, the start and pre-roll time can now no longer be adjusted.

### Fixes

#### Booking placed in root view if incorrect view was specified during creation \[ID_27557\]

When during booking creation, a user specified a bouquet view name that was not within the application service view or specified no bouquet view name, the booking was placed in the root view instead of the application service view.

#### Not possible to create booking if nodes were hidden \[ID_27896\]

If the *HideIfResourceAvailable* property of a service definition node was set to *Yes*, it could occur that it was no possible to create a booking using that service definition. The same issue could occur if the *Options* node property was set to *Hide*.

#### Not all created objects removed when booking creation was aborted \[ID_27902\]

In some cases, if a user aborted the booking creation script, it could occur that not all created objects were removed.

#### Empty or incorrect capability and capacity parameters not imported \[ID_27911\]

When resources are imported, capability and capacity parameters will not be included in case they are empty. A capability of type number will also not be included if it is not within the parameter range or if the maximum is smaller than the minimum. A capability of type discrete will not be included if no discrete values were defined or if a discrete value is invalid.

#### Booking stuck in Service Post-Roll life cycle stage \[ID_28035\]

In some cases, if a booking was edited to have no post-roll time, it could occur that the booking became stuck in the *Service Post-Roll* stage of its life cycle.

#### Problem when change to booking causing conflict was canceled \[ID_28037\]

If a booking was edited in such a way that it caused a conflict with another confirmed booking, canceling the change could cause all events to be removed from the booking that was edited.

#### Booking duration incorrect if end time of booking with post-roll was adjusted \[ID_28042\]

If the end time of a booking with post-roll phase was adjusted, it could occur that the post-roll time was not correctly added to the booking duration.

#### Cancellation of change to booking that caused conflict not correctly implemented \[ID_28044\]

If a booking was edited in such a way that it caused a conflict with another confirmed booking, it could occur that the associated main and contributing bookings were updated even if this change was canceled.

#### Problem when editing booking using Dijkstra path \[ID_28055\]

When a booking using a Dijkstra path was edited, it could occur that the path was reset.

#### Forcing a booking to start despite a conflict did not work correctly \[ID_28057\]

If a booking was started and caused a conflict with another booking, it could occur that forcing the booking to start anyway did not work correctly.

#### Not possible to delete running locked contributing booking \[ID_28068\]

In some cases, it could occur that a running locked contributing booking could not be deleted if the corresponding main booking had not yet started and was deleted.

#### Changes to contributing booking not reverted when editing is canceled \[ID_28076\]

When a confirmed booking was edited, but the user canceled the wizard, it could occur that changes implemented to a contributing booking were not reverted.

#### Not possible to start booking that has ongoing contributing booking \[ID_28284\]

In some cases, it could occur that a main booking could not be started if it used a contributing booking that was already ongoing.
