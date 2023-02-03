---
uid: Data_Aggregator_install_setup
---

# Data Aggregator installation and setup

The Data Aggregator DxM does not necessarily have to be installed on a server running a DataMiner Agent. You can also install it on a standalone server.

## Prerequisites

- DataMiner 10.2.12 or higher must be installed on the DataMiner Agents you want to use Data Aggregator with.

- The CoreGateway DxM must be installed on the DataMiner Agents you want to use Data Aggregator with. To install this DxM, you can use the [DataMiner Cloud Pack](xref:CloudPackages). The DMAs do not have to be connected to dataminer.services.

## Installing the Data Aggregator DxM

Download the installation package for the Data Aggregator DxM from the [Dojo Downloads page](https://community.dataminer.services/downloads/) and install it. <!-- TBD: is package available already? -->

## Configuring the Data Aggregator settings

1. Open the folder `C:\Program Files\Skyline Communications\DataMiner DataAggregator`.

1. Create a new file named *appsettings.custom.json*.

   This is the file in which you will be able to customize the default configuration from *appsettings.json*. The settings configured in *appsettings.json* will be merged together with the settings configured in *appsettings.custom.json* and these merged settings will be applied by Data Aggregator.

   > [!NOTE]
   > Do not make changes to the existing *appsettings.json* file, as this file get overwritten during updates.

1. Configure the necessary settings. See [Data Aggregator settings]().

1. Restart the *DataAggregator* service (e.g. using Windows Task Manager).

> [!NOTE]
> By default, a log file for Data Aggregator is stored in `C:\ProgramData\Skyline Communications\DataMiner DataAggregator\Logs`. In case the *DataAggregator* service does not start, the log file will contain more information.
