---
uid: SwarmingBookings
---

# Swarming bookings

Since 10.4.4, it is possible to swarm bookings. To do so, you need the *Swarming* soft-launch option. 
From 10.5.1 onwards, the feature is placed behind a different soft-launch option, namely *BookingSwarming*.

Swarming bookings can be done by sending a *SwarmingRequestMessage*, to which you add the new hosting agent ID and booking ID. 
This can be done as follows:

```csharp
using System;
using System.Linq;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Swarming;

public class Script
{
    public void Run(Engine engine)
    {
        var newHostingAgent = 123;
        var bookingId = Guid.Parse("...");

        var request = SwarmingRequestMessage.ForBooking(newHostingAgent, bookingId);
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
> - In order to swarm a booking, the new hosting agent must be up and running. In case the current hosting agent is unreachable, swarming will still take place but an error will be in the log file. 
> -  If you swarm a booking which has services or resources linked to it, these will not be swarmed to the new agent. 

Bookings can also be swarmed async and in bulk. When doing this, progress events will be sent out to the client every time the swarming of a booking is completed. This can be done as follows: 

```csharp
// The DMA that should host the bookings after swarming them
var targetDmaId = 123;

// The IDs of the bookings that need to be swarmed
var bookingIds = new List<Guid>() { ... };

var swarmingRequest = SwarmingRequestMessage.ForBookings(targetDmaId, bookingIds);

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

    foreach (var oneResponse in typedResponses)
    {
        foreach (var result in oneResponse.SwarmingResults)
        {
            // Handle the progress for the booking. In this case generate an information event
            var resultDetails = result.Success ? "completed successfully" : $"failed with error: {result.Messsage}";
            engine.GenerateInformation($"Swarming booking with id {result.DmaObjectRef} {resultDetails}");
        }
    }
}

// Swarming request can be aborted on the asyncReference:
// asyncReference.Abort();
```
