---
uid: SRM_1.2.2
---

# SRM 1.2.2

## New features

#### Contributing booking life cycle changes \[ID_25547\]

Some changes have been implemented to the life cycle behavior of contributing bookings (including contributing bookings within contributing bookings):

- When the main booking is confirmed:

  - Locked contributing bookings that have not yet started will also be confirmed.
  - Unlocked contributing bookings will remain unchanged.

- When the main booking is set on hold:

  - Locked contributing bookings that have not yet started will also be set on hold if no other bookings in confirmed, partial or quarantined state are using them.
  - Unlocked contributing bookings will remain unchanged.

- When the main booking is canceled:

  - Locked contributing bookings that have not yet started will also be canceled if no other bookings in confirmed, partial, on-hold or quarantined state are using them.
  - Unlocked contributing bookings will remain unchanged.

- When the main booking is deleted:

  - Locked contributing bookings will also be deleted if they are canceled and no other non-canceled bookings are still using them.
  - Unlocked contributing bookings will remain unchanged.

- When the main booking is finished:

  - Locked contributing bookings will also be finished, but only if no other bookings in confirmed, partial, on-hold or quarantined state are using them.
  - Unlocked contributing bookings will remain unchanged.

- When the main booking leaves quarantined state:

  - Contributing bookings will also be removed from quarantine if possible, regardless of whether they are locked or unlocked.

- Confirming a contributing booking is implemented without restrictions, regardless of whether the contributing booking is locked or unlocked.

- Setting a contributing booking on hold is only implemented if the contributing booking is unlocked and no bookings making use of it have already started or if it is locked but no bookings are making use of it.

- Canceling a contributing booking is only implemented if the contributing booking is unlocked and no bookings making use or if it is locked and no current bookings make use of it. Note that if any future bookings make use of the unlocked contributing booking in this case, the contributing booking will be removed from these future bookings and their state will be set to *Partial*.

- Deleting a contributing booking is only implemented if the contributing booking is locked but no bookings are making use of it, or if it is unlocked and canceled.

- Finishing a contributing booking is only implemented if the contributing booking is locked but no bookings are making use of it, or if it is unlocked and not currently in use. Note that if any future bookings make use of the unlocked contributing booking in this case, the contributing booking will be removed from these future bookings and their state will be set to *Partial*.

- When a contributing booking leaves the quarantined state, this does not affect the quarantined state of any main bookings making use of it.

#### Contributing booking timing adjustments \[ID_25599\]

Some changes have been implemented with regards to the timing of contributing bookings.

When contributing bookings are assigned as a resource:

- The time window of locked contributing bookings must always completely cover the time window of the main booking.
- The time window of unlocked contributing bookings must now overlap the time window of the main booking.

When the timing of the main booking is updated:

- For locked contributing bookings, the timing is adjusted in such a way that the difference between the start time of the main booking and the start time of the contributing bookings and between the end time of the main bookings and the end time of the contributing bookings does not change. The following limitations apply in this case:

  - If this is not possible because the start time of the contributing booking would have to be in the past, the initial time difference will not be kept the same.
  - Contributing events that have already taken place will not be rescheduled.
  - In case a contributing booking needs to be quarantined because of the timing update of the main booking, it will immediately be quarantined without asking the user for confirmation. However, a notification will be displayed.
  - In case the contributing booking is used by multiple main bookings and there is a timing update causing the main booking that initially started last to now start first, the contributing booking will be updated so that the difference between the start time of the contributing booking and the start time of the initial first main booking is maintained for the current first main booking. Similarly, if there is a timing update causing the main booking that initially ended first to now end last, the contributing booking will be updated so that the difference between the end time of the contributing booking and the end time of the initial last main booking is maintained for the current last main booking.

- For unlocked contributing bookings, if the update will cause the contributing bookings to no longer overlap with the main booking, what happens depends on whether the main booking has already started:

  - If the main booking has not started yet, the contributing booking will be removed from it, and the main booking will go into "partial" state.
  - If the main booking has already started, the update will not be allowed.

When the timing of the contributing booking is updated:

- If it is a locked contributing booking, it should still be compatible with the timing of the main booking making use of it, otherwise the update will not be allowed

- If it is an unlocked contributing booking, and the update will cause the contributing booking to no longer overlap with the main booking, what happens depends on whether the main booking has already started:

  - If the main booking has not started yet, the contributing booking will be removed from it, and the main booking will go into "partial" state.
  - If the main booking has already started, the update will not be allowed.

#### Data transfer rules \[ID_25707\]

To allow more freedom in the implementation of SRM parameter inheritance, it is now possible to configure data transfer rules (DTR), by using a custom script associated with a service definition. The DTR script can be executed when a profile instance is executed, when a parameter value is updated, or when a resource is selected.

To configure DTR:

1. Create a script to implement the transfer logic rules, based on the template script available in the standard SRM Solution.
2. Add the property *Data Transfer Rules Configuration* to the relevant service definition.
3. As the value of this property, specify the script you created earlier and the parameters or resources of which a value change will trigger this script.

    For example:

    ```json
    {"Script":"SRM_ApplyDataTransferRules","Triggers":[{"InterfaceId":null,"NodeLabel":"Demodulating","ParameterName":"RF Modulation","TriggerType":"Parameter"}]}
    ```

    The property value above will cause the script "SRM_ApplyDataTransferRules" to be triggered every time the parameter "RF Modulation" on the node with label "Demodulating" changes.

    ```json
    {"Script":"SRM_ApplyDataTransferRules","Triggers":[{"NodeLabel":"Demodulating","TriggerType":"Resource"}]}
    ```

    The property value above will cause the script "SRM_ApplyDataTransferRules" to be triggered whenever the resource on the node with label "Demodulating" changes.

> [!NOTE]
> Multiple triggers can be set in the same configuration.

## Changes

### Enhancements

#### SRM_AssignProfiles script now supports capabilities of type string \[ID_25446\]

The *SRM_AssignProfiles* script has been updated to support capabilities of type string.

#### Superfluous JSON booking properties removed \[ID_25525\]

Some booking properties contained JSON code to allow easy editing or duplication of a booking. However, most of these data were already available in the fields of the booking and if the properties contained a large amount of data, this could cause issues when they were stored. As such, the properties from the scripts *SRM_CreateNewBooking*, *SRM_ManageProperties* and *SRM_ManageEvents* have now been removed.

#### Booking Wizard: Filter in drop-down boxes \[ID_25526\]

In the Booking Wizard, all drop-down boxes now have a filter.

#### Retry mechanism for data retrieval in DataMiner System \[ID_25610\]

In order to take the synchronization timing of DataMiner Systems into account, a retry mechanism was implemented for the retrieval of SRM data in a DataMiner System. A default retry timeout of 20 seconds and retry interval of 15 ms are used, but this can be customized in specific SRM methods.

#### Error now shown in case of problem when creating silent booking \[ID_25728\]

Previously, when a booking was created silently but errors occurred, these errors were not shown, so that a user could get the impression that the booking was created correctly. Now an error will be thrown in this case.

### Fixes

#### Conversion to contributing booking triggered before booking is fully configured \[ID_25524\]

When you created a booking with a service definition that was configured to convert the booking to a contributing booking and clicked the *Back* button while in the resource selection screen of the Booking Wizard, it could occur that the conversion to a contributing booking was triggered already.

#### Problem when node is configured as hidden and optional \[ID_25635\]

If a service definition node was configured as hidden and optional at the same time, an exception could be thrown when resources were assigned to the service definition.

#### Problem with Create Booking Action script \[ID_25727\]

In some cases, if the *Create Booking Action* property was configured with a script that had to run every time a booking was set to the state Confirmed, it could occur that the booking was not updated correctly, so that changes done by this script were lost.

#### Service definition node label modified when resource was assigned \[ID_25756\]

In case a resource was compatible with more than one service definition node, it could occur that the label of the first compatible node was modified when the resource was assigned using the method *TryAddResources*.
