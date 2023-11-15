---
uid: Tutorial_Apps_Style_A_Table
---

# Styling an order arrival table

This tutorial demonstrates how we can style an order arrival table in a Low-Code App.

The content and screenshots for this tutorial have been created in DataMiner 10.4.-

## Overview

- [Step 1: Configure the query and add a table component to the dashboard](#step-1-configure-the-query-and-add-a-table-component-to-the-dashboard)
- [Step 2: Create an order hyperlink](#step-2-create-an-order-hyperlink)
- [Step 3: Style the 'created' column](#step-3-style-the-created-column)
- [Step 4: Style the Fullfilment column with some conditional coloring](#step-4-style-the-fullfilment-column-with-some-conditional-coloring)
- [Step 5: Adding a Table column to show which row is currently selected](#step-5-adding-a-table-column-to-show-which-row-is-currently-selected)

## Step 1: Configure the query and add a table component to the dashboard  

- For this tutorial we'll use an Adhoc data source that allows us to read data from a JSON file. This data source can be found on [Github](https://github.com/SkylineCommunications/SLC-GQIDS-JsonReader) or installed directly to a dataminer system via the [Catalog](https://catalog.dataminer.services/catalog/5491).

- Since this is a JSONReader we'll need to add a Json file in the correct location on our dataminer system. Add the following json data to a file named `Orders.json` and put it in this location: `C:\Skyline DataMiner\Documents\GQI data sources\Orders`

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

- The query can now be created using this data source. Create a new app and add a new query to it. Select 'Get ad hoc data', in the Data source dropdown, select 'JSON Reader' and in the File dropdown select 'Orders\Orders.json'.

    ![Query](~/user-guide/images/OrdersQuery.png).

- Drag and drop a table component on the App page.

- Drag the query on the component.

    ![Default unstyled table](~/user-guide/images/DefaultTable.png)

## Step 2: Create an order hyperlink

For the first column we want to make the Order ID a clickable link that opens a webpage in a new tab.

- To change the layout for this column, select the table component, go to the *Layout* tab on the right side of the Application. And then go to the *Column Appearance* section.

- Select the Order ID column in the dropdown. And select the hyperlink preset by clicking on the already set 'Left' template.

    ![Selecting hyperlink preset](~/user-guide/images/SelectingHyperlinkPreset.gif)

- Since the template already has most of the things we want, we can just change the action that happens when clicking on the hyperlink. To do this, we need to open the template editor by clicking on the ![More button](~/user-guide/images/MoreButton.png) and selecting 'Customize preset'.

- In the template editor, on an icon, rectangle and ellipse we can add an action. Since we want the hyperlink to open when we click on the Order ID cell, we need to have an (invisible) rectangle we can configure this action on. Since we used the preset, this rectangle is already there. We just need to configure the action. Select the rectangle and click on the 'Configure Actions' button.

    ![Configure action](~/user-guide/images/ConfigureAction.png)

- On the popup that now appears, we can configure actions that happen when clicking the rectangle. For this tutorial we'll just open google and search the clicked ID. To do this, we just need to change the already present 'Navigate to a URL' action to the correct link.

    ![Configure action URL](~/user-guide/images/ConfigureActionPopup.png)

With this configured. We can save everything by pressing 'Ok' and then 'Save' on the template editor. When the app is now publish, the result will be that when clicking on the Order ID, a new tab will open with the google search results for the Order ID.

## Step 3: Style the 'created' column

For the second column we just want to center the date, make the text bold and change the text color.

- Repeat 1 and 2 from the previous step for the 'Created' column. Instead of selecting the hyperlink preset, select the 'Center' preset.

    ![Center Preset](~/user-guide/images/CenterPreset.png)

- Alter this preset by clicking '...' and selecting 'Customize preset'.

- To make text bold we can use a HTML tag. In the template editor, put a \<b> element in front of {Created} and add \</b> at the end.

    ![Bold text](~/user-guide/images/BoldText.png)

- To change the text color, in the right sidebar we can change it using the color picker. Don't forget to click Apply to confirm the change.

    ![Change text color](~/user-guide/images/ChangeTextColor.png)

- With this configured. We can save everything by pressing 'Save' on the template editor.

Repeat this for the Profit column to give it some styling too.

## Step 4: Style the Fullfilment column with some conditional coloring

For this column we want to apply some conditional colors depending on the value of the column.

- Add the 'Fullfilment' column to the column appearance section of the table component. For this one we'll start from the already selected 'Left' preset. and open the template editor

- Since we want to add conditional coloring, We need to add some Horizontal and vertical padding to the text. This way we can add a background color to the text. This can be done in the right sidebar by changing the padding values.

    ![Add padding](~/user-guide/images/AddPadding.png)

- We can now add conditional overrides to change the background color of the text. To do this, in the right sidebar, under the 'Conditional cases' section, click on the 'Add case' button.

- Since we want to change the color depending on the value of the cell, in the 'When condition' dropdown, we can select the 'Fullfillment' column. In the text field we can enter the value we want to apply this conditional override to. Let's start with 'Pending Receipt'.

    ![Add conditional override](~/user-guide/images/AddConditionalOverride.gif)

- Now we can change what happens to the text when this 'Case' is true. We first off al want the text to be shown, so we can toggle 'Show text' to true. Then we can click on the 'Background' button to override this setting. Open the picker again to choose an override color. Let's go with purple. Don't forget to change the opacity to 100%.

    ![Override background color](~/user-guide/images/OverrideBackgroundColor.png)

- Add conditional overrides for 'Fulfilled' and 'Unfullfilled' as well. For 'Fulfilled' we'll use green and for 'Unfulfilled' we'll use red.

    ![Other overrides](~/user-guide/images/OtherConditionalBackgroundOverrides.png)

Repeat this step for the Status column to give it some conditional coloring as well.

## Step 5: Adding a Table column to show which row is currently selected

For this step we'll add a column that shows which row is currently selected using an icon. We'll first use GQI to add a new column and then style it using the template editor.

- To first start with this we'll need to add a row to the table component. We can do so by using the 'Column manipulations' operator and using the 'Concatenate' manipulation method. We can choose any column to concatenate, since we'll just change the template later on. For the purpose of this tutorial we'll choose the 'Order ID' column.
Format like this `{0}` and just put a space in the 'New column name' field.

    ![Concatenate](~/user-guide/images/ConcatenateGQIOperator.png)

- Our new column has now been added to the right side of the table. We can move it to the left side by using the 'Select' operator. Hover over the new column and click the pointer arrows on the right hand side to move it to the top of the list.

    ![Select](~/user-guide/images/SelectGQIOperator.png)

- Let's now style this column! We'll start by adding this column to the column appearance section of the table component. For this one we'll start from the icon preset (i). Open the template editor.

- We'll first change the height of the table rows. We can do this by changing the height of the template. To do this, make sure no layer is selected by clicking next to the template in the center and then change the height in the right sidebar.

    ![Change template height](~/user-guide/images/ChangeTemplateHeight.png)

- Let's change this icon to a checkmark. We can do this by selecting the icon and then changing the icon in the right sidebar. Rescale the icon so it fits the template nicely.

    ![Change icon](~/user-guide/images/ChangeIcon.png)

- We can now add a conditional override to make the checkmark green when the row is selected. To do this, in the right sidebar, under the 'Conditional cases' section, click on the 'Add case' button. In the conditions select 'State - Is Selected', check 'Yes', show the icon and change the color to green. Save the template.

    ![Add conditional override](~/user-guide/images/AddConditionalColorOverride.png)

- Publish the app and see the result. Select a row by clicking on it, the checkmark will now be green for the selected row.

    ![Result](~/user-guide/images/TableResult.png)
