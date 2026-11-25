---
uid: Intelligence_Getting_Started
keywords: DataMiner Intelligence, DataMiner Assistant, getting started
description: "Learn the requirements and steps to enable DataMiner Intelligence and access the DataMiner Assistant app in your DataMiner System."
---

# Getting started with DataMiner Intelligence

## Requirements

[DataMiner Intelligence](xref:DataMiner_Intelligence) has the following requirements:

- **DataMiner version**: DataMiner Intelligence requires DataMiner 10.7.0/10.7.1 or higher. Document Intelligence is already available in earlier DataMiner versions.

  For the best results, we recommend using the latest available DataMiner version.

- **dataminer.services connection**: Your DataMiner System must be [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- **DataMiner Assistant DxM**: The [DataMiner Assistant DxM](xref:Intelligence_Assistant_DxM) powers the DataMiner Intelligence agent framework, [natural language to GQI](xref:Intelligence_NL2GQI), and [Document Intelligence](xref:docintel).

- **System setting**: The *DataMiner Intelligence* web apps setting must be enabled. See [Enabling DataMiner Intelligence](#enabling-dataminer-intelligence).

- **User permissions**: To use any of the DataMiner Intelligence capabilities, you need the [General > DataMiner Intelligence > Access](xref:DataMiner_user_permissions#general--dataminer-intelligence--access) user permission. On DataMiner versions prior to 10.7.0/10.7.1 that already support Document Intelligence, this permission is not yet required to use Document Intelligence.

  To access the DataMiner Assistant app from the landing page, you also need the [Assistant app](xref:DataMiner_user_permissions#general--dataminer-intelligence--assistant-app) permission.

## Enabling DataMiner Intelligence

1. Make sure your DataMiner System runs DataMiner 10.7.0/10.7.1 or higher and is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. If you have a self-managed DataMiner System, make sure the [DataMiner Assistant DxM](xref:Intelligence_Assistant_DxM) is installed.

   On DaaS systems running DataMiner 10.7.0/10.7.1 or higher, this DxM is installed and running by default.

1. In DataMiner Cube, grant users (including yourself) the following user permissions:

   - To be able to use DataMiner Intelligence: [General > DataMiner Intelligence > Access](xref:DataMiner_user_permissions#general--dataminer-intelligence--access).
   - To be able to open the DataMiner Assistant app from the landing page: [General > DataMiner Intelligence > Assistant app](xref:DataMiner_user_permissions#general--dataminer-intelligence--assistant-app).

   For details on how to assign user permissions, see [Configuring a user group](xref:Configuring_a_user_group).

1. Enable the *DataMiner Intelligence* system setting:

   1. Open a DataMiner web app (e.g., Dashboards, Monitoring, etc.) or the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

   1. In the user menu in the upper-right corner, select *Settings* > *System*.

   1. Enable the *DataMiner Intelligence* toggle button.

      ![System settings showing the DataMiner Intelligence and Specialized agents toggle buttons](~/dataminer/images/DataMiner_Intelligence_System_Settings.png)<br>*DataMiner Intelligence and Specialized agents toggle buttons in the system settings in DataMiner Web 10.7.1.*

## Starting a chat with DataMiner Assistant

1. Open the [DataMiner Assistant app](xref:Intelligence_Assistant_app) from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

1. In the lower-left corner of the chat input box, select the agent you want to use, e.g., *DataMiner Insights*.

1. Enter your question in the chat input box.

   The agent will investigate your question and show the tools it invokes and the reasoning steps it performs while it constructs its response.

## Next steps

- Learn which [agents](xref:Intelligence_Agents) are available and how to create your own [specialized agents](xref:Intelligence_Specialized_Agents).
- Extend the agents with your own [skills](xref:Intelligence_Skills) and [tools](xref:Intelligence_Tools).
- Access the agents from Microsoft Teams or Microsoft Copilot with the [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365).
- Learn how DataMiner Intelligence handles [data privacy and security](xref:Intelligence_Data_Privacy_Security).
