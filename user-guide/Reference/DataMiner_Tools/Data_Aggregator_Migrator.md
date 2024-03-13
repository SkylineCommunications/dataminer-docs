---
uid: Data_Aggregator_Migrator
---

# Data Aggregator Migrator

The Data Aggregator Migrator should be used after upgrading the Data Aggregator module from version 2.x.x to 3.0.0 or higher. This **one-time migration process** is only necessary if the prior installation included [configured GQI queries](xref:Data_Aggregator_queries).

> You can download the tool from [DataMiner Dojo](https://community.dataminer.services/download/data-aggregator-migrator/).

> [!TIP]
> See also: [Data Aggregator](xref:Data_Aggregator_DxM)

> [!NOTE]
> This tool should be used after upgrading the DataAggregator DxM from 2.x.x to 3.x.x or higher.

## Using the Data Aggregator Migrator

1. Install the Data Aggregator Migrator on a DMA.

1. After downloading the files, extract them to a local folder, and place them on the server hosting Data Aggregator.

1. Use the migration tool with the following options:

   | Option | Description |
   |--|--|
   | -i | File location of `appsettings.custom.json` (typically `C:\Program Files\Skyline Communications\DataMiner DataAggregator\appsettings.custom.json`) |
   | -o | Use when another URL is configured in `appsettings.custom.json` (e.g. `https://10.10.15.32:22345`) |

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
