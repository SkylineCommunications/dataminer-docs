---
uid: Tutorial_Alarm_Dashboard_for_your_daily_DMS_health_check
---

# Alarm Dashboard for your daily DMS health check

In this tutorial, you’ll learn how to create an Alarm Report Dashboard that’s not just sleek and shareable but also gives you exactly what you need for your daily DMS health check.

Moreover, we’ll dive into the Alarm Filtering app—your trusty tool to sail through even the wildest alarm storms while keeping a clear overview.

Expected duration: 10 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.4.12 web apps.

## Prerequisites

- A DataMiner System that is connected to dataminer.services.
- Version 10.3.5 or higher of the DataMiner web apps.

## Overview

- [Alarm Dashboard for your daily DMS health check](#alarm-dashboard-for-your-daily-dms-health-check)
  - [Prerequisites](#prerequisites)
  - [Overview](#overview)
  - [Step 1: Install the Alarm Report Package](#step-1-install-the-alarm-report-package)
  - [Step 2: Create a dashboard and add a text input](#step-2-create-a-dashboard-and-add-a-text-input)
  - [Step 3: Add a query and visualize it](#step-3-add-a-query-and-visualize-it)
  - [Step 4: Replace the static filter value with a feed](#step-4-replace-the-static-filter-value-with-a-feed)
  - [Learning paths](#learning-paths)
  - [Related documentation](#related-documentation)

## Step 1: Install the Alarm Report Package

1. Go to <https://catalog.dataminer.services/details/5d795a13-814e-4ece-91da-049c3e8e9f38>.

1. Click the *Deploy* button to deploy the *Alarm Report* package on your DMA.

   This package will install the Alarm Report Dashboard that we will work with later on. It will by default be created in the root view of your Dashboard folder structure. 

   > [!TIP]
   > If you want to relocate this dashboard to another folder, you can right click on the Alarm Report name and click on Settings.
   > ![Relocated Dashboard Settings](~/user-guide/images/Tutorial_Alarm_Dashboard_RelocateDashboardSettings.png)
   >
   > In the new panel, you can edit the Location as indicated in the section [Move a dashboard to a different folder](xref:Managing_dashboard_folders#moving-a-dashboard-to-a-different-folder)

## Step 2: Create a dashboard and add a text input

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Add a [Text input](xref:DashboardTextInput) component so the user can enter a search term:

   1. In edit mode, drag and drop the *Text input* visualization from the pane on the left on to the main dashboard area.

   1. Select the input and go to the layout pane where you can configure additional options to style the input.

   1. Fill in "VLAN name" as the placeholder for the text input.

   1. Search for "Filter" in the *Icon* option and and select an applicable icon.

Your text input should look like this:

   ![Numeric input](~/user-guide/images/Dashboards_Tutorial_Controls_Feeds_Query_Numeric.jpg)

## Step 3: Add a query and visualize it

1. [Create a GQI query](xref:Creating_GQI_query) using the "IP subnets - Dummy" ad hoc data source.

1. Add a GQI operator of type "Filter":

   1. Select the "VLAN Name" as the column to filter on.

   1. Select the "contains" filter method.

   1. Fill in the "VLAN 1" as the value for the filter.

1. Visualize the result in a [Table](xref:DashboardTable) component.

   The result should look like this:

   ![Statically filtered query](~/user-guide/images/Dashboards_Tutorial_Controls_Feeds_Query_Static.jpg)

## Step 4: Replace the static filter value with a feed

1. Edit the GQI query again and open the filter operator.

1. In the *Value* box, click the "Link to feed" icon (or the "Link to data" icon in DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 or higher).

   This icon is used everywhere a user can link a value to data.

   !["Link to feed" icon in DataMiner 10.4.1](~/user-guide/images/Dashboards_Tutorial_Controls_Feeds_Query_Link.jpg)

   Clicking the icon opens the *Link to feed* dialog (or *Link to data* in recent DataMiner versions), which will ask for a specific feed or data, the type, and a property.

1. Specify the necessary info in the dialog:

   1. In the first box, select "Text input 1".

      You will notice that the type and property are automatically filled in if only one possible value is available.

   1. To determine what the behavior should be when the feed is empty, at the bottom of the dialog, select *everything*.

      This determines what will happen when the user does not fill in any value in the text input. Selecting *everything* ensures that all data is retrieved in this case.

      !["Link to feed" configuration in DataMiner 10.4.1](~/user-guide/images/Dashboards_Tutorial_Controls_Feeds_Query_Popup.jpg)

      > [!TIP]
      > If you want the text input to behave like a search engine, you can select *nothing* instead. This will not retrieve any data until the user fills in a value in the text input.

1. Leave the dashboard edit mode using the button in the top-right corner.

1. In the text input of the dashboard, fill in the value "VLAN 2".

   As soon as you press Enter or click outside the textbox, the filter will be applied in the table.

   > [!NOTE]
   > This is the default behavior for the text input. You can customize this in the *Settings* tab of the text input, so that this for instance happens as soon as the value changes, or only if Enter is pressed.

## Learning paths

This tutorial is part of the following learning path:

- [Dashboards](xref:Tutorial_Dashboards)

## Related documentation

- [Alarm Templates](xref:About_alarm_templates)
