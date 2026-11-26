---
uid: AIAgent_App_Agent
description: "Discover the DataMiner App Agent, an AI agent that builds static web apps that run inside DataMiner, and find out what you need to get started."
---

# DataMiner App Agent

The DataMiner App Agent is an AI agent from the [AI Agent marketplace](xref:AIAgentMarketplace) that builds custom web applications that run inside DataMiner. You describe the app you need in plain language, and the agent sets up the project, finds the right DataMiner data, implements the user interface, tests it, and produces a build that you can copy to your DataMiner Agent.

The agent is included in the `dataminer-apps` plugin. In your AI client, it is listed as *DataMiner App Agent* (agent ID `dataminer-app-builder`).

> [!IMPORTANT]
> The agent is experimental. You remain responsible for reviewing and testing all generated work before you use it in a production environment.

## What the agent builds

The agent builds **static frontend applications**: React apps that consist only of HTML, CSS, and JavaScript files. These apps:

- Are hosted by the DataMiner web server itself, so no extra server, backend, proxy, or Node.js runtime is needed on the DataMiner Agent.
- Use the existing DataMiner sign-in page and the permissions of the signed-in user.
- Retrieve data with [GQI queries](xref:About_GQI) and can perform actions by executing Automation scripts, including interactive Automation scripts.
- Use DataMiner styling, so that they look and feel like other DataMiner apps.
- Come with automated end-to-end tests.

Typical use cases are operator screens, overviews with a very specific layout or interaction, wizards, and apps that combine data from several sources in one view. The following detailed walkthroughs are available:

- [Building an app from scratch](xref:AIAgent_App_Agent_Example_From_Scratch)
- [Replacing an existing low-code app](xref:AIAgent_App_Agent_Example_Replace_LCA)
- [Replacing a Visual Overview](xref:AIAgent_App_Agent_Example_Replace_Visio)
- [Integrating the DataMiner Assistant into an app](xref:AIAgent_App_Agent_Example_Assistant)

> [!TIP]
> If a [low-code app](xref:Application_framework) can meet your needs, that is often the easier option to build and maintain. Use the App Agent when you need a layout, interaction, or user experience that is hard to achieve with the low-code tools.

## Skills

The agent uses the following skills, which are installed together with the plugin. You do not need to select them yourself: the agent loads the relevant skills for each task.

| Skill | Purpose |
|---|---|
| `dataminer-create-new-app` | Gathers requirements, sets up the project, implements, tests, and builds a new app, and provides deployment instructions. |
| `dataminer-api` | Implements DataMiner Web Services calls, session handling, authorization checks, and WebSocket connections. |
| `dataminer-data-discovery` | Finds the DataMiner data the app needs and turns it into a GQI query, using AI-assisted query generation. |
| `dataminer-execute-query` | Executes GQI queries in the app, including paging and real-time updates. |
| `dataminer-execute-automation-script` | Executes Automation scripts from the app and reads their output. |
| `dataminer-headless-ias` | Drives interactive Automation scripts from a custom user interface. |
| `dataminer-performing-actions` | Performs write operations in DataMiner using supported mechanisms. |
| `dataminer-frontend` | Creates user interfaces in the DataMiner style. |
| `dataminer-e2e-testing` | Creates and runs Playwright end-to-end tests against mocked DataMiner responses. |
| `dataminer-debug-issues` | Investigates problems by inspecting the running app, its network requests, and WebSocket messages. |

## Prerequisites

To use the DataMiner App Agent, you need:

- A supported AI client with the `dataminer-apps` plugin installed. See [Installing the agent](#installing-the-agent).
- A DataMiner System running DataMiner 10.5.0 or higher.
- The [Assistant DxM](xref:Intelligence_Assistant_DxM) installed on the DataMiner System. The agent uses it to discover the data your app needs.
- [Node.js](https://nodejs.org/en/download) (LTS version) and [Git](https://git-scm.com/install/) installed on the machine where you run the AI client.
- A DataMiner user account that the agent can use to discover data.
- Access to the file system of the DataMiner Agent, so that you can [deploy the app](xref:AIAgent_App_Agent_Deploying).

> [!NOTE]
> To [integrate the DataMiner Assistant into an app](xref:AIAgent_App_Agent_Example_Assistant), the [DataMiner Assistant app](xref:Intelligence_Assistant_app) must also be enabled on the DataMiner System.

## Installing the agent

1. Install a supported AI client, e.g., Visual Studio Code with GitHub Copilot.

1. Register the following marketplace source in your AI client, as described under [Getting started](xref:AIAgentMarketplace#getting-started):

   ```text
   https://github.com/SkylineCommunications/agent-marketplace.git
   ```

1. Install the `dataminer-apps` plugin.

1. Check that *DataMiner App Agent* is available in the agent picker of your AI client.

## Next steps

- [Using the App Agent](xref:AIAgent_App_Agent_Using): The workflow of a typical session with the agent.
- [Best practices](xref:AIAgent_App_Agent_Best_Practices): Tips for good prompts and reliable results.
- [How it works](xref:AIAgent_App_Agent_How_It_Works): A short technical explanation of the apps the agent builds.
- [Deploying an app](xref:AIAgent_App_Agent_Deploying): How to add the app to your DataMiner System, and the current limitations.
