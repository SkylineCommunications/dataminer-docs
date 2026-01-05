---
uid: Tutorial_Apps_Variables
---

# Using variables in a low-code app

In this tutorial, you will learn how to create a [variable](xref:Variables) and dynamically change its value through a header bar, allowing it to be used as an element state filter within a query.

By the end of this tutorial, you will have a functional low-code app that allows users to dynamically filter elements based on their state.

Estimated duration: 15 minutes.

> [!NOTE]
>
> - This tutorial uses DataMiner web version 10.5.1.
> - Variables have been available since DataMiner web version 10.4.12, and support for dynamic value changes was introduced in version 10.5.1.

> [!TIP]
> See also: [Kata #58: Low-Code Apps - Introducing Variables](https://community.dataminer.services/courses/kata-58/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- DataMiner server version 10.4.0 or higher

- DataMiner web version 10.5.1 or higher

## Overview

- [Step 1: Create a variable](#step-1-create-a-variable)

- [Step 2: Create a 'Get elements' query filtered by the variable](#step-2-create-a-get-elements-query-filtered-by-the-variable)

- [Step 3: Add buttons to modify the variable and filter elements](#step-3-add-buttons-to-modify-the-variable-and-filter-elements)

## Step 1: Create a variable

1. [Create a low-code app](xref:Tutorial_Apps_Creating_And_Publishing#step-1-create-an-app).

1. In the *Data* pane on the right, expand the *Variables* item and click the "+" icon to start creating a new variable.

1. In the *Name* box, enter a descriptive name for the variable.

1. Select *Text* from the *Type* dropdown list.

1. Ensure the *Read-only* option is disabled so the variable can be changed later.

1. Click the ![Stop editing](~/dataminer/images/Stop_Editing.png) button to stop editing the variable.

## Step 2: Create a 'Get elements' query filtered by the variable

In this step, you will create a query that retrieves elements in your DataMiner System filtered by the variable created in [step 1](#step-1-create-a-variable).

1. Create a query:

   1. In the *Data* pane, Expand the *Queries* item and click the "+" icon to start creating a new query.

   1. In the *Name* box, enter a name for the query.

   1. Select *Get elements* as the data source.

   1. Apply a [*Filter* query operator](xref:GQI_Filter):

      1. Select *Filter* from the *Operator* dropdown list.

      1. Choose *State* as the column to filter.

      1. Select *equals* as the filter method.

      1. Under *Value*, click the ![Link to data](~/dataminer/images/Link_to_Data.png) button.

      1. From the *Data* dropdown list, select the variable you created in step 1.

      1. Under *Empty data shows*, select *everything*.

      1. Click *Link* in the lower-right corner.

         > [!TIP]
         > See also: [Link the text input to the GQI query to enable dynamic filtering](xref:Tutorial_Dashboards_Controls_Query#step-4-link-the-text-input-to-the-gqi-query-to-enable-dynamic-filtering)

   1. Click the ![Stop editing](~/dataminer/images/Stop_Editing.png) button to stop editing the query.

1. Add a [table component](xref:DashboardTable) to the app.

1. Drag the newly created query from the *Data* pane onto the table component.

   The table now displays an overview of all elements in your DataMiner System.

## Step 3: Add buttons to modify the variable and filter elements

Currently, all elements are displayed in the table. To allow filtering, you will add buttons to the header bar that modify the variable's value, thereby updating the query dynamically.

1. Click the *header bar* toggle button.

1. Add a button to filter for active elements:

   1. Click the "+" on the left side of the header bar.

   1. Enter `Active` as the button label.

   1. Expand the *Events* item and select *Configure actions*.

   1. Select *Change variable* from the dropdown list.

   1. From the *Variable* dropdown list, select the variable you created in step 1.

   1. Enter `Active` as the new value.

   1. Click *Ok*.

1. Add a button to filter for stopped elements:

   1. Click the "+" on the left side of the header bar.

   1. Enter `Stopped` as the button label.

   1. Expand the *Events* item and select *Configure actions*.

   1. Select *Change variable* from the dropdown list.

   1. From the *Variable* dropdown list, select the variable you created in step 1.

   1. Enter `Stopped` as the new value.

   1. Click *Ok*.

1. Publish the app by clicking the ![Publish](~/dataminer/images/AppPublishIcon.png) button in the top-right corner of the low-code app header bar.

   Your app is now functional. By default, it displays all elements in your DataMiner System, but you can use the buttons in the header bar to filter the list to show only active or stopped elements.
