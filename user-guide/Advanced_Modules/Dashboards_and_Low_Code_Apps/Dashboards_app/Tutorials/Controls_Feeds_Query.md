---
uid: Tutorial_Dashboards_Controls_And_Feeds_Query
---

# Leveraging controls and feeds to create a dynamic GQI query

In this tutorial, you will discover how to harness controls and feeds which are used in a GQI query. An update to the user input will lead to an updated GQI result. This is especially when using visualizations that do not support any filtering.

Expected duration: 10 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created in DataMiner web 10.4.1.

## Prerequisites

- A DataMiner System that is connected to dataminer.services.

- DataMiner web 10.3.5 or higher.

## Overview

- [Step 1: Install the dummy data sources package](#step-1-install-the-dummy-data-sources-package)
- [Step 2: Create a dashboard and add a text input](#step-2-create-a-dashboard-and-add-a-text-input)
- [Step 3: Add a query and visualize it](#step-3-add-a-query-and-visualize-it)

> [!TIP]
> See also: [Kata #13: Controls and feeds in a Low-Code App](https://community.dataminer.services/courses/kata-13/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Step 1: Install the dummy data sources package

1. Go to <https://catalog.dataminer.services/catalog/5410>.

1. Click the *Deploy* button to deploy the *IPAM - GQI dummy data sources* packages on your DMA.

   This package contains data that will be used in this tutorial.

## Step 2: Create a dashboard and add a text input

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Add a [Text input](xref:DashboardTextInputFeed) so the user can enter a search term.

   1. In edit mode, drag and drop the *Text input* visualization from the pane on the left on to the main dashboard area.

   1. Select the input and go to the layout pane where you can configure additional options to style the input.

   1. Fill in "VLAN name" as the placeholder for the text input.

   1. Search for "Filter" in the *Icon* option and and select an applicable icon.

Your text input should look like this:

   ![Numeric input](~/user-guide/images/Dashboards_Tutorial_Controls_Feeds_Query_Numeric.jpg)

## Step 3: Add a query and visualize it

1. [Create a GQI query](xref:Creating_GQI_query) using the "IP subnets - Dummy" ad hoc data source.

1. Add a GQI operator of type "Filter":

   1. Select the "VLAN Name" as the filter on which we want to filter.

   1. Select the "contains" filter method.

   1. Fill in the "VLAN 1" as the value for the filter.

1. Visualize the result in a [Table](xref:DashboardTable). Your result should look like this:

   ![Statically filtered query](~/user-guide/images/Dashboards_Tutorial_Controls_Feeds_Query_Static.jpg)

## Step 4: Replace the static filter value with a feed

1. Edit the GQI query again and open the filter operator.

1. Next to the statically defined value you can find a "Link to feed" icon. This icon is used everywhere a user can link a value to a feed. Click the icon to open the "Link to feed" popup.

   ![Link to feed icon](~/user-guide/images/Dashboards_Tutorial_Controls_Feeds_Query_Link.jpg)

1. The popup will ask for a specific feed, type and property.

   1. Select "Text input 1" for the feed. You'll notice that the type and property are automatically filled in if only one possible value is available.

   1. Additionally you can specify what the behavior should be when the feed is empty. In our case, what should happen when the user did not fill in any value in the text input. Select "Everything" to make sure that all data is retrieved when no value is available in the text input.

   ![Link to feed configuration](~/user-guide/images/Dashboards_Tutorial_Controls_Feeds_Query_Popup.jpg)

   > [!TIP]
   > If you want the text input to behave as a search engine, you can select "Nothing" instead. This will not retrieve any data up until the user fills in a value in the text input.

1. Stop editing the dashboard and fill in the value "VLAN 2" in the text input. The table will apply filtering upon pressing return or when clicking outside the textbox.

   > [!TIP]
   > You can configure when a the text input sends out the feed value in the *Settings* tab of the text input.

## Learning paths

This tutorial is part of the following learning path:

- [Dashboards](xref:Tutorial_Dashboards)

## Related documentation

- [Feeds](xref:Using_dashboard_feeds)
