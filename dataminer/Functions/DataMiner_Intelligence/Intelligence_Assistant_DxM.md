---
uid: Intelligence_Assistant_DxM
keywords: DataMiner Copilot
description: "Learn how to install, upgrade, and configure the DataMiner Assistant DxM, which delivers DataMiner Intelligence, including prerequisites and feature flags."
---

# DataMiner Assistant DxM

DataMiner Intelligence is delivered by the DataMiner Assistant DxM ([DataMiner Extension Module](xref:DataMinerExtensionModules)), which provides conversational AI in DataMiner, for example in the [Assistant app](xref:Intelligence_Assistant_app) and the [Document Intelligence](xref:docintel) feature. For an overview of what DataMiner Intelligence offers, see [DataMiner Intelligence](xref:Intelligence_Overview).

The initial 1.0.0 version only supports the [natural language to GQI](xref:Intelligence_NL2GQI) feature. Starting from version 2.0.7, the [Document Intelligence](xref:docintel) feature is also supported. In addition, a [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365) is available on the Microsoft Marketplace, which has features similar to the Assistant app but allows direct access from Microsoft Teams or Microsoft Copilot.

> [!NOTE]
> Prior to version 2.0.0, the DataMiner Assistant DxM is called "Copilot" instead.

## Installation

### Prerequisites

For DataMiner Assistant to run correctly, the following prerequisites must be met:

- **Connection to dataminer.services**: The DataMiner System [must be connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- **GQI**: For the "natural language to GQI" feature to work, the [GQI DxM](xref:GQI_DxM) needs to be installed.

### Choosing the Agents to install on

You do not need to install the DataMiner Assistant DxM on every Agent in a DataMiner cluster. We recommend installing it on a few Agents to provide redundancy. The installation and configuration steps only have to be performed on the Agents that host the DxM. No changes are required on the other Agents in the cluster.

> [!WARNING]
> Do not install the DataMiner Assistant DxM on Failover pairs. Failover configurations are not supported for this DxM. Most features will still work if the DxM is hosted on a Failover Agent, but [script tools](xref:Intelligence_Assistant_ScriptTools) will not be able to run Automation scripts in that configuration.

### DataMiner as a Service (DaaS)

No installation is needed on DaaS systems. The DataMiner Assistant DxM is already installed and running on every DaaS system running DataMiner 10.6 or newer. However, the Assistant app and the optional capabilities are not visible by default. To make them available, configure the [feature flags](#feature-flags).

### On-premises systems

For DataMiner versions prior to 10.6, DataMiner Assistant is not included in the DataMiner upgrade packages and [needs to be deployed separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).

From DataMiner 10.6 onwards, the local DataMiner installers include the DataMiner Assistant DxM. To install it, run the DataMiner Assistant MSI installer from the `C:\Skyline DataMiner\Tools\ModuleInstallers\Web` folder on the DataMiner Agent.

> [!NOTE]
> Only use the MSI installer for the initial installation of the DataMiner Assistant DxM. Do not run it again for updates. Once the DxM has been installed, it is upgraded automatically when you install DataMiner upgrades.

## Upgrading

Once DataMiner Assistant has been deployed, it is upgraded when you install DataMiner upgrades from DataMiner 10.5.7/10.6.0 onwards.<!-- RN 42896 --> Starting from DataMiner 10.6.0 [CU7]/10.6.2, it is sufficient to install a web upgrade instead of a full DataMiner upgrade.<!-- RN 44291 -->

To upgrade to version 2.0.0 (which involves a name change of the DxM, as previously it was called "Copilot"), you will need to install DataMiner Assistant manually, even if the Copilot DxM was already installed. After that, automatic upgrades will resume.

## Configuration

Once the DxM has been installed, it runs with default settings, but it is not user-facing by default. To make features visible, configure the [feature flags](#feature-flags).

To override the default settings, create an *appsettings.custom.json* file in the same folder as the default *appsettings.json* file, i.e., `C:\Program Files\Skyline Communications\DataMiner Assistant\`. Only include the settings you want to override.

### Feature flags

The following feature flags can be configured in the *appsettings.custom.json* file. All flags are set to `false` by default and have to be explicitly enabled.

| Feature flag | Description | More information |
|--------------|-------------|------------------|
| `NL2GQIOptions.ShowUserInterface` | Controls whether the natural language to GQI feature is available when [configuring queries in dashboards and low-code apps](xref:Letting_DataMiner_Assistant_create_a_query). | [Natural language to GQI](xref:Intelligence_NL2GQI) |
| `AssistantOptions.ShowUserInterface` | Controls whether the Assistant app (chat interface) and the [Assistant chat component](xref:DashboardAssistantChat) are available. | [DataMiner Assistant app](xref:Intelligence_Assistant_app) |
| `AssistantOptions.CustomAgents.Enabled` | Controls whether the specialized agents feature is available. | [Specialized agents](xref:Intelligence_Assistant_Specialized_Agents) |

Example of an *appsettings.custom.json* file with all feature flags enabled:

```json
{
  "NL2GQIOptions": {
    "ShowUserInterface": true
  },
  "AssistantOptions": {
    "ShowUserInterface": true,
    "CustomAgents": {
      "Enabled": true
    }
  }
}
```

> [!NOTE]
>
> - From DataMiner Assistant DxM version 2.1.9 onwards, changes to the configuration are picked up in real time. In earlier versions, you have to restart the DataMiner Assistant DxM process for the custom configuration to be loaded.
> - The *appsettings.custom.json* files are not synchronized in a cluster. You have to change the file on every Agent that hosts the DataMiner Assistant DxM.
> - The web app itself may need some time to pick up configuration changes. To speed up this process, you can restart the server in IIS Manager.

## Logging

Errors and warnings are logged to log files in the `C:\ProgramData\Skyline Communications\DataMiner Assistant\Logs` folder.

This folder stores a maximum of two log files. A new log file is created when the current file exceeds a predefined size. If the folder already contains two log files, the oldest will be removed to make room for the new one.
