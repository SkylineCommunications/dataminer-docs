---
uid: Scripted_Connectors
---

# Scripted connectors

> [!IMPORTANT]
> At present, scripted connectors are only available in preview, if the [DataAPI](xref:Overview_of_Soft_Launch_Options#dataapi) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Scripted connectors are executed by the *DataAggregator* DxM, operating independently from DataMiner. To use scripted connectors, Data Aggregator must be installed on the same server as DataMiner.

> [!TIP]
> See [Installing the necessary DxMs](xref:Data_Sources_Setup#installing-the-necessary-dxms).

Consequently, the scripts are stored on the same machine as DataMiner. The execution of scripted connectors is carried out separately from any other DataMiner processes.

Once added, scripted connectors operate at regular intervals, running every minute.

These connectors can be written in PowerShell and Python. Data Aggregator is equipped with Python 3.12.0, and in the event that a scripted connector requires additional Python packages, you can [install extra Python packages](xref:Data_Sources_Setup#installing-extra-python-packages).

The scripts transmit JSON data through a local HTTP call to the [Data API](xref:Data_API).
