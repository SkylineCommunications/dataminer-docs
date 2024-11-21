---
uid: SwarmingBookings
---

# Swarming bookings

From DataMiner 10.4.4/10.5.0 onwards<!-- RN 38181 -->, it is possible to swarm bookings if the *Swarming* [soft-launch option](xref:SoftLaunchOptions) is enabled. However, from DataMiner 10.5.1/10.6.0 onwards<!-- RN 41293 -->, a different soft-launch option needs to be enabled for this, namely *BookingSwarming*. By enabling only this last option and not the *Swarming* option, you can swarm bookings without enabling the swarming of other DataMiner objects.

When an Agent hosts a booking, it will register the booking and execute the start, end, and event actions. If you want this to happen on a different Agent than the current hosting Agent, you can swarm the booking to a different Agent in the cluster. While swarming, DataMiner will try to unregister the booking from the Agent where it is currently hosted and wait until all ongoing actions have been completed. When this is done, DataMiner will try to register the booking on the new hosting Agent. When the booking is swarmed to the new Agent, event scripts of that booking will be executed on the new Agent.

> [!NOTE]
> To find out where a booking is currently hosted, you can check the *HostingAgentID* property of the booking.

## Triggering swarming for a booking

To trigger the swarming of a booking, send a *SwarmingRequestMessage* with the new hosting Agent ID and the booking ID. This can be done as follows:

```csharp
using System;
using System.Linq;
using System.Collections.Generic;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Swarming;

public class Script
{
    public void Run(Engine engine)
    {
        var newHostingAgent = 123;
        var bookingIds = new List<Guid>()
        {
            Guid.Parse("..."),
            Guid.Parse("..."),
        };


        var request = SwarmingRequestMessage.ForBookings(newHostingAgent, bookingIds.ToArray());
        var response = engine.SendSLNetMessage(request)?.First() as SwarmingResponseMessage;

        if (response == null)
        {
            engine.ExitFail($"Response was null, which was not expected.");
        }

        foreach (var result in response.SwarmingResults)
        {
            if (!result.Success)
            {
                engine.ExitFail($"Swarming failed: {result?.Message}.");
            }
        }
    }
}
```

> [!NOTE]
>
> - To swarm a booking, the new hosting Agent must be up and running. In case the current hosting Agent is unreachable, swarming will still take place, but an error will be logged in the *SLResourceManager* log file.
> - If you swarm a booking to a new Agent, the linked resources and/or services will **not** be swarmed to that new Agent.

## Swarming bookings asynchronously and in bulk

Bookings can also be swarmed asynchronously and in bulk. When this happens, progress events will be sent out to the client every time the swarming of a booking is completed.

You can trigger this as follows:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Async;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Swarming;

public class Script
{
    public void Run(Engine engine)
    {
        // The DMA that should host the bookings after swarming them
        var targetDmaId = 123;

        // The IDs of the bookings that need to be swarmed
        var bookingIds = new List<Guid>() { ... };

        var swarmingRequest = SwarmingRequestMessage.ForBookings(targetDmaId, bookingIds.ToArray());

        // TODO: provide your connection here
        var asyncConnection = connection.Async;

        // Event that will be set in the complete handler
        var completeEvent = new ManualResetEventSlim(false);

        var asyncReference = asyncConnection.Launch(
            swarmingRequest,
            onCompleteHandler: (o, args) => completeEvent.Set(),
            onProgressHandler: HandleProgressEvent
        );

        void HandleProgressEvent(object sender, AsyncProgressArgs args)
        {
            if (!(args.Progress is AsyncProgressResponseEvent responseEvent))
            {
                // This should not happen, progress event sent out for booking swarming will always be of type 'AsyncProgressResponseEvent'
                return;
            }

            if (responseEvent.Response == null || responseEvent.Response.Length == 0)
            {
                // This should not happen either, there should always be at least one response in the event.
                return;
            }

            // The response messages in the progress event will always be of type 'SwarmingResponseMessage'
            var typedResponses = responseEvent.Response.OfType<SwarmingResponseMessage>().ToList();
            var resultBuilder = new StringBuilder();
            foreach (var oneResponse in typedResponses)
            {
                foreach (var result in oneResponse.SwarmingResults)
                {
                    // Handle the progress for the booking. In this case generate an information event
                    var resultDetails = result.Success ? "completed successfully" : $"failed with error: {result.Message}";
                    resultBuilder.AppendLine($"Swarming booking with id {result.DmaObjectRef} {resultDetails}");
                }
            }

            // Example value of 'resultBuilder.ToString()':
            //      Swarming booking with id 54add931-66fc-44f5-a76e-95ad0317f6af completed successfully
            //      Swarming booking with id a250cffb-7054-4704-aa58-96200b0c49b3 failed with error: Could not swarm booking with id 'a250cffb-7054-4704-aa58-96200b0c49b3': ResourceManager is not initialized
        }
    }
}

// Swarming request can be aborted on the asyncReference:
// asyncReference.Abort();
```

> [!NOTE]
> Currently, progress events do not work when sent via the impersonated connection in Automation scripts (engine.GetUserConnection().Async).
