---
uid: SRM_10.3.0.2
---

# SRM 10.3.0.2

> [!NOTE]
> This version requires that **DataMiner 10.3.0 [CU0] or higher** is installed. The DataMiner Feature Release track is not supported.

## New features

#### New Details icon in Booking Manager app [ID 37469]

It is now possible to view the details of a booking in the Booking Manager application. To do so, when you have selected a booking on the timeline, click the *Details* icon in the lower-right corner.

#### SRM Framework Configuration BPA [ID 37417] [ID 37689]

A new SRM Framework Configuration BPA test is now included in the SRM Framework.

You can use this BPA test to check if properties of current and future bookings have been set correctly and to check if the SRM logging location is correctly configured.

For the properties, the test will check the following things:

- Whether each booking has properties with the name *Booking Manager*, *Booking Life Cycle*, *FriendlyReference*, *PreRoll*, *PostRoll*, *Service State*, *Start*, *End*, *VisualBackground*, and/or *VisualForeground*.
- Whether the above-mentioned properties have a value.
- Whether the properties *Start* and *End* are in DateTime format.
- Whether the properties *PreRoll* and *PostRoll* are in TimeSpan format.
- Whether the *Start* - *PreRoll* property value is the same as *Reservation.Start*.
- Whether the *End* + *PostRoll* property value is the same as *Reservation.End* when the *End* property does not have the value *Not Applicable*.
- Whether the *PostRoll* property value is the same as *TimeSpan.Zero* when the *End* property has the value *Not Applicable*.
- Whether the Booking Manager property value refers to an existing, active DataMiner element using the connector Skyline Booking Manager.
- Whether the booking has the *Virtual Platform* property and its value is the same as the value of the element's *Default Virtual Platform* parameter.

For the booking location, the test will check if there is a parameter with name *Logging Location*, and it will check whether the value of this parameter is valid, it is part of the Skyline DataMiner\\Documents folder, and it does not end in a backslash character.

> [!NOTE]
> Depending on the number of bookings in the system, the BPA test can take some time to run.

#### Booking creation now supports security view IDs [ID 37774]

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

#### SRM_ResourceAction script now supports adding lite contributing resources [ID 37512]

The *SRM_ResourceAction* "Add" action now supports lite contributing resources.

### Fixes

#### SRM Function Resources Consistency BPA test could not find hidden or service element [ID 37568]

When the main element referenced by a resource was a hidden element or service element, it could occur that the SRM Function Resources Consistency BPA test reported that this element could not be found.

#### Not possible to reset resource pool parameter with DTR [ID 37639]

When a data transfer rule (DTR) was used to reset a resource pool parameter, it could occur that this did not work. After a value was set in the parameter, only values that were present in the parameter discrete options were accepted, so a reset to an empty string was discarded.

#### Start property of booking not set correctly for booking with pre-roll stage in the past [ID 37887]

When a booking with pre-roll stage was created and this pre-roll stage was situated in the past, it could occur that the start property of the booking could not be set correctly.
