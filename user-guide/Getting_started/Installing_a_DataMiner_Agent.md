---
uid: Installing_a_DataMiner_Agent
description: Use the DataMiner Installer and then upgrade to the latest feature or main release, connect to dataminer.services, and set up data storage.
---

# Installing a self-hosted DataMiner Agent

If you want to take care of hosting your DataMiner System yourself, you can manually install the DataMiner Agents instead of [creating the DMS in the cloud](xref:Creating_a_DMS_in_the_cloud).

> [!IMPORTANT]
>
> - The server onto which you plan to install the DataMiner Agent software has to comply with the DataMiner system requirements. See [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).
> - Avoid using duplicates of existing VMs to install a new DataMiner machine. Using cloned VMs can cause certain configurations from the previous DataMiner machine to linger and cause conflicts in the system.

To manually install a DataMiner Agent, you can either use the [DataMiner Installer](xref:Installing_DM_using_the_DM_installer) or use a [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk).

If you have experience with virtualization and would like to have DataMiner in a virtualized environment, use the virtual hard disk option. In case you want to install DataMiner on a server, use the DataMiner installer.
