---
uid: SwarmingBookings
---

# Swarming bookings

Since 10.4.4, it is possible to swarm bookings. To do so, you need the *Swarming* soft-launch option. 
From 10.5.1 onwards, the feature is placed behind a different soft-launch option, namely *BookingSwarming*. This also means that you can swarm bookings without having the permission to swarm other objects. 

When an agent hosts a booking, it will register the booking and execute the start, end and event actions. If you want this to happen on a different agent than the currently hosting agent, you can swarm the booking to a different agent in the cluster. While swarming, an attempt is made to unregister the booking from the agent where it is currently hosted and waits until all ongoing actions have been completed. Only when this is done, we will try to register the booking on the new hosting agent. Also note that, when the booking is swarmed to the new agent, event scripts of that booking will be executed on that new agent.

> [!TIP]
> If you want to know where the booking is currently hosted, you can check the *HostingAgentID* property on the booking.

Swarming bookings can be done by sending a *SwarmingRequestMessage*, to which you add the new hosting agent ID and booking ID. 
This can be done as follows:

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
> - In order to swarm a booking, the new hosting agent must be up and running. In case the current hosting agent is unreachable, swarming will still take place but an error will be in the *SLResourceManager* log file. 
> -  If you swarm a booking to a new agent, the linked resources and/or services will not be swarmed to that new agent. 

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
    var resultBuilder = new StringBuilder();
    foreach (var oneResponse in typedResponses)
    {
        foreach (var result in oneResponse.SwarmingResults)
        {
            // Handle the progress for the booking. In this case generate an information event
            var resultDetails = result.Success ? "completed successfully" : $"failed with error: {result.Messsage}";
            resultBuilder.AppendLine($"Swarming booking with id {result.DmaObjectRef} {resultDetails}");
        }
    }

    // Example value of 'resultBuilder.ToString()':
    //      Swarming booking with id 54add931-66fc-44f5-a76e-95ad0317f6af completed successfully
    //      Swarming booking with id a250cffb-7054-4704-aa58-96200b0c49b3 failed with error: Could not swarm booking with id 'a250cffb-7054-4704-aa58-96200b0c49b3': ResourceManager is not initialized
}

// Swarming request can be aborted on the asyncReference:
// asyncReference.Abort();
```

> [!NOTE]
>
> Currently, progress events don't work when sent via the impersonated connection in Automation Scripts (engine.GetUserConnection().Async).
