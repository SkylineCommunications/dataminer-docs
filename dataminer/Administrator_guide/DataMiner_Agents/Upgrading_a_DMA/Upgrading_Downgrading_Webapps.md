---
uid: Upgrading_Downgrading_Webapps
---

# Upgrading the DataMiner web apps

From DataMiner 10.3.0/10.3.3 onwards, DataMiner web upgrades are **available separately from the general DataMiner upgrades**. These updates include only the web API and the web apps, leaving all other DataMiner processes untouched. This way you can get access to the latest features and enhancements of the web apps without having to do a full DataMiner upgrade. The web upgrades only require a brief installation and do not necessitate a DataMiner restart, ensuring uninterrupted monitoring and orchestration.

Starting from DataMiner 10.4.0, every **cumulative update of a Main Release includes the same web apps changes as the corresponding DataMiner Feature Release**. For example, all DataMiner web apps changes from Feature Release 10.5.4 are also available in Main Release 10.4.0 (CU13) and 10.5 (CU1). This means that if you are on the Main Release track, you can simply install the latest web upgrade package without having to check for a separate Main Release or Feature Release package. <!-- It also means that if you for example build a low-code app using the latest DataMiner Feature Release, your app will also be compatible with the latest Main Release cumulative updates. (This comment can be published once GQI DxM becomes the default in a 10.5.x Feature Release, as backwards compatibility will apply from DataMiner 10.5.0 onwards.) -->

Note that it is not possible to upgrade the web apps to a DataMiner 10.5.x version or higher if the DataMiner Agent itself is still running a DataMiner version older than 10.4.0/10.4.1. **To install a 10.5.x web upgrade, the server must first be upgraded to at least version 10.4.0**.<!--RN 41395-->

> [!NOTE]
>
> - Executing a DataMiner upgrade will override any DataMiner web upgrades that have been performed in the past.
> - New web functionality that depends on new features in the core processes will not be available until you have also upgraded the core software.
> - **All Agents within a cluster must run the same version** of the web apps. When you upgrade the web apps, you should therefore make sure the upgrade is applied to every Agent in the cluster.
> - Web upgrades also update the [GQI DxM](xref:GQI_DxM) (since 10.5.2) and [Web DcM](xref:DataMinerExtensionModules#web) (since 10.5.11).

> [!TIP]
> You can download the latest web upgrade package on [DataMiner Dojo](https://community.dataminer.services/dataminer-web-upgrade-packages/).

## Automatic backup

From DataMiner 10.3.11/10.3.0 [CU8] onwards<!--RN 37413-->, whenever you [upgrade your DMA](xref:Upgrading_a_DataMiner_Agent) or install a DataMiner web upgrade, an automatic backup of all existing dashboards and low-code apps on the system is generated and stored in `C:\Skyline DataMiner\System Cache\Web\Backups`.

From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43906-->, the backup includes up to two versions per low-code app:

- The latest published version

- The most recent draft

Prior to this, the backup includes all versions of each app. The [version history](xref:LowCodeApps_earlier_version) itself is left untouched.

After the upgrade process, your dashboards and low-code apps may be migrated to ensure compatibility with the updated software version. If an error occurs during this migration, or if you need to perform a DataMiner downgrade, you can manually restore your dashboards and low-code apps from the backup.

> [!NOTE]
>
> - The *Backups* folder retains only the five most recent backup files.
> - From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43906-->, only apps with a valid *App.info.json* file will be included in the automatic backup. When the file is not present or invalid, or if the published and draft versions are set to null in the file, the app will not be included in the backup.

## Downgrading the DataMiner web apps

Since dashboards and low-code apps can automatically get migrated after a software upgrade, these will then no longer work in combination with older versions of the software.

To deal with this, after a downgrade, follow the steps below:

1. Optionally, create a copy of the current files in `C:\Skyline DataMiner\Applications` and `C:\Skyline DataMiner\Dashboards`.
1. Go to `C:\Skyline DataMiner\System Cache\Web\Backups` and locate the most recent zip package (or the zip package that originally got created on the version you have now downgraded to).
1. Extract this zip package in `C:\Skyline DataMiner` and let it replace the files in the *Applications* and *Dashboards* folders.
1. Do the same on every DMA in cluster.

> [!NOTE]
>
> - Any changes that have been done on the dashboards and low-code apps after the backup was created will be lost.
> - New web functionality that depends on new features in the core processes will no longer be available.
