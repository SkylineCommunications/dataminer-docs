---
uid: Data_Aggregator_install_setup
---

# Data Aggregator installation and setup

Data Aggregator does not necessarily have to be installed on a server running a DataMiner Agent. You can also install it on a standalone server.

## Prerequisites

- [DataMiner Cloud Pack](xref:DataMiner_Cloud_Pack) 2.8.4 or higher must be installed on the server where you want to install Data Aggregator.

- The [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) hosting bundle must be installed on the server where you want to install Data Aggregator.

- DataMiner 10.2.12 or higher must be installed on the DataMiner Agents you want to use Data Aggregator with.

  > [!NOTE]
  > If you want to use queries with [ad hoc data sources](xref:Get_ad_hoc_data), you will need DataMiner 10.3.3/10.4.0 or higher.

- Depending on the [`UseGQIDxM`](xref:Data_Aggregator_settings#using-the-gqi-dxm-for-queries) setting, either:

  - The [GQI DxM](xref:GQI_DxM) (included in DataMiner 10.5.0 [CU1]/10.5.4) must be installed on the DataMiner Agents you want to use Data Aggregator with.

  - CoreGateway 2.12.0 or higher (included in Cloud Pack 2.8.4) must be installed on the DataMiner Agents you want to use Data Aggregator with. To install this DxM, you can use the [DataMiner Cloud Pack](xref:DataMiner_Cloud_Pack). The DMAs do not have to be connected to dataminer.services.

## Installing Data Aggregator

1. Open the Admin app. See [Accessing the Admin app](xref:Accessing_the_Admin_app).

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *DxMs* page.

1. Next to *DataMiner DataAggregator*, select to install this DxM.

## Configuring the Data Aggregator settings

1. Open the folder `C:\Program Files\Skyline Communications\DataMiner DataAggregator`.

1. Create a new file named *appsettings.custom.json* in this folder.

   This is the file in which you will be able to customize the default configuration from *appsettings.json*. The settings configured in *appsettings.json* will be merged together with the settings configured in *appsettings.custom.json* and these merged settings will be applied by Data Aggregator.

   > [!NOTE]
   > Do not make changes to the existing *appsettings.json* file, as this file get overwritten during updates.

1. Configure the necessary settings. See [Data Aggregator settings](xref:Data_Aggregator_settings).

1. Restart the *DataMiner DataAggregator* service (e.g., using Windows Task Manager).

> [!NOTE]
> By default, a log file for Data Aggregator is stored in `C:\ProgramData\Skyline Communications\DataMiner DataAggregator\Logs`. In case the *DataAggregator* service does not start, the log file will contain more information.

## Updating Data Aggregator

- From DataMiner 10.5.9/10.6.0 onwards<!--RN 43334-->, Data Aggregator is included in DataMiner upgrade packages. **Updates occur automatically** during a DataMiner upgrade.

  However, the DxM will only be upgraded if an older version is already installed on the DMA. If no older version is found, it will not be installed.

- Alternatively, you can **manually update** Data Aggregator [via the dataminer.services Admin app](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

  > [!NOTE]
  > When upgrading the Data Aggregator module from version 2.x.x to 3.0.0 or higher, and if your prior installation included configured GQI queries, a one-time migration process using a [Data Aggregator Migrator](xref:Data_Aggregator_Migrators#upgrading-from-version-2xx) is necessary.
