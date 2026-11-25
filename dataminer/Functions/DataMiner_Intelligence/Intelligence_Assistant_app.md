---
uid: Intelligence_Assistant_app
description: "Use the DataMiner Assistant app to chat with DataMiner Intelligence agents, ask questions, and explore information in your DataMiner System."
---

# DataMiner Assistant app

The DataMiner Assistant app is the built-in chat interface for [DataMiner Intelligence agents](xref:Intelligence_Agents). Use it to ask questions and explore information from your DataMiner System. Depending on the agent you choose, it can use different sources, tools, and skills to answer your questions.

## Accessing the Assistant app

You can access the Assistant app from the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page).

If you cannot see the app there, make sure DataMiner Intelligence has been fully set up. See [Getting started with DataMiner Intelligence](xref:Intelligence_Getting_Started).

![Assistant app icon on the DataMiner landing page](~/dataminer/images/AssistantDxM_AssistantIcon.png)<br>*DataMiner Assistant app icon on the DataMiner landing page in DataMiner Web 10.7.1*

You can also chat with DataMiner Intelligence agents from Microsoft Teams or Microsoft Copilot using [DataMiner Assistant for Microsoft 365](xref:Intelligence_Assistant_M365).

## Assistant app user interface

When you open the app, a welcome screen is displayed with the following elements:

![Assistant app welcome screen, including suggestion cards, agent selector, model selector, and chat input box](~/dataminer/images/Assistant.png)<br>*DataMiner Assistant welcome screen in DataMiner Web 10.7.1*

- **Left sidebar**: Allows you to start a new session at any time by clicking *+ New session*. Below that, you can access your sessions, [agents](xref:Intelligence_Agents), [skills](xref:Intelligence_Skills), and [tools](xref:Intelligence_Tools).

  > [!NOTE]
  > The *Agents* button is always visible in the sidebar. However, you can only create a new agent on that page if the *Specialized agents* setting is enabled. See [specialized agents](xref:Intelligence_Specialized_Agents).

- **Header bar**: The header bar is similar to other native DataMiner apps, with a button to return to the landing page on the left, and a user icon on the right. Clicking the user icon opens a menu with the following options:

  - *About*: Provides access to information about the app, including the version of the app and all of its components.
  - *Settings*: Allows you to select whether the time zone configured in the client operating system is used or a custom time zone.
  - *Sign out*: Logs you out of the app and returns you to the logon screen.

- **Suggestion cards**: A set of predefined prompts to help you get started quickly. These are only available for native AI agents and are unique to the selected agent, providing relevant starting points tailored to that agent's capabilities.

- **Chat input box**: Located at the bottom of the screen, this is where you type your questions. While the agent is working, the chat shows the tools it invokes and the reasoning steps it performs.

  When you start a chat, the app automatically shares your browser's detected time zone and language with the agent. This lets the agent determine your preferred formatting for dates, times, and numbers without any manual configuration. See [Agent context](xref:Intelligence_Agents#agent-context).

  Within the chat input box, the following features are available:

  - **Agent selector**: In the lower-left corner of the chat input, select which agent handles your conversation (e.g., [DataMiner Insights](xref:Intelligence_InsightsAgent)). You can switch between native agents and [specialized agents](xref:Intelligence_Specialized_Agents) as needed. The app restores your last selected agent when you reopen the chat.

  - **Reasoning level selector**: A speed option (e.g., *Fast*) that lets you choose between faster responses and deeper reasoning. The selected reasoning level is preserved across sessions for models that support reasoning.

  - **Model selector**: In the lower-right corner, you can choose which model answers your question (e.g., GPT-5.6 Luna). The last selected model is remembered across sessions.

  - **Speech-to-text**: A microphone button next to the chat input that allows you to use speech-to-text for entering your questions.
