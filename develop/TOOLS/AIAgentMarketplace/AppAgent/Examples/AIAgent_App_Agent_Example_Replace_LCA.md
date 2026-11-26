---
uid: AIAgent_App_Agent_Example_Replace_LCA
description: "Step-by-step example: let the DataMiner App Agent analyze an existing low-code app in the browser, plan the rebuild in milestones, and switch users over."
---

# Replacing an existing low-code app

In this example, you use the [DataMiner App Agent](xref:AIAgent_App_Agent) to rebuild an existing [low-code app](xref:Application_framework) as a custom web app. As an example, an *Order Tracker* low-code app is used, with an *Orders* page, a *Planning* page, a details panel, and a *Cancel order* button that executes an Automation script.

Instead of documenting the low-code app yourself, you let the agent open it in a browser and analyze it. The agent sees the app as users see it, and captures the GQI queries and Automation script calls the app makes. You then review the analysis, let the agent plan the rebuild in milestones, and build and validate it one milestone at a time.

> [!TIP]
> You do not need to replace a low-code app that works well. Consider a replacement when the low-code app is hard to maintain, slow because of many components and queries, or when users ask for an experience that the low-code tools cannot offer.

## Prerequisites

- The App Agent is [installed](xref:AIAgent_App_Agent#installing-the-agent), and you meet all [prerequisites](xref:AIAgent_App_Agent#prerequisites).
- Your AI client has a browser tool the agent can use. See [Letting the agent inspect your DataMiner System](xref:AIAgent_App_Agent_Using#letting-the-agent-inspect-your-dataminer-system).
- The low-code app is available on a non-production DataMiner System, with representative data. If the app only exists on a production system, make a copy of it available on a test system first.
- You have access to the low-code app, and preferably edit rights.

## Overview

| Milestone | Result | What you review |
|---|---|---|
| 1. Analyze the low-code app | `reference/inventory.md` with screenshots, queries, and scripts | Is everything the app does in the inventory? |
| 2. Plan the rebuild | `plan.md` with the build milestones | Is this the app you want, in the right order? |
| 3. Main page, read-only | The *Orders* page with real data | Does it show the same data as the low-code app? |
| 4. Interactions | Filters, selection, and the details panel | Does it behave like the low-code app? |
| 5. Actions | The *Cancel order* button | Does it have the same effect in DataMiner? |
| 6. Other pages and improvements | The *Planning* page and the requested improvements | Is the app complete? |
| 7. Switch over | Users open the new app from the same place | Do users find and use the new app? |

## Milestone 1: Let the agent analyze the low-code app

1. Create an empty workspace folder, e.g., `C:\Apps\order-tracker`, and open it in your AI client.

1. Select *DataMiner App Agent*.

1. Enter a prompt that asks for an analysis only. For example:

   ```text
   We are going to replace our low-code app "Order Tracker" with a custom app. Do not build anything yet.

   Open the low-code app in the browser: https://my-dma/app/<app ID>
   I will sign in when you ask me to.

   Go through every page and panel of the app, and:
   - Take a screenshot of every page and panel, also after selecting a row and after using the filters. Save them in reference/screenshots.
   - Capture the network requests and WebSocket messages while you do this, and identify every GQI query the app executes, and which component uses it.
   - Identify every Automation script the app executes, with its parameters, from the configuration of the buttons. Do not click any button that executes a script or changes data.

   Write the result to reference/inventory.md: for every page and panel, the components, the query behind each component, the interactions between components, and the actions. List what you could not determine.
   ```

1. When the agent opens the app, sign in in the shared browser, and tell the agent you are done.

1. Let the agent go through the app. This can take a few minutes for an app with many pages.

1. Review `reference/inventory.md`, and add what the agent cannot see in the app itself:

   - Who uses the app, and for what.
   - The [security settings](xref:LowCodeApps_security_config) of the app.
   - Business rules that are not visible, e.g., "Orders older than 30 days are archived by a scheduled script".
   - Parts of the app that are no longer used and do not need to be rebuilt.

> [!TIP]
> If you have edit rights, you can also let the agent open the low-code app in edit mode to read the configuration of components, events, and feeds. Tell it explicitly not to save or publish anything. From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards, you can also [export the queries to JSON](xref:Exporting_a_query) yourself and add them to the `reference` folder, e.g., when a query in the captured traffic is hard to interpret.

## Milestone 2: Plan the rebuild

1. Ask the agent to create a plan based on the inventory. For example:

   ```text
   Based on reference/inventory.md, create plan.md for a new app called "Order Tracker" that replaces the low-code app. Do not write code yet.

   Keep the same functionality and data. In addition:
   - The details panel should open without reloading the table.
   - Show the number of orders per status as counters above the table.

   Split the work into milestones that I can each review against the low-code app:
   the Orders page read-only, then the filters and details panel, then the Cancel order action, then the Planning page and the improvements.
   For each milestone, describe what I should compare with the low-code app.
   ```

1. Review the plan, and check in particular how the agent translates the low-code app concepts. The following table shows how they are typically translated:

   | Low-code app concept | In the app built by the agent |
   |---|---|
   | Page | A page or tab in the app's navigation. |
   | Panel | A side panel, dialog, or expandable section. |
   | Component with a GQI query | A user interface element that executes the same query. |
   | Feed (e.g., a table selection that filters another component) | Application state that is shared between parts of the app. |
   | Event that executes an Automation script | A button or action that calls the Automation script and shows its result. |
   | Interactive Automation script | A dialog in the app's own style that drives the same script. |
   | App security | The security of the low-code app that shows the new app, plus the user permissions in DataMiner. See [milestone 7](#milestone-7-switch-users-over). |

1. Answer the open questions in the plan, and let the agent update it until you agree with it.

## Milestones 3 to 6: Build and validate one milestone at a time

Repeat the following for every build milestone in `plan.md`:

1. Ask the agent to implement the next milestone, e.g., "Implement milestone 3 from plan.md".

1. When the agent asks for the URL and credentials of your DataMiner System to discover or validate the queries, provide the details of the non-production system.

1. Let the agent finish the implementation, the tests, and the build. [Deploy the build](xref:AIAgent_App_Agent_Deploying) to the DataMiner Agent.

1. Let the agent compare the new app with the low-code app in the browser. For example:

   ```text
   The build of milestone 3 is deployed at https://my-dma/public/order-tracker/index.html.
   Open the low-code app and the new app in the browser, and compare the Orders page:
   - Take screenshots of both, with the same filter.
   - Check that both show the same rows, columns, and values.
   Report every difference, and fix the differences that are not intended.
   ```

1. Check the result yourself as well, in particular what the agent cannot judge: whether the app is easy to use, and whether it behaves correctly for a user with limited permissions.

1. Commit the workspace to Git, and let the agent mark the milestone as done in `plan.md`.

For the milestone with actions, such as *Cancel order*, test the action yourself on a test item, and check the result in DataMiner. Do not let the agent click buttons that change data on a system that is used by others.

When all milestones are done, ask a few key users to test the new app.

## Milestone 7: Switch users over

To switch users over without changing their bookmarks or the landing page, replace the content of the existing low-code app with the new app:

1. Open the existing low-code app in edit mode.

1. Optionally, [duplicate the app](xref:Creating_custom_apps#duplicating-an-existing-low-code-app) first, so that you keep the original version for reference.

1. Remove the existing components from the first page, and add a [web component](xref:DashboardWeb) that fills the entire page. Configure it as described under [Adding the app to the DataMiner landing page](xref:AIAgent_App_Agent_Deploying#step-4-optional-add-the-app-to-the-dataminer-landing-page).

1. Remove the other pages, which are now part of the new app.

1. Publish the low-code app.

Users keep opening the app from the same place on the landing page, with the same security settings, but now see the new app.

When the new app has been in use for a while without issues:

- Delete the duplicate of the original low-code app, if you created one.
- Check whether the Automation scripts and ad hoc data sources the original app used are still needed.
- Store the source workspace of the new app, including `plan.md` and the `reference` folder, in a repository, so that it can be maintained later.
