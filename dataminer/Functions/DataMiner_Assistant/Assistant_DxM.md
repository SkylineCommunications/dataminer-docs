---
uid: Assistant_DxM
keywords: DataMiner Copilot
description: "Learn about the DataMiner Assistant DxM, which provides conversational AI in DataMiner, for example in the Assistant app and the Document Intelligence API."
---

# DataMiner Assistant DxM

DataMiner Intelligence makes use of the DataMiner Assistant DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)), which provides conversational AI in DataMiner.

The initial 1.0.0 version only supports the [natural language to GQI](xref:NL2GQI) feature. Starting from version 2.0.7, the [Document Intelligence](xref:docintel) feature is also supported.

A [DataMiner Assistant app](xref:DataMinerAssistant) is also currently being developed. You can preview it in DataMiner upon request. In addition, a [DataMiner Assistant for Microsoft 365](xref:Assistant_M365) is available on the Microsoft Marketplace, which has features similar to the Assistant app but allows direct access from Microsoft Teams or Microsoft Copilot.

## Installation

DataMiner Assistant is currently not included in DataMiner upgrade packages and [needs to be deployed separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).

Once it has been deployed, DataMiner Assistant is upgraded when you install DataMiner upgrades from DataMiner 10.5.7/10.6.0 onwards.<!-- RN 42896 --> Starting from DataMiner 10.6.0 [CU7]/10.6.2, it is sufficient to install a web upgrade instead of a full DataMiner upgrade.<!-- RN 44291 -->

To upgrade to version 2.0.0 (which involves a name change of the DxM, as previously it was called "Copilot"), you will need to install DataMiner Assistant manually, even if the Copilot DxM was already installed. After that, automatic upgrades will resume.

For DataMiner Assistant to run correctly, the following **prerequisites** must be met:

- **Connection to dataminer.services**: The DataMiner System [must be connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- **GQI**: For the "natural language to GQI" feature to work, the [GQI DxM](xref:GQI_DxM) needs to be installed.

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Assistant\Logs` folder.

This folder stores a maximum of two log files. A new log file is created when the current file exceeds a predefined size. If the folder already contains two log files, the oldest will be removed to make room for the new one.
