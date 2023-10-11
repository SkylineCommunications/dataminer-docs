---
uid: Upgrading_Downgrading_Webapps
---

# Upgrading and downgrading the DataMiner web apps

## DataMiner web upgrades

From DataMiner 10.3.0/10.3.3 onwards, DataMiner web upgrades are available. These updates include only the web API and the web apps, and typically take about 1 minute to install. This way you get access to the latest features and enhancements of the web apps, without having to do a DataMiner upgrade. All other DataMiner processes remain untouched.

> [!NOTE]
>
> - Executing a DataMiner upgrade will override any DataMiner web upgrades that have been performed in the past.
> - New web functionality that depends on new features in the core processes will not be available until you have also upgraded the core software. For example, GQI is part of the core DataMiner software, so new GQI features will only become available with a full DataMiner upgrade.

> [!TIP]
> You can download the latest web upgrade package on [DataMiner Dojo](https://community.dataminer.services/dataminer-web-upgrade-packages/).

## DataMiner web downgrades

From DataMiner 10.3.11/10.3.0 [CU8] onwards<!--RN 37413-->, whenever you [upgrade your DMA](xref:Upgrading_a_DataMiner_Agent) or install a DataMiner web upgrade, an automatic backup of all existing dashboards and low-code apps on the system is generated and stored in *C:\Skyline DataMiner\System Cache\Web\Backups*.

After the upgrade process, your dashboards and low-code apps may be migrated to ensure compatibility with the updated software version. If an error occurs during this migration, or if you need to perform a DataMiner downgrade, you can manually restore your dashboards and low-code apps from the backup.
