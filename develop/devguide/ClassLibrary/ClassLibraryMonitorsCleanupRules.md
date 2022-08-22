---
uid: ClassLibraryMonitorsCleanupRules
---

# Cleanup rules

## Default behavior

Any monitor will be automatically stopped in the following cases:

- When the source element (i.e. the element that starts the monitors) is stopped or restarted.

  This means that all monitors must be manually restarted when the element is restarted.

- When the destination element (i.e. the element that is being monitored) is deleted.

## Cleanup configuration

You can override the default cleanup behavior by adding a delay to the cleanup. This can be useful to avoid having to recreate monitors when an element is restarted or migrated.

> [!IMPORTANT]
> Cleanup configuration is mandatory for support of a DataMiner System with Failover setup. If the DMA with the element that creates the monitors remains running, but the DMA of the destination element goes into Failover, then you need to set up a cleanup delay, or else all subscriptions for that destination element will be removed.

The cleanup is canceled when the source or destination element that triggered the cleanup is started again before the delay timer is done.

> [!NOTE]
> The element state is checked every 2 seconds, so it is best to create delays as a multiple of 2000 ms.

In the example below, cleanup after source element stop is delayed by 6 seconds.

```csharp
MonitorCleanupConfig monitorCleanupConfig = new MonitorCleanupConfig(0, 0, 6000);
protocol.SetupMonitorsCleanupConfig(monitorCleanupConfig);
```

By passing a MonitorCleanupConfig object to the protocol, you can define delays on:

- Cleanup after destination element deletion.
- Cleanup after source element deletion.
- Cleanup after source element stop.
