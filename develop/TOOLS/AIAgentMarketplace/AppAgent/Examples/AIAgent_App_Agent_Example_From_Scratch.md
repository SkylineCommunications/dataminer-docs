---
uid: AIAgent_App_Agent_Example_From_Scratch
description: "Step-by-step example: build a site health overview app from scratch with the DataMiner App Agent and deploy it to DataMiner."
---

# Building an app from scratch

In this example, you use the [DataMiner App Agent](xref:AIAgent_App_Agent) to build a new app from scratch: a **site health overview** for a network operations center (NOC). The app shows all sites with their worst active alarm, and lets operators drill down to the elements and alarms of a site.

Expected duration: 1 to 2 hours, depending on the number of milestones.

## Prerequisites

- The App Agent is [installed](xref:AIAgent_App_Agent#installing-the-agent), and you meet all [prerequisites](xref:AIAgent_App_Agent#prerequisites).
- Your DataMiner System has a view per site, e.g., below a view named *Sites*, with elements in each site view. If your system is organized differently, adapt the prompt.
- You have a DataMiner user account for the agent with read access to these views.

## Step 1: Prepare the workspace

1. Create an empty folder on your computer, e.g., `C:\Apps\site-overview`.

1. Open the folder in Visual Studio Code (*File > Open Folder*).

1. Open the Copilot Chat panel, and select *DataMiner App Agent* in the agent picker.

## Step 2: Describe the app

Enter a prompt that covers the app name, the key features, the data sources, and any write-back operations. For example:

```text
Create a new app called "Site Overview" for the operators in our NOC. It runs on a large wall screen and on operator desktops.

Key features:
- A grid of tiles, one per site. Each tile shows the site name, the number of active alarms, and is colored by the worst alarm severity of that site.
- Sites with a critical alarm are always shown first.
- Clicking a tile opens a detail panel with the elements of that site, their state, and the active alarms of the site, sorted by severity and time.
- A search box to filter the sites by name.
- The data updates in real time.

Data sources:
- Sites are the child views of the view "Sites".
- Elements and active alarms come from the elements in each site view.

Write-back: none, the app is read-only.

Do not write code yet. First create plan.md with the pages, the data, the open questions, and the milestones to build the app. Each milestone must give me something I can review in the browser.
```

> [!TIP]
> Use the exact names as they appear in DataMiner, e.g., the name of the view. This makes the data discovery more accurate.

## Step 3: Answer the agent's questions

The agent may ask questions when something is unclear, e.g., which columns to show in the alarm list. Answer them in the chat.

The agent then asks for:

- The URL of your DataMiner System, e.g., `https://my-dma`.
- The user name and password of the DataMiner user account for the agent.

The agent uses these to sign in once and discover the GQI queries for the sites, elements, and alarms. Your AI client may ask you to allow the commands the agent runs; review and allow them.

## Step 4: Review the plan

Open `plan.md`, and check that it describes the app you want. For this app, a good set of milestones is, for example:

1. The site tiles with the site name and the number of active alarms, with real data.
1. The tile colors by worst alarm severity, the sorting with critical sites first, and real-time updates.
1. The detail panel with the elements and active alarms of a site.
1. The search box, and the empty, loading, and error states.

Correct the plan where needed, e.g., "Move the search box to milestone 1, operators need it from the start", and let the agent update it.

## Step 5: Build and review one milestone at a time

For every milestone in the plan:

1. Ask the agent to implement it, e.g., "Implement milestone 1 from plan.md".

   The first time, the agent creates the project in a subfolder, e.g., `site-overview-app`, and installs the dependencies. For every milestone, it implements the features, creates or extends the Playwright end-to-end tests, runs the tests, and creates the production build. It then reports the name of the build folder, e.g., `site-overview`, and the URL to open the app.

1. Copy the build folder to `C:\Skyline DataMiner\Webpages\Public` on the DataMiner Agent.

1. Open `https://<dma>/auth/?url=%2Fpublic%2Fsite-overview%2Findex.html`, sign in, and check the milestone with real data. For example:

   - Do the site tiles match the views in DataMiner Cube?
   - Does the color of a tile change when an alarm is raised or cleared?
   - Does the detail panel show the correct elements and alarms?

1. If something does not look right, describe what you see and what you expected, e.g., "The tile of site Brussels is green, but there is a major alarm on element BRU-ENC-01". You can also ask the agent to [open the app in the browser](xref:AIAgent_App_Agent_Using#letting-the-agent-inspect-your-dataminer-system) and check it itself.

1. When the milestone is OK, commit the workspace to Git, and let the agent mark the milestone as done in `plan.md`.

For more information, see [Deploying an app](xref:AIAgent_App_Agent_Deploying).

## Step 6: Improve the app

When all milestones are done, ask for further improvements one at a time, and redeploy after each change. For example:

```text
Add a wall screen mode: a button in the header that hides the search box and the header, and enlarges the tiles. Pressing Esc returns to normal mode.
```

```text
In the detail panel, show for each alarm how long it has been active, e.g., "12 min".
```

For a larger improvement, ask the agent to add it to `plan.md` as a new milestone first.

## Step 7: Add the app to the landing page

Optionally, [add the app to the DataMiner landing page](xref:AIAgent_App_Agent_Deploying#step-4-optional-add-the-app-to-the-dataminer-landing-page) by creating a low-code app that shows it full screen.
