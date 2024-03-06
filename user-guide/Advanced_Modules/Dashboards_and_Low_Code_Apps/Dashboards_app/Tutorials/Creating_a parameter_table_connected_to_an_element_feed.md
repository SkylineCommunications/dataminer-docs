---
uid: Creating_a_parameter_table_connected_to_an_element_feed
---

# Creating a parameter table connected to an element feed

In this tutorial, you will learn how to craft a GQI query to display parameters from a specific protocol table. You will also learn how to link the query to an element feed to control which element's data populates in the table's results.

Expected duration: 10min

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner Web Apps version 10.3.6.

## Prerequisites

- DataMiner Web Apps version 10.3.5 or higher

## Overview

- [Step 1: Create a dashboard and add a *Dropdown* component and a *Table* component](#step-1-create-a-dashboard-and-add-a-dropdown-component-and-a-table-component)
- [Step 2: Configure the *Dropdown* component to list all elements of a specific protocol](#step-2-configure-the-dropdown-component-to-list-all-elements-of-a-specific-protocol)
- [Step 3: Configure a GQI query to display parameters from a specific protocol table and link it to the dropdown feed](#step-3-configure-a-gqi-query-to-display-parameters-from-a-specific-protocol-table-and-link-it-to-the-dropdown-feed)

> [!NOTE]
> The parameters being queried in the example are originating from elements using the Microsoft Platform protocol. However, this process will work for elements utilizing any protocol that features table-based parameters.

## Step 1: Create a dashboard and add a 'Dropdown' component and a 'Table' component

1. Create a new dashboard.

1. Add a *Dropdown* component so that the user can select applicable elements to filter the GQI results.

   - In edit mode, drag a *Text input* component from the pane on the left onto the main dashboard area.

1. Add a *Table* component so that the user can view the results from a GQI query.

   - In edit mode, drag a *Text input* component from the pane on the left onto the main dashboard area.

## Step 2: Configure the 'Dropdown' component to list all elements of a specific protocol

1. Configure the *Dropdown* component with an "Elements" data source.

   1. In edit mode, drag the "Elements" data header from the right pane onto the data input of the *Dropdown* component.

      ![](~/user-guide/images/Tutorial_Dropdown_Elements.png)

   1. In edit mode, drag the desired protocol from the right pane onto the filter input of the *Dropdown* component.

      ![](~/user-guide/images/Tutorial_Dropdown_Protocol.png)

The *Dropdown* component should now list all available elements that match the specified protocol.

## Step 3: Configure a GQI query to display parameters from a specific protocol table and link it to the dropdown feed

1. In edit mode, create a new query in the right pane under the *QUERIES* section.

   1. Give the query a descriptive name.

   1. Select the *Get parameters for elements where* data source.

      1. Select a protocol.

         > [!NOTE]
         > This should be the same protocol that was used to filter the *Dropdown* component.

      1. Select a protocol version.

      1. Select the name of the table that holds the data that you wish to display in the *Table* component.

   1. Optional: Use a subsequent *Select* operator to control which parameters from the specified protocol table to display in the GQI table.

      > [!NOTE]
      > It is important that *Element ID* remains selected to allow linking to the *Dropdown* component.

   1. Use a *Filter* operator to filter the query results according to the element selected in the dropdown feed.

      1. Select the *Filter* operator.
      1. Choose "Element ID" as the column to filter on.
      1. Choose "regex" as the filter method.
      1. In the *Value* box, click the *Link to feed* icon.
      1. Clicking the icon opens the *Link to feed* dialog, which will ask for a specific feed, type and property.
      1. In the *Feed* field, select the *Dropdown* component.
      1. In the *Property* field, select "Element ID".
      1. Click *Apply*.

   1. Optional: Use a subsequent *Select* operator to remove "Element ID" from being displayed on the *Table* component.

      Below, you can see an example of query used in this tutorial:

      ![](~/user-guide/images/Tutorial_completed_query.png)

   1. Stop editing the query by clicking the pen icon, and drag the query from the right pane to the *Table* component to indicate that the query will serve as data input for the table.

      ![](~/user-guide/images/Tutorial_query_as_table_input.png)

1. Exit edit mode.

The *Table* component should now display the parameters specified during query creation, and their values should change depending on the element selected in the dropdown feed.

## Related documentation

- [Feeds](xref:Using_dashboard_feeds)
