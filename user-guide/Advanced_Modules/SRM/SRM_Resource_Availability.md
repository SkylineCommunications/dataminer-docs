---
uid: Resource_availability
---

# Resource availability

The **resource availability** feature, available from DataMiner 10.5.3/10.6.0 onwards<!-- RN 41894 -->, allows you to define a specific period during which a resource is available for booking. This can be useful in several scenarios. Some examples:

- A resource will be commissioned at a specific date and as such can only be used in bookings after that date. An availability window can be defined on the resource that makes it possible to add the resource to the system but makes sure it can only be included in bookings after the commission date.
- A resource will be decommissioned at a specific date. An availability window can be defined on the resource that makes it impossible to book the booking after that decommission date.
- A resource always needs to be available within 30 days. An availability window can be defined on the resource that makes it impossible to book it further than 30 days in the future.

Trying to book a resource outside its availability window will move that booking to quarantine. Likewise, adjusting the availability window of an existing resource in such a way that existing bookings are no longer supported will quarantine those bookings (see [Quarantine](xref:SRM_Quarantine)). If the available resources in a certain time range are requested (see [Getting available resources](xref:srm_using_resourcemanagerhelper#getting-available-resources)), resources that are configured to not be available during that time range will also not be returned.

## Availability window properties

An availability window consists of three properties:

| Property | Type | Description |
|--|--|--|
| AvailableFrom | DateTimeOffset | Defines the start of the availability window. The default value is *DateTimeOffset.MinValue*, which means there is no start time. Must be lower than the *AvailableUntil* property. |
| AvailableUntil | DateTimeOffset | Defines the end of the availability window. The default value is *DateTimeOffset.MaxValue*, which means there is no end time. Must be greater than the *AvailableFrom* property. |
| RollingWindowConfiguration | RollingWindowConfiguration | Specifies a rolling window of availability relative to the current time. For example, setting the rolling window to 30 days means the resource is available for booking until "now + 30 days". |

If both a fixed end time (`AvailableUntil`) and a rolling window are set, the earlier end time is used to determine the end of the availability. For instance, if `AvailableUntil` is 15 days from now, but the rolling window is 30 days, the resource will only be available for the next 15 days.

If a fixed start time (`AvailableFrom`) and a rolling window are set, the resource needs to be available according to both conditions before it can be included in a booking. For instance, if the fixed start time is 30 days from now, and the rolling window is 10 days, the resource is not bookable yet, because the rolling window ends before the fixed start time.

## Code examples

### Example of configuring an availability window

Here is a code example showing how to configure the availability window for a resource:

```csharp
var resource = _rmHelper.GetResource(...);

resource.AvailabilityWindow = new BasicAvailabilityWindow()
{
    AvailableFrom = DateTimeOffset.Now.AddDays(1),  // Resource available starting from tomorrow
    AvailableUntil = DateTimeOffset.Now.AddDays(100), // Resource available for the next 100 days
    // RollingWindow can be left as 'null' if no rolling window is configured
    RollingWindowConfiguration = new RollingWindowConfiguration(TimeSpan.FromDays(30)) // 30-day rolling window
};

resource = _rmHelper.AddOrUpdateResources(resource)?.FirstOrDefault();

var td = _rmHelper.GetTraceDataLastCall();

if (!td.HasSucceeded())
{
    // Handle the error
}
```

### Retrieving available time ranges

The availability window provides a method to retrieve the specific time ranges in which the resource is available.

```csharp
AvailabilityResult result = resource.AvailabilityWindow.GetAvailability(new AvailabilityContext());
List<ResourceWindowTimeRange> availableRanges = result.AvailableTimeRanges;

foreach (var range in availableRanges)
{
    DateTimeOffset start = range.Start;
    DateTimeOffset end = range.Stop;
    
    // You can also get detailed information about the boundaries of the time ranges
    TimeRangeBoundaryDetails startDetails = range.StartDetails;
    
    // Check if the start boundary is defined by a rolling window
    BoundaryDefinition startDefinition = startDetails.BoundaryDefinition;
    if (startDefinition == BoundaryDefinition.RollingWindow)
    {
        // Handle cases where the boundary is defined by a rolling window
    }
}
```

The `AvailabilityContext` includes a `Now` property that allows you to override the "current time" when determining the end of a rolling window. However, when reusing a context, be cautious not to use one with an outdated `Now` property, as this could lead to incorrect rolling window end times. Nevertheless, reusing the same context can be useful when calculating the (un)available time ranges for multiple resources, as it ensures consistent rolling window calculations across all resources.
