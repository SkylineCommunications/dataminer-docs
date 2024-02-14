---
uid: Installing_a_DataMiner_Agent
---

# Installing a self-hosted DataMiner Agent

If you want to take care of hosting your DataMiner System yourself, you can manually install the DataMiner Agents instead of [creating the DMS in the cloud](xref:Creating_a_DMS_in_the_cloud).

> [!IMPORTANT]
> The server onto which you plan to install the DataMiner Agent software has to comply with the DataMiner system requirements. See [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

To manually install a DataMiner Agent, you will need to [use the DataMiner Installer](xref:Installing_DM_using_the_DM_installer). Afterwards, you will need to [upgrade to the latest feature or main release version](xref:Upgrading_a_DataMiner_Agent), [connect your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), and either deploy [Storage as a Service](xref:STaaS) to make use of cloud-native storage hosted by Skyline or, if you wish to host the DataMiner storage yourself, [configure the databases](xref:Configuring_dedicated_clustered_storage).

> [!NOTE]
> The DataMiner Installer is available on the [DataMiner software](https://community.dataminer.services/downloads/) page on DataMiner Dojo. Note that the 10.2.0 installer does not support 32-bit systems, MySQL installation, and unattended installation of a cluster.

> [!TIP]
> Do you already have a self-hosted DataMiner System that you want to connect to dataminer.services? Go to [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) for more info.
