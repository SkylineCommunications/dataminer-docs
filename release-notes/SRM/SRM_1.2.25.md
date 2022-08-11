---
uid: SRM_1.2.25
---

# SRM 1.2.25

> [!NOTE]
> This version requires that **DataMiner 10.2.6 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### Extended SRM import/export \[ID_33400\]

The SRM import and export feature has been extended to also include the following items:

- DTR scripts
- LSO scripts
- Created Booking Actions scripts
- Custom Contributing Conversion scripts
- Path LSO scripts
- Contributing Apply Profile scripts

#### Quick resource booking with capacity \[ID_33445\]

When you create a booking using the *SRM_BookResourcesQuickly* script, for example from a timeline, you can now define which capacity needs to be booked. The script contains an optional new dialog where you can define the capacities for the resources used in the booking. If you select the maximum for a capacity, the maximum currently defined on resource level will be booked. You can also book all concurrency and capacity.

To support booking all concurrency and capacity, when a booking is created or edited, it is now possible for an unmapped function to set the *ConcurrencyUsageType* to *All* and the *UsesCompleteCapacity* set to *true*, by setting the function field *ShouldBookFullConcurrencyAndCapacity* to *true*. This is only supported when the Optimized Silent Booking Type is used.

#### Booking Manager configuration export \[ID_33452\]

In the Booking Manager app, on the *Config* > *Backup* page, you can now export the full configuration for a Booking Manager.

The export user interface was added to the *SRM_FullConfigurationExport* script, which will now show the generated exported file name in case of success, or the error message in case of failure.

## Changes

### Enhancements

#### Username specified in logging when script is executed asynchronously \[ID_33164\]

Previously, when a script was executed asynchronously, the username of the person executing the script was mentioned as "Automation-script XXX" in the SRM logging. Now the actual name of the user executing the script will be specified instead.

#### CreateSla property now saved as boolean instead of string \[ID_33549\]

To prevent possible issues with Elasticsearch, the *CreateSla* property is now saved as a boolean instead of a string when a new booking is created with the *SRM_CreateNewBooking* script.

### Fixes

#### Problem with validation of recurrence duration \[ID_33343\]

A problem with the validation of the duration of a recurrence could cause issues with resource scheduling. For example, the following exception could be thrown:

```txt
Skyline.DataMiner.Library.Exceptions.InvalidBookingDataException: Duration needs to match the difference between EndDate and StartDate
```

#### Incorrect error message in case 'ResourceOutputInterfaces' or 'ResourceInputInterfaces' were missing \[ID_33380\]

In case the profile parameters *ResourceOutputInterfaces* or *ResourceInputInterfaces* are missing, it is not possible to create a booking. Up to now, in that case the following incorrect error message was shown:

```txt
create new booking failed: ResourceOutputInterfaces or ResourceInputInterfaces Please run srm_migrateresourceioproperties.
```

This error message has been improved as follows:

```txt
create new booking failed: Failed to find required interface capabilities because ResourceInputInterfaces or ResourceOutputInterfaces doesn't exist.
```

In addition, the *SRM_CreateNewBooking* script has been adjusted to display such errors.
