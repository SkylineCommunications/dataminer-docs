---
uid: Upgrading_a_DataMiner_Agent
---

# Upgrading a DataMiner Agent

> [!TIP]
> For more information on DataMiner upgrades, check out the following videos on Dojo:
>
> - [Rui's Rapid Recap – DataMiner Upgrade](https://community.dataminer.services/video/ruis-rapid-recap-dataminer-upgrade/) ![Video](~/user-guide/images/video_Duo.png)
> - [Agents – Upgrading a DataMiner System](https://community.dataminer.services/video/agents-upgrading-a-dataminer-system/) ![Video](~/user-guide/images/video_Duo.png)

## Before you upgrade

> [!IMPORTANT]
>
> - Make sure your system meets the necessary [**system requirements**](xref:DataMiner_Compute_Requirements). Among others, upgrading to the **latest .NET version** is highly recommended.
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

## Other types of upgrades

The DataMiner platform consists of many components (core processes, DataMiner Extension Modules (DxMs), web API, web apps, etc.). While the sections above are related to a standard DataMiner upgrade, which includes most of these components, some components can be upgraded separately.

A standard DataMiner upgrade updates the core processes, DataMiner Cube, the web API, web apps, and potentially also some DxMs (depending on the DataMiner version). As this is a big upgrade, this can take some time to execute, which entails downtime of the DataMiner System. If you only want to have the latest version of a specific component, it can therefore be useful to upgrade this separately.

The following other types of upgrades exist:

- **DataMiner web upgrades**: These include only the web API and the web apps. This way you get access to the latest features and enhancements of the web apps, without having to do a DataMiner upgrade. DataMiner web upgrades are available from DataMiner 10.3.0/10.3.3 onwards and typically take about 1 minute to install. All other DataMiner processes remain untouched.

  > [!NOTE]
  >
  > - Executing a DataMiner upgrade will override any DataMiner web upgrades that have been performed in the past.
  > - New web functionality that depends on new features in the core processes will not be available until you have also upgraded the core software. For example, GQI is part of the core DataMiner software, so new GQI features will only become available with a full DataMiner upgrade.

  > [!TIP]
  > You can download the latest web upgrade package on [DataMiner Dojo](https://community.dataminer.services/dataminer-web-upgrade-packages/).

- **DxM upgrades**: [DataMiner Extension Modules (DxMs)](xref:DataMinerExtensionModules) can be updated independently in the [Admin app](https://admin.dataminer.services).

- **DataMiner Cube upgrades**: DataMiner Cube can automatically update to a more recent version (see [Managing client versions](xref:DMA_configuration_related_to_client_applications#managing-client-versions)).
