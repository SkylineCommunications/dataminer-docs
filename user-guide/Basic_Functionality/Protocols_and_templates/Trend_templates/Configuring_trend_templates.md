---
uid: Configuring_trend_templates
---

# Configuring trend templates

## Configuring a trend template in the Protocols & Templates module

To configure a trend template:

1. Open the template editor. This can be done in two ways:

   - Go to the Protocols & Templates module, right-click the template and select *Open*, *Open in new card* or *Open in new undocked card*.

   - Right-click an item in the Surveyor and select *View \> Trend template*.

1. In the template editor, you can do the following:

   - In the *General* section, click *Show details* and enter a description in the description field.

     > [!NOTE]
     > From DataMiner 9.0.5 onwards, templates can be quickly assigned via the Surveyor right-click menu. The description you enter here is shown as a tooltip in that menu, and may help users to select the correct template.

   - If you are editing an existing trend template, to view parameters that are not yet trended, you may need to click the button next to the filter box and select *Only protocol parameters*.

   - To view general parameters as well, click the button next to the filter box and select *All parameters (protocol + general)*.

   - For each parameter, select the checkbox for real-time or for average trending to activate trending for this parameter.

     > [!NOTE]
     >
     > - Enabling or disabling average or real-time trending for a parameter is also possible via the trend template context menu.
     > - From DataMiner 9.0.0 CU11 onwards, the context menu of the column header of the list of parameters allows you to enable or disable average and/or real-time trending for all parameters at once.

   - Use the filter box in the top-right corner to quickly find a parameter.

   - For dynamic table parameters, select a parameter and use one of the following options if necessary:

     - Specify a mask in the filter column to apply the trend configuration only to a filtered selection of available rows of the dynamic table.

     - Duplicate column parameters using the *+* button to define different trending with different filters.

     - Remove a duplicated column parameter using the *x* button.

     - Use the up and down buttons to change the order of the filters. This may be important as trending is applied top to bottom.

       > [!NOTE]
       >
       > - For dynamic table parameters, each column of the dynamic table that has trending enabled is represented by one row in the trend template.
       > - Trending of column parameters of type string is only supported from DataMiner 10.0.9 onwards.

1. When ready, click *Apply* to apply the trend template, or *OK* to apply the trend template and exit the editor.

   From DataMiner 9.0.5 onwards, a dialog box will then appear that allows you to immediately link the template to one or more elements.

> [!NOTE]
> The trend template options button also provides an option to configure which trend data is offloaded to the offload database. For more information, see [Configuring trend templates to exclude/include data in offloads](xref:Configuring_data_offloads#configuring-trend-templates-to-excludeinclude-data-in-offloads).

## Changing the trend template for one parameter

Both from the Alarm Console and from a parameter card, it is possible to quickly change the trend template for one particular parameter. This can be particularly useful for users who do not have access to the Protocols & Templates module.

There are several ways you can access the parameter trending editor:

- In the Alarm Console, right-click an alarm for that particular parameter, and select *Change > Trending*.

- On a parameter card, click the hamburger button in the top-left corner, and select *Change trending*.

- On a parameter card, go to the templates tab and select *TREND*.

You can then do the following

1. Change the selection for real-time and/or average trending for the parameter.

1. Save the changes in one of the following two ways:

   - To change the trend template for all elements using the same template, click *Update Trend Template*.

     > [!NOTE]
     > All elements using the template are listed for reference at the bottom of the window.

   - To only change the trend template for this element, click *Update this element only*. In this case, a copy of the trend template will be created, and you will have to enter a name for this new trend template.
