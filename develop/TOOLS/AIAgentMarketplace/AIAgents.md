---
uid: AIAgents
description: "Learn what DataMiner AI agents are, why they can help with development, and when to use them alongside your existing tools."
---

# AI agents

AI agents help you develop DataMiner solutions using task-specific instructions, reusable skills, and tools. You describe what you need, and the agents can inspect files, make changes, and run checks in your workspace.

Skyline distributes them through use-case-specific plugins in the [AI Agent marketplace](xref:AIAgentMarketplace). They run in your AI client, such as GitHub Copilot or Claude Code. They should not be confused with "DataMiner Agents", i.e., DataMiner nodes.

## Agents, skills, and plugins

- An **agent** has a specialized role, such as implementing, investigating, or reviewing changes.
- A **skill** provides guidance and resources for a specific task.
- A **plugin** bundles the agents and skills needed for a use case.

A plugin can contain one agent or several cooperating agents. An orchestrator can coordinate the workflow and delegate tasks to specialized agents.

## Why use an agent

AI agents bring DataMiner-specific guidance into your workspace, reduce repetitive work, and help you follow established development patterns. A plugin brings the relevant expertise together so you do not need to configure each agent and skill separately.

## When to use an agent

Choose a plugin that matches your use case, such as application development, connector development, or automation scripting. Check the [AI Agent marketplace](xref:AIAgentMarketplace) for currently available plugins and their scope. If a plugin provides an orchestrator, use it as the entry point to coordinate the work.
