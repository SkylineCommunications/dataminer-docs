---
uid: Using_visio_to_control_dashboard_feed_components
---

# Using Visual Overview to control dashboard feed components

In this tutorial, you will learn how to feed data into a dashboard URL in order to automate selections on feed components when the dashboard is opened. The data to be fed into the URL will be defined on an element's visual overview through the clever use of shape data.

Expected duration: 45 minutes

> [!NOTE]
> The content of this tutorial has been created with DataMiner web apps version 10.4.1.

## Prerequisites

- DataMiner version 10.2.2 or higher

- Protocol: [Skyline Generic Virtual Connector](https://catalog.dataminer.services/details/connector/7021) – version 1.0.0.3 or higher

- Microsoft Visio

## Overview

- [Step 1: Create a new Virtual Connector element and add numerical data to the 'Numerical Master Table' on the element's 'Table' data page](#step-1-create-a-new-virtual-connector-element-and-add-numerical-data-to-the-numerical-master-table-on-the-elements-table-data-page)

- [Step 2: Create a new dashboard and add a 'Parameter feed' component and a 'State' component to display the numerical data from the Virtual Connector](#step-2-create-a-new-dashboard-and-add-a-parameter-feed-component-and-a-state-component-to-display-the-numerical-data-from-the-virtual-connector)

- [Step 3: Create a new visual overview for the Generic Virtual Connector element with shapes for each numerical table index linking to the dashboard](#step-3-create-a-new-visual-overview-for-the-generic-virtual-connector-element-with-shapes-for-each-numerical-table-index-linking-to-the-dashboard)

> [!NOTE]
> The data being interacted with in the example below originates from elements using the *Skyline Generic Virtual Connector* protocol. However, this process will work for elements using any protocol that features table-based parameters.

## Step 1: Create a new Virtual Connector element and add numerical data to the 'Numerical Master Table' on the element's 'Table' data page

1. Open DataMiner Cube.

1. Create a new element using the *Skyline Generic Virtual Connector* protocol.

   1. Open the Surveyor.

   1. Right-click a view (e.g. the root view), and select *New* > *Element*.

   1. Enter an element name, select the DMA, the protocol (i.e. *Skyline Generic Virtual Connector*) and the protocol version (e.g. 1.0.0.3), and click *Create*.

1. Go to the *DATA* > *Table* page of the newly created element, which contains the *Numeric Master Table*.

1. Right-click below the table's column headers, and click *Add* to add a new row to the table.

   ![Add Row Numeric Table](~/dataminer/images/VisioURLFeed_AddRowNumericTable.png)

1. Enter the row's primary key [IDX], enter random numbers into the first three columns, and click *OK*.

   > [!IMPORTANT]
   > Do not use any special characters for the primary key, as they will interfere with the URL linking later in this tutorial.

   ![Table input](~/dataminer/images/VisioURLFeed_AddRowNumericTableInput.png)

1. Add at least one more row to the table.

   ![Table rows](~/dataminer/images/VisioURLFeed_NumericTableRows.png)

## Step 2: Create a new dashboard and add a 'Parameter feed' component and a 'State' component to display the numerical data from the Virtual Connector

1. Open the *Dashboards* app.

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. If you are not yet in edit mode, then click *Start editing*.

1. Add a [Parameter picker component](xref:DashboardParameterPicker).

1. From the *Data* pane on the right, drag the *ELEMENTS* header onto the *Parameter feed* component to be used as data.

1. From the *Data* pane on the right, add the necessary parameters:

   1. Expand the *PARAMETERS* section.

   1. Set *From* to "Protocol".

   1. Set *Protocol* to "Skyline Generic Virtual Connector".

   1. Use the filter to find the three numeric table parameters that you entered numbers for.

   1. Drag each of these parameters onto the *Parameter feed* component to be used as data.

   ![Parameters](~/dataminer/images/VisioURLFeed_ParameterDataForFeed.png)

1. From the *Data* pane on the right, add a protocol filter:

   1. Expand the *PROTOCOLS* section.

   1. Search for the *Skyline Generic Virtual Connector*.

   1. Drag the protocol onto the *Parameter feed* component to be used as a filter.

   ![Protocols](~/dataminer/images/VisioURLFeed_ProtocolDataForFeed.png)

1. Add a [State component](xref:DashboardState).

1. Click the *State* component to select it.

1. From the *Data* pane on the right, add the *Parameters* feed:

   1. Expand the *FEEDS* section to find the items associated with the parameter feed.

   1. Expand the *Parameter feed* component.

   1. Drag the *Parameters* item onto the *State* component to be used as data.

   ![Feeds](~/dataminer/images/VisioURLFeed_ParameterDataForState.png)

1. In the *Layout* pane on the right, select the *LABELS* boxes to display the parameter name, the index, and the value.

   ![Labels](~/dataminer/images/VisioURLFeed_StateLayoutOptions.png)

1. Click *Stop editing* to exit edit mode.

   At this point, you should be able to make manual parameter feed selections to control which parameter values are shown on the *State* component.

   ![State component](~/dataminer/images/VisioURLFeed_DashboardManualResults.png)

1. In the top-right corner of the screen, click the ellipsis button, and then click *Share*.

   ![Share button](~/dataminer/images/VisioURLFeed_ShareButton.png)

1. In the pop-up window, enable the *Use uncompressed URL parameters* option, and then click *Copy link*.

   ![Pop-up window](~/dataminer/images/VisioURLFeed_URLLink.png)

   The URL you copied will be used later in this tutorial.

1. Close the pop-up window by clicking the "X" in the top-right corner.

## Step 3: Create a new visual overview for the Generic Virtual Connector element with shapes for each numerical table index linking to the dashboard

1. In DataMiner Cube, open the *Generic Virtual Connector* element you created earlier in this tutorial.

1. Go to the *VISUAL* page of the element, and right-click anywhere to have the Visio file options displayed.

1. Hover the mouse pointer over *Set as active "..." element Visio file*, and click *New blank*.

   ![New blank](~/dataminer/images/VisioURLFeed_NewBlankVisio.png)

1. In the confirmation box, click *Yes*.

   A new Visio file associated with the element will now be created. It will look like a blank canvas on the VISUAL page of the element.

1. If the new Visio file is not opened automatically, on the blank *VISUAL* page, right-click anywhere, and select *Edit in Visio*.

   This will open Microsoft Visio.

   > [!NOTE]
   > When you make changes to the Visio file, they will immediately appear in DataMiner Cube as soon as you save the file.

1. Add a large rectangle that represents a table row.

1. Add a textbox with the text *[tableIndex]*, and move it on top of the rectangle.

1. Add a button to navigate to the Dashboards app:

   1. Add a small rectangle shape.

   1. Double-click the rectangle, and give it a useful description.

   1. Move the rectangle on top of the first rectangle representing a row.

1. Ctrl-click all three components to select them all, then right-click, and select *Group > Group*.

   You should see the following under the *Drawing Explorer*:

   ![Drawing Explorer](~/dataminer/images/VisioURLFeed_VisioRowGroup.png)

   > [!NOTE]
   > If the Drawing Explorer is not automatically displayed, follow these steps:
   >
   > 1. Right-click the ribbon and select *Customize the Ribbon*.
   > 1. In the *Main Tabs* list on the right, make sure *Developer* is enabled.
   > 1. Click *OK* in the lower-right corner.
   > 1. Access the *Developer* tab, and select the *Drawing Explorer* checkbox in the *Show/Hide* group.
   >
   >    The Drawing Explorer window will become available in the corner of your drawing.

1. Right-click the grouped sheet representing a row, select *Shape Data*, and add the following shape data:

   | Shape data field | Value |
   |---|---|
   | ChildType   | Row |
   | ChildMargin | 5   |

1. Ctrl-click the grouped sheet representing the row and the existing background sheet that came with the new Visio file to select both, then right-click, and select *Group* > *Group*.

1. Add the following shape data to the larger grouped sheet:

   | Shape data field | Value |
   |---|---|
   | Children       | Row   |
   | ChildrenSort   | Name  |
   | ChildrenPanel  | Stack |
   | ChildrenSource | [this element]/1200 |

   > [!NOTE]
   > *[this element]* is a dynamic placeholder, and *1200* is the table parameter ID of the *Numeric Master Table*.

1. Using a publicly available web-based encoded JSON URL converter, convert the URL you copied earlier to a human-readable format.

   This will make it easier to understand how feed selections are represented in the dashboard's URL.

   ![URL converter](~/dataminer/images/VisioURLFeed_URLConvert.png)

1. Replace sections of the URL with placeholders to allow dynamic entry based on the row index that is fed into it:

   ```txt
   http://<DMAIP>/dashboard/#/db/zStaging/Visio%20URL%20Feed.dmadb?data={"version":1,"feed":null,"components":[{"cid":2,"select":{"parameters":["[cardVar:_elementId]/1202/[tableIndex]","[cardVar:_elementId]/1203/[tableIndex]","[cardVar:_elementId]/1204/[tableIndex]"],"elements":["[cardVar:_elementId]"],"indices":["[tableIndex]/[displaytableIndex]"]}}],"feedAndSelect":{}}
   ```

   > [!NOTE]
   > The first part of the URL (i.e. the part on the left of the question mark) needs to be changed to match the naming structure of your dashboard. The component ID (`cid`) also needs to be changed to match that of your parameter feed. You can find the ID of each component in the lower-right corner of the component while in edit mode.

1. Again use a web-based encoded JSON URL converter, this time to convert the URL back to encoded JSON.

1. Add the following shape data to the button shape.

   | Shape data field | Value |
   |---|---|
   | Enabled | *true* |
   | Link    | The URL with encoded JSON |

1. Make sure nothing is selected in the Visio drawing, and add the following shape data to *ThePage*:

   | Shape data field | Value |
   |---|---|
   | InitVar | _elementId:[This ElementID] |

   This is needed to initialize the card variable that is used in the URL.

1. Save the Visio file.

For each table row that was added in [step 1](#step-1-create-a-new-virtual-connector-element-and-add-numerical-data-to-the-numerical-master-table-on-the-elements-table-data-page), a child shape should now be displayed on the visual overview of the *Generic Virtual Connector* element. Each shape will have its own button that, when clicked, will open the dashboard that was created in [step 2](#step-2-create-a-new-dashboard-and-add-a-parameter-feed-component-and-a-state-component-to-display-the-numerical-data-from-the-virtual-connector). Depending on the button that was clicked, the URL will be fed with the appropriate table index information so that the parameter feed on the dashboard automatically selects the index associated with the button's row, and the *State* component will display the corresponding results.

## Related documentation

- [Dashboards tutorials](xref:Tutorial_Dashboards)
- [Visio drawings](xref:visio)
- [Getting started with basic shapes](xref:Getting_started_with_basic_shapes)
- [Component data](xref:Component_Data)
- [Specifying data input in a dashboard or app URL](xref:Specifying_data_input_in_a_URL)
- [Generating shapes based on table rows](xref:Generating_shapes_based_on_table_rows)
