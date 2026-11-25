---
uid: Intelligence_Assistant_DxM
keywords: DataMiner Copilot
description: "Learn how to install and upgrade the DataMiner Assistant DxM, which powers the Assistant app and Document Intelligence API."
---

# DataMiner Assistant DxM

DataMiner Intelligence makes use of the DataMiner Assistant DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)), which provides the AI capabilities in DataMiner.

## Installation

DataMiner Assistant is included in DataMiner web upgrade packages, but it is not activated automatically in all systems:

- On [**DataMiner as a Service (DaaS)**](xref:DaaS_hosting) systems, the DataMiner Assistant DxM is enabled by default starting from DataMiner 10.7.0/10.7.1.

- On **self-managed DataMiner Systems**, you need to install the DxM initially to activate it. To do so, run the DataMiner Assistant MSI installer from the folder `C:\Skyline DataMiner\Tools\ModuleInstallers\Web` on the DataMiner Agent. Local installers include the DataMiner Assistant DxM by default starting from DataMiner 10.6.x.

  You do not need to install the DataMiner Assistant DxM on every node in a DataMiner cluster. We recommend installing it on a few suitable Agents to provide redundancy.

Once it has been installed, DataMiner Assistant is upgraded automatically when you install DataMiner web upgrades.

> [!TIP]
> For information on how to make sure DataMiner assistant runs correctly and on how to get started with the Assistant app, refer to [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started).

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Assistant\Logs` folder.

This folder stores a maximum of two log files. A new log file is created when the current file exceeds a predefined size. If the folder already contains two log files, the oldest will be removed to make room for the new one.
