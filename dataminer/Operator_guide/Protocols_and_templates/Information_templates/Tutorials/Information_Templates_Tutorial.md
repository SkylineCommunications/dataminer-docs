---
uid: Information_Templates_Tutorial
---

# Using information templates for enhanced parameter presentation and monitoring

This tutorial will show you how to configure and use an information template to enhance the presentation and monitoring of satellite earth station parameters. You will learn to customize a table for quick data comprehension by adjusting the display name of columns, hiding unnecessary columns, and applying filters.

Because it is common to reuse information templates, you will also learn how to make a quick edit to it for one specific element only.

Although the primary focus of this tutorial lies on information templates, you will also learn to use an alarm template to visualize both minor and critical alarms for earth stations affected by potentially challenging weather conditions.

Expected duration: 20 minutes

> [!TIP]
> See also:
>
> - [Information templates](xref:Information_templates)
> - [Alarm templates](xref:About_alarm_templates)
> - [Kata #30: Create your own information template](https://community.dataminer.services/courses/kata-30/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.5.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the Info Template Quick Tips package from the Catalog](#step-1-deploy-the-info-template-quick-tips-package-from-the-catalog)
- [Step 2: Create and configure a new information template](#step-2-create-and-configure-a-new-information-template)
- [Step 3: Hide the unnecessary table columns](#step-3-hide-the-unnecessary-table-columns-optional)
- [Step 4: Assign a customized alarm template](#step-4-assign-a-customized-alarm-template)
- [Step 5: Override the 'Location' parameter description](#step-5-override-the-location-parameter-description)

## Step 1: Deploy the 'Info Template Quick Tips' package from the Catalog

1. Go to <https://catalog.dataminer.services/details/32274506-07a4-4ecb-98d3-bea773c3903e>.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and check whether a view and element named "Info template quick tips" have been added to your DataMiner Agent.

   If this is the case, the package has been successfully deployed.

   On the *Data* > *Table* page of the element, you will see that the Master Table of the element contains pre-provisioned data:

   ![Master Table](~/dataminer/images/Info_Template_Quick_Tips_img00.png)

## Step 2: Create and configure a new information template

In this step, you will configure an information template to change the way the parameters from the example element are displayed.

1. In Cube, select *Apps* in the sidebar and open the *Protocols & Templates* module.

1. Select *Skyline Generic Virtual Connector* in the list of protocols.

1. Under *Information Templates*, right-click the default information template and select *New*.

   ![New information template creation](~/dataminer/images/Info_Template_Quick_Tips_img01.png)

1. Specify a name for the template and select *OK*.

1. Change the display name of the parameters *Master Table*, *Column 1*, *Column 2*, *Column 3*, and *Column 4*:

   1. Select the parameter in the parameter list on the left.

   1. In the *details of parameter* section, under *Description*, select the *Override* checkbox.

   1. Enter the new display name for the parameter.

      | Parameter name | Display name |
      |--|--|
      | Master Table | Earth Stations |
      | Column 1 | Name |
      | Column 2 | Location |
      | Column 3 | Weather Conditions |
      | Column 4 | Hide Me |

   ![Configuration display name](~/dataminer/images/InfoTemplates.gif)

1. Click *Only protocol parameters* in the top-left corner, and select *Only edited parameters*.

   The list of parameters will now be limited to the ones you have just edited.

1. Select the *Hide Me* parameter, and under *Parameter access* > *Hide parameter* on the right, select the *Override* checkbox.

1. Hover the mouse pointer over the *Weather Conditions* parameter and click the "+" button to duplicate the parameter entry.

   ![Duplicating a parameter](~/dataminer/images/InfoTemplateDuplicateParameter.png)

   This way, there will be two entries for this same parameter, which can each be configured with their own filter.

1. In the filter boxes next to the parameter names, specify the following filters:

   | Parameter | Filter |
   |--|--|
   | Name | * |
   | Location | * |
   | Hide Me | * |
   | Weather Conditions | \*East Coast* |
   | Weather Conditions | \*West Coast* |

   The information template configuration will now only be applied to a filtered selection of available rows of the dynamic table.

   ![Filter configuration](~/dataminer/images/Info_Template_Quick_Tips_img04.png)

1. Select the *Weather Conditions* parameter with the *West Coast* filter, and make changes to the following parameter data:

   - *Parameters > Detailed description*: `The weather at the location of the site`

   - *Parameters > Custom name*: `Weather Conditions`

   - *Parameters > Category*: `Signal fault`

   - *Parameters > Key point*: `Reception`

   - *Parameters > Component info*: `Entire service`

   - *Alarm > Alarm description*: `Weather impact`

   - *Alarm > Corrective actions*: `Rain, mask for 1 hour | Snow, mask for 2 hours`

   > [!TIP]
   > For more information about the different parameter data, see [Creating an information template](xref:Creating_an_information_template).

1. Select the *Weather Conditions* parameter with the *East Coast* filter, and make changes to the following parameter data:

   - *Parameters > Detailed description*: `The weather at the location of the site`

   - *Parameters > Custom name*: `Weather Conditions`

   - *Parameters > Category*: `Signal fault`

   - *Parameters > Key point*: `Reception`

   - *Parameters > Component info*: `Entire service`

   - *Alarm > Alarm description*: `Weather impact`

   - *Alarm > Corrective actions*: `Rain, mask for 2 hours | Snow, mask for 3 hours`

1. In the lower-right corner, select *Apply* to save your changes.

1. Click *OK* to close the information template.

1. Under *Information Templates*, right-click your new template and select *Set as active Information template*.

1. In the dialog, click *Yes* to confirm that the information template should be set.

## Step 3: Hide the unnecessary table columns (optional)

By default, the table shows a lot of columns that are not useful for this tutorial. In this step, you will hide these to get a cleaner view on the data.

1. In the Surveyor, select the *Info template quick tips* element, and navigate to *Data > Table*.

   > [!NOTE]
   > If the element card was still open from earlier, you may need to close and reopen it to see the changes from the information template.

1. Right-click the top row of the table and hover the mouse pointer over the *Columns* option until it expands to show all columns in the table.

1. Clear the selection from all columns except *Name*, *Location*, and *Weather Conditions*.

1. At the bottom of the menu, select *Save layout*.

   Only the *Name*, *Location*, and *Weather Conditions* columns will be displayed now.

   ![Table with only the necessary columns shown](~/dataminer/images/Info_Template_Quick_Tips_img06.png)

## Step 4: Assign a customized alarm template

To enhance the way the table data are shown, in this step, you will assign an alarm template to the element.

1. Navigate to *Apps > Protocols & Templates*.

1. Select *Skyline Generic Virtual Connector* in the list of protocols, and make sure the production version is selected under *Versions*.

1. Under *Alarm*, right-click *Info template quick tips* and select *Open*.

1. Next to the *Earth Stations: Weather Conditions* parameter, click *Excluded* to include the parameter in the alarm template.

1. Configure the alarm thresholds:

   - In the *Normal* column, enter `Sunny`.

   - In the *MIN HI* column, enter `Rain`.

   - In the *CRIT HI* column, enter `Snow`.

   ![alarm template](~/dataminer/images/Info_Template_Quick_Tips_img07.png)

   > [!TIP]
   > See also: [Configuring normal alarm thresholds](xref:Configuring_normal_alarm_thresholds)

1. In the lower-right corner, select *Apply* to apply your changes.

1. Click *OK* to close the alarm template.

1. Make sure the *Info template quick tips* alarm template is selected under *Alarms*, and select *Assign elements* at the top of the *Elements* section.

1. In the *Assign Template* window, use the *Add >>* button to apply the alarm template to the *Info template quick tips* element, and then select *Close*.

   Now that you have applied the alarm template, you will find minor and critical alarms in the Alarm Console for the earth stations with weather conditions "Rain" and "Snow", respectively. Additionally, on the *Data > Table* page of the *Info template quick tips* element, the alarm severity will be shown with appropriate colors.

1. In the Alarm Console, add the following columns:

   - Category

   - Alarm description

   - Corrective action

   - Component info

   - Key point

   > [!TIP]
   > See also: [Adding or removing columns](xref:ChangingTheAlarmConsoleLayout#adding-or-removing-columns)

   Depending on whether an alarm is detected for an earth station on the East or West Coast, you will find the appropriate corrective action in the Alarm Console.

   ![Alarm severity shown on the element card and in the Alarm Console](~/dataminer/images/Info_Template_Quick_Tips_img08.png)

## Step 5: Override the 'Location' parameter description

This step will show how you can make a quick edit to the information template for one specific element only.

1. Select the hamburger button in the top-left corner of the *Info template quick tips* element card and select *Parameter names*.

1. In the *Element parameter names* window, look up the "Location" parameter name in the *Information template name* column.

   To quickly find this parameter, you can use the filter box in the top-right corner.

1. In the *Custom name* column for this parameter, enter the custom parameter name `Region`.

   ![Custom name configuration](~/dataminer/images/Info_Template_Quick_Tips_img10.png)

1. Click *Apply* to apply your changes and *OK* to close the *Parameter names* window.

   On the *Data > Table* page, the column previously called "Location" will now be called "Region".

   ![Customized parameter name](~/dataminer/images/Info_Template_Quick_Tips_img11.png)

> [!TIP]
> See also: [Changing parameter names for a particular element](xref:Changing_parameter_names_for_a_particular_element)
