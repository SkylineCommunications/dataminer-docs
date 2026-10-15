---
uid: Intelligence_Overview
description: "Get an overview of DataMiner Intelligence: agents, skills, and tools that use LLMs to answer questions, retrieve information, and perform actions."
---

# DataMiner Intelligence

DataMiner Intelligence brings agents, skills, and tools to your DataMiner System. Agents have access to various sources of information within the DataMiner System and use Large Language Models (LLMs) to combine this information, extract useful insights, and perform guided actions.

## Terminology

- **DataMiner Intelligence** is the overarching term for the intelligence capabilities of DataMiner. It covers agents, skills, tools, and the other AI-powered features described in this section.
- **DataMiner Assistant** is the conversational interface to DataMiner Intelligence. It allows you to interact with DataMiner using natural language, explore operational insights, and start actions.
- **DataMiner Assistant DxM** is the [DataMiner Extension Module](xref:DataMinerExtensionModules) that delivers DataMiner Intelligence. This technical name appears in installers, folder paths, configuration settings, and version numbers.

## Capabilities

- **[Agents](xref:Intelligence_Assistant_Agents)**: Autonomous entities that investigate questions, retrieve information, and perform guided actions. DataMiner Intelligence includes built-in [native agents](xref:Intelligence_Assistant_Agents#native-agents) and user-defined [specialized agents](xref:Intelligence_Assistant_Specialized_Agents).

- **[Skills](xref:Intelligence_Assistant_Skills)**: Modular capability packages that provide agents with domain-specific workflows, instructions, and supporting resources.

- **[Tools](xref:Intelligence_Assistant_Tools)**: Actionable capabilities that give agents the ability to query data and execute actions. These include [data tools](xref:Intelligence_Assistant_DataTools) and [script tools](xref:Intelligence_Assistant_ScriptTools).

- **[Natural language to GQI](xref:Intelligence_NL2GQI)**: Translates requests in human language into ready-to-execute GQI queries.

- **[Document Intelligence](xref:docintel)**: Analyzes the contents of documents using an LLM to extract insights and information.

For guidance on how to divide responsibilities between agents, skills, and tools, see [Designing agents, skills, and tools](xref:Intelligence_Agent_Best_Practices).

## Access channels

You can access DataMiner Intelligence in the following ways:

- **[DataMiner Assistant app](xref:Intelligence_Assistant_app)**: A web app that allows you to navigate and troubleshoot your DataMiner System in natural language, and to manage agents, skills, and tools.

- **[DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365)**: Use the Assistant directly from Microsoft Teams or Microsoft Copilot.

- **Dashboards and low-code apps**: Use [natural language to GQI](xref:Letting_DataMiner_Assistant_create_a_query) to create queries, or embed a chat with an agent in your dashboard or low-code app using the [Assistant chat component](xref:DashboardAssistantChat).

## Getting started

1. [Deploy and configure](xref:Intelligence_Assistant_DxM) the DataMiner Assistant DxM, and make sure the [prerequisites](xref:Intelligence_Assistant_DxM#installation) are met.

   On DataMiner as a Service (DaaS) systems, the DxM is already installed.

1. Enable the Assistant app and the other features you want to use by configuring the [feature flags](xref:Intelligence_Assistant_DxM#feature-flags).

   Once the DxM is up and running, the [native agents](xref:Intelligence_Assistant_Agents#native-agents) are available. They are included at no additional cost.

1. If you want to create your own agents, enable the specialized agents feature.

   [Specialized agents](xref:Intelligence_Assistant_Specialized_Agents) are an experimental feature and are licensed separately.

1. Start adding your own [specialized agents](xref:Intelligence_Assistant_Specialized_Agents), [skills](xref:Intelligence_Assistant_Skills), and [tools](xref:Intelligence_Assistant_Tools) to tailor DataMiner Intelligence to your operational context.

## Pricing, privacy, and support

- For information about how usage of DataMiner Intelligence is metered and charged, see [DataMiner Intelligence pricing](xref:Pricing_DataMiner_Intelligence).
- For information about how your data is handled, see [Data privacy and security](xref:Intelligence_Data_Privacy_Security).
- For answers to common questions, see [DataMiner Intelligence FAQ](xref:Intelligence_FAQ).
- For notable changes in each version, see the [DataMiner Assistant DxM release notes](xref:DataMinerAssistant_change_log).
