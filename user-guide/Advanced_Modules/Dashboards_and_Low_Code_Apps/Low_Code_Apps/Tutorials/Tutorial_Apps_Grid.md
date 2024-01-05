---
uid: Tutorial_Apps_Grid
---

# Getting started with the grid component

This tutorial demonstrates how you can create your first grid visualization.

Expected duration: 5 minutes.

> [!TIP]
> See also: [Using the Template Editor](xref:Template_Editor)

> [!NOTE]
> This tutorial uses DataMiner version 10.4.1.

## Prerequisites

- A DataMiner System using DataMiner 10.4.1 or higher.
- The [Style a table](xref:Tutorial_Apps_Style_A_Table) tutorial has been completed.

## Overview

- [Step 1: Create a query](#step-1-create-a-query)

- [Step 2: Add a grid component](#step-2-add-a-grid-component)

- [Step 3: Style the grid blocks](#step-3-style-the-blocks)

- [Step 4: Tweak the grid layout](#step-4-tweak-the-grid-layout)

## Step 1: Create a query

You can now create the query using the *Orders.json* file as the data source.

> [!NOTE]
> The *Orders.json* file should have been created while following the [Style a table](xref:Tutorial_Apps_Style_A_Table#step-1-configure-the-query) tutorial.

1. Create a new low-code app. See [Creating low-code applications](xref:Creating_custom_apps).

1. Expand *Queries* in the data pane.

1. Click the + icon to add a new query.

1. Provide the necessary information:

   1. Give the query a name, e.g. "Orders".

   1. In the dropdown box, select *Get ad hoc data*.

   1. Select *JSON Reader* from the *Data source* dropdown list.

   1. Select *Orders.json* from the *Filter* dropdown list.

      ![Query](~/user-guide/images/OrdersQuery.png).

## Step 2: Add a grid component

1. Drag the created query onto an empty section of the low-code app page.

1. Hover the mouse pointer over the component and click the ![Visualizations](~/user-guide/images/DashboardsX_visualizations00095.png) icon.

1. Choose the [grid](xref:DashboardGrid) visualization. The grid will be populated with a block for every order in the orders dataset.

   ![Default grid](~/user-guide/images/DefaultGrid.png)

## Step 3: Style the blocks

The default grid blocks look quite basic and do not provide a lot of information, let's change that!

> [!NOTE]
> Learn more about the Template Editor: [Using the Template Editor](xref:Template_Editor)

1. Make sure the grid component is selected, and navigate to *Layout > Item templates*.

1. Click *Edit* to open the Template Editor.

1. Use the Template Editor to style the grid blocks.

   ![Styled grid](~/user-guide/images/StyledGrid.png) 

## Step 4: Tweak the grid layout

Let's change the way the blocks are positioned. We would like to show one row of four blocks at a time.

1. Make sure the grid component is selected, and navigate to *Layout > Advanced*.

1. Locate the *Grid template* section. There you can change the way the grid blocks are positioned.

1. Set the number of columns to 4 and ensure that *Scaling* is applied.

1. Similarly, for the rows, opt for 1 row and apply *Scaling*.

    ![Grid settings](~/user-guide/images/GridSettings.png)

Applying these settings will make sure our grid has 4 columns, 1 row and a button to navigate to the next items.

![Finished grid](~/user-guide/images/FinishedGrid.png)
