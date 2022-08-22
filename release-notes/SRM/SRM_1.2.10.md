---
uid: SRM_1.2.10
---

# SRM 1.2.10

## New features

#### New LockLifeCycle property now used for bookings instead of custom Lock Life Cycle property \[ID_28659\]

While previously a custom *Lock Life Cycle* property was used for bookings, now the *LockLifeCycle* property of the *ServiceReservationInstance* object will be used (introduced in DataMiner 10.0.11). This property is taken into account for licensing: contributing bookings of type locked are now considered to be part of a main booking and do not consume a license credit.

#### SRM_ImportFunction script can now run without user interaction \[ID_28706\]

The *SRM_ImportFunction* script can now run without user interaction. For this purpose, it now has an *Input Data* parameter, which takes a JSON object. To run the script without user interaction, the key *IsSilent* has to be set to true:

```json
{ "IsSilent":true }
```

To keep using the old behavior of the script, an empty object can be used:

```json
{}
```

Note that if the script is run without user interaction, an error will occur if the function import directory is not available.

#### New ApplyServiceState method \[ID_28764\]

A new method allowing custom service state transitions has been added to the *BookingManager* class:

```csharp
public void ApplyServiceState(Engine engine, ServiceReservationInstance reservation, string state);
```

As input, the method requires the engine reference, the booking where the state should be applied and the state to apply.

The target state is not defined in the Booking Manager, only in the service definition actions. While LSO (Life cycle Service Orchestration) is running, the *Service State* property of the booking will have the value "Configuring *\[state to apply\]*...". When LSO has finished, the booking returns to its initial state. If LSO fails, the *Service State* will be set to "Failed". Note that it is possible to apply identical states consecutively.

#### Updated behavior for adjusting end time of locked contributing bookings \[ID_28772\]

When multiple bookings use the same locked contributing booking, and the end time of one of the main bookings is edited, the following principles will now be applied to determine the end time of the contributing booking:

- If there is no initial time difference between the end times of all involved bookings, extending one of the main bookings will extend the contributing booking correspondingly.

    ![No delta](~/release-notes/images/NoDelta.svg)

- If the initial time difference between the contributing and main bookings is the same for all main bookings, this time delta will be maintained when one of the main bookings is extended.

    ![Equal delta](~/release-notes/images/EqualDelta.svg)

- If the initial time difference between the contributing and main bookings is different for each main booking, the smallest time difference will be maintained. This means that if the contributing booking for example ends 20 minutes after booking A but 10 minutes after booking B, and booking A is extended with 30 minutes, the contributing booking will be adjusted to end 10 minutes after booking A.

    ![Different delta](~/release-notes/images/DifferentDelta.svg)

#### Custom booking action buttons \[ID_28784\]

Five custom buttons can now be configured to be displayed when a booking is selected on the *Bookings* tab. You can configure these on the *Config* > *Custom Actions* tab.

For each button, you can configure the following settings:

- *Type*: Select *Script* to make the button launch a custom Automation script. Select *Disabled* to hide the button.
- *Icon View*: The view page where an icon is available.
- *Icon Page*: The Visio page of the selected view containing the icon.
- *Argument*: The script tag to trigger an Automation script. Use the same syntax as is used to link a shape to an Automation script in Visual Overview, but leave out the "Script:" prefix. For example:

```json
CustomActionScript||Input Data={"bookingsManager":"[this element]","reservationId":"[cardvar:varBookingId]","action":"CustomAction1"}||Custom Tooltip|NoConfirmation,CloseWhenFinished
```

To pass the name of the Booking Manager, you can use the placeholder *\[this element\]*. To pass the ID of the selected booking, you can use the placeholder *\[cardvar:varBookingId\]*.

#### Adjusted behavior when booking is finished by user \[ID_28815\]

When a user finishes a booking that has a locked contributing booking, and the locked contributing booking end time is later than the main booking end time, the end time difference will now be maintained.

## Changes

### Enhancements

#### Inheritance from parameter or resource now deprecated \[ID_28614\]

Parameter inheritance from another parameter, from a resource name or from a resource property is now deprecated, as these functions are now supported by Data Transfer Rules (DTR). Resource pool inheritance continues to be supported.

#### Improved capability and capacity values assigned to contributing function resource during creation \[ID_28656\]

When a contributing function resource is created, the capability and capacity parameters defined in its function definition are automatically added. The values assigned to these parameters are now determined as follows:

- For a capacity, if a maximum range is defined on the profile parameter, this will be applied. Otherwise no value will be assigned.
- For a discrete capability, all discrete options defined in the profile parameter are applied.
- For a numeric capability, the minimum and maximum range (if any) defined in the profile parameter are applied.
- For a text capability, no value will be assigned.
- Undefined capabilities are not supported.

    > [!NOTE]
    > As the maximum range can be an invalid value in some cases, we recommend to change this value after resource creation.

#### Cleanup mechanism added to SRM_CustomDijkstraContributingReservation script \[ID_28708\]

When a booking is created based on a service definition containing a Dijkstra node, and an error prevents the contributing resource from being created properly, any objects created by the failed contributing booking script will now be removed.

#### Custom events can no longer have 'immediate' timing \[ID_28730\]

To prevent issues, custom booking events must now always have at least 1 second of time difference to start/stop events.

#### Profile parameters now shown even if no profile exists \[ID_28825\]

The Booking Wizard will now show profile parameters even if no profile instance is available for a specific node or interface. However, note that in such a case, LSO features will not work, as these are based on the selected profile.

#### Contributing resource DVE enabled at booking start instead of at creation time \[ID_28847\]

When a contributing resource is created, the corresponding resource DVE will no longer be enabled immediately. The core SRM software will ensure that it is enabled at the latest when the booking starts.

### Fixes

#### Capability not correctly flagged when profile instance was assigned to function by reference \[ID_28652\]

When a profile instance was assigned to a function by reference, this was not correctly flagged on the required capabilities.

#### Extend action not applied correctly if time value was edited several times in wizard \[ID_28662\]

When the Extend action was used and the user edited the time value several times in the wizard, it could occur that the time extension was not added correctly.

#### Problem when enabling contributing DVE state \[ID_28771\]

It could occur that the state of a contributing function resource DVE was not triggered correctly, which could cause issues with bookings not starting correctly.

#### Problem with DTR updates on interfaces \[ID_28854\]

In case a capability parameter was used on an interface and it influenced resource selection, an issue with DTR scripts could cause this to function incorrectly.

Note that to prevent this issue, you should also ensure that interface parameters are unique for a service definition node. The same parameter should not be used on two interfaces of the same service definition node

#### Problem with Booking Wizard in case custom script threw exception \[ID_28856\]

In case a custom script executed after converting a booking to a contributing booking threw an exception, a problem could occur in the Booking Wizard.
