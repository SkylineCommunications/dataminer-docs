---
uid: Assistant_DxM
---

# DataMiner Assistant DxM

The DataMiner Assistant module is available as a DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)) and is responsible for bringing conversational AI into DataMiner.

The current 1.0.0 version only supports the [natural language to GQI](xref:NL2GQI) feature, but more features, such as the [DataMiner Assistant app](xref:DataMinerAssistant), will be added soon.

> [!NOTE]
> Prior to version 2.0.0, the DxM is called "Copilot".

## Installation

DataMiner Assistant is currently not included in DataMiner upgrade packages and [needs to be deployed separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node). However, once it has been deployed, it gets upgraded when you install DataMiner upgrades from DataMiner 10.5.7/10.6.0 onwards.<!-- RN 42896 -->

For DataMiner Assistant to run correctly, the following **prerequisites** must be met:

- **Connection to dataminer.services**: The DataMiner System [must be connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- **GQI**: For the "natural language to GQI" feature to work, the [GQI DxM](xref:GQI_DxM) needs to be installed.

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Assistant\Logs` folder. If this folder does not exist, it will be created automatically.

This folder will only store at most two log files. A new log file is created when the current file exceeds a predefined size. In case the folder already contains two log files, the oldest will be removed to make room for the new one.
