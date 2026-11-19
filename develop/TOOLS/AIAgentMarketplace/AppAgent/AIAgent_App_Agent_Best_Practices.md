---
uid: AIAgent_App_Agent_Best_Practices
description: "Get better and more reliable results from the DataMiner App Agent with these best practices for prompting, data, security, and maintenance."
---

# DataMiner App Agent best practices

The following best practices help you get better and more reliable results from the [DataMiner App Agent](xref:AIAgent_App_Agent).

## Make a plan and work in milestones

The most important best practice is to **plan before you build**. An agent that starts coding from a single long prompt makes many decisions on its own, and mistakes in early decisions are expensive to correct later. A good plan, split into small milestones, keeps you in control and makes every result easy to review.

### Let the agent write the plan first

Start every new app, and every large change, by asking for a plan instead of code. For example:

```text
Do not write any code yet. Based on my description and the reference material, create plan.md with:
- The goal of the app and its users.
- The pages, panels, and main interactions.
- The data each part needs, and where it comes from in DataMiner.
- The actions that change data in DataMiner.
- Open questions and assumptions.
- The milestones to build it, with for each milestone what I can review when it is done.
```

Review the plan carefully. This is the cheapest moment to correct a misunderstanding: changing a line in `plan.md` takes seconds, while changing a finished app takes a lot more effort. Answer the open questions, correct the assumptions, and ask the agent to update the plan until it describes exactly what you want.

### Split the work into milestones

A good milestone:

- **Delivers something you can see and test**, e.g., "The Orders page shows the orders table with real data". Avoid technical milestones such as "Set up the state management" that you cannot review.
- **Is small**: one page, one panel, or one group of related interactions.
- **Builds on the previous milestone**, starting with the most important part of the app.
- **Has a clear definition of done**: what you check before you continue with the next milestone.

A typical order is:

1. The layout and navigation, with read-only data on the main page.
1. The interactions on that page, e.g., selection, filtering, and detail panels.
1. The other pages.
1. Actions that change data in DataMiner, e.g., running Automation scripts.
1. Polish: empty states, error messages, responsiveness, and wall screen or mobile layouts.

### Build one milestone at a time

For each milestone:

1. Ask the agent to implement only that milestone, e.g., "Implement milestone 2 from plan.md".
1. Let the agent run the tests and create the build.
1. [Deploy the build](xref:AIAgent_App_Agent_Deploying) and review the result on your DataMiner System.
1. Report what is wrong, and let the agent fix it before you continue.
1. Commit the workspace to Git, and ask the agent to mark the milestone as done in `plan.md`.

> [!TIP]
> Keep `plan.md` in the workspace. When you continue the next day, or start a new chat session, the agent can read the plan to see what has been done and what comes next. Starting a new chat session per milestone also keeps the conversation short and focused.

## Before you start

- **Start from a decision, not from a screen.** Think about which decision or task the app should support, e.g., "Which site does the night shift need to look at first?". An app that answers one clear question is easier to build and more useful than an app that tries to show everything.

- **Know your data.** Find out where the data lives in DataMiner: which views, elements, protocols, parameters, services, or DOM modules. Use the exact names as they appear in DataMiner in your prompt.

- **Use a test system.** Develop against a non-production DataMiner System with representative data. Create a dedicated DataMiner user account for the agent with only the permissions it needs.

## Writing prompts

- **Describe the end result.** Explain what users see and do, not how to implement it. For example: "Operators see a list of all sites with their worst alarm severity. Clicking a site shows its elements and active alarms."

- **Include all four requirement areas** in your first prompt: the app name, the key features, the data sources, and any write-back operations. This saves a round of questions.

- **Mention the users and their context.** For example, "Used on a wall screen in the NOC" or "Used by field engineers on a tablet". This influences layout, font sizes, and interaction.

- **Make one change at a time.** Within a milestone, and after the first version, ask for one visible change per prompt. Small steps are easier to review, and the agent is less likely to break something that already works.

- **Let the agent look instead of describing it yourself.** When the app replaces or extends something that already exists in DataMiner, such as a low-code app, a dashboard, or a Visual Overview, let the agent [open it in a browser](xref:AIAgent_App_Agent_Using#letting-the-agent-inspect-your-dataminer-system) and inspect it. The agent can take screenshots and capture the requests the existing screen makes, which is faster and more accurate than writing down everything yourself. See the practical examples for [low-code apps](xref:AIAgent_App_Agent_Example_Replace_LCA) and [Visual Overview](xref:AIAgent_App_Agent_Example_Replace_Visio).

- **Attach other references.** A sketch, a mockup, or a document that describes the process the app supports helps the agent understand what you want.

- **Be explicit about what must not change.** For example: "Keep the layout and the existing features unchanged. Do not add new libraries."

## Data and actions

- **Describe data needs, not API calls.** The app communicates with DataMiner through the Web Services API, and reads all data by running GQI queries through that API. Describe *which* data you need, e.g., "all active alarms of the elements in the Encoders view", and let the agent discover the query. Do not ask it to use specific Web Services methods to retrieve elements or parameters directly. See [How it works](xref:AIAgent_App_Agent_How_It_Works#communicating-with-dataminer).

- **Check the discovered queries.** If the app shows unexpected data, ask the agent which query it uses for that part of the app, and verify the query in a low-code app or dashboard with the [query builder](xref:About_GQI).

- **Use Automation scripts for actions.** For anything that changes data in DataMiner, prefer an existing, tested Automation script. The app then only starts the script and shows its result. Creating the script itself is outside the scope of the App Agent.

## Security

- Do not put passwords, API keys, tokens, or other secrets in prompts or in the app code. The app uses the session of the signed-in user and does not need any credentials of its own.

- The app runs with the permissions of the signed-in user. Do not rely on hiding buttons in the app to restrict access: configure the correct [user permissions](xref:DataMiner_user_permissions) in DataMiner.

- Review the generated code before you deploy it to a production system, in particular code that performs actions.

## Testing and maintenance

- **Keep the tests.** The end-to-end tests are part of the app. Ask the agent to run and extend them with every change.

- **Use version control.** Commit the workspace to Git after every working version, so that you can review what changed and roll back when needed.

- **Review on the real system.** The automated tests use mocked data. Always open the deployed app on your DataMiner System and check it with real data and with a user account that has the permissions of the intended users.

- **Store the source, not only the build.** The build folder on the DataMiner Agent cannot be changed by the agent. Keep the source workspace in a repository so that you, or a colleague, can make changes later.
