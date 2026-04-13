---
uid: Installing_a_DataMiner_Agent
description: Use the DataMiner Installer and then upgrade to the latest feature or main release, connect to dataminer.services, and set up data storage.
---

# Installing a self-managed DataMiner Agent

If you want to take care of hosting and managing your DataMiner System yourself, there are two ways you can install the DataMiner Agents:

- [Using the DataMiner Installer](xref:Installing_DM_using_the_DM_installer).
- [Deploying a virtual hard disk with DataMiner pre-installed](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk).

The table below outlines the main differences between these installation methods.

| [DataMiner Installer](xref:Installing_DM_using_the_DM_installer) | [Pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk) |
| -- | -- |
| Allows installation on an existing machine. | Requires a new VM. |
| Storage options:<br>- [StaaS](xref:STaaS) (recommended)<br>- Self-managed storage with [dedicated clustered storage setup](xref:Configuring_dedicated_clustered_storage) (requires expert knowledge) | Storage options:<br>- [StaaS](xref:STaaS) (recommended)<br>- Self-managed storage with [dedicated clustered storage setup](xref:Configuring_dedicated_clustered_storage) (requires expert knowledge)<br>- Self-managed storage deployed on the same Windows machine (for small-scale setups only) |

> [!NOTE]
> By default, a DataMiner System is deployed with a **Community Edition license**. For information on pricing and limitations for this license, see [DataMiner Community Edition](xref:Pricing_Commercial_Models#dataminer-community-edition).
