---
uid: DataMiner_Intelligence
keywords: DataMiner Intelligence, agentic AI, AI agents, DataMiner Assistant
description: "Discover DataMiner Intelligence, the agentic AI capabilities of DataMiner, its main components, and how to get started with the DataMiner Assistant."
---

# About DataMiner Intelligence

DataMiner Intelligence is officially available from DataMiner 10.7.1/10.7.0 onwards.<!--RN 47196-->

DataMiner Intelligence covers all agentic AI capabilities of DataMiner. It consists of:

- The **DataMiner Intelligence agent framework**, with AI agents that help you **understand**, **act**, and **create** on the DataMiner platform.
- **Other integrated AI capabilities**, such as natural language to GQI and Document Intelligence.

> [!NOTE]
> In the context of DataMiner Intelligence, "agents" refers to AI agents. These are not to be confused with DataMiner Agents, i.e., DataMiner nodes. See [DataMiner System architecture and components](xref:Overview_Architecture_and_components).

## DataMiner Intelligence agent framework

The DataMiner Intelligence agent framework is an agentic framework in which AI agents investigate questions, retrieve information, and perform actions in your DataMiner System. The agents can help you:

- **Understand**: Gain insights into your DataMiner System, for example by investigating alarms, trends, and the state of your elements and services, or by finding answers in the DataMiner documentation.
- **Act**: Perform controlled operational actions, such as running approved automation scripts to start maintenance or apply a configuration.
- **Create**: Build and extend solutions on the DataMiner platform.

### Agents, context, and tools

The framework comes with out-of-the-box [native agents](xref:Intelligence_Assistant_Agents#native-agents), such as the [DataMiner Insights](xref:Intelligence_Assistant_InsightsAgent) and [DataMiner Docs](xref:Intelligence_Assistant_DocumentationAgent) agents.

It is also extensible, so that you can tailor it to your own environment and workflows:

- Add your own context and domain-specific workflows with [skills](xref:Intelligence_Assistant_Skills).
- Add your own [tools](xref:Intelligence_Assistant_Tools), such as [custom data tools](xref:Intelligence_Assistant_custom_data_tools) to query data and [script tools](xref:Intelligence_Assistant_ScriptTools) to execute automation scripts.
- Add entire agents of your own with [specialized agents](xref:Intelligence_Assistant_Specialized_Agents), which bundle instructions, skills, and tools into a reusable, purpose-built agent.

### Interacting with the agents

You can interact with the agents through the following DataMiner Assistant chat interfaces:

- The [DataMiner Assistant app](xref:Intelligence_Assistant_app), which is integrated within DataMiner and available from the DataMiner landing page.
- The [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365), which gives you access to the agents from Microsoft Teams or Microsoft Copilot.

In addition to chat interaction, it will soon be possible to trigger DataMiner Intelligence from DataMiner Automation. This will allow you to launch agentic workflows from any automated workflow, for example when a new alarm is generated.

## Access and prerequisites

The DataMiner Intelligence user permissions and system-wide setting are available from DataMiner 10.7.1/10.7.0 onwards. On earlier supported DataMiner versions, Document Intelligence can still be used through the DataMiner Assistant DxM, but it is not guarded by the DataMiner Intelligence permissions.

To enable the *DataMiner Intelligence* setting in *Settings* > *System*, the DataMiner System must run DataMiner 10.7.1/10.7.0 or later and be [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

From DataMiner 10.7.1/10.7.0 onwards, you need the *General > DataMiner Intelligence > Access* user permission to use DataMiner Intelligence capabilities, including DataMiner Assistant, Document Intelligence, and natural language to GQI. On earlier supported versions, Document Intelligence is not guarded by this permission. To access the DataMiner Assistant app from the landing page, you also need the *Assistant app* permission. For details, see [DataMiner user permissions](xref:DataMiner_user_permissions).

The DataMiner Assistant DxM provides the AI capabilities, while the DataMiner Assistant app provides the chat interface to the agents. For the steps to enable DataMiner Intelligence and start exploring it, see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started).

## Other AI capabilities

Next to the agent framework, the DataMiner Assistant DxM also powers the following integrated AI capabilities:

- [Natural language to GQI](xref:Intelligence_NL2GQI): Describe the data you need in human language, and let DataMiner Assistant create the corresponding GQI query for you in dashboards and low-code apps.
- [Document Intelligence](xref:docintel): Extract structured information from unstructured documents, such as PDF files, based on instructions you provide, for example as part of an automated workflow.
