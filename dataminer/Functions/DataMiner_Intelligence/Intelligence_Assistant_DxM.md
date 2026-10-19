---
uid: Intelligence_Assistant_DxM
keywords: DataMiner Copilot
description: "Learn about the DataMiner Assistant DxM, which provides conversational AI in DataMiner, for example in the Assistant app and the Document Intelligence API."
---

# DataMiner Assistant DxM

DataMiner Intelligence makes use of the DataMiner Assistant DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)), which provides conversational AI in DataMiner.

The DxM is used for the [DataMiner Assistant app](xref:Intelligence_Assistant_app), the [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365), the [natural language to GQI](xref:Intelligence_NL2GQI) feature, and the [Document Intelligence](xref:docintel) feature.

## Installation

DataMiner Assistant is included in DataMiner web upgrade packages, but it is not activated automatically:

- On [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud) systems, the DataMiner Assistant DxM is enabled by default.
- On on-premises systems, you need to install the DxM initially to activate it. To do so, run the DataMiner Assistant MSI installer from the folder `C:\Skyline DataMiner\Tools\ModuleInstallers\Web` on the DataMiner Agent. Local installers for DataMiner 10.6.x or newer include the DataMiner Assistant DxM by default.

Once it has been installed, DataMiner Assistant is upgraded automatically when you install DataMiner upgrades. From DataMiner 10.5.7/10.6.0 onwards, it is upgraded with full DataMiner upgrade packages.<!-- RN 42896 --> Starting from DataMiner 10.6.0 [CU7]/10.6.2, it is sufficient to install a web upgrade instead of a full DataMiner upgrade.<!-- RN 44291 -->

If you are still running a version of the DxM prior to version 2.0.0 (when the DxM was still called "Copilot"), you will need to install DataMiner Assistant manually. After that, automatic upgrades will resume.

For DataMiner Assistant to run correctly, the following **prerequisites** must be met:

- **Connection to dataminer.services**: The DataMiner System [must be connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- **GQI**: For the "natural language to GQI" feature to work, the [GQI DxM](xref:GQI_DxM) needs to be installed.
- **No Failover**: For [script tools](xref:Intelligence_Assistant_ScriptTools) to work, the DxM must not be installed on DataMiner Agents that are part of a Failover pair. See [Limitation for Failover setups](xref:Intelligence_Assistant_ScriptTools#limitation-for-failover-setups).

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Assistant\Logs` folder.

This folder stores a maximum of two log files. A new log file is created when the current file exceeds a predefined size. If the folder already contains two log files, the oldest will be removed to make room for the new one.
