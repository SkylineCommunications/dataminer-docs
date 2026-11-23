---
uid: Intelligence_Getting_Started
keywords: DataMiner Intelligence, DataMiner Assistant, getting started
description: "Learn the requirements and steps to enable DataMiner Intelligence and access the DataMiner Assistant app in your DataMiner System."
---

# Getting started with DataMiner Intelligence

[DataMiner Intelligence](xref:DataMiner_Intelligence) has the following requirements:

- **DataMiner version**: The DataMiner Intelligence user permissions and system-wide setting require DataMiner 10.7.0 or later. On earlier supported versions, Document Intelligence can still be used, but it is not guarded by a DataMiner Intelligence permission.

- **dataminer.services connection**: Your DataMiner System must be [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- **DataMiner Assistant DxM**: This [DataMiner Extension Module](xref:DataMinerExtensionModules) provides the AI capabilities in DataMiner, including the agent framework, [natural language to GQI](xref:Intelligence_NL2GQI), and [Document Intelligence](xref:docintel).

- **System setting**: The *DataMiner Intelligence* setting must be enabled in *Settings* > *System*. You can only enable it when the DataMiner System runs DataMiner 10.7.0 or later and is connected to dataminer.services.

- **User permissions**: On DataMiner 10.7.0 or later, you need the *General > DataMiner Intelligence > Access* permission to use DataMiner Intelligence capabilities, including Document Intelligence and natural language to GQI. On earlier supported versions, Document Intelligence can still be used without this permission. To access the DataMiner Assistant app from the landing page, you also need the *Assistant app* permission. See [DataMiner user permissions](xref:DataMiner_user_permissions).

For the best results, we recommend using the latest available DataMiner version.

## Enabling DataMiner Intelligence

1. For the system-wide setting and permission controls, make sure your DataMiner System runs DataMiner 10.7.0 or later and is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. Make sure the [DataMiner Assistant DxM](xref:Intelligence_Assistant_DxM) is installed.

1. Grant users the *General > DataMiner Intelligence > Access* permission. To allow them to open the DataMiner Assistant app from the landing page, also grant them the *Assistant app* permission.

1. In *Settings* > *System*, enable *DataMiner Intelligence*.

   ![System settings showing the DataMiner Intelligence and Specialized agents toggles](~/dataminer/images/DataMiner_Intelligence_System_Settings.png)<br>*DataMiner Intelligence and Specialized agents toggles in system settings.*

   To change this setting, you need both the *General > DataMiner Intelligence > Access* permission and the [*Modules > System configuration > Tools > Admin tools* permission](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools). Without both permissions, the setting is read-only. If the DataMiner System does not meet the version or cloud connection requirements, the toggle is disabled; hover over it to see the reason.

   The change takes effect immediately without reloading the page. When DataMiner Intelligence is turned off, the Assistant app is removed from the app menu and apps overview. If the app is already open, it displays a "page not found" message. The app returns when DataMiner Intelligence is turned on again.

1. Open the DataMiner Assistant app from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

1. In the lower-left corner of the chat input box, select the agent you want to use, e.g., *DataMiner Insights*.

1. Enter your question in the chat input box.

   The agent will investigate your question and show the tools it invokes and the reasoning steps it performs while it constructs its response.

## Next steps

- Learn which [agents](xref:Intelligence_Assistant_Agents) are available and how to create your own [specialized agents](xref:Intelligence_Assistant_Specialized_Agents).
- Extend the agents with your own [skills](xref:Intelligence_Assistant_Skills) and [tools](xref:Intelligence_Assistant_Tools).
- Access the agents from Microsoft Teams or Microsoft Copilot with the [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365).
- Learn how DataMiner Intelligence handles your data in [Data privacy and security](xref:Intelligence_Data_Privacy_Security).
