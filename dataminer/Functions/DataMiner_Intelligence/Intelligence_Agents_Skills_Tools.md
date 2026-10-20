---
uid: Intelligence_Agents_Skills_Tools
description: "Learn when to use agents, skills, or tools in DataMiner Intelligence, and when to create a separate specialized agent for a distinct responsibility."
---

# Choosing between agents, skills, and tools

[Agents](xref:Intelligence_Assistant_Agents), [skills](xref:Intelligence_Assistant_Skills), and [tools](xref:Intelligence_Assistant_Tools) work together, but each has a different role. This page helps you decide which one to use for a given need.

## Overview

| | What is it | Use it for | Examples |
|---|---|---|---|
| **Tool** | A single capability that lets an agent query data or run an action. | Atomic operations, such as retrieving data or running a script. | Get a parameter, set a parameter, run a script. |
| **Skill** | A reusable procedure or body of expertise that tells an agent how to approach a task, usually using one or more tools. | Workflows, rules, and domain knowledge that are only relevant in certain situations. | Diagnose signal loss, schedule a downlink. |
| **Agent** | An autonomous owner of an operational domain that combines tools and skills to solve problems. | A distinct domain with its own goals, instructions, and tools. | Satellite operations agent, booking and scheduling agent. |

## Which one should you use?

Start with the smallest concept that can do the job:

- If you need to retrieve data or perform a single action, create a [tool](xref:Intelligence_Assistant_Tools).
- If you need to describe how to approach a task, for example a procedure to follow or domain knowledge to apply, create a [skill](xref:Intelligence_Assistant_Skills).
- If you need a focused assistant for a distinct domain that users can ask questions or assign tasks to, create a [specialized agent](xref:Intelligence_Assistant_Specialized_Agents).

Avoid creating a separate agent just because a reusable function exists, such as "get service" or "query alarms". Those are tools or skills.

## When to create a specialized agent

The [native agents](xref:Intelligence_Assistant_Agents#native-agents) are intended to answer general questions about the data in your DataMiner System, so you do not need a specialized agent for every use case. Create a specialized agent when:

- It represents a distinct business or operational domain with its own goals, for example a particular network segment.
- Users could reasonably ask it to solve a problem independently.
- It requires substantially different context, instructions, or expertise than the native agents.
- It needs its own set of tools and data sources.

If a capability is mainly a reusable procedure, make it a skill. If it is a single action or data operation, make it a tool.

## Tips

- **Start small.** Start with one agent and add skills and tools to it. Only introduce a separate agent when a clear responsibility boundary emerges.

- **Do not create an agent per capability.** For example, if alarm handling, parameter changes, and scheduling all belong to the same operational domain, group them in one domain agent with the relevant skills and tools. Splitting them up makes the setup harder to maintain and debug.

- **Do not create one agent that does everything.** An agent that is expected to handle anything in DataMiner ends up with oversized instructions, ambiguous tool selection, and conflicting guidelines. Prefer a limited number of focused agents.

- **Use skills for situational context.** Put substantial context that is only relevant in certain situations in a skill, even if only one agent uses it. The skill is only loaded when needed, which keeps the agent focused.

- **Assign only what the agent needs.** A specialized agent only has access to the tools and skills assigned to it. If a skill refers to specific tools in its instructions, also add those tools to the agent.

## Example: ticketing

Several operational domains, such as broadcast, satellite, and network operations, may need to create and update tickets. Whether ticketing requires its own agent depends on the responsibility you assign to it:

- **Ticketing as tools and skills**: If ticketing mainly involves creating, reading, updating, and deleting tickets, a separate agent is not necessary. Each operational agent can use tools such as *create ticket* and *update ticket*, or a skill such as *summarize ticket history* when more reasoning is involved.

- **Dedicated ticketing agent**: If ticketing involves owning the entire ticket lifecycle, such as re-evaluating open tickets, escalating tickets, and verifying that an issue is resolved before a ticket is closed, a separate ticketing agent makes sense.

In general, do not create an agent because a module exists. Create one when the module represents an independent responsibility.
