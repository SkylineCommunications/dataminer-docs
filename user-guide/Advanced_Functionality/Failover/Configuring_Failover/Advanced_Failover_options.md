---
uid: Advanced_Failover_options
---

# Advanced Failover options

When you click *Advanced* in the *Failover* dialog box, a window opens with several tabs where you can configure advanced options.

> [!NOTE]
> Some Failover options can also be configured directly in *MaintenanceSettings.xml*. For more information, refer to the Watchdog settings in [MaintenanceSettings.xml](xref:MaintenanceSettings_xml).

## Type

Go to this tab to specify whether Failover should occur manually or automatically.

- If you choose *Automatic*, you must then go to the *Heartbeats* tab to specify all necessary settings.

- If you choose *Manual*, switching can be done with the *Switch* button at the bottom of the *Failover* dialog box.

  > [!NOTE]
  >
  > - Manual switching is not possible when the offline DMA is not running. In that case, the *Switch* button will be unavailable.
  > - If the online DMA becomes unavailable for some reason, you can switch by connecting to the offline DMA with DataMiner Cube. You will then get the option to bring that DMA online.

## Synchronization

Go to this tab to configure the network interface for data synchronization from the online DMA to the backup DMA.

> [!NOTE]
>
> - If there is a third network interface that connects both DMAs using a cross cable, it is advisable to select that one in order to prevent synchronization failures.
> - Note that synchronization of a Cassandra or Elasticsearch database is taken care of by the database itself, outside of DataMiner.

## Heartbeats

If Failover has been set to occur automatically, the “heartbeats” need to be configured on this tab.

The DMAs use these heartbeats to check whether their Failover team mate is still up and running. At regular intervals, both DMAs send heartbeats to each other. When the backup Agent notices that all configured heartbeats have been failing, it will automatically go online. However, if both Agents notice that normal heartbeats are failing, no switch is performed (assuming that the Agents still have a way to communicate).

There are two types of heartbeats:

- **Normal heartbeats**: An offline Agent goes online automatically when all normal heartbeats are failing.

- **Inverted heartbeats**: An Agent goes or remains offline when all inverted heartbeats are failing. This prevents both Agents from going online simultaneously when for instance a network switch between them is down.

  > [!CAUTION]
  > It is important that the inverted heartbeats are configured as well, to avoid issues with both DMAs going online the moment they can no longer contact each other. This can especially be a problem with less recent DataMiner systems.

Each heartbeat causes a periodical connection check:

- **To a DMA**: A DataMiner communication check using IP port 8004. With this type of heartbeat, it is possible to specify the network interface to be used.

- **To an IP address**: A ping request is performed.

For every heartbeat you configure, you can specify a maximum number of allowed failures. This way, you can keep the backup DMA from taking over each time a single heartbeat fails for one reason or another.

## Virtual IP Addresses

On this tab, you can configure virtual IP addresses for the different network interfaces. These addresses will be moved between agents when switching.

This tab is not available if a shared hostname is used instead of virtual IP addresses.

## Advanced Options

This tab is available from DataMiner 10.2.0 \[CU5]/10.2.8 onwards. It contains the following option:

- **Auto restart Agent when going offline**: If you select this option, when one of the DMAs in the Failover pair goes offline, it will restart as soon as possible instead of waiting until all elements have been unloaded. This will speed up Failover switching. In earlier DataMiner versions, this could be configured in [DMS.xml](xref:DMS_xml#failover-subtag).
