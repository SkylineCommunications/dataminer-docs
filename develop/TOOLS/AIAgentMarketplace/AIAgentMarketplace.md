---
uid: AIAgentMarketplace
description: Discover the AI Agent marketplace, its available DataMiner agents, prerequisites, installation options, and best practices.
---

# AI Agent marketplace

The [Skyline Agent Marketplace](https://github.com/SkylineCommunications/agent-marketplace) is Skyline Communications' public marketplace for AI agents and reusable skills. It packages specialized DataMiner knowledge and workflows so that supported AI clients can help you perform DataMiner development tasks.

The marketplace supports GitHub Copilot, Claude Code, Cursor, and OpenAI Codex. The available agents and their behavior may evolve as the marketplace is updated.

> [!IMPORTANT]
> The agents are experimental. You remain responsible for reviewing and testing all generated work before you use it in a production environment.

## Currently included agents

| Agent | Description |
|---|---|
| DataMiner App Builder | Builds static frontend applications that can be deployed in DataMiner. It provides reusable skills for DataMiner APIs, data discovery, GQI queries, Automation scripts, Interactive Automation Scripts, frontend design, testing, and debugging. |

## Get started

1. Make sure your environment meets the [prerequisites](#prerequisites).

1. Follow the installation instructions for your AI client:

   | Client | Installation instructions |
   |---|---|
   | GitHub Copilot CLI | [Finding and installing plugins](https://docs.github.com/en/copilot/how-tos/copilot-cli/customize-copilot/plugins-finding-installing) |
   | Visual Studio Code with GitHub Copilot | [Agent plugins](https://code.visualstudio.com/docs/agent-customization/agent-plugins?plugin-marketplace=extensions-view#_install-a-plugin-from-source) |
   | Claude Code | [Discover and install plugins](https://code.claude.com/docs/en/discover-plugins) |
   | Cursor | [Customize Cursor](https://cursor.com/docs/customize-cursor) |
   | OpenAI Codex | [Package and manage plugins](https://developers.openai.com/plugins/build/plugins) |

1. Register the following marketplace source in your AI client:

   ```text
   https://github.com/SkylineCommunications/agent-marketplace.git
   ```

   The marketplace registration name is `skyline-agent-marketplace`.

1. Install the plugins you want to use.

1. Open your development workspace and select an agent.

1. Describe what you want to create or the change you want to make.

## Best practices

- Give the agent clear requirements and open the relevant project or workspace before you start.
- Review generated code for correctness, security, and compatibility with your DataMiner System.
- Do not include passwords, API keys, tokens, or other secrets in prompts.

## Releases

New versions and their changelogs are published on the [Skyline Agent Marketplace releases page](https://github.com/SkylineCommunications/agent-marketplace/releases).

## Issues

If you encounter a problem or have a suggestion for the AI Agent marketplace, [create an issue in the agent-marketplace repository](https://github.com/SkylineCommunications/agent-marketplace/issues). Include enough detail to reproduce the problem or understand the proposed improvement.

## Prerequisites

To use the AI Agent marketplace, you need:

- A supported AI client with agent plugin support.
- The account or license required by your chosen AI client.
- Access to GitHub to retrieve the marketplace and its plugins.

To use the DataMiner App Builder, you also need:

- A DataMiner System running DataMiner 10.5.0 or higher.
- [Node.js](https://nodejs.org/en/download)
- [Git](https://git-scm.com/install/)
- [Assistant DxM](xref:Assistant_DxM)
