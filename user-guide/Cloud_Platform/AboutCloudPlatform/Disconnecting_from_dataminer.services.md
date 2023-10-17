---
uid: Disconnecting_from_dataminer.services
---

# Permanently disconnecting from dataminer.services

Though this is not recommended, once a DataMiner Agent has been connected to dataminer.services, it is possible to disconnect it again.
If you only want to temporarily disconnect your system from dataminer.services take a look at [Temporarely disconnecting from dataminer.services](#temporarely-disconnecting-from-dataminer.services)

> [!WARNING]
> Disconnecting a DataMiner System from dataminer.services will result in the **loss of all data for that DataMiner System on dataminer.services**. This action is **irreversible** and can have far-reaching consequences:
>
> - Skyline Communications will no longer be able to provide [CCA Support Services](xref:CCA_Support_Services) for your DMS.
> - All data for the DMS that was saved on dataminer.services will be lost, including shares, settings, and users and permissions configured on dataminer.services.
> - If your DMS consists of one or more fully self-hosted DataMiner Agents, these will continue to work, but you will no longer have access to dataminer.services features.
> - If your DMS uses DataMiner **Storage as a Service** (STaaS), **all data will be permanently lost** and the system will become unusable.

To disconnect a DataMiner Agent from dataminer.services:

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

1. Contact Skyline Communications to remove the remaining information for your DMS from dataminer.services.

> [!NOTE]
> This procedure is not applicable for DataMiner as a Service (DaaS) systems. If you want to deactivate a DaaS system, contact Skyline Communications. However, note that this will cause that DataMiner System to be permanently removed.

# Temporarely disconnecting from dataminer.services

Follow this procedure if you would like to temporarily disconnect your system from dataminer.services.

Go to each server that has the CloudGateway module installed and complete the following steps:

1. Stop the service through the task manager:
   1. Open the task manager
   2. Go to Services
   3. Find the _DataMiner CloudGateway_ service
   4. Right-click the service and click **Stop**

2. Disable automatic startup for the service:
   1. Search for _Services_ in Windows
   2. Locate the _DataMiner CloudGateway_ service
   3. Right-click and select _Properties_
   4. Change the startup type from _Automatic_ to _Disabled_

> [!WARNING]
> If you do not disable the automatic startup for the service, the CloudGateway module will restart when the server restarts.

If you want to **reconnect your system** you will need to change the startup type for the DataMiner CloudGateway service from _Disabled_ to _Automatic_ again and start the service manually. 

Disconnecting your system for a longer period of time might lead to your Cloud session becoming invalid. When this happens you will need to manually renew the connection by going to _System center > Cloud_ in Cube and clicking the renew button.
