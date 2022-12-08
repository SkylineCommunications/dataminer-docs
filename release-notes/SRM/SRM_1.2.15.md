---
uid: SRM_1.2.15
---

# SRM 1.2.15

## New features

#### Booking attachments \[ID_29953\]

It is now possible to manage attachments of a booking in the Booking Manager app. For this purpose, a new *Attachments* button is available, which launches a wizard where you can add, delete and open booking attachments.

When a booking is deleted or ends, its attachments will be removed.

#### Configurable height of booking blocks \[ID_29991\]

On the timeline in the Booking Manager, you can now have booking info shown over several lines. For this purpose, on the *Config* > *Timeline* tab of the Booking Manager app, increase the size of the *Block Height* parameter.

#### Possibility to postpone conversion to contributing booking until shortly before booking start \[ID_30186\]

It is now possible to not have a booking converted to a contributing booking immediately, but instead only some time before the booking actually starts. This can help reduce the load on the system.

To use this feature, on the *General* data page of the Booking Manager app, set the parameter *Contributing Conversion Window* to a specific time value, e.g. 2 hours. Below this parameter, the *Late Conversion Status* parameter will indicate the progress in case conversions are being done.

## Changes

### Enhancements

#### No longer possible to reuse persistent service if service definition allows contributing conversion \[ID_30005\]

When you create a booking (with the regular Booking Wizard or using service profiles), it is now no longer possible to reuse a persistent service that was created with a service definition allowing contributing conversion. Previously, this was possible, but caused the booking to fail with an error similar to the one illustrated below:

```txt
Failed to create reservation definedcont1 due to: Skyline.DataMiner.Library.Solutions.SRM.Contributing.ContributingReservationException: Error while Configuring the new contributing resource: TraceData: (amount = 1)
```

#### Improved error information for SRM_ImportFunctions and SRM_ExportFunctions script \[ID_30184\]

When the *SRM_ImportFunctions* fails because of an incorrect script input parameter, the script will now provide information on the correct format for the input parameter.

In addition, when an error occurs during the execution of the *SRM_ImportFunctions* or the *SRM_ExportFunctions* script, detailed error information will now be displayed.

#### SRM_QuarantineHandling script improvements \[ID_30219\]

The efficiency of the *SRM_QuarantineHandling* script has been improved as follows:

- Only bookings that have a booking life cycle stage other than *Quarantine* are now processed.
- When loading future bookings, the script now filters by date as well as on whether the bookings are quarantined.

#### Cleanup mechanism for fast booking creation \[ID_30221\]

In case an error happens during fast booking creation, the created objects will now be cleaned up to prevent possible issues.

### Fixes

#### Not possible to adjust start time permanent booking \[ID_29982\]

It was not possible to adjust the start time of an upcoming permanent booking. Now, the Booking Manager will show the *Adjust Time* button for such a booking.

#### Problem converting to contributing booking if node/interface had no profile definition \[ID_30225\]

If a node or interface did not have a profile definition configured, it could occur that a booking could not be converted to a contributing booking. This issue will now be prevented.

However, note that this kind of configuration should be avoided. If a node or interface does not need parameters, it should have a profile definition without parameters.

#### Incorrect resource used by silent booking using resource pool inheritance \[ID_30235\]

When resource pool inheritance was used for a silent booking, it could occur that the first resource from the pool was briefly used before the correct resource was included.

#### Silent booking creation failed if capability parameter had no value \[ID_30268\]

When a capability parameter in a profile instance had no value, it could occur that silent booking creation failed with a null reference exception like the following:

```txt
Failed to create reservation test 2_Source due to: System.ArgumentNullException: Value cannot be null.
```
