---
uid: Disconnecting_from_dataminer.services
keywords: disconnect from the cloud
reviewer: Alexander Verkest
---

# Disconnecting from dataminer.services

Though this is not recommended, once a DataMiner Agent has been connected to dataminer.services, it is possible to disconnect it again. You can either [disconnect temporarily](#temporarily-disconnecting-from-dataminerservices), or [disconnect permanently](#permanently-disconnecting-from-dataminerservices).

> [!TIP]
> If you just want to remove one DMA from a DMS on dataminer.services, refer to [Removing a DataMiner Agent from a DataMiner System](xref:Removing_a_DataMiner_Agent_from_a_DataMiner_System).

## Temporarily disconnecting from dataminer.services

Temporarily disconnect your system from dataminer.services, go to each server that has the CloudGateway module installed, and complete the following steps:

1. Stop the CloudGateway service through the Task Manager:

   1. Open Windows Task Manager.

   1. Go to the *Services* tab.

   1. Locate the *DataMiner CloudGateway* service

   1. Right-click the service and click *Stop*.

1. Disable automatic startup for the CloudGateway service:

   1. Search for *Services* in Windows.

   1. Locate the *DataMiner CloudGateway* service.

   1. Right-click and select *Properties*.

   1. Change the startup type from *Automatic* to *Disabled*.

> [!NOTE]
> If you do not disable the automatic startup for the service, the CloudGateway module will restart when the server restarts.

To **reconnect your system**, you will need to change the startup type for the DataMiner CloudGateway service from *Disabled* to *Automatic* again and start the service manually.

> [!IMPORTANT]
> Disconnecting your system for a longer period of time might lead to your cloud session becoming invalid. When this happens, you will need to manually renew the connection via DataMiner Cube by going to *System Center* > *Cloud* and clicking the renew button.

## Permanently disconnecting from dataminer.services

> [!WARNING]
> Disconnecting a DataMiner System from dataminer.services will result in the **loss of all data for that DataMiner System on dataminer.services**. This action is **irreversible** and can have far-reaching consequences:
>
> - Skyline Communications will no longer be able to provide [Proactive Support](xref:Proactive_Support) for your DMS.
> - All data for the DMS that was saved on dataminer.services will be lost, including shares, settings, and users and permissions configured on dataminer.services.
> - If your DMS consists of one or more fully **self-hosted** DataMiner Agents, these will continue to work, but you will no longer have access to dataminer.services features. If your DataMiner Agents are Community Edition systems or run in subscription mode, they will stop working after 1 month, unless you **convert them to a perpetual license or offline demo license**. See also [Switching from subscription mode to perpetual license](xref:Switching_from_subscription_mode_to_perpetual_license) and [Switching from subscription mode to an offline demo license](xref:Switching_from_subscription_mode_to_offline_demo).
> - If your DMS uses DataMiner **Storage as a Service** (STaaS), **all data will be permanently lost** 7 days after the system is disconnected, and the system will no longer be usable.
> - If you use **DataMiner as a Service** (DaaS), this will **delete your system**. See [Removing a DaaS system](xref:Removing_a_DaaS_system).

To disconnect a DataMiner System from dataminer.services:

1. Delete the DMS on dataminer.services:

   1. On the dataminer.services page, click the ellipsis ( "...") button in the top-right corner of the box representing the DataMiner System and select *Delete DMS*.

   1. Fill in the name of the system to confirm that this is the system you want to remove.

   1. Click *Delete*.

1. Unregister the DMS using SLNetClientTest tool:

   1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

      > [!CAUTION]
      > Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

   1. Go to *Advanced* > *CcaGateway*.

      This will open the CcaGateway window.

      > [!TIP]
      > For detailed information about this window, see [Debugging the dataminer.services connection](xref:SLNetClientTest_debugging_cloud_connection).

   1. Click *Unregister Dms*.

      > [!WARNING]
      > This action is **irreversible** and can have far-reaching consequences for your DataMiner System. Always consult with a Skyline DevOps Engineer before you use this option.

> [!NOTE]
> Performing either of the two main steps above is already enough to disconnect the DMS. However, if you only delete the DMS on dataminer.services, the DMS will still try to reach dataminer.services, and if you only unregister the DMS, the information related to the DMS will still be displayed on dataminer.services.
