---
uid: SRM_2.0.6
---

# SRM 2.0.6

> [!NOTE]
> This version requires that **DataMiner 10.6.1.0-16647 or higher** is installed. The DataMiner Main Release track is not supported.

## Enhancements

#### Support for booking creation and editing in ambiguous time slots during DST transitions [ID 45307]

During a Daylight Saving Time (DST) fallback transition (e.g., when clocks move from 2:00 AM back to 1:00 AM), the same local hour occurs twice. This creates ambiguous local times, where a given timestamp (e.g., 1:30 AM) may refer to either the first or the second occurrence. Previously, SRM always resolved ambiguous local times to the second occurrence, which could result in bookings being scheduled at an unintended time.

With this change, SRM now supports providing booking dates in UTC rather than local time when performing silent operations (without user interaction), both when creating or editing bookings and when updating their time using the *ChangeTime* action. When the time zone is explicitly set to UTC, SRM ignores the conversion to UTC and uses the dates provided as is. This allows the intended occurrence to be clearly specified and avoids ambiguity during DST transitions.

Both *ChangeTimeInputData* and the *Recurrence* classes now include a *TimeZoneInfo* property, allowing the time zone of the provided start and end dates to be explicitly defined. For example:

```csharp
var booking = new Booking
{
   Description = "Booking Description",
   Recurrence = new Recurrence
   {
      StartDate = new DateTime(2026, 1, 1, 12, 30, 0),
      EndDate = new DateTime(2026, 1, 1, 13, 00, 0),
      TimeZoneInfo = TimeZoneInfo.Utc
   },
   ServiceDefinition = "c2583ca4-a55e-483f-a50e-7d5e0a6b357f"
};

var newTiming = new ChangeTimeInputData
{
   StartDate = new DateTime(2026, 1, 1, 12, 30, 0),
   EndDate = new DateTime(2026, 1, 1, 13, 00, 0),
   PreRoll = TimeSpan.FromMinutes(1),
   PostRoll = TimeSpan.FromMinutes(1),
   IsSilent = true,
   TimeZoneInfo = TimeZoneInfo.Utc
};
```

#### SRM_DiscoverResources and PFM_ProfileInstancesImportExport scripts now use MiniExcel library [ID 45404]

The Excel import/export functionality in the *SRM_DiscoverResources* and *PFM_ProfileInstancesImportExport* scripts has been updated. The previous implementation used the OLEDB library, which in some cases caused operations to hang or Excel files to remain locked. Now the MiniExcel library will be used instead, which provides more stable handling of Excel files.

#### New option to skip 'Configuring (...)' service state [ID 45985]

Up to now, SRM bookings always updated the service state twice for every transition: first to an intermediate *Configuring (...)* value while the LSO script ran, and then to the target state after completion. On systems with many bookings starting at the same time, these extra updates could delay booking starts.

To address this, you can now configure bookings to skip the intermediate *Configuring (...)* updates. To do so, add the property *SkipConfiguringStates* to the reservation object and set its value to true. With this configuration, the service state will keep its previous value while the LSO script runs. It will only be updated when the final state is reached.

To automatically add this property to new bookings, a new *Skip Configuring States* setting is available in the Booking Manager app, under *Config* > *Services and SLA*. However, note that this setting only applies to new bookings. To add the property to existing bookings, you will need to use a script.

## Fixes

#### Full configuration of Booking Manager element could not be imported [ID 45264]

When the full configuration of a Booking Manager element was imported from another DMA, this could fail because of an issue in the *SRM_ExportFullConfiguration* script.

#### AssignResources did not synchronize resources inherited through resource pool references [ID 46105]

Previously, when *AssignResources* was used on a node or interface containing parameters configured with resource pool inheritance, changes to those parameter values did not correctly update the associated booking resources. As a result, the inherited resources in the booking could become out of sync with the parameters that referenced them.

This has been fixed. From now on, *AssignResources* correctly synchronizes the booking resources when such parameters change, adding, removing, replacing, or auto-selecting the referenced resource as needed.

#### Resource or service orchestration triggered unnecessary booking lookups [ID 46110]

Previously, during resource or service orchestration, DataMiner SRM retrieved the booking instance even when this was not required. As a result, extra calls were made to the Resource Manager without adding value.

This has been improved. SRM now retrieves the booking instance only when needed, reducing unnecessary Resource Manager calls and improving orchestration efficiency.
