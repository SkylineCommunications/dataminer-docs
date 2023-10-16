---
uid: Disconnecting_from_dataminer.services
---

# Disconnecting from dataminer.services

Though this is not recommended, once a DataMiner Agent has been connected to dataminer.services, it is possible to disconnect it again.

> [!WARNING]
> Disconnecting a DataMiner System from dataminer.services will result in the **loss of all data for that DataMiner System on dataminer.services**. This action is **irreversible** and can have far-reaching consequences:
>
> - Skyline Communications will no longer be able to provide [CCA Support Services](xref:CCA_Support_Services) for your DMS.
> - All data for the DMS that was saved on dataminer.services will be lost, including shares, settings, and users and permissions configured on dataminer.services.
> - If your DMS consists of one or more fully self-hosted DataMiner Agents, these will continue to work, but you will no longer have access to dataminer.services features.
> - If your DMS uses **DataMiner as a Service** (DaaS), the **entire DataMiner System will be removed**.
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
