---
uid: Intelligence_Agents
description: "Learn about native and specialized DataMiner Intelligence agents, the tools and skills they use, and the context they receive during chats."
---

# Agents

Agents are part of the [DataMiner Intelligence agent framework](xref:DataMiner_Intelligence#dataminer-intelligence-agent-framework). They combine tools, skills, and context to investigate questions, retrieve information, and perform guided actions. You can interact with them through the [DataMiner Assistant chat integrations](xref:DataMiner_Intelligence#interacting-with-the-agents).

These AI agents are not to be confused with "DataMiner Agents", i.e., DataMiner nodes. (See [DataMiner System architecture and components](xref:Overview_Architecture_and_components).)

AI agents operate by combining:

- **[Tools](xref:Intelligence_Tools)**: These give the agents the ability to query data and execute actions.
- **[Skills](xref:Intelligence_Skills)**: These provide the agents with domain-specific workflows and instructions.

## Types of agents

### Native agents

Native agents are built-in [DataMiner Intelligence](xref:DataMiner_Intelligence) agents. They are available when the [requirements for DataMiner Intelligence](xref:Intelligence_Getting_Started#requirements) are met.

The following native agents are available:

- **[DataMiner Insights](xref:Intelligence_InsightsAgent)**: Investigates questions about your DataMiner System using data tools and skills.
- **[DataMiner Docs](xref:Intelligence_DocumentationAgent)**: Provides answers based on DataMiner documentation.

On the agents overview page, native agents are labeled with a "Native" tag. You can use the *Native only* toggle button to filter the list and show only native agents. Native agents open in read-only mode, so editing and deleting is not possible for them.

![DataMiner Assistant Agents page showing native and specialized agents, with a Native tag on built-in agents](~/dataminer/images/Assistant_Agents_List.png)<br>*Native and specialized agents listed in the DataMiner Assistant app in DataMiner Web 10.7.1*

### Specialized agents

[Specialized agents](xref:Intelligence_Specialized_Agents) are user-defined agents that bundle a name, description, instructions, and a curated set of references into a reusable, purpose-built entity. You can create them to have agents that are specifically tailored to certain operational workflows or domains.

Specialized agents only have access to the specific tools and skills assigned to them.

> [!IMPORTANT]
> Specialized agents are an experimental feature. They are available when the system-wide *DataMiner Intelligence* and *Specialized agents* web app settings have both been enabled. For more information, see [Specialized agents](xref:Intelligence_Specialized_Agents).

## Agent context

When a chat session is opened, agents receive contextual metadata about the user and their environment. This helps them produce more relevant and consistently formatted responses.

The following metadata is available to agents:

- **Username**: The name of the user interacting with the agent.
- **Time zone**: The user's time zone, used to determine the current local time. This helps agents interpret time-relative instructions such as "in the last 2 hours" or "from 8 to 10".
- **Culture**: The user's culture (locale), which provides formatting conventions for dates, times, and numbers. This helps agents produce responses that match the user's expected format.

Time zone and culture are optional and depend on the client providing them when opening a chat session.
