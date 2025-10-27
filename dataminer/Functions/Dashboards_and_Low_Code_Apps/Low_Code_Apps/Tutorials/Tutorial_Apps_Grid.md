---
uid: Tutorial_Apps_Grid
---

# Getting started with the grid component

This tutorial demonstrates how you can create your first grid visualization.

Expected duration: 5 minutes.

> [!TIP]
> See also:
>
> - [Using the Template Editor](xref:Template_Editor)
> - [Kata #16: Introducing grid components](https://community.dataminer.services/courses/kata-16/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

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

1. Create a new low-code app. See [Creating apps](xref:Creating_custom_apps).

1. In the *Data* pane, expand *Queries*.

1. Click the + icon to add a new query.

1. Provide the necessary information:

   1. Give the query a name, e.g. "Orders".

   1. Open the selection box, and select *Get ad hoc data*.

   1. Open the *Data source* selection box, and select *JSON Reader*.

   1. Open the *File* selection box, select *Orders.json*.

      ![Query](~/dataminer/images/OrdersQuery.png)

## Step 2: Add a grid component

1. Drag the created query onto an empty section of the low-code app page.

1. Hover the mouse pointer over the component, and click the ![Visualizations](~/dataminer/images/DashboardsX_visualizations00095.png) icon.

1. Choose the [grid](xref:DashboardGrid) visualization. The grid will be populated with a block for every order in the orders dataset.

   ![Default grid](~/dataminer/images/DefaultGrid.png)

## Step 3: Style the blocks

The default grid blocks look quite basic and do not provide a lot of information. If required, you can change their style.

> [!NOTE]
> For more information about the Template Editor, see [Using the Template Editor](xref:Template_Editor)

1. Make sure the grid component is selected, and go to *Layout > Item templates*.

1. Click *Edit* to open the Template Editor.

1. Use the Template Editor to style the grid blocks.

   ![Styled grid](~/dataminer/images/StyledGrid.png)

## Step 4: Tweak the grid layout

Change the way the blocks are positioned. The goal is to have a row of four blocks.

1. Make sure the grid component is selected, and go to *Layout > Advanced*.

1. Locate the *Grid template* section. There you can change the way the grid blocks are positioned.

1. Set the number of columns to 4, and ensure that *Scaling* is applied.

1. For the rows, opt for 1 row, and apply *Scaling*.

   ![Grid settings](~/dataminer/images/GridSettings.png)

Applying these settings will make sure your grid has 4 columns, 1 row and a button to navigate to the next items.

![Finished grid](~/dataminer/images/FinishedGrid.png)
