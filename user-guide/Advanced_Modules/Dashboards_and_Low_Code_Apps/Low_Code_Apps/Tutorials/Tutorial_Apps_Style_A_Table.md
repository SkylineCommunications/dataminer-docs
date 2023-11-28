---
uid: Tutorial_Apps_Style_A_Table
---

# Styling an order arrival table

This tutorial demonstrates how you can style an order arrival table in a low-code app.

Expected duration: ** minutes.

> [!TIP]
> See also: [Using the Template Editor](xref:Template_Editor)

> [!NOTE]
> This tutorial uses DataMiner version 10.4.1.

## Prerequisites

- DataMiner 10.4.1/10.5.0 or higher.

- Download the JSON reader [from Github](https://github.com/SkylineCommunications/SLC-GQIDS-JsonReader), or deploy it directly to your DataMiner System via the [Catalog](https://catalog.dataminer.services/catalog/5491).

  > [!TIP]
  > Deploying a package is very similar to deploying a DataMiner connector. See [Deploying a DataMiner connector to your system](xref:Deploying_A_DataMiner_Connector_to_your_system).

## Overview

- [Step 1: Configure the query](#step-1-configure-the-query)

- [Step 2: Add a table component](#step-2-add-a-table-component)

- [Step 3: Configure a hyperlink](#step-3-configure-a-hyperlink)

- [Step 4: Style the 'created' column](#step-4-style-the-created-column)

- [Step 5: Add conditional coloring to the 'Fulfillment' column](#step-5-add-conditional-coloring-to-the-fulfillment-column)

- [Step 6: Add a table column that indicates which row is selected](#step-6-add-a-table-column-that-indicates-which-row-is-selected)

- [Step 7: Add a context menu](#step-7-add-a-context-menu)

## Step 1: Configure the query

In this tutorial, you will use an [ad hoc data source](xref:Get_ad_hoc_data), which can retrieve data from a JSON file.

1. Add the following data to a JSON file.

   ```json
   {
       "Columns": [
           {
               "Name": "Order ID",
               "Type": "string"
           },
           {
               "Name": "Created",
               "Type": "datetime"
           },
           {
               "Name": "Customer",
               "Type": "string"
           },
           {
               "Name": "Fullfillment",
               "Type": "string"
           },
           {
               "Name": "Total",
               "Type": "Double"
           },
           {
               "Name": "Profit",
               "Type": "Double"
           },
           {
               "Name": "Status",
               "Type": "string"
           },
           {
               "Name": "Updated",
               "Type": "datetime"
           }
       ],
       "Rows": [
           {
               "Cells": [
                   {
                       "Value": 149384
                   },
                   {
                       "DisplayValue": "Nov 3, 2023",
                       "Value": 1699009200000
                   },
                   {
                       "Value": "Sebastiaan Dumoulein"
                   },
                   {
                       "Value": "Unfulfilled"
                   },
                   {
                       "DisplayValue": "$604.50",
                       "Value": 604.50
                   },
                   {
                       "DisplayValue": "$182.50",
                       "Value": 182.50
                   },
                   {
                       "Value": "Authorized"
                   },
                   {
                       "DisplayValue": "Today",
                       "Value": 1698966000000
                   }
               ]
           },
           {
               "Cells": [
                   {
                       "Value": 153322
                   },
                   {
                       "DisplayValue": "Oct 28, 2023",
                       "Value": 1698487200000
                   },
                   {
                       "Value": "Abbas Melendez"
                   },
                   {
                       "Value": "Fulfilled"
                   },
                   {
                       "DisplayValue": "$307.70",
                       "Value": 307.70
                   },
                   {
                       "DisplayValue": "$68.20",
                       "Value": 68.20
                   },
                   {
                       "Value": "Paid"
                   },
                   {
                       "DisplayValue": "Today",
                       "Value": 1698966000000
                   }
               ]
           },
           {
               "Cells": [
                   {
                       "Value": 148826
                   },
                   {
                       "DisplayValue": "Oct 25, 2023",
                       "Value": 1698228000000
                   },
                   {
                       "Value": "Harmony Franklin"
                   },
                   {
                       "Value": "Unfulfilled"
                   },
                   {
                       "DisplayValue": "$528.35",
                       "Value": 528.35
                   },
                   {
                       "DisplayValue": "$90.50",
                       "Value": 90.50
                   },
                   {
                       "Value": "Authorized"
                   },
                   {
                       "DisplayValue": "Today",
                       "Value": 1698966000000
                   }
               ]
           },
           {
               "Cells": [
                   {
                       "Value": 146178
                   },
                   {
                       "DisplayValue": "Oct 22, 2023",
                       "Value": 1697968800000
                   },
                   {
                       "Value": "Sahil Middleton"
                   },
                   {
                       "Value": "Pending Receipt"
                   },
                   {
                       "DisplayValue": "$62.60",
                       "Value": 62.60
                   },
                   {
                       "DisplayValue": "$10.10",
                       "Value": 10.10
                   },
                   {
                       "Value": "Paid"
                   },
                   {
                       "DisplayValue": "Yesterday",
                       "Value": 1698879600000
                   }
               ]
           },
           {
               "Cells": [
                   {
                       "Value": 142115
                   },
                   {
                       "DisplayValue": "Oct 20, 2023",
                       "Value": 1697796000000
                   },
                   {
                       "Value": "Elijah Copeland"
                   },
                   {
                       "Value": "Fulfilled"
                   },
                   {
                       "DisplayValue": "$905.50",
                       "Value": 905.50
                   },
                   {
                       "DisplayValue": "$206.75",
                       "Value": 206.75
                   },
                   {
                       "Value": "Paid"
                   },
                   {
                       "DisplayValue": "Yesterday",
                       "Value": 1698879600000
                   }
               ]
           },
           {
               "Cells": [
                   {
                       "Value": 137265
                   },
                   {
                       "DisplayValue": "Oct 18, 2023",
                       "Value": 1697623200000
                   },
                   {
                       "Value": "Philip Acosta"
                   },
                   {
                       "Value": "Fulfilled"
                   },
                   {
                       "DisplayValue": "$657.35",
                       "Value": 657.35
                   },
                   {
                       "DisplayValue": "$264.55",
                       "Value": 264.55
                   },
                   {
                       "Value": "Paid"
                   },
                   {
                       "DisplayValue": "Yesterday",
                       "Value": 1698879600000
                   }
               ]
           },
           {
               "Cells": [
                   {
                       "Value": 133255
                   },
                   {
                       "DisplayValue": "Oct 15, 2023",
                       "Value": 1697364000000
                   },
                   {
                       "Value": "Sian Vaughan"
                   },
                   {
                       "Value": "Pending Receipt"
                   },
                   {
                       "DisplayValue": "$365.40",
                       "Value": 365.40
                   },
                   {
                       "DisplayValue": "$58.00",
                       "Value": 58.00
                   },
                   {
                       "Value": "Authorized"
                   },
                   {
                       "DisplayValue": "Oct 15, 2023",
                       "Value": 1697364000000
                   }
               ]
           },
           {
               "Cells": [
                   {
                       "Value": 112025
                   },
                   {
                       "DisplayValue": "Oct 06, 2023",
                       "Value": 1696586400000
                   },
                   {
                       "Value": "Haaris Carroll"
                   },
                   {
                       "Value": "Pending Receipt"
                   },
                   {
                       "DisplayValue": "$259.50",
                       "Value": 259.50
                   },
                   {
                        "DisplayValue": "$80.20",
                        "Value": 80.20
                   },
                   {
                       "Value": "Paid"
                   },
                   {
                       "DisplayValue": "Oct 06, 2023",
                       "Value": 1696586400000
                   }
               ]
           }
       ],
       "Version": 1
   }
   ```

1. Save the file under the name *Orders.json* in the *C:\Skyline DataMiner\Documents\GQI data sources* folder.

## Step 2: Add a table component

You can now create the query using the *Orders.json* file as the data source.

1. Create a new low-code app. See [Creating low-code applications](xref:Creating_custom_apps).

1. In the data pane, select *Queries* and click the + icon to add a new query.

1. Give the query a name, e.g. "Orders".

1. In the dropdown box, select *Get ad hoc data*.

1. Select *JSON Reader* from the *Data source* dropdown list.

1. Select *Orders.json* from the *Filter* dropdown list.

   ![Query](~/user-guide/images/OrdersQuery.png).

1. Drag the ad hoc data feed onto an empty section of the low-code app page.

1. Hover the mouse pointer over the component and click the ![Visualizations](~/user-guide/images/DashboardsX_visualizations00095.png) icon.

1. Choose the [table](xref:DashboardTable) visualization.

   ![Default unstyled table](~/user-guide/images/DefaultTable.png)

## Step 3: Configure a hyperlink

Now that the table component is set up, make it so that the first table column, *Order ID*, is configured to open a webpage in a new tab when clicked.

1. Make sure the table component is selected, and navigate to *Layout > Column Appearance*.

1. Select *Order ID* from the dropdown list.

   A preview of the column's appearance is displayed. By default, this is set to *Left*.

1. Click the preview and select *Hyperlink* from the list of available presets.

   ![Selecting hyperlink preset](~/user-guide/images/SelectingHyperlinkPreset.gif)

1. To specify the webpage this hyperlink redirects to, configure an action in the Template Editor.

   > [!TIP]
   > In the Template Editor, you can configure actions for icon, rectangle, and ellipse layers. For more information, see [Specifying layer properties](xref:Template_Editor#specifying-layer-properties)

   1. In the *Column Appearance* settings, click the ellipsis button ("...") and select *Customize preset* to open the Template Editor.

   1. In the *Layers* tab, select the rectangle layer and click *Configure actions* in the *Settings* pane.

      > [!TIP]
      > You can recognize the type of layer by the symbol displayed in the lower left corner. For a rectangle layer, a rectangle icon is displayed.

      ![Configure action](~/user-guide/images/ConfigureAction.png)

      Because you used the *Hyperlink* preset option, a [*Navigate to a URL* action](xref:LowCodeApps_event_config#navigating-to-a-url) is already configured that redirects the user to `http(s)://[DMA name]/{Order ID}` when they click the shape.

   1. To edit this hyperlink, expand the configuration section by clicking the sideward arrow. Replace the URL with the following link: `https://www.google.com/search?q={Order ID}`.

      ![Configure action URL](~/user-guide/images/ConfigureActionPopup.png)

   1. To save the new hyperlink, click *Ok* in the lower right corner.

   1. To save all changes, click *Save* in the lower right corner of the Template Editor.

      Now, when you click a table cell in the *Order ID* column, a google search page is opened with results for that order ID.

## Step 4: Style the 'created' column

For the second column, *Created*, ensure a more visually appealing styling by centering the date, making the text bold, and changing the text color.

1. Make sure the table component is selected, and navigate to *Layout > Column Appearance*.

1. Select *Created* from the dropdown list.

   A preview of the column's appearance is displayed. By default, this is set to *Right*.

1. Click the preview and select *Center* from the list of available presets.

   ![Center Preset](~/user-guide/images/CenterPreset.png)

1. Click the ellipsis button ("...") and select *Customize preset* to open the Template Editor.

1. In the *Layers* tab, select the text layer.

1. In the *Properties* section of the *Settings* pane on the right side of the preview, enclose the text by HTML \<b> elements to signify bold text.

1. To modify the text color, use the color picker box and select *Apply*.

   ![Change text color](~/user-guide/images/ChangeTextColor.png)

1. To save all changes, click *Save* in the lower right corner of the Template Editor.

1. Optionally, you can repeat these steps for the *Profit* column to apply similar styling.

## Step 5: Add conditional coloring to the 'Fulfillment' column

For the fourth column, *Fulfillment*, we want to add conditional coloring, dependent on the value of the column.

1. Make sure the table component is selected, and navigate to *Layout > Column Appearance*.

1. Select *Fulfillment* from the dropdown list.

   A preview of the column's appearance is displayed. By default, this is set to *Left*.

1. Click the ellipsis button ("...") and select *Customize preset* to open the Template Editor.

1. In the *Layers* tab, select the text layer.

1. In the *Properties* section of the *Settings* pane on the right side of the preview, change the horizontal padding to 10 px and the vertical padding to 2 px.

   ![Add padding](~/user-guide/images/AddPadding.png)

   By adjusting these padding settings, you can now add a clearly visible background color.

1. In the *Conditional cases* section of the *Settings* pane, click *Add case*.

1. Select *Fulfillment* from the dropdown list.

1. Enter "Pending Receipt" in the *Filter* text box.

   ![Add conditional override](~/user-guide/images/AddConditionalOverride.gif)

   The configured action will now only be executed when the value in the *Fulfillment* column is set to *Pending Receipt*.

1. To configure what will happen to the text when the item meets the condition, follow these steps:

   1. Enable *Show text*.

   1. Click *Background* and use the color picker box to adjust the background color to purple. Make sure the opacity is set to 100%.

      ![Override background color](~/user-guide/images/OverrideBackgroundColor.png)

   Click *Apply* to save these changes.

1. Click *Add case* to add another conditional case.

1. Select *Fulfillment* from the dropdown list.

1. Enter "Fulfilled" in the *Filter* text box.

1. Configure the following settings:

   1. Enable *Show text*.

   1. Click *Background* and use the color picker box to adjust the background color to green. Make sure the opacity is set to 100%.

   Click *Apply* to save these changes.

1. Click *Add case* to add another conditional case.

1. Select *Fulfillment* from the dropdown list.

1. Enter "Unfulfilled" in the *Filter* text box.

1. Configure the following settings:

   1. Enable *Show text*.

   1. Click *Background* and use the color picker box to adjust the background color to red. Make sure the opacity is set to 100%.

   Click *Apply* to save these changes.

1. To save all changes, click *Save* in the lower right corner of the Template Editor.

1. Optionally, you can repeat these steps for the *States* column to apply similar styling.

## Step 6: Add a table column that indicates which row is selected

To add a column that shows which row is currently selected, you must add a new column using GQI and customize an icon with the Template Editor.

Add a new column using GQI:

1. In the *Data* tab, go to *Queries*.

1. Click the pencil icon next to *Orders* and specify the following details:

   - Operator: *Column manipulations*.

   - Manipulation method: *Concatenate*.

   - Columns: *Order ID*.

   - Format: `{0}`.

   - New column name: Enter one space.

1. Add *Select* as a second operator.

   ![Select](~/user-guide/images/SelectGQIOperator.png)

1. To stop editing the *Orders* query, click the pencil icon.

1. Select the top row of the newly added column and drag it from the far right to the far left side of the table.

Customize the column appearance in the Template Editor:

1. Make sure the table component is selected, and navigate to *Layout > Column Appearance*.

1. Select your new column from the dropdown list.

1. Click the preview and select the [Icon](~/user-guide/images/Icon_Preset.png) icon from the list of available presets.

1. Click the ellipsis button ("...") and select *Customize preset* to open the Template Editor.

1. Make sure no layers are selected. In the *Settings* pane, change the height to 64 px.

   This change will modify the height of the table rows.

   ![Change template height](~/user-guide/images/ChangeTemplateHeight.png)

1. In the *Layers* tab, select the icon layer.

1. In the *Properties* section of the *Settings* pane, click *Icon* and change the icon to a checkmark.

1. Rescale the icon so that it fits the template nicely.

   ![Change icon](~/user-guide/images/ChangeIcon.png)

1. In the *Conditional cases* section of the *Settings* pane, click *Add case*.

1. Select *Is selected* from the dropdown list.

1. Select *Yes*.

1. Configure the following settings:

   1. Enable *Show icon*.

   1. Click *color* and use the color picker box to adjust the text color to green.

1. Do not close the Template Editor yet, as you will need it again in step 7.

## Step 7: Add a context menu

To finish off this tutorial, you will add a context menu to the table.

1. In the *Tools* tab, click *Icon*.

1. Within the preview, press and hold down the left mouse button to define the area for your new icon layer. Release the mouse button once you are satisfied with the size and shape of the icon.

1. In the *Properties* section of the *Settings* pane, click *Icon* and change the icon to an ellipsis ("...").

   > [!TIP]
   > To locate this icon more efficiently, enter "More" in the filter box at the top.

1. Make sure the new icon layer is selected in the *Layers* tab and rescale the icon so that it fits the template nicely.

   ![Add context menu icon](~/user-guide/images/AddContextMenuIcon.png)

1. In the *Properties* section of the *Settings* pane, click *Configure actions*.

1. In the pop-up window, select *Show context menu* from the dropdown list.

1. Configure the different menu items:

   - Let's add a 'Calculate percentage profit' button to the context menu where we divide the 'profit' column with the 'total' column, We'll just use google and search the division to show the result. On the left side on the menu we can first add an icon to the item. We'll use a calculator icon for this tutorial. After that we can add a name to the item. Let's pick 'Calculate percentage profit'

    ![Configure Name and Icon](~/user-guide/images/ConfigureIconAndName.gif)

- We now need to configure an action. Click the button next to the name (Configure actions). This opens the actions menu we already know. Here select the action to 'Navigate to URL' and enter the following URL: `https://google.com/search?q={Profit}%2F{Total}`. This will open google and search the division of the profit and total column. We can use the intellisense provided by low code apps to grab the profit and total. To do this, make sure a column is selected, type '{' and start using the intellisense to select the correct column (To confirm a intellisense selection, press 'TAB' and use the arrow keys to navigate).

    ![Configure action](~/user-guide/images/ConfigureGoogleAction.gif)

- Adding another item in the context menu is done the same way. Click 'Add menu item'. Let's use a 'Search' icon and just google the orderID again, Name it 'Search order'. We can now configure an action the same way we did before. Using  the 'Navigate to URL' action and enter the following URL: `https://google.com/search?q={Order ID}` (Use intellisense to configure the Order ID column).

    ![Configure action](~/user-guide/images/ConfigureGoogleAction2.gif)

Publish the app and see the result. Select a row by clicking on it, the checkmark will now be green for the selected row. Click the 3 dots to open the context menu and click on 'Calculate percentage profit'. A new tab will open with the google search results for the division of the profit and total column. Same for the 'Search order' option.

![Result](~/user-guide/images/TableResult.png)
