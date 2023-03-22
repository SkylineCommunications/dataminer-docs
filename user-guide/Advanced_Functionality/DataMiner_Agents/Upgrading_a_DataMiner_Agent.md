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
> To ensure a successful upgrade of your DMA, see [Preparing to upgrade a DataMiner Agent](xref:Preparing_to_upgrade_a_DataMiner_Agent).

Make sure your system meets the necessary [system requirements](https://community.dataminer.services/dataminer-compute-requirements/). Among others, upgrading to the **latest .NET version** is highly recommended.

> [!NOTE]
> From DataMiner 10.3.3/10.4.0 onwards, during a DataMiner upgrade, Microsoft .NET 6.0 will be installed if this was not installed on your system already. <!-- RN 35363 --> Note that this will require a reboot during the upgrade.

Keep in mind that it is strongly recommended that you **use the same version of DataMiner on all Agents in a DMS**.

> [!IMPORTANT]
> In the case you are not upgrading to the DataMiner version that immediately follows your current version, follow the provided [upgrade paths](xref:Upgrade_Paths).

> [!NOTE]
>
> - You can [configure the default options](xref:Configuring_the_default_upgrade_options) for upgrades in System Center.
> - Each upgrade creates a folder under *C:\\Skyline DataMiner\\Upgrades\\Packages*, which contains the upgrade package that has been used, together with a log file (progress.log) and (prior to DataMiner 10.0.0/10.0.3) the rollback package. From DataMiner 10.0.3 onwards, a rollback package is no longer included, as it is better to downgrade by using the full installation package of the version you want to go back to instead.
> - DMPs can be upgraded in System Center like regular DMAs, though additional options will be available in the upgrade window. If the DMP is not ready for an upgrade, or no connection can be established, by default after 10 seconds a warning will appear.

## Upgrading a DataMiner Agent in the Update Center

It is possible to upgrade or update a DMA via the Update Center within DataMiner Cube.

For detailed steps, go to [Upgrading a DataMiner Agent in the Update Center](xref:Upgrading_a_DataMiner_Agent_in_the_Update_Center).

Note that this is not recommended for an upgrade to a major DataMiner version that is several versions higher than the current version, e.g. from 9.6 to 10.3. In that case, use the Taskbar Utility or System Center and upgrade to one major version at a time, as mentioned above.

## Upgrading a DataMiner Agent using DataMiner Taskbar Utility

If you intend to upgrade your DMS directly from one of your DMAs, and you have downloaded the necessary upgrade package(s) from the [DataMiner Software](https://community.dataminer.services/downloads/) page, you can use DataMiner Taskbar Utility.

For detailed steps, go to [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility).

## Upgrading a DataMiner Agent in System Center

You can also start an upgrade from the Agents page in DataMiner Cube’s System Center. You will need to download the necessary upgrade package(s) from the [DataMiner Software](https://community.dataminer.services/downloads/) page to do so.

For detailed steps, go to [Upgrading a DataMiner Agent in System Center](xref:Upgrading_a_DataMiner_Agent_in_System_Center).

## Upgrade BPA test

From DataMiner 9.6.0 \[CU24\]/10.0.0 \[CU16\]/10.1.0 \[CU5\]/10.1.8 onwards, if a **BPA test** is available to check if the system meets the requirements to upgrade to the target version, this test will run before the upgrade is started. If the test fails, the upgrade will be canceled.

Though this is not recommended, you can bypass this check by manually removing the *Prerequisites* folder from *Update.zip* in the upgrade package.

> [!TIP]
> For more information about BPA tests, see [Running BPA tests](xref:Running_BPA_tests) and [Preparing to upgrade a DataMiner Agent](xref:Preparing_to_upgrade_a_DataMiner_Agent#prerequisites).
