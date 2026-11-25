---
uid: Intelligence_Assistant_DxM
keywords: DataMiner Copilot
description: "Learn how to install and upgrade the DataMiner Assistant DxM, the extension module that powers DataMiner Intelligence capabilities."
---

# DataMiner Assistant DxM

The DataMiner Assistant DxM is the [DataMiner Extension Module](xref:DataMinerExtensionModules) that powers [DataMiner Intelligence](xref:DataMiner_Intelligence) capabilities, including the agent framework, natural language to GQI, and Document Intelligence. The DxM is separate from the [DataMiner Assistant app](xref:Intelligence_Assistant_app), which provides a chat interface for the agents.

## Installation

The DataMiner Assistant DxM is included in DataMiner web upgrade packages, but it is not activated automatically in all systems:

- On [**DataMiner as a Service (DaaS)**](xref:DaaS_hosting) systems, the DataMiner Assistant DxM is enabled by default starting from DataMiner 10.7.0/10.7.1.

- On **self-managed DataMiner Systems**, you need to install the DxM initially to activate it. To do so, run the DataMiner Assistant MSI installer from the folder `C:\Skyline DataMiner\Tools\ModuleInstallers\Web` on the DataMiner Agent. Local installers include the DataMiner Assistant DxM by default starting from DataMiner 10.6.x.

  You do not need to install the DataMiner Assistant DxM on every node in a DataMiner cluster. We recommend installing it on a few suitable Agents to provide redundancy.

Once installed, the DxM is upgraded automatically when you install DataMiner web upgrades.

> [!TIP]
> For the system settings and permissions required to use these capabilities, see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started).

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Assistant\Logs` folder.

This folder stores a maximum of two log files. A new log file is created when the current file exceeds a predefined size. If the folder already contains two log files, the oldest will be removed to make room for the new one.
