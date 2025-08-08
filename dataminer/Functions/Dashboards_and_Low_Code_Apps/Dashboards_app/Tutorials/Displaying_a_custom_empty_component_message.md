---
uid: Tutorial_Dashboards_Displaying_a_custom_empty_component_message
---

# Displaying a custom empty component message

This tutorial demonstrates how to add a custom message when a query returns no results for any of the following components of a dashboard:

- Table
- Grid
- Pie & donut chart
- Column & bar chart
- Line & area chart
- Timeline
- Node edge graph.

This way you can let users know why there is no data in your specific case.

The content and screenshots for this tutorial have been created in DataMiner 10.3.11.

> [!NOTE]
> Depending on your DataMiner version, you may need to activate a soft-launch option to be able to use the grid or timeline component. See [Soft-launch options](xref:SoftLaunchOptions).

## Overview

- [Step 1: Adding any component that allows having a custom message](#step-1-add-a-component-that-allows-a-custom-message)
- [Step 2: Configure the custom message on the component](#step-2-configure-the-custom-message-on-the-component)

## Step 1: Add a component that allows a custom message

1. Drag and drop any of the above-mentioned components to the dashboard, for example a table.

![Possible components](~/dataminer/images/PossibleComponents.png)<br/>*DataMiner 10.3.11 with soft-launch options ReportsAndDashboardsScheduler and ReportsAndDashboardsDynamicVisuals enabled.*

1. Add a query to the component.

## Step 2: Configure the custom message on the component

Configure the message that should be shown when no data is received for the query:

1. Select the component and go to the layout settings on the right side of the dashboard.

1. Under *Advanced*, set the *Empty result message* to the message you want the component to display when no data is returned for the query.

   ![Text Field](~/dataminer/images/TextField.png)

The custom message will now be properly configured.

The example above will result in the following message:

![Custom message](~/dataminer/images/CustomMessage.png)
