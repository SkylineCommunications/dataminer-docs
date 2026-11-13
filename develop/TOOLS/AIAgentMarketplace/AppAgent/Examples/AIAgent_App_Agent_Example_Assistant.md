---
uid: AIAgent_App_Agent_Example_Assistant
description: "Step-by-step example: integrate a DataMiner Assistant agent into an app with the DataMiner App Agent, from a chat panel to contextual actions."
---

# Integrating the DataMiner Assistant into an app

In this example, you use the [DataMiner App Agent](xref:AIAgent_App_Agent) to add a [DataMiner Assistant](xref:Intelligence_Assistant_app) agent to an existing app. The Assistant agent can then answer questions, analyze alarms, or make suggestions directly in the context of your app, instead of in a separate chat window.

> [!IMPORTANT]
> The app communicates with the Assistant through the same API calls as the DataMiner Assistant app. These calls are not yet part of the documented [Web Services API](xref:Using_the_Web_Services_v1) and can change in future versions of the Assistant DxM. Test the integration again after you upgrade the Assistant DxM.

## Prerequisites

- The App Agent is [installed](xref:AIAgent_App_Agent#installing-the-agent), and you meet all [prerequisites](xref:AIAgent_App_Agent#prerequisites).
- An app that was built with the App Agent, e.g., the app from [Building an app from scratch](xref:AIAgent_App_Agent_Example_From_Scratch).
- The [Assistant DxM](xref:Intelligence_Assistant_DxM), with the [DataMiner Assistant app](xref:Intelligence_Assistant_app) enabled.
- The users of the app have access to the DataMiner Assistant.

## Step 1: Choose or create the Assistant agent

The app connects to one Assistant [agent](xref:Intelligence_Assistant_Agents). You can use:

- A **native agent**, e.g., the [DataMiner Insights agent](xref:Intelligence_Assistant_InsightsAgent).
- A **[specialized agent](xref:Intelligence_Assistant_Specialized_Agents)** that you create for this app, with instructions, tools, and skills tailored to its purpose, e.g., an agent that knows the escalation rules of your NOC.

Test the agent in the Assistant app first, with the questions you plan to ask from your app. If the answers are not good in the Assistant app, they will not be good in your app either. Note the exact name of the agent: the app looks up the agent by name, because agent IDs differ between systems.

## Step 2: Choose an integration pattern

Decide how the agent should appear in your app. The following patterns are listed from the least to the most autonomous:

| Pattern | What the user sees | What the agent does |
|---|---|---|
| Chat panel | An *Assistant* button that opens a side panel. | Answers free questions in one conversation, with the context of the current screen. |
| Suggest | A *Suggest* button, e.g., above a list. | Recommends which item to handle first, with its reason. The user decides. |
| Contextual action | An action on an item, e.g., *Analyze* on an alarm. | Analyzes that one item, e.g., probable cause, impact, and next step. |
| Briefing | An overview panel that is filled when the app opens. | Writes a summary of the current situation, with a *Refresh* button. |
| Background draft | A draft that appears after the app has loaded. | Prepares a message or report. The user edits, approves, or discards it. |
| Autonomous | An on/off switch, off by default. | Periodically decides something in the app, e.g., which item to focus on, with an activity log, *Undo*, and *Pause*. |

Start with the chat panel or a contextual action: these are the easiest for users to understand and to trust.

## Step 3: Plan the integration in milestones

1. Open the workspace of your app in your AI client, and select *DataMiner App Agent*.

1. Describe the integration you want, and ask for a plan first. Replace the agent name and items with your own. For example, for a chat panel and a contextual action:

   ```text
   I want to add my DataMiner Assistant agent "NOC Advisor" to this app. Do not write code yet. Add the integration to plan.md as new milestones:

   1. A chat panel: an Assistant button in the header opens a side panel with suggested questions and free input. Every question goes to the agent in the same conversation. Show that the answers come from the agent, a loading state with the progress steps, and an error message with Try again.
   2. Screen context: every question also contains the context of the screen (the selected site and its active alarms).
   3. A contextual action: an Analyze icon on every active alarm in the detail panel. Clicking it shows the agent's analysis of that alarm under the row: probable cause, impact, and a suggested next step. Nothing is changed in DataMiner.

   The rest of the app must keep working if the Assistant is not available.
   ```

1. Review the plan. Make sure the first milestone is small: a working connection with the Assistant agent is the basis for everything else.

## Step 4: Build, deploy, and verify one milestone at a time

For every milestone:

1. Ask the agent to implement it, e.g., "Implement the chat panel milestone from plan.md". The agent implements the integration, extends the tests, and creates a new build.

1. [Deploy the new build](xref:AIAgent_App_Agent_Deploying#updating-an-app) to the DataMiner Agent.

1. Open the app, and try the integration with real data:

   - Does the agent receive the right context? Ask, e.g., "Which site am I looking at?".
   - Is it clear to the user which content comes from the agent?
   - Does the app keep working when the Assistant is slow or not available?

1. Test the app with a user account that has the permissions of the intended users. The agent only sees the data that the signed-in user has access to.

1. Commit the workspace to Git, and let the agent mark the milestone as done in `plan.md`.

If the integration does not work, ask the agent to [open the app in the browser](xref:AIAgent_App_Agent_Using#letting-the-agent-inspect-your-dataminer-system) and inspect the WebSocket messages between the app and the Assistant.

## How it works

The app talks to the Assistant in the same way as the DataMiner Assistant app does:

1. When the app loads, it checks whether the Assistant feature is available, and looks up the configured agent by name.

1. It retrieves the models available for the agent, and uses the default model and reasoning level.

1. It starts a chat session over the app's WebSocket connection, with the user's time zone and language.

1. For every request, it sends the prompt together with the context of the screen, e.g., the selected items as text.

1. The answer is streamed back in parts, together with the progress steps of the tools the agent uses, until the answer is complete.

The chat panel reuses the same chat session for follow-up questions. The other patterns usually start a new chat session for each request, so that every analysis starts without earlier context.

All calls use the session of the signed-in user, so no extra credentials are needed.

## Best practices

- **Keep the user in control.** Let the agent advise, analyze, and draft, but let the user decide and act. Only use the autonomous pattern for decisions within the app itself, and make it easy to undo and pause.
- **Label agent output.** Show clearly which content is generated by the agent, and when it was generated.
- **Pass the context explicitly.** The agent only knows what the app sends with the prompt and what it can retrieve with its own tools. Ask the agent to include the relevant screen context with every request.
- **Plan for slow answers.** An answer can take from a few seconds up to a few minutes. Show progress, allow users to keep working, and show a clear error with a retry option when an answer does not arrive.
- **Keep the app usable without the Assistant.** The integration should never block the rest of the app.

> [!TIP]
> If you only need a chat with an Assistant agent, without integration into your own app, you can also use the [Assistant chat component](xref:DashboardAssistantChat) in a low-code app or dashboard.
