---
uid: Intelligence_Specialized_Agents
description: "Create and manage specialized DataMiner Intelligence agents for specific workflows using the DataMiner Assistant app."
---

# Specialized agents

> [!IMPORTANT]
> Specialized agents are an experimental feature. Using them requires DataMiner 10.7.0/10.7.1 or later, the system-wide *DataMiner Intelligence* setting to be enabled, and the *General > DataMiner Intelligence > Access* permission. An administrator must also enable the *Specialized agents* setting in *Settings* > *System*.

A specialized agent is a DataMiner Intelligence agent that you configure with a name, description, instructions, and a selected set of references. When invoked, the agent operates according to its instructions and has access only to the references assigned to it, making it focused and predictable.

Unlike [native agents](xref:Intelligence_Agents#native-agents), which are built-in, specialized agents are fully user-defined and tailored to specific use cases or workflows.

## Enabling specialized agents

1. Open the user menu in the upper-right corner of the Assistant app.

1. Select *Settings* > *System*.

1. Enable the *Specialized agents* toggle button.

   ![System settings showing the DataMiner Intelligence and Specialized agents toggle buttons](~/dataminer/images/DataMiner_Intelligence_System_Settings.png)<br>*DataMiner Intelligence and Specialized agents toggle buttons in the system settings in DataMiner Web 10.7.1*

The change will be saved immediately without reloading the page. The Assistant chat, the *Agents* page, and the agent editor update immediately.

> [!NOTE]
> If you disable this setting and the selected agent is no longer available because of this, the chat will switch to the default agent.

## Why use specialized agents

Specialized agents are typically used for the following purposes:

- Create purpose-built agents for specific operational workflows or domains.
- Control exactly which tools and knowledge an agent can access.
- Provide tailored instructions so the agent behaves consistently for its intended task.
- Enable team members to interact with complex processes through a simple conversational interface.

For example, you could use them for incident triage, capacity planning, or customer health workflows.

## Agent components

A specialized agent consists of the following components:

- **Name**: A unique, human-readable name.
- **Description**: A short summary of what the agent does and when it should be used.
- **Context**: The instructions that guide the agent during conversations.
- **References**: The resources the agent can access during execution.

## References

References define what a specialized agent can use during execution:

- **[Data tools](xref:Intelligence_DataTools)**: Give the agent access to specific data sources.
- **[Script tools](xref:Intelligence_ScriptTools)**: Give the agent access to assigned automation scripts.
- **[Skills](xref:Intelligence_Skills)**: Provide domain-specific workflows and best practices.

By assigning only the relevant references, you ensure that the agent stays focused and does not access unrelated resources. Native tools can also be selected directly.

> [!IMPORTANT]
> If a skill references specific tools in its instructions, add those tools explicitly to the specialized agent. Skills provide instructions and context; they do not automatically grant access to tools.

## Creating and managing specialized agents in the Assistant app

You can create specialized agents on the *Agents* page of the Assistant app. This page displays all available agents in a searchable list.

![Agents page in the DataMiner Assistant app showing available agents and the new agent button](~/dataminer/images/Assistant_Agents_List.png)<br>*Available agents and the New agent button in the DataMiner Assistant app in DataMiner Web 10.7.1*

From this page, you can:

- **Search** for existing agents by name.
- **Create a new specialized agent** by clicking the *+ New agent* button.
- **Edit a specialized agent** by clicking the pencil button next to the agent.
- **Duplicate or delete a specialized agent** by clicking the ellipsis button (...) next to the agent. Selecting *Duplicate* creates a copy of the agent, pre-filled with the original data and an automatically generated unique name. Selecting *Delete* removes the agent.

> [!NOTE]
> The [Modules > System configuration > Tools > Admin tools](xref:DataMiner_user_permissions#modules--system-configuration--tools--admin-tools) user permission is not required to view existing agents, but it is required to create or edit specialized agents.

## Authoring specialized agents as files

For specialized agents managed in source control or deployed through an Intelligence project, see [Authoring specialized agents](xref:Authoring_Intelligence_specialized_agents).

## Interacting with specialized agents

To interact with specialized agents in the Assistant app, use the agent selector at the bottom of the chat window. All available specialized agents are listed there alongside the native agents.

Selecting a specialized agent directs your conversation to that agent, which will respond according to its instructions and references.
