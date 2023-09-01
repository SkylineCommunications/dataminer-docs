---
uid: Tutorial_Dashboards_Displaying_a_custom_empty_component_message
---

# Displaying a custom empty component message

This tutorial lesson demonstrates how to add a custom message when the query returns no results for any of the following components: Table, Grid, Pie & donut chart, Column & bar chart, Line & area chart, Timeline and the Node edge graph. This way you can notify the user why there would be no data in your specific case.

## Overview

- [Displaying a custom empty component message](#displaying-a-custom-empty-component-message)
  - [Overview](#overview)
  - [Step 1: Adding any component that allows having a custom message](#step-1-adding-any-component-that-allows-having-a-custom-message)
  - [Step 2: Configure the custom message on the component](#step-2-configure-the-custom-message-on-the-component)

## Step 1: Adding any component that allows having a custom message

The custom message is only allowed on certain components as mentioned above.

1. Drag and drop any of these components on the dashboard (for this tutorial we will use the table).

    ![Possible components](~/tutorials/images/PossibleComponents.png)

1. Add a query to the component.

## Step 2: Configure the custom message on the component

With our component now on the dashboard we can configure the message shown when no data is received from the query.

1. Select the component and go to the layout settings on the right side of the dashboard.

1. Under the Advanced section you will find a setting called *Empty result message*.

1. Edit the text field in this setting to the message you want the component to display when no data is returned from the query.

    ![Text Field](~/tutorials/images/TextField.png)

The custom message will now be properly configured:

![Custom message](~/tutorials/images/CustomMessage.png)
