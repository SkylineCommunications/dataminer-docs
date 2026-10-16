---
uid: Intelligence_Getting_Started
keywords: DataMiner Intelligence, DataMiner Assistant, getting started
description: "Learn how to enable the DataMiner Assistant DxM and the DataMiner Assistant app to start exploring DataMiner Intelligence in your DataMiner System."
---

# Getting started with DataMiner Intelligence

[DataMiner Intelligence](xref:DataMiner_Intelligence) has the following requirements. The DataMiner Assistant DxM and the DataMiner Assistant app each need to be enabled separately.

- **dataminer.services connection**: Your DataMiner System must be [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- **DataMiner Assistant DxM**: This [DataMiner Extension Module](xref:DataMinerExtensionModules) provides the AI capabilities in DataMiner, including the agent framework, [natural language to GQI](xref:Intelligence_NL2GQI), and [Document Intelligence](xref:docintel).
- **DataMiner Assistant app**: This chat interface allows you to interact with the DataMiner Intelligence agents from within DataMiner.

## Enabling DataMiner Intelligence

1. Make sure your DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. [Install the DataMiner Assistant DxM](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).

   The DxM is included in DataMiner web upgrade packages, but you need to install it once to activate it. After that, it is upgraded automatically when you install DataMiner upgrades. For more information on the installation and prerequisites, see [DataMiner Assistant DxM](xref:Intelligence_Assistant_DxM).

1. [Enable the DataMiner Assistant app](xref:Intelligence_Assistant_app#accessing-the-assistant-app).

   For more information on the app and its user interface, see [DataMiner Assistant app](xref:Intelligence_Assistant_app).

1. Open the DataMiner Assistant app from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

1. In the lower-left corner of the chat input box, select the agent you want to use, e.g., *DataMiner Insights*.

1. Enter your question in the chat input box.

   The agent will investigate your question and show the tools it invokes and the reasoning steps it performs while it constructs its response.

## Next steps

- Learn which [agents](xref:Intelligence_Assistant_Agents) are available and how to create your own [specialized agents](xref:Intelligence_Assistant_Specialized_Agents).
- Extend the agents with your own [skills](xref:Intelligence_Assistant_Skills) and [tools](xref:Intelligence_Assistant_Tools).
- Access the agents from Microsoft Teams or Microsoft Copilot with the [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365).
- Learn how DataMiner Intelligence handles your data in [Data privacy and security](xref:Intelligence_Data_Privacy_Security).
