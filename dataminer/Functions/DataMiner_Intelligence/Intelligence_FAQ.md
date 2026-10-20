---
uid: Intelligence_FAQ
description: "Find answers to common questions about DataMiner Intelligence, including access, configuration, agents, skills, tools, permissions, and performance."
---

# DataMiner Intelligence FAQ

## General

### What is DataMiner Intelligence, and what is the DataMiner Assistant?

DataMiner Intelligence is the overarching term for the intelligence capabilities of DataMiner: agents, skills, and tools that use Large Language Models (LLMs) to answer questions, retrieve information, and perform guided actions. The DataMiner Assistant is the conversational chat interface to DataMiner Intelligence.

Technically, DataMiner Intelligence is delivered by the DataMiner Assistant DxM. For more information, see [DataMiner Intelligence](xref:Intelligence_Overview).

### Does DataMiner Intelligence support languages other than English?

Yes. The underlying models are multilingual and respond in the language used in the question.

### What is the difference between agents, skills, and tools?

- **Agents** interpret requests and decide how to investigate or act.
- **Skills** provide agents with domain-specific workflows, instructions, and resources.
- **Tools** let agents query data or run explicitly assigned actions, such as GQI data queries or Automation scripts.

For more information, see [Agents](xref:Intelligence_Assistant_Agents), [Skills](xref:Intelligence_Assistant_Skills), and [Tools](xref:Intelligence_Assistant_Tools).

### Do I need a specialized agent for every use case?

No. The [native agents](xref:Intelligence_Assistant_Agents#native-agents) are intended to answer general questions about the data in your DataMiner System without requiring separate agents. [Specialized agents](xref:Intelligence_Assistant_Specialized_Agents) are useful when you need to narrow the scope or add specialized domain context, for example for a particular network segment. For guidance, see [Choosing between agents, skills, and tools](xref:Intelligence_Agents_Skills_Tools).

### Can DataMiner Intelligence answer questions that require DataMiner context?

Yes. Agents can handle questions that require DataMiner context, such as retrieving data across many elements, identifying the worst performer, or filtering alarms for a specific view.

Use cases that require explicit knowledge of your environment, for example diagnosing the cause of a specific type of network failure based on alarm patterns and traffic shifts, will likely require a specialized agent with the necessary instructions and skills.

## Installation and configuration

### Which DataMiner versions support DataMiner Intelligence?

The DataMiner Assistant DxM is compatible with DataMiner 10.6 or newer. Some features of the [Assistant app](xref:Intelligence_Assistant_app) require a more recent version of DataMiner Web. For more information, see [DataMiner Assistant DxM](xref:Intelligence_Assistant_DxM).

### Do I need to install the DxM on every DataMiner Agent in the cluster?

No. Install the DataMiner Assistant DxM on a few suitable Agents to provide redundancy. The installation and configuration only have to be performed on the Agents that host the DxM.

Do not install the DxM on a Failover pair. Failover configurations are not supported, and script tools cannot run Automation scripts when the DxM is hosted on a Failover Agent.

### Is installation required on a DaaS system?

No. The DataMiner Assistant DxM is already installed and running on DataMiner as a Service (DaaS) systems. You do have to enable the relevant [feature flags](xref:Intelligence_Assistant_DxM#feature-flags) if you want to make the Assistant app visible or use optional capabilities.

### Why is the Assistant app not visible?

Check the following:

- Make sure the DataMiner Assistant DxM is installed and running.
- Make sure the `AssistantOptions.ShowUserInterface` feature flag is set to `true` in the `appsettings.custom.json` file.
- Make sure the file is located in `C:\Program Files\Skyline Communications\DataMiner Assistant\`.
- In a cluster, apply the configuration on every Agent that hosts the DxM, as custom configuration files are not synchronized.
- If the change is not picked up, restart the DxM or restart the server in IIS Manager, depending on the DxM version.

For more information, see [Configuration](xref:Intelligence_Assistant_DxM#configuration).

### How do I enable specialized agents or natural language to GQI?

Enable the corresponding [feature flag](xref:Intelligence_Assistant_DxM#feature-flags) in the `appsettings.custom.json` file:

- `AssistantOptions.CustomAgents.Enabled` enables [specialized agents](xref:Intelligence_Assistant_Specialized_Agents).
- `NL2GQIOptions.ShowUserInterface` enables [natural language to GQI](xref:Intelligence_NL2GQI) in dashboards and low-code apps.

All feature flags are disabled by default.

### Where can I find the DataMiner Assistant DxM version?

In the DataMiner web apps, click the user icon in the top-right corner and select *About*. The version of the DataMiner Assistant DxM is listed as *Assistant*, together with the versions of the other DataMiner components.

### Does adding a new model require a new DxM version?

Not always. Newer models that use the same APIs can be made available automatically. Adding a new model provider does require a DxM upgrade.

## Permissions

### Why can I view an agent, skill, or tool but not edit it?

Viewing agents, skills, and tools does not require the same permissions as managing them. Creating or editing them requires the [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission. The *Agents* page is only available if the specialized agents feature flag has been enabled.

## Skills, tools, and agents

### Should a capability that is only used by one agent still be implemented as a skill?

Often, yes. When context is substantial and only relevant in certain situations, putting it in a skill is preferable, even if only one agent uses it. The skill is then only loaded when needed, which keeps the agent focused and reduces the context sent by default.

### What is the best way to make documentation available to agents?

The simplest approach is to create one [skill](xref:Intelligence_Assistant_Skills) with multiple resource files. Organize the documentation as text-based files in the skill folder or in nested subfolders, and reference those resources from the skill instructions. Agents will load the resources progressively when they are relevant.

If you use a table of contents (TOC) file, reference it explicitly in the `SKILL.md` file, and instruct the agent to follow the paths listed in it. Specify each path relative to the skill folder, including every nested folder, for example `reference/network/overview.md` instead of only `overview.md`. A TOC does not make resource paths discoverable automatically.

For the supported folder structure and `SKILL.md` requirements, see [Using skill files](xref:Intelligence_Assistant_Skills#using-skill-files).

### Why must script input descriptions be defined in the script tool?

Agents use the descriptions defined in the [script tool](xref:Intelligence_Assistant_ScriptTools) to understand how to interact with the script, which values to provide, and how to validate user input. This ensures that each tool has consistent, AI-friendly metadata, regardless of how the underlying script is documented.

The description will generally be the same for a given script, but defining it in the script tool also allows the same script to be used in different operational contexts. Multiple tools can provide different instructions, examples, or validation requirements without modifying the underlying script.

## Performance and scalability

### How does DataMiner Intelligence handle very large datasets?

DataMiner Intelligence normally limits the raw data sent directly to the LLM to approximately 100 rows, to stay within context limits and keep responses reliable. For larger datasets, it can export the data to a CSV file and provide the LLM with metadata such as the row count, column names, and a sample.

The LLM can then write code to analyze the CSV file in a sandboxed environment in the cloud. This code can filter, aggregate, search, and summarize tens of thousands of rows, after which only the relevant results are returned to the LLM. This allows requests involving a very large number of records to be handled without putting every record into the model context.

### How are data queries executed and scaled?

Tool execution and data fetching are load-balanced across the DataMiner Agents in the cluster. A single prompt can initiate multiple data fetches.

DataMiner Intelligence uses GQI to fetch data efficiently. GQI uses bulk parameter fetching, paging, and optimized query lifecycles to reduce the impact on DataMiner System operations. Queries are load-balanced across DataMiner Agents through the NATS message broker, which supports scalability and resilience.

Queries on very large tables can be expensive. In that case, we recommend using targeted filtering, for example through custom skills.

### What is the current EPM capability?

EPM support is currently limited. EPM chains are not yet supported, and relational table data that is important for EPM is still being developed. Existing skills and tools can provide the data you need in the interim. You can create custom skills to optimize filtering for large collector-table queries.
