---
uid: SwarmingScriptBooking
---

# Configuring a script to swarm bookings

If [swarming of bookings is enabled](xref:SwarmingBookings), you can use an automation script to trigger the swarming.

In this script, create a *SwarmingHelper* with the new hosting Agent ID and the booking IDs. See also [Configuring a script to swarm elements](xref:SwarmingScriptElement) for examples on how to use the swarming helper to swarm elements.

This can be done as follows:

```csharp
using System;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Swarming.Helper;

public class Script
{
    public void Run(Engine engine)
    {
        var newHostingAgent = 123;

        // This example parses the booking IDs from strings. The script could for example also obtain the IDs via an input parameter,
        // or by retrieving bookings using the Resource Manager helper.
        var bookingIds = new[]
        {
            Guid.Parse("..."),
            Guid.Parse("...")
        };

        var swarmingResults = SwarmingHelper.Create(engine.GetUserConnection())
                                            .SwarmBookings(bookingIds)
                                            .ToAgent(newHostingAgent);

        if (swarmingResults == null)
        {
            engine.ExitFail("Swarming failed: result was null");
        }

        // There should be a result for each booking.
        if (swarmingResults.Length != bookingIds.Length)
        {
            var sentIds = string.Join(", ", bookingIds.OrderBy(b => b));

            // 'ToString' of a SwarmingResult will contain the ID of the object, the message, and whether swarming succeeded for the object or not.
            var results = string.Join(", ", swarmingResults.Select(s => s.ToString()));

            engine.ExitFail($"Did not receive enough swarming responses. Requested to swarm {bookingIds.Length} bookings, but got {swarmingResults.Length} responses.{Environment.NewLine}" +
                            $"Sent ids: {sentIds}{Environment.NewLine}Results: {results}");
        }

        var unsuccessfulResults = swarmingResults.Where(s => !s.Success).ToList();
        if (unsuccessfulResults.Count != 0)
        {
            var failedBookings = string.Join(", ", unsuccessfulResults.Select(s => s.ToString()));
            engine.ExitFail($"Failed to swarm some bookings. Failed results: {failedBookings}");
        }
    }
}
```

> [!NOTE]
>
> - To find out where a booking is currently hosted, you can check the *HostingAgentID* property of the booking.
> - To swarm a booking, the new hosting Agent must be up and running. In case the current hosting Agent is unreachable, swarming will still take place, but an error will be logged in the *SLResourceManager* log file.
> - If you swarm a booking to a new Agent, the linked resources and/or services will **not** be swarmed to that new Agent.
> - To be able to trigger swarming for a booking, you need the [Swarming](xref:DataMiner_user_permissions#modules--swarming) user permission.
