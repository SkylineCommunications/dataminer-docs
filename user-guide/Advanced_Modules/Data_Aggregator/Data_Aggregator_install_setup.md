---
uid: Data_Aggregator_install_setup
---

# Data Aggregator installation and setup

Data Aggregator does not necessarily have to be installed on a server running a DataMiner Agent. You can also install it on a standalone server.

## Prerequisites

- [DataMiner Cloud Pack](xref:CloudPackages) 2.8.4 or higher must be installed on the server where you want to install Data Aggregator.

- DataMiner 10.2.12 or higher must be installed on the DataMiner Agents you want to use Data Aggregator with.

  > [!NOTE]
  > If you want to use queries with [ad hoc data sources](xref:Get_ad_hoc_data), you will need DataMiner 10.3.3/10.4.0 or higher.

- CoreGateway 2.12.0 or higher (included in Cloud Pack 2.8.4) must be installed on the DataMiner Agents you want to use Data Aggregator with. To install this DxM, you can use the [DataMiner Cloud Pack](xref:CloudPackages). The DMAs do not have to be connected to dataminer.services.

## Installing Data Aggregator

1. Open the Admin app. See [Accessing the Admin app](xref:Accessing_the_Admin_app).

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Nodes* page.

1. Next to *DataMiner DataAggregator*, select to install this DxM.

## Configuring the Data Aggregator settings

1. Open the folder `C:\Program Files\Skyline Communications\DataMiner DataAggregator`.

1. Create a new file named *appsettings.custom.json* in this folder.

   This is the file in which you will be able to customize the default configuration from *appsettings.json*. The settings configured in *appsettings.json* will be merged together with the settings configured in *appsettings.custom.json* and these merged settings will be applied by Data Aggregator.

   > [!NOTE]
   > Do not make changes to the existing *appsettings.json* file, as this file get overwritten during updates.

1. Configure the necessary settings. See [Data Aggregator settings](xref:Data_Aggregator_settings).

1. Restart the *DataMiner DataAggregator* service (e.g. using Windows Task Manager).

> [!NOTE]
> By default, a log file for Data Aggregator is stored in `C:\ProgramData\Skyline Communications\DataMiner DataAggregator\Logs`. In case the *DataAggregator* service does not start, the log file will contain more information.
