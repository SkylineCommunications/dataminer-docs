---
uid: Creating_a parameter_table_connected_to_an_element_feed
---

# Creating a parameter table connected to an element feed

In this tutorial, you will learn how to craft a GQI query to display parameters from a specific protocol table. You will also learn how to link the query to an element feed to control which element's data populates in the table's results.

Expected duration: 10min

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.3.6 web apps.

## Prerequisites

- Version 10.3.5 or higher of the DataMiner web apps.

## Overview

Step 1: Create a dashboard and add a “Dropdown” component and a “Table” component
Step 2: Configure the Dropdown component to list all elements of a specific protocol
Step 3: Configure a GQI query to display parameters from a specific protocol table and link it to the dropdown feed

> [!NOTE]
> The parameters being queried in the example are originating from elements using the Microsoft Platform protocol. However, this process will work for elements utilizing any protocol that features table-based parameters.

## Step 1: Create a dashboard and add a 'Dropdown' component and a 'Table' component

1. Create a new dashboard.
1. Add a Dropdown component so that the user can select applicable elements to filter the GQI results.

   - In edit mode, drag and drop the Text input visualization from the pane on the left on to the main dashboard area.

1. Add a Table component so that the user display results from a GQI query.

   - In edit mode, drag and drop the Text input visualization from the pane on the left on to the main dashboard area.

## Step 2: Configure the Dropdown component to list all elements of a specific protocol

1. Configure the Dropdown with a data source of “Elements”

   1. In edit mode, drag the top “Elements” data header from the right pane to the data input of the dropdown component.
   1. In edit mode, drag the desired protocol from the right pane to the filter input of the dropdown component.

1. The dropdown should then list available elements present on the system that match the specified protocol.

## Step 3: Configure a GQI query to display parameters from a specific protocol table and link it to the dropdown feed

1. In edit mode, create a new query on the right pane under the “QUERIES” section.

   1. Give the query a descriptive name.
   1. Select data source: “get parameters for elements where”

      1. Select a protocol

         > [!NOTE]
         > This should be the same protocol that was used when filtering the Dropdown component.

      1. Select a protocol version
      1. Select the table name from the specified protocol that holds the data that you wish to display in the “Table” component

   1. Optional: Use a subsequent “Select” operator to control which parameters from the specified protocol table to display in the GQI table.

      > [!NOTE]
      > it is important that “Element ID” remain selected to allow linking to the dropdown component”

   1. Use a “Filter” operator to filter the query results to the selected element in the drop down feed

      1. Select the “Filter” operator
      1. Choose “Element ID” as the specified column to filter
      1. Choose “regex” as the filter method
      1. In the Value box, click the "Link to feed" icon.
      1. Clicking the icon opens the Link to feed dialog, which will ask for a specific feed, type, and property.
      1. In the “Feed” field, choose the dropdown component.
      1. In the “Property” filed, choose Element ID.
      1. Click Apply

   1. Optional: Use a subsequent “Select” operator to remove Element ID from being displayed on the Table component.
   1. Below is an example of a competed query for this tutorial:
   1. Stop editing the query with the pen icon and then drag the query from the right pane to the Table component to specify the query as data input to the table.

1. Exit edit mode.
1. The Table should now be displaying the parameters specified during the query creation and their values should change depending on the element selected in the dropdown feed.

## Learning paths

This tutorial is part of the following learning path:

- Dashboards

## Related documentation

- Feeds
