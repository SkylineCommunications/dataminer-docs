---
uid: AIAgent_App_Agent_Example_Replace_Visio
description: "Step-by-step example: let the DataMiner App Agent analyze a Visual Overview, plan the rebuild in milestones, and replace it with a web app."
---

# Replacing a Visual Overview

In this example, you use the [DataMiner App Agent](xref:AIAgent_App_Agent) to rebuild a [Visual Overview](xref:About_Visual_Overview) as a custom web app. As an example, a Visual Overview of a signal chain is used: a background drawing with shapes that show the alarm state of devices, a few key parameter values, buttons to switch between a primary and a backup chain, and a button that executes a switchover script.

A web app can offer a responsive layout that works on any screen size, and it can be maintained without Microsoft Visio.

The agent analyzes the Visual Overview from two sources, so that you do not have to document it yourself:

- **The Visio file (.vsdx)** tells the agent *what* each shape does. A .vsdx file is a ZIP package with XML files, from which the agent can read the pages, the shapes, and their [shape data](xref:Overview_of_DataMiner_shape_data_fields).
- **The Visual Overview in the browser** shows the agent *how* it looks and behaves with real data. The agent takes screenshots and clicks through the pages.

> [!NOTE]
> In the web apps, a Visual Overview is rendered on the DataMiner Agent and sent to the browser as images. The captured network traffic therefore does not show which data each shape uses. This is why the agent also needs the .vsdx file.

## Prerequisites

- The App Agent is [installed](xref:AIAgent_App_Agent#installing-the-agent), and you meet all [prerequisites](xref:AIAgent_App_Agent#prerequisites).
- Your AI client has a browser tool the agent can use. See [Letting the agent inspect your DataMiner System](xref:AIAgent_App_Agent_Using#letting-the-agent-inspect-your-dataminer-system).
- The Visual Overview is available on a non-production DataMiner System with representative data.
- You have the Visio file (.vsdx) of the Visual Overview, e.g., by opening it in edit mode in DataMiner Cube and saving a copy.
- The Visual Overview can be opened in a browser, e.g., in a dashboard with a [Visual Overview component](xref:DashboardVisualOverview). Note the URL.

## Overview

| Milestone | Result | What you review |
|---|---|---|
| 1. Analyze the Visual Overview | `reference/inventory.md` with screenshots and the meaning of every shape | Is every shape and behavior in the inventory? |
| 2. Plan the rebuild | `plan.md` with the build milestones | Is this the app you want, in the right order? |
| 3. Layout | The background and the device indicators at the right positions, without live data | Does it look like the Visual Overview, also on other screen sizes? |
| 4. Live data | Alarm colors and parameter values, updated in real time | Do the colors and values match the Visual Overview? |
| 5. Navigation and details | Switching between chains, and a details panel per device | Does it behave like the Visual Overview? |
| 6. Actions | The switchover button | Does it have the same effect in DataMiner? |
| 7. Switch over | Users open the new app instead of the Visual Overview | Do users find and use the new app? |

## Milestone 1: Let the agent analyze the Visual Overview

1. Create an empty workspace folder, e.g., `C:\Apps\signal-chain`, with a `reference` subfolder.

1. Copy the .vsdx file into the `reference` folder.

1. Optionally, add an SVG export of the background, e.g., `reference/background.svg`, if the drawing has a background you want to keep, such as a floor plan or a signal chain diagram. In Visio, remove the DataMiner shapes from a copy of the page, and save the page as SVG via *File > Save As*.

1. Open the workspace folder in your AI client, and select *DataMiner App Agent*.

1. Enter a prompt that asks for an analysis only. For example:

   ```text
   We are going to replace a DataMiner Visual Overview with a custom app. Do not build anything yet.

   1. Read reference/signal-chain.vsdx. For every page, list every shape that has DataMiner shape data (Element, Parameter, View, Service, Link, Execute, SetVar, etc.), with its value, its position, and what it shows or does.
   2. Open the Visual Overview in the browser: https://my-dma/dashboard/#/db/signal-chain.dmadb
      I will sign in when you ask me to.
      Take a screenshot of every page, and save them in reference/screenshots. Click the navigation buttons to see how the pages are linked. Do not click any shape that executes a script or changes data.
   3. Match the shapes from the .vsdx file with what you see in the browser.

   Write the result to reference/inventory.md, and list anything you could not interpret.
   ```

1. When the agent opens the Visual Overview, sign in in the shared browser, and tell the agent you are done.

1. Review `reference/inventory.md`, and add what the agent cannot know: the meaning of shapes that only make sense with operational knowledge, how operators use the Visual Overview, and which parts are no longer needed.

> [!TIP]
> To capture different states, e.g., with and without alarms, raise a test alarm on the test system while the agent takes screenshots, or ask the agent to describe the expected appearance per state based on the shape data.

## Milestone 2: Plan the rebuild

1. Ask the agent to create a plan based on the inventory. For example:

   ```text
   Based on reference/inventory.md, create plan.md for a new app called "Signal Chain" that replaces the Visual Overview. Do not write code yet.

   - Use reference/background.svg as the background of the main page, with the device indicators at the same positions as the shapes, also when the window is resized.
   - Clicking a device opens a side panel with its active alarms and key parameters, instead of opening the element card.
   - The switchover button executes the Automation script "Chain_Switchover" and asks for confirmation first.

   Split the work into milestones that I can each review against the Visual Overview:
   the layout without live data, then the live alarm colors and values, then the navigation and details panel, then the switchover action.
   ```

1. Review the plan, and check in particular how the agent translates the Visual Overview features. The following table shows how they are typically translated:

   | Visual Overview feature | In the app built by the agent |
   |---|---|
   | Shape linked to an element, service, or view | An indicator that shows the alarm state, retrieved with a GQI query and updated in real time. |
   | Shape that displays a parameter value | A value retrieved with a GQI query and updated in real time. |
   | Page navigation and links to other pages | Pages, tabs, or routes in the app. |
   | Shape that opens an element card | A detail panel in the app. |
   | Shape that executes an Automation script | A button that calls the Automation script and shows its result. |
   | Session variables (SetVar) | Application state, e.g., a selected item. |
   | Background drawing | An SVG or image, with the indicators positioned on top of it. |

   Some Visual Overview features have no direct equivalent and need extra effort, e.g., dynamically generated shapes based on filters, connectivity lines based on DCF connections, or embedded DataMiner Cube components such as trend graphs. Make sure the plan states how these are handled.

1. Answer the open questions in the plan, and let the agent update it until you agree with it.

## Milestones 3 to 6: Build and validate one milestone at a time

Repeat the following for every build milestone in `plan.md`:

1. Ask the agent to implement the next milestone, e.g., "Implement milestone 3 from plan.md".

1. When the agent asks for the URL and credentials of your DataMiner System to discover the queries, provide the details of the non-production system.

1. Let the agent finish the implementation, the tests, and the build. [Deploy the build](xref:AIAgent_App_Agent_Deploying) to the DataMiner Agent.

1. Let the agent compare the new app with the Visual Overview in the browser. For example:

   ```text
   The build of milestone 4 is deployed at https://my-dma/public/signal-chain/index.html.
   Open the Visual Overview and the new app in the browser, take screenshots of both, and compare the alarm color and the values of every device in the inventory.
   Report every difference, and fix the differences that are not intended.
   ```

1. Check the result yourself as well: raise and clear a test alarm, and check that both show the change. Check the layout on the screens your operators use.

1. Commit the workspace to Git, and let the agent mark the milestone as done in `plan.md`.

For the milestone with actions, such as the switchover, test the action yourself on the test system, and check the result in DataMiner.

## Milestone 7: Switch users over

Depending on how users currently open the Visual Overview, choose one of the following options:

- **Users open the app directly**: Share the sign-in URL of the app, or [add the app to the landing page](xref:AIAgent_App_Agent_Deploying#step-4-optional-add-the-app-to-the-dataminer-landing-page).

- **Users open the Visual Overview from DataMiner Cube**: During the transition, you can show the new app inside the existing Visual Overview. Add a shape that fills the page, and [link it to a webpage](xref:Linking_a_shape_to_a_webpage) with a "#" in front of the URL, so that the page is displayed inside the shape. For example:

  ```txt
  #https://my-dma/public/signal-chain/index.html
  ```

  Depending on the client, users may need to sign in again inside the embedded page. Test this with a regular user account before you roll it out.

When users have switched over, you can remove the original Visual Overview, or keep only the page that embeds the new app. Store the source workspace of the new app, including `plan.md` and the `reference` folder, in a repository, so that it can be maintained later.
