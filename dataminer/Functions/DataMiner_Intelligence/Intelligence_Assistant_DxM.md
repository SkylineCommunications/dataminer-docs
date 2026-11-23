---
uid: Intelligence_Assistant_DxM
keywords: DataMiner Copilot
description: "Learn how to install and upgrade the DataMiner Assistant DxM, which powers the Assistant app and Document Intelligence API."
---

# DataMiner Assistant DxM

DataMiner Intelligence makes use of the DataMiner Assistant DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)), which provides the AI capabilities in DataMiner.

## Installation

DataMiner Assistant is included in DataMiner web upgrade packages, but it is not activated automatically in all systems:

- On [DataMiner as a Service (DaaS)](xref:Creating_a_DMS_in_the_cloud) systems, the DataMiner Assistant DxM is enabled by default.

- On on-premises systems, you need to install the DxM initially to activate it. To do so, run the DataMiner Assistant MSI installer from the folder `C:\Skyline DataMiner\Tools\ModuleInstallers\Web` on the DataMiner Agent. Local installers for DataMiner 10.6.x or newer include the DataMiner Assistant DxM by default.

  You do not need to install the DataMiner Assistant DxM on every node in a DataMiner cluster. We recommend installing it on a few suitable Agents to provide redundancy.

Once it has been installed, DataMiner Assistant is upgraded automatically when you install DataMiner upgrades. From DataMiner 10.5.7/10.6.0 onwards, it is upgraded with full DataMiner upgrade packages.<!-- RN 42896 --> Starting from DataMiner 10.6.0 [CU7]/10.6.2, it is sufficient to install a web upgrade instead of a full DataMiner upgrade.<!-- RN 44291 -->

For DataMiner Assistant to run correctly, the following **prerequisites** must be met:

- **DataMiner version**: DataMiner 10.7.0/10.7.1 or later is required for the DataMiner Intelligence user permissions and system-wide setting. On earlier supported versions, Document Intelligence can still be used through the Assistant DxM, but it is not guarded by a DataMiner Intelligence permission.

- **DataMiner Intelligence access**: From DataMiner 10.7.0/10.7.1 onwards, the system-wide *DataMiner Intelligence* setting must be enabled, and users must have the *General > DataMiner Intelligence > Access* permission. To access the Assistant app from the landing page, they also need the *Assistant app* permission. For more information, see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started).

- **Connection to dataminer.services**: The DataMiner System [must be connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- **GQI**: For the "natural language to GQI" feature to work, the [GQI DxM](xref:GQI_DxM) needs to be installed.

### DataMiner as a Service (DaaS)

DataMiner 10.7.0/10.7.1 is the minimum version for the DataMiner Assistant app on DaaS. On DaaS systems running DataMiner 10.7.0/10.7.1 or later, the DataMiner Assistant DxM is already installed and running, so no installation is needed. The app also requires the applicable system setting and user permissions; see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started). Some optional capabilities may not be available by default. To request preview access for those capabilities, contact [ai@skyline.be](mailto:ai@skyline.be).

### On-premises systems

For on-premises installation and getting-started instructions, see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started).

## Upgrading

Once DataMiner Assistant has been deployed, it is upgraded when you install DataMiner upgrades from DataMiner 10.5.7/10.6.0 onwards.<!-- RN 42896 --> Starting from DataMiner 10.6.0 [CU7]/10.6.2, it is sufficient to install a web upgrade instead of a full DataMiner upgrade.<!-- RN 44291 -->

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Assistant\Logs` folder.

This folder stores a maximum of two log files. A new log file is created when the current file exceeds a predefined size. If the folder already contains two log files, the oldest will be removed to make room for the new one.
