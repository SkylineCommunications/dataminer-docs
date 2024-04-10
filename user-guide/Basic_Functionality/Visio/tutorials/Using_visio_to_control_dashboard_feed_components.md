---
uid: Using_visio_to_control_dashboard_feed_components
---

# Using Visio to control dashboard feed components

In this tutorial, you will learn feed data into a dashboard URL in order to automate selections on feed components when the dashboard is opened.The data to be passed into the URL will be defined on an element's visual overview through the clever use of shape data.

Expected duration: 45min

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.4.1 web apps.

## Prerequisites

- DataMiner Version 10.2.2 or higher.
- Protocol: Skyline Generic Virtual Connector – 1.0.0.3
- Microsoft Visio

## Overview

- Step 1: Create a new Virtual Connector Element and add numerical data to the Master Numerical Table on the element’s “Tables” data page.
- Step 2: Create a new dashboard and add a “Parameter Feed” component and a “State” component.
- Step 3: Create a new Visual Overview for the Generic Virtual Connector Element with shapes for each Numeric table index linking to the Dashboard.

> [!NOTE]
> The data being interacted with in the example are originating from elements using the Skyline Generic Virtual Connector. However, this process will work for elements utilizing any protocol that features table-based parameters.

## Step 1: Create a New Virtual Connector Element and Add Numerical Data to the “Numerical Master Table” on the Element’s “Table” Data Page

1. Create a new element using the Skyline Generic Virtual Connector protocol. The minimum required version 1.0.0.3 can be downloaded, or cloud deployed from here.
1. Once created, navigate to the “Table” data page on the element to find the “Numeric Master Table”.
1. Right-click below the table’s column headers to add a new row to the table.  
1. Input the row’s Primary Key [IDX] and enter random numbers into the first 3 columns, then click OK. NOTE: Do not use any special characters for the Primary Key as they will interfere with the URL linking in Step #3.
1. Add at least one more row to the table before continuing.

## Step 2: Create a New Dashboard and Add a “Parameter Feed” Component and a “State” Component to Display the Numeric data from the Virtual Connector

1. Create a new dashboard.
1. Enter Edit mode.
1. Add a Parameter Feed component.
1. From the data pane on the right, drag over the “ELEMENTS” field to add it as data into the parameter feed.
1. From the data pane on the right, expand the “PARAMETERS” section to filter and find the three numeric table parameters that you entered numbers for. Drag them each over to the parameter feed to be used as data.
1. From the data pane on the right, expand the “PROTOCOLS” field and search for the Skyline Generic Virtual Connector. Drag it over to the parameter feed to be used as a filter.
1. Add a State component.
1. Click on the State component to highlight it. Under the “Layout” tab on the right side data pane, check the “LABELS” boxes to show parameter name, index, and value.
1. From the data pane on the right, expand the “FEEDS” section to find the items associated to the parameter feed. Expand the parameter feed and drag the “Parameters” item over to the State component to be used as data.
1. At this point, you should be able to make manual Parameter Feed selections to control which parameter values are shown on the State component.
1. Exit Edit mode.
1. On the top right of the dashboard webpage, click the ellipsis to find the “Share” option. Click Share to open a dialog window. Enable the option to “Use uncompressed URL parameters” and then copy the URL link. The URL will used in Step #3 of this tutorial.

## Step 3: Create a new Visual Overview for the Generic Virtual Connector Element with shapes for each numeric table index linking to the dashboard

1. Back on Cube, open the Generic Virtual Connector element that was created in step #1.
1. Open the “VISUAL” page of the element (the visual overview - VISIO) and right click anywhere to display Visio file options. Hover the cursor over “Set as active…element Visio file” and click on “New blank”. This will create a new Visio file associated to the element. It will look like a blank canvas on the Visual Overview for the element.
1. On the blank Visual Overview page, right-click anywhere and select “Edit in Visio”. This will open Microsoft Visio. NOTE: Changes that are made to the Visio file and saved can be seen immediately back on cube.
1. Start by adding a new rectangle that represents a table row.
1. Add a new textbox with the text: [tableIndex]. Move it on top of the rectangle.
1. Add a new smaller rectangle that will act as a button to navigate to the dashboard webpage. Double-click the rectangle to give it a useful description. Move it on top of the first rectangle representing a row.
1. Ctrl-click all 3 components to highlight all 3 at once. Right-click and group them. You should see the following under the “Drawing Explorer”:
1. Add the following shape data to the grouped sheet representing a row.

   - ChildType: Row
   - ChildMargin: 5

1. Ctrl-click the grouped sheet representing the row and the existing background sheet that came with the new Visio file to highlight both at once. Right-click and group them to create a new group. Add the following shape data to the larger grouped sheet.

   - Children: Row
   - ChildrenSort: Name
   - ChildrenPanel: Stack
   - ChildrenSource: [this element]/1200

     > [!NOTE]
     > “this element” is acting as a dynamic placeholder. “1200” is the table PID for the “Numeric Master Table”.

1. Using a publicly available web-based encoded JSON URL converter, the URL that was captured in Step #2 can be transformed into a human readable format. This allows the user to understand how feed selections are represented in the dashboard’s URL.
1. With this information, certain sections of the URL can be replaced with placeholders that will allow dynamic entry based on the row index that is fed into it.
1. Add the following shape data to the button shape. NOTE: the first part of the URL needs to be changed to match the naming structure of your dashboard. The component ID (cid) also needs to be changed to match that of your parameter feed. Note: You can find the ID of each component in the lower right corner of the component while in edit mode.

   - Enabled: true
   - Link: `http://<DMAIP>/dashboard/#/db/zStaging/Visio%20URL%20Feed.dmadb?data={"version":1,"feed":null,"components":[{"cid":2,"select":{"parameters":["[cardVar:_elementId]/1202/[tableIndex]","[cardVar:_elementId]/1203/[tableIndex]","[cardVar:_elementId]/1204/[tableIndex]"],"elements":["[cardVar:_elementId]"],"indices":["[tableIndex]/[displaytableIndex]"]}}],"feedAndSelect":{}}`

1. Add the following shape data to the “ThePage” (when nothing is selected on the Visio drawing). This is needed to initialize the card variable that is being used in the URL.

   - InitVar: _elementId:[This ElementID]

1. Once the Visio is saved, a child shape for each table row that was added in Step #1 should be displayed on the visual overview for the Generic Virtual Connector element. Each shape will have its own button, that when clicked will open the dashboard that was created in Step #2. Depending on the button clicked, the URL will be fed with the appropriate table index information so that the parameter feed on the dashboard automatically selects the index associated to the button’s row and the State component will display the corresponding results.

## Learning paths

This tutorial is part of the following learning path:

- Dashboards tutorials | DataMiner Docs
- Getting started with basic shapes | DataMiner Docs
- Visio drawings | DataMiner Docs
- Specifying data input in a dashboard URL | DataMiner Docs

## Related documentation

- Feeds
- Visio drawings | DataMiner Docs
- Specifying data input in a dashboard URL | DataMiner Docs
- Generating shapes based on table rows | DataMiner Docs
