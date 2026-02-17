---
uid: Creating_a_parameter_table_connected_to_an_element_feed
---

# Creating a custom parameter table connected to an element feed

In this tutorial, you will learn how to craft a GQI query to display parameters from a specific protocol table in a dashboard. You will also learn how to link the query to an element feed to control which element's data is shown in the table.

Expected duration: 10 min.

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner Web Apps version 10.4.3.

## Prerequisites

- DataMiner Web Apps version 10.3.5 or higher

> [!NOTE]
> The parameters queried in the example originate from elements using the Microsoft Platform protocol. However, this process will work for elements utilizing any protocol that features table-based parameters.

## Overview

- [Step 1: Create a dashboard and add a dropdown and table component](#step-1-create-a-dashboard-and-add-a-dropdown-and-table-component)
- [Step 2: Configure the dropdown component to list all elements of a specific protocol](#step-2-configure-the-dropdown-component-to-list-all-elements-of-a-specific-protocol)
- [Step 3: Configure a GQI query to display parameters from a specific protocol table and link it to the dropdown feed](#step-3-configure-a-gqi-query-to-display-parameters-from-a-specific-protocol-table-and-link-it-to-the-dropdown-feed)

## Step 1: Create a dashboard and add a dropdown and table component

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Drag and drop the dropdown visualization from the pane on the left to the dashboard.

   This will add a dropdown component, where users will be able to select an element in order to filter the GQI results.

1. Drag and drop the table visualization from the pane on the left to the dashboard.

   This will add a table component, where the output of the GQI query will be shown.

## Step 2: Configure the dropdown component to list all elements of a specific protocol

1. From the *Data* pane, drag the *Elements* data header onto the data input of the dropdown component.

   ![Dragging the Elements data header onto the data input of the component](~/dataminer/images/Tutorial_Dropdown_Elements.png)

1. From the *Data* pane, drag the desired protocol onto the filter input of the dropdown component.

   ![Dragging a protocol onto the filter input of the component](~/dataminer/images/Tutorial_Dropdown_Protocol.png)

The dropdown component will now list all available elements that match the protocol you selected.

## Step 3: Configure a GQI query to display parameters from a specific protocol table and link it to the dropdown feed

1. In the *Data* pane, open the *QUERIES* section and click the "+" icon.

   ![Adding a query](~/dataminer/images/Tutorial_Add_Query.png)

1. Enter a descriptive query name, e.g., *Disk Information Table*.

1. Select the *Get parameters for elements where* data source.

1. Set *Type* to "Protocol".

1. Select a protocol.

   > [!NOTE]
   > This should be the same protocol as the one you used to filter the dropdown component in step 2.

1. Select a protocol version.

1. Select the protocol table that contains the data that you want to display in the table component.

   ![Selecting the protocol table](~/dataminer/images/Tutorial_ProtocolTable.png)

1. Optionally, add a *Select* operator to control which parameters from the specified protocol table are displayed in the GQI table.

   ![Adding a Select operator](~/dataminer/images/Tutorial_SelectOperator.png)

   > [!NOTE]
   > At this point, it is important that *Element ID* column remains selected to allow linking to the dropdown component.

1. Add a *Filter* operator to filter the query results using the element that will be selected in the dropdown feed.

   1. Select the *Filter* operator.

   1. Set *Column* to "Element ID".

   1. Set *Filter method* to "regex".

   1. On the right side of the *Value* box, click the link icon to open the *Link to* dialog.

      1. Open the *Feed* box, and select the dropdown component.

      1. Open the *Property* box, and select "Element ID".

      1. Click *Apply*.

   ![Adding a Filter operator](~/dataminer/images/Tutorial_FilterOperator.png)

1. Optionally, if you do not want the element ID to be displayed in the table, add another *Select* operator where "Element ID" is no longer selected.

   ![Omitting the element ID](~/dataminer/images/Tutorial_OmittingElementID.png)

1. Scroll up until you see the header of the query you are editing, and click the pencil icon to save the query.

   ![Saving the query](~/dataminer/images/Tutorial_SavingTheQuery.png)

1. Drag the query from the *Data* pane onto the table component.

   ![Dragging the query onto the table component](~/dataminer/images/Tutorial_query_as_table_input.png)

1. Click *Stop editing* to exit the edit mode.

The table component should now display the parameters specified during query creation, and their values should change depending on the element selected in the dropdown feed.

![Result](~/dataminer/images/Tutorial_Result.png)

## Related documentation

- [Component data](xref:Component_Data)
