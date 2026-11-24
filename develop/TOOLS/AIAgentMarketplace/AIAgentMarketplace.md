---
uid: AIAgentMarketplace
description: "Discover the AI Agent marketplace, its available DataMiner AI agents, prerequisites, installation options, and best practices."
---

# AI Agent marketplace

The [Skyline Agent Marketplace](https://github.com/SkylineCommunications/agent-marketplace) is Skyline Communications' public marketplace for AI agents and reusable skills. It packages specialized DataMiner knowledge and workflows so that supported AI clients can help you perform DataMiner development tasks.

The marketplace supports GitHub Copilot, Claude Code, Cursor, and OpenAI Codex. The available agents and their behavior may evolve as the marketplace is updated.

> [!IMPORTANT]
> The agents are experimental. You remain responsible for reviewing and testing all generated work before you use it in a production environment.

## Currently included agents

The marketplace contains the following plugins. Each plugin can be installed independently.

| Plugin | Agents | Description |
|---|---|---|
| `dataminer-apps` | DataMiner App | Builds static frontend applications that can be deployed in DataMiner. It provides reusable skills for DataMiner APIs, data discovery, GQI queries, automation scripts, interactive automation scripts, frontend design, testing, and debugging. |
| `dataminer-automation` | DataMiner Automation, plus specialist agents (Scaffolder, Author, Test Writer, Investigator, and Reviewer) | Supports the full development of DataMiner Automation scripts, including interactive Automation scripts. The DataMiner Automation agent acts as the orchestrator: it analyzes the task, creates a plan, and delegates work to the specialist agents. |
| `dataminer-connector` | DataMiner Connector, plus specialist agents (Scaffolder, XML Author, QAction Writer, Validator, Reviewer, Test Writer, Investigator, Help Writer, and Simulation Generator) | Supports the full development of DataMiner connectors. The DataMiner Connector agent acts as the orchestrator: it analyzes the task, creates a plan, and delegates work to the specialist agents. |

## Prerequisites

To use the AI Agent marketplace, you need:

- A supported AI client with agent plugin support.
- The account or license required by your chosen AI client.
- Access to GitHub to retrieve the marketplace and its plugins.

To use the DataMiner App agent, you also need:

- A DataMiner System running DataMiner 10.5.0 or higher.
- [Node.js](https://nodejs.org/en/download)
- [Git](https://git-scm.com/install/)
- [Assistant DxM](xref:Intelligence_Assistant_DxM)

## Getting started

1. Make sure your environment meets the [prerequisites](#prerequisites).

1. Add the Skyline Agent Marketplace to your AI client, and install the plugin you need.

   See [Installation instructions per AI client](#installation-instructions-per-ai-client).

1. Open your development workspace in your AI client.

1. Select an agent of the plugin you installed.

1. Describe what you want to create or the change you want to make.

## Installation instructions per AI client

The marketplace contains several plugins, and you can install each of them independently. For example, the DataMiner App agent is provided by the `dataminer-apps` plugin.

Use `https://github.com/SkylineCommunications/agent-marketplace` as the marketplace source. The marketplace name is `skyline-agent-marketplace`.

### Visual Studio Code with GitHub Copilot

1. Press *Ctrl+Shift+P* to open the Command Palette, and run *Chat: Add Plugin Marketplace*.

1. Enter the marketplace source.

1. Select *skyline-agent-marketplace*

1. Select *Browse*

1. Select the plugin you want to use, for example `dataminer-apps`, and click *Install*.

> [!NOTE]
> If the unified *Browse* page is not available in your version of VS Code, select *Plugins* and then *Browse* in the Session Customizations editor instead. For more information, see [Agent plugins in VS Code](https://code.visualstudio.com/docs/agent-customization/agent-plugins).

### Other AI clients

For the following AI clients, follow the official instructions to add the marketplace source and install a plugin from it:

- GitHub Copilot CLI: [Finding and installing plugins for GitHub Copilot CLI](https://docs.github.com/en/copilot/how-tos/copilot-cli/customize-copilot/plugins-finding-installing)
- GitHub Copilot app: [Customizing the GitHub Copilot app](https://docs.github.com/en/copilot/how-tos/github-copilot-app/customize-github-copilot-app#adding-a-plugin-marketplace)
- Claude Code: [Discover and install plugins](https://code.claude.com/docs/en/discover-plugins)
- Cursor: [Plugins](https://cursor.com/docs/plugins)
- OpenAI Codex: [Build plugins](https://developers.openai.com/codex/plugins/build)

## Best practices

- Give the agent clear requirements and open the relevant project or workspace before you start.
- Review generated code for correctness, security, and compatibility with your DataMiner System.
- Do not include passwords, API keys, tokens, or other secrets in prompts.

## Releases

New versions and their changelogs are published on the [Skyline Agent Marketplace releases page](https://github.com/SkylineCommunications/agent-marketplace/releases).

## Issues

If you encounter a problem or have a suggestion for the AI Agent marketplace, [create an issue in the agent-marketplace repository](https://github.com/SkylineCommunications/agent-marketplace/issues). Include enough detail to reproduce the problem or understand the proposed improvement.
