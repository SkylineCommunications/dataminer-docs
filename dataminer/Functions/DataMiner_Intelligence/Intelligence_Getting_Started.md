---
uid: Intelligence_Getting_Started
keywords: DataMiner Intelligence, DataMiner Assistant, getting started
description: "Learn how to enable the DataMiner Assistant DxM and the DataMiner Assistant app to start exploring DataMiner Intelligence in your DataMiner System."
---

# Getting started with DataMiner Intelligence

[DataMiner Intelligence](xref:DataMiner_Intelligence) relies on two components that each need to be enabled separately:

- **DataMiner Assistant DxM**: This [DataMiner Extension Module](xref:DataMinerExtensionModules) provides the AI capabilities in DataMiner, including the agent framework, [natural language to GQI](xref:Intelligence_NL2GQI), and [Document Intelligence](xref:docintel).
- **DataMiner Assistant app**: This chat interface allows you to interact with the DataMiner Intelligence agents from within DataMiner.

## Enabling DataMiner Intelligence

1. Make sure your DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. Deploy the DataMiner Assistant DxM.

   The DxM is not included in DataMiner upgrade packages, so you need to [deploy it separately](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node). For more information on the prerequisites, see [DataMiner Assistant DxM](xref:Intelligence_Assistant_DxM).

1. Request access to the DataMiner Assistant app by contacting [ai@skyline.be](mailto:ai@skyline.be).

   The app is currently available in preview on request. For more information, see [DataMiner Assistant app](xref:Intelligence_Assistant_app).

1. Open the DataMiner Assistant app from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

1. In the lower-left corner of the chat input box, select the agent you want to use, e.g., *DataMiner Insights*.

1. Enter your question in the chat input box.

   The agent will investigate your question and show the tools it invokes and the reasoning steps it performs while it constructs its response.

## Next steps

- Learn which [agents](xref:Intelligence_Assistant_Agents) are available and how to create your own [specialized agents](xref:Intelligence_Assistant_Specialized_Agents).
- Extend the agents with your own [skills](xref:Intelligence_Assistant_Skills) and [tools](xref:Intelligence_Assistant_Tools).
- Access the agents from Microsoft Teams or Microsoft Copilot with the [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365).
- Learn how DataMiner Intelligence handles your data in [Data privacy and security](xref:Intelligence_Data_Privacy_Security).
