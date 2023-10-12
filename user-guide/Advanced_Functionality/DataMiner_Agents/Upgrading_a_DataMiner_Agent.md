---
uid: Upgrading_a_DataMiner_Agent
---

# Upgrading a DataMiner Agent

> [!TIP]
> For more information on DataMiner upgrades, check out the following videos on Dojo:
>
> - [Rui's Rapid Recap – DataMiner Upgrade](https://community.dataminer.services/video/ruis-rapid-recap-dataminer-upgrade/)
> - [Agents – Upgrading a DataMiner System](https://community.dataminer.services/video/agents-upgrading-a-dataminer-system/)

## Before you upgrade

> [!IMPORTANT]
>
> - Make sure your system meets the necessary [**system requirements**](https://community.dataminer.services/dataminer-compute-requirements/). Among others, upgrading to the **latest .NET version** is highly recommended.
> - To ensure a successful upgrade of your DMA, see [**Preparing to upgrade a DataMiner Agent**](xref:Preparing_to_upgrade_a_DataMiner_Agent).
> - In case you are not upgrading to the DataMiner version that immediately follows your current version, follow the provided [**upgrade paths**](xref:Upgrade_Paths).
> - It is strongly recommended that you **use the same version of DataMiner on all Agents in a DMS**.

> [!NOTE]
>
> - You can [configure the default options](xref:Configuring_the_default_upgrade_options) for upgrades in System Center.
> - DMPs can be upgraded in System Center like regular DMAs, though additional options will be available in the upgrade window. If the DMP is not ready for an upgrade, or no connection can be established, by default after 10 seconds a warning will appear.

## Upgrading a DataMiner Agent in the Update Center

It is possible to upgrade or update a DMA via the Update Center within DataMiner Cube.

For detailed steps, go to [Upgrading a DataMiner Agent in the Update Center](xref:Upgrading_a_DataMiner_Agent_in_the_Update_Center).

Note that this is not recommended for an upgrade to a major DataMiner version that is several versions higher than the current version, e.g. from 9.6 to 10.3. In that case, use the Taskbar Utility or System Center and refer to our [upgrade paths](xref:Upgrade_Paths).

## Upgrading a DataMiner Agent using DataMiner Taskbar Utility

If you intend to upgrade your DMS directly from one of your DMAs, and you have downloaded the necessary upgrade package(s) from the [DataMiner Software](https://community.dataminer.services/downloads/) page, you can use DataMiner Taskbar Utility.

For detailed steps, go to [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility).

## Upgrading a DataMiner Agent in System Center

You can also start an upgrade from the Agents page in DataMiner Cube’s System Center. You will need to download the necessary upgrade package(s) from the [DataMiner Software](https://community.dataminer.services/downloads/) page to do so.

For detailed steps, go to [Upgrading a DataMiner Agent in System Center](xref:Upgrading_a_DataMiner_Agent_in_System_Center).

***
