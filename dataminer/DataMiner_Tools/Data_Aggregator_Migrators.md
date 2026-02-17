---
uid: Data_Aggregator_Migrators
---

# Data Aggregator Migrators

Following migrators are available to make it easier to update existing setups to newer versions:

- [Enabling GQI DxM](#enabling-gqi-dxm)
- [Upgrading from version 2.x.x](#upgrading-from-version-2xx)

> [!TIP]
> See also: [Data Aggregator](xref:Data_Aggregator_DxM)

## Enabling GQI DxM

The Data Aggregator *MigratorToGQIDxM* tool should be used to migrate any existing queries into the format supported by the GQI DxM.

1. Make sure Data Aggregator version 3.1.0 or higher is installed.

1. Enable the [`UseGQIDxM`](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries) setting.

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

### Reverting the GQI DxM migration

When you migrate the existing queries, a backup of the query files is created, so that it is possible to revert the migration if necessary.

To revert the GQI DxM migration:

1. Stop the `DataMiner DataAggregator` service.

1. Disable the [`UseGQIDxM`](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries) setting.

1. In `C:\Program Files\Skyline Communications\DataMiner DataAggregator`, replace the new `.json` files with their corresponding `.bak` file.

1. In `C:\Program Files\Skyline Communications\DataMiner DataAggregator\Helper.json` within the `DataSources` array, remove the `"Contract": 1` property on every item where it exists.

1. Start the `DataMiner DataAggregator` service.

## Upgrading from version 2.x.x

The Data Aggregator Migrator should be used **after** upgrading the Data Aggregator DxM from version **2.x.x to 3.x.x** or higher. This **one-time migration process** is only necessary if the prior installation included [configured GQI queries](xref:Data_Aggregator_queries).

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

   - The configuration of the queries from *appsettings.custom.json* is migrated to the *Helper.json* file  located at `C:\Program Files\Skyline Communications\DataMiner DataAggregator\Data Sources.`

   - The JSON files containing the queries have been moved to `C:\Program Files\Skyline Communications\DataMiner DataAggregator\Data Sources\Scripted Connectors`.
