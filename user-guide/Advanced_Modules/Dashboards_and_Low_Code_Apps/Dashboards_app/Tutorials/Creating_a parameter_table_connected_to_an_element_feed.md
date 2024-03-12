---
uid: Creating_a_parameter_table_connected_to_an_element_feed
---

# Creating a parameter table connected to an element feed

In this tutorial, you will learn how to craft a GQI query to display parameters from a specific protocol table. You will also learn how to link the query to an element feed to control which element's data populates in the table's results.

Expected duration: 10 min.

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

1. Add a *Dropdown* component.

   This component will allow users to select an element in order to filter the GQI results.

1. Add a *Table* component.

   This component will allow users to view the output of the GQI query.

## Step 2: Configure the 'Dropdown' component to list all elements of a specific protocol

1. Configure the *Dropdown* component with an "Elements" data source.

   1. Go to the right pane, and drag the "Elements" data header onto the data input of the *Dropdown* component.

      ![](~/user-guide/images/Tutorial_Dropdown_Elements.png)

   1. Go to the right pane, and drag the desired protocol from the right pane onto the filter input of the *Dropdown* component.

      ![](~/user-guide/images/Tutorial_Dropdown_Protocol.png)

The *Dropdown* component should now list all available elements that match the specified protocol.

## Step 3: Configure a GQI query to display parameters from a specific protocol table and link it to the dropdown feed

1. Go to the right pane, and open the *QUERIES* section.

1. Click the plus icon.

1. Enter a descriptive query name.

1. Select the *Get parameters for elements where* data source.

1. Set *Type* to "Protocol".

1. Select a protocol.

   > [!NOTE]
   > This should be the same protocol as the one you used to filter the *Dropdown* component in Step 2.

1. Select a protocol version.

1. Select the protocol table that holds the data that you wish to display in the *Table* component.

1. Optional: Use a subsequent *Select* operator to control which parameters from the specified protocol table to display in the GQI table.

   > [!NOTE]
   > It is important that *Element ID* remains selected to allow linking to the *Dropdown* component.

1. Use a *Filter* operator to filter the query results using the element that will be selected in the dropdown feed.

   1. Select the *Filter* operator.
   1. Set *Column* to "Element ID".
   1. Set *Filter method* to "regex".
   1. In the *Value* box, click the *Link to feed* icon or open the *Link to feed* dialog.

      1. Open the *Feed* box, and select the *Dropdown* component.
      1. Open the *Property* box, and select "Element ID".
      1. Click *Apply*.

1. Optional: Use a subsequent *Select* operator to remove "Element ID" from being displayed on the *Table* component.

   Below, you can see an example of the query you made following the instructions above:

   ![](~/user-guide/images/Tutorial_completed_query.png)

1. Scroll up until you see the header of the query you are editing, and click the pen icon to save the query.

1. Drag the query from the right pane onto the *Table* component.

   ![](~/user-guide/images/Tutorial_query_as_table_input.png)

1. Click *Stop editing* to exit the edit mode.

The *Table* component should now display the parameters specified during query creation, and their values should change depending on the element selected in the dropdown feed.

## Related documentation

- [Feeds](xref:Using_dashboard_feeds)
