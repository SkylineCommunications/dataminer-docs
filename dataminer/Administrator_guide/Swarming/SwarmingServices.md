---
uid: SwarmingServices
---

# Swarming services

With DataMiner Swarming, you can swarm services from one DataMiner Agent to another within a cluster. You can do so [in DataMiner Cube](#swarming-services-in-dataminer-cube) or [via an automation script](#swarming-services-via-automation).

When you are swarming a service so it gets hosted on a different DataMiner Agent, a temporary transition occurs. While this happens, a message will be displayed to inform users that the service is currently swarming. The ability to open the service card or change the service configuration for the involved service will be temporarily suspended. Once the migration is complete, it will become accessible again.

> [!NOTE]
> Swarming a service does not swarm the elements linked to that service. If you want those elements to be hosted on the same Agent as the service, you must [swarm them separately](xref:SwarmingElements).

## Required user permissions

To be able to trigger swarming for a service, you need the [Swarming](xref:DataMiner_user_permissions#modules--swarming) user permission as well as config rights on the service.

## Swarming services in DataMiner Cube

To swarm services in DataMiner Cube:

1. Go to *System Center* > *Agents* > *Status* and click the *Swarm* button in the lower-right corner.

1. On the left, select the service(s) you want to swarm.

   This list does not include services that cannot be swarmed because of technical restrictions or because they have been explicitly blocked from swarming.

1. On the right, select the destination DMA.

1. Click *Swarm*.

## Swarming services via Automation

To swarm services via an automation script, call the SwarmingHelper.Create method and indicate the services that need to be swarmed and the ID of the node they need to be swarmed to.

For example:

```csharp
Skyline.DataMiner.Net.Swarming.SwarmingResult[] swarmingResults = Skyline.DataMiner.Net.Swarming.Helper.SwarmingHelper.Create(engine.GetUserConnection())
           .SwarmService(new ServiceID(123, 456))
           .ToAgent(789);
```

For more detailed examples, refer to [Configuring a script to swarm services](xref:SwarmingScriptService).
