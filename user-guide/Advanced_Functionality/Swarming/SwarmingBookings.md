---
uid: SwarmingBookings
---

# Swarming bookings

From DataMiner 10.4.4/10.5.0 onwards<!-- RN 38181 -->, it is possible to swarm bookings if the *Swarming* [soft-launch option](xref:SoftLaunchOptions) is enabled. However, from DataMiner 10.5.1/10.6.0 onwards<!-- RN 41293 -->, a different soft-launch option needs to be enabled for this, namely *BookingSwarming*. By enabling only this last option and not the *Swarming* option, you can swarm bookings without enabling the swarming of other DataMiner objects.

When an Agent hosts a booking, it will register the booking and execute the start, end, and event actions. If you want this to happen on a different Agent than the current hosting Agent, you can swarm the booking to a different Agent in the cluster. While swarming, DataMiner will try to unregister the booking from the Agent where it is currently hosted and wait until all ongoing actions have been completed. When this is done, DataMiner will try to register the booking on the new hosting Agent. When the booking is swarmed to the new Agent, event scripts of that booking will be executed on the new Agent.

> [!NOTE]
> To find out where a booking is currently hosted, you can check the *HostingAgentID* property of the booking.

## Triggering swarming for bookings 

To trigger the swarming of bookings, create a *SwarmingHelper* with the new hosting Agent ID and the booking IDs. See also [Swarming elements](xref:SwarmingElements) for examples on how to use the swarming helper to swarm elements. This can be done as follows:

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
> - To swarm a booking, the new hosting Agent must be up and running. In case the current hosting Agent is unreachable, swarming will still take place, but an error will be logged in the *SLResourceManager* log file.
> - If you swarm a booking to a new Agent, the linked resources and/or services will **not** be swarmed to that new Agent.
