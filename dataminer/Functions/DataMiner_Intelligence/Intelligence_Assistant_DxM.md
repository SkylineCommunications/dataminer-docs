---
uid: Intelligence_Assistant_DxM
keywords: DataMiner Copilot
description: "Learn about the DataMiner Assistant DxM, which provides conversational AI in DataMiner, for example in the Assistant app and the Document Intelligence API."
---

# DataMiner Assistant DxM

DataMiner Intelligence makes use of the DataMiner Assistant DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)), which provides the AI capabilities in DataMiner.

## Installation

DataMiner Assistant is included in DataMiner web upgrade packages, but it is not activated automatically in all systems:

- On [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud) systems, the DataMiner Assistant DxM is enabled by default.
- On on-premises systems, you need to install the DxM initially to activate it. To do so, run the DataMiner Assistant MSI installer from the folder `C:\Skyline DataMiner\Tools\ModuleInstallers\Web` on the DataMiner Agent. Local installers for DataMiner 10.6.x or newer include the DataMiner Assistant DxM by default.

Once it has been installed, DataMiner Assistant is upgraded automatically when you install DataMiner upgrades. From DataMiner 10.5.7/10.6.0 onwards, it is upgraded with full DataMiner upgrade packages.<!-- RN 42896 --> Starting from DataMiner 10.6.0 [CU7]/10.6.2, it is sufficient to install a web upgrade instead of a full DataMiner upgrade.<!-- RN 44291 -->

For DataMiner Assistant to run correctly, the following **prerequisites** must be met:

- **Connection to dataminer.services**: The DataMiner System [must be connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- **GQI**: For the "natural language to GQI" feature to work, the [GQI DxM](xref:GQI_DxM) needs to be installed.

- **No Failover**: The DxM is not supported on DataMiner Agents that are part of a Failover pair.

   If you currently have Failover Agents, we recommend one of the following approaches:

  - Move away from Failover and use [Swarming](xref:Swarming) instead.
  - Add one or more DataMiner Agents that are not part of a Failover pair to your DataMiner System, and install the DataMiner Assistant DxM on those Agents.

    > [!TIP]
    > To request a free license for such a DataMiner Agent, contact the Skyline Sales department at [sales@skyline.be](mailto:sales@skyline.be).

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Assistant\Logs` folder.

This folder stores a maximum of two log files. A new log file is created when the current file exceeds a predefined size. If the folder already contains two log files, the oldest will be removed to make room for the new one.
