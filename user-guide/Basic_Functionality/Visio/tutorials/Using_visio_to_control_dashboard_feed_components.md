---
uid: Using_visio_to_control_dashboard_feed_components
---

# Using Visio to control dashboard feed components

In this tutorial, you will learn how to feed data into a dashboard URL in order to automate selections on feed components when the dashboard is opened. The data to be fed into the URL will be defined on an element's visual overview through the clever use of shape data.

Expected duration: 45 minutes

> [!NOTE]
> The content of this tutorial has been created with DataMiner web apps version 10.4.1.

## Prerequisites

- DataMiner version 10.2.2 or higher
- Protocol: Skyline Generic Virtual Connector – 1.0.0.3
- Microsoft Visio

## Overview

- [Step 1: Create a new Virtual Connector element and add numerical data to the 'Numerical Master Table' on the element's 'Table' data page](#step-1-create-a-new-virtual-connector-element-and-add-numerical-data-to-the-numerical-master-table-on-the-elements-table-data-page)
- [Step 2: Create a new dashboard and add a 'Parameter feed' component and a 'State' component to display the numerical data from the Virtual Connector](#step-2-create-a-new-dashboard-and-add-a-parameter-feed-component-and-a-state-component-to-display-the-numerical-data-from-the-virtual-connector)
- [Step 3: Create a new visual overview for the Generic Virtual Connector element with shapes for each numerical table index linking to the dashboard](#step-3-create-a-new-visual-overview-for-the-generic-virtual-connector-element-with-shapes-for-each-numerical-table-index-linking-to-the-dashboard)

> [!NOTE]
> The data being interacted with in the example below originates from elements using the *Skyline Generic Virtual Connector* protocol. However, this process will work for elements using any protocol that features table-based parameters.

## Step 1: Create a new Virtual Connector element and add numerical data to the 'Numerical Master Table' on the element's 'Table' data page

1. Open DataMiner Cube.
1. Create a new element using the *Skyline Generic Virtual Connector* protocol. The minimum required version 1.0.0.3 can be [deployed from the DataMiner Catalog](https://catalog.dataminer.services/details/connector/7021).
1. Once you have created the element, go to the *Table* data page of the element to find the *Numeric Master Table*.
1. Right-click below the table's column headers to add a new row to the table.  

   ![]((~/user-guide/images/VisioURLFeed_AddRowNumericTable.png)

1. Enter the row's primary key [IDX], enter random numbers into the first three columns, and click *OK*.

   > [!IMPORTANT]
   > Do not use any special characters for the primary key as they will interfere with the URL linking performed in step 3.

   ![]((~/user-guide/images/VisioURLFeed_AddRowNumericTableInput.png)

1. Add at least one more row to the table.

   ![]((~/user-guide/images/VisioURLFeed_NumericTableRows.png)

## Step 2: Create a new dashboard and add a 'Parameter feed' component and a 'State' component to display the numerical data from the Virtual Connector

1. Open the *Dashboards* app.
1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).
1. Enter edit mode.
1. Add a [Parameter feed component](xref:DashboardParameterFeed).
1. From the *Data* pane on the right, drag the *ELEMENTS* header onto the *Parameter feed* component to be used as data.
1. In the *Data* pane on the right, expand the *PARAMETERS* section, use the filter to find the three numeric table parameters that you entered numbers for, and drag each of them onto the *Parameter feed* component to be used as data.

   ![]((~/user-guide/images/VisioURLFeed_ParameterDataForFeed.png)

1. In the *Data* pane on the right, expand the *PROTOCOLS* section, search for the *Skyline Generic Virtual Connector*, and drag the protocol onto the *Parameter feed* component to be used as a filter.

   ![]((~/user-guide/images/VisioURLFeed_ProtocolDataForFeed.png)

1. Add a [State component](xref:DashboardState).
1. Click on the *State* component to highlight it.
1. In the *Layout* pane on the right, select the *LABELS* boxes to display the parameter name, the index and the value.

   ![]((~/user-guide/images/VisioURLFeed_StateLayoutOptions.png)

1. In the *Data* pane on the right, expand the *FEEDS* section to find the items associated with the parameter feed. Expand the *Parameter feed* component, and drag the *Parameters* item onto the *State* component to be used as data.

   ![]((~/user-guide/images/VisioURLFeed_ParameterDataForState.png)

   At this point, you should be able to make manual parameter feed selections to control which parameter values are shown on the *State* component.

   ![]((~/user-guide/images/VisioURLFeed_DashboardManualResults.png)

1. Exit edit mode.
1. In the top-right corner of the screen, click the ellipsis button, and then click *Share* to open a dialog box.
1. Enable the *Use uncompressed URL parameters* option, and then click *Copy link*. The URL you copied will be used in step 3 below.

   ![]((~/user-guide/images/VisioURLFeed_URLLink.png)

## Step 3: Create a new visual overview for the Generic Virtual Connector element with shapes for each numerical table index linking to the dashboard

1. In DataMiner Cube, open the *Generic Virtual Connector* element you created in step 1.
1. Go to the *VISUAL* page of the element, and right-click anywhere to have the Visio file options displayed.
1. Hover the mouse pointer over *Set as active "..." element Visio file*, and click *New blank*. This will create a new Visio file associated with the element. It will look like a blank canvas on the VISUAL page of the element.

   ![]((~/user-guide/images/VisioURLFeed_NewBlankVisio.png)

1. On the blank *VISUAL* page, right-click anywhere, and select *Edit in Visio*. This will open Microsoft Visio.

   > [!NOTE]
   > When you make changes to the Visio file, they will immediately appear in DataMiner Cube as soon as you save the file.

1. Start by adding a new rectangle that represents a table row.
1. Add a new textbox with the text *[tableIndex]*, and move it on top of the rectangle.
1. Add a new smaller rectangle that will act as a button to navigate to the Dashboards app. Double-click the rectangle, give it a useful description, and move it on top of the first rectangle representing a row.
1. CTRL-click all three components to highlight them all, then right-click, and group them.

   You should see the following under the *Drawing Explorer*:

   ![]((~/user-guide/images/VisioURLFeed_VisioRowGroup.png)

1. Add the following shape data to the grouped sheet representing a row.

   | Shape data field | Value |
   |---|---|
   | ChildType   | Row |
   | ChildMargin | 5   |

1. CTRL-click the grouped sheet representing the row and the existing background sheet that came with the new Visio file to highlight both at once. Then right-click, and group them to create a new group. Add the following shape data to the larger grouped sheet.

   | Shape data field | Value |
   |---|---|
   | Children       | Row   |
   | ChildrenSort   | Name  |
   | ChildrenPanel  | Stack |
   | ChildrenSource | [this element]/1200 |

   > [!NOTE]
   > *[this element]* is a dynamic placeholder, and *1200* is the table parameter ID of the *Numeric Master Table*.

1. Using a publicly available web-based encoded JSON URL converter, convert the URL you captured in step 2 to a human-readable format. This will allow users to understand how feed selections are represented in the dashboard's URL.

   ![]((~/user-guide/images/VisioURLFeed_URLConvert.png)

   With this information, certain sections of the URL can be replaced with placeholders that will allow dynamic entry based on the row index that is fed into it.

1. Add the following shape data to the button shape.

   > [!NOTE]
   >
   > - The first part of the URL needs to be changed to match the naming structure of your dashboard. The component ID (`cid`) also needs to be changed to match that of your parameter feed.
   > - You can find the ID of each component in the bottom-right corner of the component while in edit mode.

   | Shape data field | Value |
   |---|---|
   | Enabled | true |
   | Link    | `http://<DMAIP>/dashboard/#/db/zStaging/Visio%20URL%20Feed.dmadb?data={"version":1,"feed":null,"components":[{"cid":2,"select":{"parameters":["[cardVar:_elementId]/1202/[tableIndex]","[cardVar:_elementId]/1203/[tableIndex]","[cardVar:_elementId]/1204/[tableIndex]"],"elements":["[cardVar:_elementId]"],"indices":["[tableIndex]/[displaytableIndex]"]}}],"feedAndSelect":{}}` |

1. Make sure nothing is selected in the Visio drawing, and add the following shape data to *ThePage*. This is needed to initialize the card variable that is used in the URL.

   | Shape data field | Value |
   |---|---|
   | InitVar | _elementId:[This ElementID] |

1. Save the Visio file.

For each table row that was added in step 1, a child shape should be displayed on the visual overview of the *Generic Virtual Connector* element.Each shape will have its own button that, when clicked, will open the dashboard that was created in step 2. Depending on the button that was clicked, the URL will be fed with the appropriate table index information so that the parameter feed on the dashboard automatically selects the index associated with the button's row, and the *State* component will display the corresponding results.

## Learning paths

This tutorial is part of the following learning path:

- [Dashboards tutorials](xref:Tutorial_Dashboards)
- [Getting started with basic shapes](xref:Getting_started_with_basic_shapes)
- [Visio drawings](xref:visio)
- [Specifying data input in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL)

## Related documentation

- [Feeds](xref:Using_dashboard_feeds)
- [Visio drawings](xref:visio)
- [Specifying data input in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL)
- [Generating shapes based on table rows](xref:Generating_shapes_based_on_table_rows)
