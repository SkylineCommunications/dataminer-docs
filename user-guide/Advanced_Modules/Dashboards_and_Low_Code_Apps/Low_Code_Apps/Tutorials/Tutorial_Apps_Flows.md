---
uid: Tutorial_Apps_Flows
keywords: flows
---

# Using flows in a Low-Code Apps

In this tutorial, you will learn how to create a flow (See: [Flows](xref:Using_flows) to learn more about what a flow is). You'll then use a flow to make a timeline only load the items inside of the timeline viewport and reuse a panel using data coming from multiple components.

> [!NOTE]
> This tutorial uses DataMiner web version 10.5.2.

## Prerequisites

- DataMiner server 10.4.0/10.3.9 or higher and Dataminer web 10.5.2 or higher.

- Deploy this package to your DataMiner System. [Catalog](https://catalog.dataminer.services/details/4149a3a6-f87d-466e-bf09-1503a5a0dbb5).

  > [!TIP]
  > For information on how to deploy a package, see [Deploying a Catalog item](xref:Deploying_a_catalog_item).

## Overview

- [Step 1: Open the Flows app](#step-1-open-the-flows-app)

- [Step 2: Make the timeline only load items inside the viewport](#step-2-make-the-timeline-only-load-items-inside-the-viewport)

- [Step 3: Reuse a panel](#step-3-reuse-a-panel)

## Step 1: Open the Flows app

In this tutorial, you will use the app provided in the prerequisites. This app contains three different pages:

- An overview page of the two operators you will be using today.
- A timeline exercise where you will only fetch the items inside the viewport instead of all data (50000 rows).
- A panel reuse exercise where you will reuse a single panel for two component data outputs.

After installing the package, go to the root webpage: https://<YourDmaIP>/root and open the "Flows" app. You can then either explore the operators or directly start on the exercises by editing the app.

## Step 2: Make the timeline only load items inside the viewport

In this step, you will modify the timeline to fetch only the items that are within the viewport. This optimization significantly speeds up the initial load of the timeline. Flows are essential for ensuring the app doesn't start fetching the new data multiple times every time a user zooms out.

1. Create a new flow by opening the Flows section in the right sidebar and clicking the '+' icon.

   ![Creating new flow](~/user-guide/images/CreatingNewFlow.gif)

1. Give a name to the flow by typing in the Name textbox 

1. Add the viewport as the starting point of the flow by navigating to the *Data* tab, opening the *Components* expander, opening the *Timeline* component, and then dragging the *Viewport timespan* to the middle section of the editor.

   ![Adding viewport to flow](~/user-guide/images/AddingViewportToFlow.gif)

1. Open the *Operators* tab in the left sidebar of the editor. Then drag the *Debounce* operator on the middle section of the editor. Change the time value to 500ms by selecting the operator we just added and changing the value in the right sidebar.

1. Connect the *Viewport* source to the *Debounce* operator by connecting the bottom of the viewport to the top of the debounce block. 

   ![Linking viewport and debounce](~/user-guide/images/LinkingViewportAndDebounce.gif)

1. Save the Flow by clicking the *Create* button

1. Now we need to plug in this new flow into the query that is populating the timeline component. To do this open the query section in the right panel of the low code app editor. The query that needs to be editted here is the *Bookings filtered* query. Edit it by clicking the pencil icon. 

1. Add a filter operator to the GQI query and select the *From* column. Choose the 'Greater than or equals' filter method and link the value to the *From* property of the flow you just created.

   ![Linking debounced viewport to from query](~/user-guide/images/LinkingDebouncedViewportToFromQuery.gif)

1. Add another filter for the *Till* column of the query, the filter method should be 'Less than or equals' and the value should be linked to the *To* property of the flow. 

1. Now only the items in the viewport are fetched, and when zooming out, a debounce of 500ms is applied so the app does not fetch multiple times while the user is still scrolling.

## Step 3: Making the timeline only load items in the viewport

In this second step, we will reuse a panel to handle a selection from two different components. Before the introduction of flows, this was only possible by copying the entire panel and changing the used data for each panel. Now this is possible by using a *Merge* operator in a flow. Note that the query used in both components needs to be the same or have the same node keys. There are already actions configured to open the panel on double-click of both tables. So let's configure this panel to handle both selections.

1. Open the *Reusing Panels* page. 

1. Select a row in both tables. This makes both component selections available within the flow editor.

1. Create a new flow and give it a name.

   ![Create merged tables Flow](~/user-guide/images/CreateMergedTablesFlow.gif)

1. Add both table row selections to the flow. 

1. Add the *Merge* opererator to the center of the editor and link both selections to the merge. You can then go ahead and create this flow by clicking *Create* button

   ![Merged tables Flow](~/user-guide/images/MergedTablesFlow.png)

1. Edit the panel so you can plug in the newly created flow. To do this, remove the *Tables* data that is now used in the grid. Then add the flow you've just created to the grid component instead. Since we now use a new data source for the component, you can set the grid to use the entire width of the component again by selecting the grid and applying the following configuration.

   ![Configure grid](~/user-guide/images/ConfigureGridForFlow.png)

1. Done! You can now reuse this panel to open details for both tables by double-clicking on a table entry.

   ![Configure grid](~/user-guide/images/ReusePanelFlows.gif)
