---
uid: SRM_10.3.0.2
---

# SRM 10.3.0.2

> [!NOTE]
> This version requires that **DataMiner 10.3.0 [CU0] or higher** is installed. It is not compatible with the DataMiner Feature Release track.

## New features

#### New Details icon in Booking Manager app [ID_37469]

It is now possible to view the details of a booking in the Booking Manager application. To do so, when you have selected a booking on the timeline, click the *Details* icon in the lower right corner.

#### SRM Framework Configuration BPA [ID_37689]

A new SRM Framework Configuration BPA test is now included in the SRM Framework.

You can use this BPA test to check if the SRM logging location is correctly configured. The test will check if there is a parameter with name *Logging Location*, and it will check whether the value of this parameter is valid, it is part of the Skyline DataMiner\\Documents folder, and it does not end in a backslash character.

#### Booking creation now supports security view IDs [ID_37774]

​The SRM Framework has been extended to support the creation of a booking with its corresponding security view IDs.

As illustrated below, it is now possible to pass the IDs of the security views in the Booking class:

```csharp
var booking = new Booking
{
    Description = "Game 1",
    Recurrence = new Recurrence
    {
        StartDate = startTime,
        EndDate = endTime,
    },
    ServiceDefinition = serviceDefinitionId.ToString(),
    SecurityViewIds = new HashSet<int> { view.ViewID }
};
```

## Changes

### Enhancements

#### SRM_ResourceAction script now supports adding lite contributing resources [ID_37512]

The *SRM_ResourceAction* "Add" action now supports lite contributing resources.

### Fixes

#### Not possible to reset resource pool parameter with DTR [ID_37639]

When a data transfer rule (DTR) was used to reset a resource pool parameter, it could occur that this did not work. After a value was set in the parameter, only values that were present in the parameter discrete options were accepted, so a reset to an empty string was discarded.

#### Start property of booking not set correctly for booking with pre-roll stage in the past [ID_37887]

When a booking with pre-roll stage was created and this pre-roll stage was situated in the past, it could occur that the start property of the booking could not be set correctly.
