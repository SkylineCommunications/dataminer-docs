---
uid: DataMiner_Intelligence
keywords: DataMiner Intelligence, agentic AI, AI agents, DataMiner Assistant
description: "Explore DataMiner Intelligence, the AI capabilities in DataMiner, including DataMiner Assistant chat, natural language to GQI, and Document Intelligence."
---

# About DataMiner Intelligence

**DataMiner Intelligence** is the umbrella term for AI capabilities in DataMiner. It includes the agent framework, the DataMiner Assistant chat interfaces, and features such as natural language to GQI and Document Intelligence.

DataMiner Intelligence was introduced in DataMiner 10.7.0/10.7.1.<!--RN 47196--> Some capabilities, such as [Document Intelligence](xref:docintel), are also available in earlier versions. The [DataMiner Assistant DxM](xref:Intelligence_Assistant_DxM) is the extension module that powers the capabilities described here.

DataMiner Intelligence consists of:

- The [**DataMiner Intelligence agent framework**](#dataminer-intelligence-agent-framework), with AI agents that help you **understand**, **act**, and **create** on the DataMiner platform.
- [**DataMiner Assistant**](#interacting-with-the-agents), the chat integrations for interacting with those agents.
- [**Other integrated AI capabilities**](#other-ai-capabilities), such as natural language to GQI and Document Intelligence.

> [!NOTE]
> In the context of DataMiner Intelligence, "agents" refers to AI agents. These are not to be confused with DataMiner Agents, i.e., DataMiner nodes. See [DataMiner System architecture and components](xref:Overview_Architecture_and_components).

> [!TIP]
> For information about how to access DataMiner Intelligence and about its prerequisites, see [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started).

## DataMiner Intelligence agent framework

The DataMiner Intelligence agent framework is an agentic framework in which AI agents investigate questions, retrieve information, and perform actions in your DataMiner System. The agents can help you:

- **Understand**: Gain insights into your DataMiner System, for example by investigating alarms, trends, and the state of your elements and services, or by finding answers in the DataMiner documentation.
- **Act**: Perform controlled operational actions, such as running approved automation scripts to start maintenance or apply a configuration.
- **Create**: Build and extend solutions on the DataMiner platform.

### Agents, context, and tools

The framework comes with out-of-the-box [native agents](xref:Intelligence_Agents#native-agents), such as the [DataMiner Insights](xref:Intelligence_InsightsAgent) and [DataMiner Docs](xref:Intelligence_DocumentationAgent) agents.

It is also extensible, so that you can tailor it to your own environment and workflows:

- Add your own context and domain-specific workflows with [skills](xref:Intelligence_Skills).
- Add your own [tools](xref:Intelligence_Tools), such as [custom data tools](xref:Intelligence_custom_data_tools) to query data and [script tools](xref:Intelligence_ScriptTools) to execute automation scripts.
- Add entire agents of your own with [specialized agents](xref:Intelligence_Specialized_Agents), which bundle instructions, skills, and tools into a reusable, purpose-built agent.

### Interacting with the agents

**DataMiner Assistant** is the name for the chat integrations that let you interact with DataMiner Intelligence agents:

- The [DataMiner Assistant app](xref:Intelligence_Assistant_app), which is integrated within DataMiner and available from the DataMiner landing page.
- The [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365), which gives you access to the agents from Microsoft Teams or Microsoft Copilot.
- The [Assistant chat component](xref:DashboardAssistantChat), which lets you interact with the agents from a dashboard or low-code app.

## Other AI capabilities

DataMiner Intelligence also includes capabilities that do not require a chat interface:

- [Natural language to GQI](xref:Intelligence_NL2GQI): Describe the data you need in natural language to generate the corresponding GQI query in dashboards and low-code apps.
- [Document Intelligence](xref:docintel): Extract structured information from unstructured documents, such as PDF files, based on instructions you provide, for example as part of an automated workflow.
