---
uid: Information_Templates_Tutorial
---

# Using information templates for enhanced parameter presentation and monitoring

This tutorial will show you how to configure and use an information template to enhance the presentation and monitoring of parameters associated with satellite earth stations.

Expected duration: 20 minutes

> [!TIP]
> See also: [Information templates](xref:Information_templates)

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.5.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Deploy the *Info Template Quick Tips* package from the [Catalog](https://catalog.dataminer.services/details/32274506-07a4-4ecb-98d3-bea773c3903e).

  Once you have deployed the package, a view and element named "Info template quick tips" will be added to your DataMiner Agent, and the Master Table on the *Data > Table* page of this element will contain pre-provisioned data.

  ![Info template quick tips tutorial image 0](~/user-guide/images/Info_Template_Quick_Tips_img00.png)

## Overview

This tutorial consists of the following steps:

- [Step 1: Create and configure a new information template](#step-1-create-and-configure-a-new-information-template)

- [Step 2: Enhance the table's data presentation](#step-2-enhance-the-tables-data-presentation)

- [Step 3: Override the 'Location' parameter description](#step-3-override-the-location-parameter-description)

## Step 1: Create and configure a new information template

1. In Cube, select *Apps* in the sidebar and open the *Protocols & Templates* module.

1. Select *Skyline Generic Virtual Connector* from the list of protocols.

1. Under *Information Templates*, right-click the default information template and select *New*.

   ![Info template quick tips tutorial image 1](~/user-guide/images/Info_Template_Quick_Tips_img01.png)

1. Choose a name for the template and select *OK*.

1. Change the display name of the following parameters: *Master Table*, *Column 1*, *Column 2*, *Column 3*, and *Column 4*.

   1. Select the parameter in the parameter list to the left.

   1. On the *details of parameter* page, navigate to *Description* and select the *Override* check box.

   1. Enter a new display name for the parameter.

      | Parameter name | Display name |
      |--|--|
      | Master Table | Earth Stations |
      | Column 1 | Name |
      | Column 2 | Location |
      | Column 3 | Weather Conditions |
      | Column 4 | Hide Me |

   ![display name](~/user-guide/images/InfoTemplates.gif)

1. Click *Only protocol parameters* in the top-left corner, and select *Only edited parameters* from the dropdown list.

   The list of parameters will now be limited to the ones you just edited.

1. Select the *Hide Me* parameter, navigate to *Parameter access > Hide parameter* on the *details of parameter* page, and select the *Override* check box.

1. Hover your mouse pointer over the *Weather Conditions* parameter and click the "+" button to duplicate the parameter.

1. Specify a filter for the following parameters:

   | Parameter | Filter |
   |--|--|
   | Name | * |
   | Location | * |
   | Hide Me | * |
   | Weather Conditions | \*East Coast* |
   | Weather Conditions | \*West Coast* |

   The information template configuration is now only applied on a filtered selection of available rows of the dynamic table.

   ![filter](~/user-guide/images/Info_Template_Quick_Tips_img04.png)

1. To save all changes, select *Apply* in the lower right corner.

1. Click *OK* to close the information template.

## Step 2: Enhance the table's data presentation

1. Under *Information Templates*, right-click your new template and select *Set as active Information template*.

1. In the Surveyor, select the *Info template quick tips* element, and navigate to *Data > Table*.

1. Optionally, right-click the top row of the table, hover your mouse pointer over *Columns* and make sure only the following columns remain selected: *Name*, *Location*, and *Weather Conditions*. Select *Save layout*.

   Only the *Name*, *Location*, and *Weather Conditions* columns are displayed now.

   ![intuitive table](~/user-guide/images/Info_Template_Quick_Tips_img06.png)

1. Navigate to *Apps > Protocols & Templates*, and select *Skyline Generic Virtual Connector* from the list of protocols.

1. Under *Alarm*, right-click *Info template quick tips* and select *Open*.

1. Include the *Earth Stations: Weather Conditions* parameter in the alarm template.

1. Enter "Sunny" in the *Normal* column, "Rain" in the *Minor High* column, and "Snow" in the *Critical High* column.

   ![alarm template](~/user-guide/images/Info_Template_Quick_Tips_img07.png)

1. To apply all changes, select *Apply* in the lower right corner.

1. Click *OK* to close the alarm template.

1. Make sure the *Info template quick tips* alarm template is selected under *Alarms*, and select *Assign elements* at the top of the *Elements* section.

1. In the *Assign Template* window, use the *Add >>* button to apply the alarm template to the *Info template quick tips* element, and select *Close*.

   Now that you have applied the alarm template, you can find earth stations with weather conditions "Rain" and "Snow" in the Alarm Console, flagged as minor and critical alarms respectively. Additionally, on the *Data > Table* page of the *Info template quick tips* element, the alarm severity is visually represented with appropriate colors.

   ![alarm severity](~/user-guide/images/Info_Template_Quick_Tips_img08.png)

## Step 3: Override the 'Location' parameter description

1. Select the hamburger button in the top-left corner of the *Info template quick tips* element card and select *Parameter names*.

1. In the *Element parameter names* window, scroll down until you find "Location" in the *Information template name* column, and enter the custom parameter name "Region" in the *Custom name* column.

   ![custom name](~/user-guide/images/Info_Template_Quick_Tips_img10.png)

1. Click *Apply* to apply your changes and *OK* to close the *Parameter names* window.

   On the *Data > Table* page, the column previously called "Location" is now called "Region".

   ![region](~/user-guide/images/Info_Template_Quick_Tips_img11.png)
