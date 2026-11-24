---
uid: Data_Aggregator_Migrators
description: "Migrate Data Aggregator queries to the GQI DxM during installation or with the migrator tools, and restore a legacy setup."
---

# Data Aggregator migrators

Select the migrations that apply to your upgrade path and query configuration:

- [Upgrading from version 2.x.x](#upgrading-from-version-2xx)
- [Migrating queries to the GQI DxM format](#migrating-queries-to-the-gqi-dxm-format)
  - [Automatic migration from Data Aggregator 3.4.0 onwards](#automatic-migration-from-data-aggregator-340-onwards)
    - [Reverting an automatic migration](#reverting-an-automatic-migration)
  - [Manual migration in Data Aggregator 3.1.0 to 3.3.0](#manual-migration-in-data-aggregator-310-to-330)
    - [Reverting a manual migration](#reverting-a-manual-migration)

> [!TIP]
> For details on the GQI DxM and its query setting, see [Data Aggregator](xref:Data_Aggregator_DxM) and [Data Aggregator settings](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries).

## Upgrading from version 2.x.x

The Data Aggregator Migrator should be used **after** upgrading the Data Aggregator DxM from version **2.x.x to 3.x.x** or higher. This **one-time migration process** is only necessary if the prior installation included [configured GQI queries](xref:Data_Aggregator_queries).

> [!TIP]
> You can download the tool from [DataMiner Dojo](https://community.dataminer.services/download/data-aggregator-migrator/).

1. Install the Data Aggregator Migrator on a DMA.

1. After downloading the files, extract them to a local folder, and place them on the server hosting Data Aggregator.

1. Use the migration tool with the following options:

   | Option | Description |
   |--|--|
   | -i | File location of `appsettings.custom.json` (typically `C:\Program Files\Skyline Communications\DataMiner DataAggregator\appsettings.custom.json`) |
   | -o | Use when another URL is configured in `appsettings.custom.json` (e.g., `https://10.10.15.32:22345`) |

   - If there is no specific URL configured in the *appsettings.custom.json* file, execute this command to perform the one-time migration:

     ```powershell
     .\"DataMiner DataAggregator.Migrator.exe"  -i "C:\Program Files\Skyline Communications\DataMiner DataAggregator\appsettings.custom.json"
     ```

   - If one or more specific URLs are configured in the *appsettings.custom.json* file, execute this command to perform the one-time migration:

     ```powershell
     .\"DataMiner DataAggregator.Migrator.exe"  -i "C:\Program Files\Skyline Communications\DataMiner DataAggregator\appsettings.custom.json" -o "https://10.10.15.32:22345/api/"
     ```

1. Verify the migration was successful:

   - The configuration of the queries from *appsettings.custom.json* is migrated to the *Helper.json* file located at `C:\Program Files\Skyline Communications\DataMiner DataAggregator\Data Sources`.

   - The JSON files containing the queries are present in `C:\Program Files\Skyline Communications\DataMiner DataAggregator\Data Sources\Scripted Connectors`.

1. If you upgraded directly to Data Aggregator 3.4.0 or later, run an [MSI repair](#automatic-migration-from-data-aggregator-340-onwards) to convert the imported queries. These are registered after installation and are not included in the initial migration.

## Migrating queries to the GQI DxM format

The migration method depends on your Data Aggregator version.

### Automatic migration from Data Aggregator 3.4.0 onwards

From Data Aggregator 3.4.0 onwards, the MSI installer migrates CoreGateway queries registered in *Helper.json* to the GQI DxM format during installation, upgrade, or repair. Queries already in GQI DxM format are left unchanged.<!-- RN 47072+47201 -->

The installer also removes `false` or `null` overrides for `QueryExecutorOptions:UseGQIDxM` from *appsettings.custom.json*. Modified configuration files may be reformatted and lose their comments; the originals are backed up.

If you add CoreGateway queries after installation, repair the installed Data Aggregator MSI to migrate them:

1. Open *Programs and Features* in Windows.

1. Select *DataMiner DataAggregator*.

1. Select *Repair*. If this option is unavailable, select *Change* and then *Repair* in the installer.

Each migration that modifies files has its own folder under `%ProgramData%\Skyline Communications\DataMiner DataAggregator\Migrations`. Its *Backups* subfolder contains the original versions of the modified files. Administrator permissions are required to access these files. If installation rolls back, Windows Installer attempts to restore them automatically.

For installation failures and incomplete migrations, see [Data Aggregator troubleshooting](xref:Data_Aggregator_troubleshooting#installation-upgrade-or-repair-fails-during-gqi-query-migration).

#### Reverting an automatic migration

If you need to switch back to using CoreGateway and SLHelper, you can restore the original query files from the migration backups and change the query executor. This affects all queries, not just those migrated.

> [!IMPORTANT]
> Before you revert the migration, make sure you can still use GQI via SLHelper on all target clusters. See [EndOfSupport.SLHelperGQI](xref:Overview_of_Soft_Launch_Options#endofsupportslhelpergqi).

> [!CAUTION]
> Restoring a backup overwrites any changes made to that file after the migration.

1. Stop the `DataMiner DataAggregator` service.

1. Back up the current `Data Sources` folder and *appsettings.custom.json* (if present) from the Data Aggregator installation folder.

1. In the `Migrations` directory mentioned above, identify the migration folders to restore. Each folder's *manifest.json* lists its migrated query IDs under `Sources`.

1. Copy the files from each folder's *Backups* subfolder back to the Data Aggregator installation folder, keeping the same folder structure. If you restore several migrations, copy them from oldest to newest based on the folder creation date, so that the most recent backup of each file is kept.

   > [!NOTE]
   > Use an elevated PowerShell or File Explorer session to copy the files. Do not change the permissions of the migration folders, as this can cause future installations, upgrades, or repairs to fail.

1. Make sure every query that will run uses the CoreGateway format, with `Contract` set to `0` or omitted in *Helper.json* (see [GQI queries](xref:Data_Aggregator_settings#gqi-queries)). After restoring several migrations, queries from older migrations may still have `Contract` set to `1`. Recreate or remove any queries that were added in GQI DxM format after the migration. See [Configuring GQI queries for Data Aggregator](xref:Data_Aggregator_queries#manual-configuration-for-earlier-dataminer-versions-or-advanced-scenarios).

1. In *appsettings.custom.json*, set `UseGQIDxM` to `false`, preserving other settings. Create the file in the installation folder if it does not exist, and update any existing override rather than adding a duplicate:

   ```json
   {
     "QueryExecutorOptions": {
       "UseGQIDxM": false
     }
   }
   ```

1. Start the `DataMiner DataAggregator` service.

1. Verify the restored queries and scheduled jobs.

> [!IMPORTANT]
> A later installation, upgrade, or repair applies the automatic migration again.

### Manual migration in Data Aggregator 3.1.0 to 3.3.0

In Data Aggregator 3.1.0 through 3.3.0, follow the procedure below to manually migrate existing CoreGateway queries when you enable the GQI DxM.

> [!NOTE]
> From Data Aggregator 3.4.0 onwards, existing query data sources are [automatically migrated](#automatic-migration-from-data-aggregator-340-onwards) during installation, upgrade, or repair, so this manual procedure is not needed.

1. Make sure Data Aggregator version 3.1.0 or higher is installed.

1. Enable the [UseGQIDxM](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries) setting.

1. Restart the `DataMiner DataAggregator` service.

1. Use the *MigratorToGQIDxM* tool, by executing the following command with Administrator permissions, with or without the options below:

   ```bat
   DataAggregator.MigratorToGQIDxM.exe
   ```

   | Option | Description |
   |--|--|
   | -u | Optional. To be used when another URL is configured in `appsettings.custom.json` (default: `http://localhost:12345`). |
   | -p | Optional. To be used when Data Aggregator is installed in a custom location (default: `C:\Program Files\Skyline Communications\DataMiner DataAggregator`). |

   > [!NOTE]
   > At present, this tool is only available on demand by sending a request to <support@dataminer.services>.

1. The output will confirm whether the migration succeeded.

#### Reverting a manual migration

The following instructions apply to manual migrations in Data Aggregator 3.1.0 through 3.3.0.

When you migrate the existing queries, a backup of the query files is created, so that it is possible to revert the migration if necessary.

To revert the GQI DxM migration:

1. Stop the `DataMiner DataAggregator` service.

1. Disable the [UseGQIDxM](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries) setting.

1. In `C:\Program Files\Skyline Communications\DataMiner DataAggregator`, replace the new `.json` files with their corresponding `.bak` file.

1. In `C:\Program Files\Skyline Communications\DataMiner DataAggregator\Helper.json` within the `DataSources` array, remove the `"Contract": 1` property on every item where it exists.

1. Start the `DataMiner DataAggregator` service.
