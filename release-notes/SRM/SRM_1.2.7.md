---
uid: SRM_1.2.7
---

# SRM 1.2.7

## New features

#### New SRM_ExportFunctions and SRM_ImportFunctions scripts\[ID_27634\]

Two new scripts, *SRM_ExportFunctions* and *SRM_ImportFunctions*, are now available, which can be used to export a function definition, including the associated profile definition, parameters and profile loading script, from one DMA and import it on another DMA.

In the export script, you can select whether to include the associated system function and components or not. This option is enabled by default. The export script will create a .dmapp package in the documents folder *General Documents* > *SRM* > *FunctionExport*. If you install this package, its files we be placed under *System Cache* > *SRM FunctionImport*. This folder will be removed at the end of the *SRM_ImportFunctions* script.

The import script will:

- Not import a function and its associated components if the associated protocol does not exist.
- Append the existing functions to new functions. If the target DMS already has a functions.xml with same version, it will increase the functions.xml version by one.
- Append an incremented integer to the new function/parameter/profile definition name if the target DMS has that name for another GUID.
- Append the links to protocol parameters when importing a profile parameter.
- Append the links to scripts when importing a profile definition.
- If a profile-load script with the same name already exists but has different content, rename the old script to \<script name>\_Backup\<datetime>.
- Generate a log indicating the old data/new data if the protocol function/system function/parameter/profile definition already exists in the target DMS but with different content.
- Finally, display a summary indicating what has or has not been imported.

#### DTR between main and contributing bookings \[ID_27763\]

Data Transfer Rules (DTR) have been implemented between contributing and main bookings.

Below you can find an example of how to copy a value from the main booking to a contributing booking:

```csharp
/// <summary>
/// Copies the value of parameter RF Frequency from main booking demodulator 1 to contributing booking demodulator.
/// </summary>
private static void CopyDemodulator1FrequencyToContributingDemodulator(SrmBookingConfiguration mainBooking)
{
     var mainDemodulator1 = mainBooking.GetResource("Demodulator 1");
     var mainDemodulator1Frequency = mainDemodulator1.GetParameter<double>("RF Frequency");
     var rxSatBooking = mainBooking.GetContributingBooking("Rx Sat");
     var rxSatDemodulator = rxSatBooking.GetResource("Demodulating");
     rxSatDemodulator.SetParameter("RF Frequency", mainDemodulator1Frequency);
}
```

You can copy a value form a contributing booking to the main booking as follows:

```csharp
/// <summary>
/// Copies the value of parameter Video State from contributing decoder to main booking decoder.
/// </summary>
private static void CopyContributingDecoderVideoStateToMainDecoder(SrmBookingConfiguration mainBooking)
{
     var rxSatBooking = mainBooking.GetContributingBooking("Rx Sat");
     var rxSatDecoder = rxSatBooking.GetResource("Decoding");
     var mainDecoderUsage = mainBooking.GetResourceUsage("Decoding");
     var rxSatDecoderVideoState = rxSatDecoder.GetParameter<string>("Video State");
    mainDecoderUsage.SetParameter("Video State", rxSatDecoderVideoState);
}
```

These examples are available in the script *SRM_DataTransferRulesTemplate*.

#### Booking Manager: Creating a new booking based on a service profile \[ID_27907\]

In the Booking Manager UI, it is now possible to create a new booking based on a service profile. You can enable this new wizard by going to *Config* > *Wizard* in the Booking Manager and setting *Type of Wizard* to *Service Profile*.

## Changes

### Enhancements

#### SRM_ServiceDefinitionImportExport script improved \[ID_27485\]

The *SRM_ServiceDefinitionImportExport* script now also imports the service definition, node and interface properties.

#### Support for editing contributing bookings \[ID_27502\]

It is now possible to edit contributing bookings that were created by converting a booking to a contributing booking.

#### Default Virtual Platform parameter automatically initialized \[ID_27662\]

The *Default Virtual Platform* of the Booking Manager is now automatically initialized, so that bookings are listed in the *Bookings* tab even if this parameter has not been configured.

#### Progress of booking creation displayed \[ID_27665\]

When bookings are created via the *SRM_DefineBooking* script, the progress of the creation is now displayed.

#### Support for cancellation of bookings in Interrupted state \[ID_27672\]

When a booking is in the *Interrupted* state, it is now possible to cancel the booking.

#### Performance improvement when creating bookings using DTR \[ID_27731\]

Performance has improved when bookings are created using data transfer rules (DTR). Note that this improvement involves a small change in functionality, as DTR scripts will now need to initialize the object *SrmBookingConfiguration* with a constructor that takes the Engine object.

Previously:

```csharp
var srmBooking = new SrmBookingConfiguration(inputData.ReservationInstanceId, inputData.BookingManagerInfo);
```

Now:

```csharp
var srmBooking = new SrmBookingConfiguration(inputData.ReservationInstanceId, inputData.BookingManagerInfo, engine);
```

#### Improved booking wizard screen titles \[ID_27906\]

The different screens of the booking wizard have been updated with user-friendly titles matching the current action.

### Fixes

#### Failure not logged in case profile loading script throws exception \[ID_26873\]\[ID_27944\]

When the method *ProfileParameterEntryHelper.LogFailureResult* was used to log the failure of a set in a profile loading script, it could occur that this information was not recorded in the log file if the script threw an exception.

#### End time control displayed for permanent services \[ID_27537\]

If only the booking type Permanent Service was enabled in the Booking Manager, the UI still displayed an end time control, even though this was not relevant in that case.

#### Booking actions triggered before booking could be converted to contributing \[ID_27573\]

When the option *Automatically Convert to Contributing* was used in the Booking Wizard, it could occur that the booking actions were already triggered before the conversion could be started.

#### Problem when no property name was provided for new booking \[ID_27637\]

When a new booking was created and no property name was provided, it could occur that custom property values were not set.

#### User not notified of error during conversion to contributing booking \[ID_27661\]

If an error happened during the conversion of a booking to a contributing booking, it could occur that the user was not notified.

#### DTR script not triggered correctly if function data were set by value \[ID_27792\]

In some cases, it could occur that a DTR (Data Transfer Rules) script was not triggered correctly if the script was called silently and the function data were set by value instead of by reference.

#### Not possible to view booked resources of booking created using service profiles \[ID_27886\]

In some cases, when a booking using service profiles had been successfully created, it could occur that it was not possible to view the booked resources.

#### Problem exporting profile instance with enabled capability parameter without value \[ID_27982\]

If a profile instance had a required capability parameter enabled without any value, a problem could occur if it was exported.

#### Resources selected automatically for hidden and optional nodes \[ID_28019\]

In some cases, it could occur that resources were automatically selected for hidden and optional nodes when a booking was created, even though this should not happen.
