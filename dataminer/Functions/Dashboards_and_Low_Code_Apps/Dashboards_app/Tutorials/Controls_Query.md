---
uid: Tutorial_Dashboards_Controls_Query
---

# Using controls to create a dynamic GQI query

In this tutorial, you will discover how to harness controls to interact with a GQI query. An update to the user input will lead to an updated GQI result. This is especially useful for visualizations that do not support any filtering.

Expected duration: 10 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.5.9 web apps.

## Prerequisites

- A DataMiner System that is connected to dataminer.services.

- Version 10.3.5 or higher of the DataMiner web apps.

## Overview

- [Step 1: Install the dummy data sources package](#step-1-install-the-dummy-data-sources-package)
- [Step 2: Create a dashboard and add a text input](#step-2-create-a-dashboard-and-add-a-text-input)
- [Step 3: Add a query and visualize it](#step-3-add-a-query-and-visualize-it)
- [Step 4: Link the text input to the GQI query to enable dynamic filtering](#step-4-link-the-text-input-to-the-gqi-query-to-enable-dynamic-filtering)

## Step 1: Install the dummy data sources package

1. Go to <https://catalog.dataminer.services/details/d9089bae-0680-4da2-9c30-1c768f68fe63>.

1. Click the *Deploy* button to deploy the *IPAM - GQI dummy data sources* packages on your DMA.

   This package contains data that will be used in this tutorial.

## Step 2: Create a dashboard and add a text input

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Add a [Text input](xref:DashboardTextInput) component so the user can enter a search term:

   1. In edit mode, drag and drop the *Text input* visualization from the pane on the left on to the main dashboard area.

   1. Select the input and go to the *Layout* pane where you can configure additional options to style the input.

   1. Fill in "VLAN name" as the placeholder for the text input.

   1. Search for "Filter" in the *Icon* option and and select an applicable icon.

Your text input should look like this:

   ![Step 2 result](~/dataminer/images/Dashboards_Tutorial_Step2.jpg)

## Step 3: Add a query and visualize it

1. [Create a GQI query](xref:Creating_GQI_query) using the "IP subnets - Dummy" ad hoc data source.

1. Add a GQI operator of type "Filter":

   1. Select the "VLAN Name" as the column to filter on.

   1. Select the "contains" filter method.

   1. Fill in the "VLAN 1" as the value for the filter.

1. Visualize the result in a [Table](xref:DashboardTable) component.

   The result should look like this:

   ![Statically filtered query](~/dataminer/images/Dashboards_Tutorial_Static.jpg)

## Step 4: Link the text input to the GQI query to enable dynamic filtering

1. Edit the GQI query again and open the filter operator.

1. In the *Value* box, click the ![Link to](~/dataminer/images/Link_to_Data.png) icon. This icon is used everywhere a user can link a value to data.

   Clicking the icon opens the *Link to* dialog, which will ask for specific data, the type, and a property.

1. Specify the necessary info in the dialog:

   1. In the first box, select "Text input 1".

      You will notice that the type and property are automatically filled in if only one possible value is available.

   1. To determine what the behavior should be when the data is empty, at the bottom of the dialog, select *everything*.

      This determines what will happen when the user does not fill in any value in the text input. Selecting *everything* ensures that all data is retrieved in this case.

      ![*Link to* pop-up window](~/dataminer/images/Link_to_popup.jpg)

      > [!TIP]
      > If you want the text input to behave like a search engine, you can select *nothing* instead. This will not retrieve any data until the user fills in a value in the text input.

1. Select *Link* in the lower-right corner of the *Link to* dialog.

1. Leave the dashboard edit mode using the button in the top-right corner.

1. In the text input of the dashboard, fill in the value "VLAN 2".

   As soon as you press Enter or click outside the textbox, the filter will be applied in the table.

   > [!NOTE]
   > This is the default behavior for the text input. You can customize this in the *Settings* pane of the text input, so that this for instance happens as soon as the value changes, or only if Enter is pressed.

## Learning paths

This tutorial is part of the following learning path:

- [Dashboards](xref:Tutorial_Dashboards)

## Related documentation

- [Text input](xref:DashboardTextInput)
