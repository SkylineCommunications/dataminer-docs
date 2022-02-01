---
uid: Configuring_dashboard_components
---

# Configuring dashboard components

Each dashboard component consists of a visualization and a data feed.

When a dashboard is in edit mode, visualizations are available via the green panel on the left, and data feeds are available via the *Data* pane on the right.

There are several ways to add a component:

- Drag a visualization from the pane on the left onto an empty section of the dashboard. A data feed will then need to be applied to the component.

- Drag a data feed from the *Data* pane on the right onto an empty section of the dashboard. A visualization will then still need to be applied to the component.

The following actions are then possible to configure the component:

The following actions are then possible to configure the component:

- [Applying a visualization](#applying-a-visualization)

- [Applying a data feed](#applying-a-data-feed)

- [Customizing the component layout](#customizing-the-component-layout)

- [Deleting a component](#deleting-a-component)

In addition, depending on the visualization, additional configuration options may be available. For more information, refer to the relevant section in [Available visualizations](xref:Available_visualizations).

## Applying a visualization

To apply a visualization to a component or change the visualization of a component:

1. Click on the component or hover the mouse over the component and click the ![](~/user-guide/images/DashboardsX_visualizations00095.png) icon.

2. Select the visualization you want to apply from the options displayed below the component.

    As soon as the mouse pointer hovers over the different visualizations, a preview will be displayed in the component.

## Applying a data feed

To apply a data feed or change the data feed of a component:

1. Click on the component or hover the mouse over the component and click the ![](~/user-guide/images/dashboards_data.png) icon.

    In the data pane on the right, any data feeds that do not match the visualization of the component will become unavailable. Data feeds that are compatible with the component will be marked with the following icon: ![](~/user-guide/images/NewRD_datafeed.png)

2. Drag the compatible data feed onto the component.

    - To find specific data more quickly, you can use the filter box at the top of each data section.

        For parameters, you can select a specific parameter by first selecting *Element* or *Service* in the *From* box and then specifying a filter. Alternatively, you can select a parameter by first selecting *Protocol* in the *From* box and then specifying a protocol in the filter.

    - For some components, you can add the complete set of a certain type of items. In that case, the data feed icon will be displayed in front of the group in the data pane, and you will be able to drag the entire group onto the component.

        > [!NOTE]
        > If you add the entire *Bookings* data set to a *Drop-down*, *List* or *Tree* feed, you will also need to link this to a *Time range* feed.

    - A data feed can also be provided by a feed component. When such a component has been added to the dashboard, the *Feeds* section is added to the available data in the *Data* pane. You can then drag an entry from this section to a component in order to link the component to the feed component.

    - Some components allow you to specify multiple data feeds. For example, for a *State* component and a *Line chart* component, multiple parameters can be dragged onto the component.

        > [!NOTE]
        > From DataMiner 10.0.12 onwards, for some visualizations that use multiple data feeds (e.g. Parameter table, State), you can modify the order in which these data feeds are displayed.
        >
        > To do so, in the *Data in component* section of the data pane, click the arrow icons next to the data feeds to place them higher or lower in the order.

    - If you try to add a data feed that is not compatible with the component, a red icon will be displayed on the component when you try to drag the data onto it.

3. Some visualizations and data feeds allow you to specify an additional filter feed. In that case, a yellow filter icon will be displayed below the component when you select it or hover the mouse over it: ![](~/user-guide/images/DashboardsX_filter.png)

    After you click this icon, compatible filter feeds will be marked with this icon in the data pane, and you will be able to drag these onto the component just like a data feed.

### Using Queries data input

From DataMiner 10.0.13 onwards, a special type of data feed is available, using the Generic Query Interface. This “Queries” data item allows you to construct a query in order to tap into the wealth of data available in your DataMiner System.

#### Creating a query

You can create a query as follows:

1. In edit mode, select the dashboard component for which you want to use a query as a data input. At present, this is support for Bar chart, Pie chart, State and Table components.

2. In the data pane, select *Queries* and click the + icon to add a new query.

3. Specify a name for the query.

    > [!NOTE]
    > From DataMiner 10.1.0/10.1.1 onwards, specifying a name is optional. However, note that this is still recommended, as a name can help clarify what the purpose of the query is.

4. In the drop-down box below this, select the data source you want to use. The following options are currently available:

    - *Get alarms*: Available from DataMiner 10.2.0/10.1.9 onwards. The alarms in the DataMiner System. Several columns, such as *Element Name*, *Parameter Description*, *Value* and *Time*, are included by default. Others can be added with a *Select* operation (see below).

    - *Get DCF connections*: Available from DataMiner 10.2.0/10.1.6 onwards. A list of the DCF connections in the DataMiner System. For each connection, this includes the source and destination element ID and interface ID, the ID of the connection, any properties on interfaces, any parameters that interfaces are linked to, and an *IsInternal* column that indicates whether the connection is internal or external.

        > [!NOTE]
        > DCF connections are returned for each active element. As external connections are configured both on the source element and the destination element, each external connection will therefore be listed twice if both elements are active. If both the source element and the destination element of an external connection are stopped, the connection will not be listed. If only the source element or the destination element is stopped, the connection will be listed once.

        > [!TIP]
        > See also:
        > [DataMiner Connectivity Framework](xref:DCF#dataminer-connectivity-framework)

    - *Get elements*: The elements in the DataMiner System.

    - *Get parameter table by alias*: The parameter table using the specified alias in the Elasticsearch database.

    - *Get parameter table by ID*: The selected parameter table from the element with the specified DataMiner ID and element ID. From DataMiner 10.2.0/10.1.5 onwards, a *Use feed* checkbox is available that allows you to retrieve a parameter table from an existing feed in the dashboard.



        > [!NOTE]
        > When you use this data source, from DataMiner 10.2.0/10.2.1 onwards, an *Update data* option is available in the *Settings* pane. When you enable this, the component will automatically refresh the data when changes are detected.



    - *Get parameters for element where*: The selected parameters for the specified protocol or the parameters linked to the specified profile definition. Note that if parameters are displayed based on a specific protocol, it is not possible to combine a table parameter with other parameters, and only column parameters from the same table can be displayed in the same query. From DataMiner 10.2.0/10.1.5 onwards, if a protocol and version have been specified, a *Use feed* checkbox is available that allows you to also retrieve parameters from an existing feed in the dashboard.

    - *Get services*: The services in the DataMiner System.

    - *Get view relations*: Available from DataMiner 10.2.0/10.1.4 onwards. A list of the DataMiner objects that are direct children of views in the DMS. The list includes the following columns:

        - *View ID*: The ID of the view containing the object.

        - *Child ID*: The ID of the object.

        - *Depth*: The level of the object in the tree view in relation to the root view.

        Select the *Recursive* option for this data source to also include objects that are not directly included in a view, e.g. child objects of objects within the view.

    - *Get views*: Available from DataMiner 10.2.0/10.1.4 onwards. A list of the views in the DMS. By default, only the columns *View ID* and *Name* are included, but you can include additional columns using a *Select* operator.

    - *Start from*: Available from DataMiner 10.1.0/10.1.1 onwards. If another query has already been configured in the dashboard, this option allows you to start from that query and then refine it further. However, note that if the query you start from is modified, the new query that makes use of it will not be updated unless it is also modified or the dashboard is refreshed.

    > [!NOTE]
    > By default, only a limited number of columns will be displayed in the dashboard for certain data sources. For example, for a parameter table, only the first 10 columns are displayed by default. In such a case, you can use the *Select* operator to display other columns or more columns than this default (see below).

5. Select an operator. This step is optional; if you do not select an operator, the entire data set will be used. The following operators are available:

    - *Aggregate*: Allows you to aggregate data from the data source. After you have selected this option, first select the aggregation column, and the method that should be used. Depending on the type of data available in the selected column, different methods are available, e.g. Average, Count, Distinct Count, Maximum, Median, Minimum, Percentile 90/95/98 or Standard deviation.

        You can then further filter the result by applying another operator. An additional *Group by* operator is available for this, which will display the result of the aggregation operation for each different item in the column selected in the *Group by column* box.



        > [!NOTE]
        > From DataMiner 10.1.0/10.1.3 onwards, exception values are not taken into account, except for the Count and Distinct Count methods.



    - *Column manipulations*: Creates a new column based on existing columns. When you select this option, you also need to select a manipulation method.

        If you choose the *Concatenate* method, you will need to select several columns and then specify the format that should be used to concatenate the content of those columns, using placeholders in the format {0}, {1}, etc. to refer to those columns.

        If you choose the *Regexmatch* method, you will need to select a column and specify a regular expression, so that the new column will only contain the items from the selected column that match the regular expression.

        For both manipulation methods, you will also need to specify the name for the new column. When the column manipulation operation is fully configured, you can further fine-tune the result by applying another operator.

    - *Filter*: Filters the data set. When you select this option, select the column to filter, specify the filter method (e.g. equals, greater than, etc.) and the value to use as a filter. The available filter methods depend on the type of data in the selected column. Once the filter has been fully configured, you can refine the results by applying another operator, e.g. an additional filter.

        From DataMiner 10.2.0/10.1.3 onwards, instead of specifying an exact filter value, you can select *Use feed* to use one of the available feeds in the dashboard as the column filter. Depending on the type of data in the feed, you will then need to specify the following information:

        - *Feed*: The name of the feed that should provide the data. If only one feed is available, it will automatically be selected.

        - *Type*: The type of data that needs to be selected. If the feed only provides one type of data, it will automatically be selected.

        - *Property*: The property by which the column will be filtered (depending on the type of data).

        From DataMiner 10.1.11 onwards, an additional option, *Return no rows when feed is empty*, is available. When you select this option, in case the feed is empty, an empty table will be returned instead of the entire table.



        > [!NOTE]
        > - Index feeds are only supported from DataMiner 10.2.0/10.1.5 onwards.
        > - If the *regex* or *not regex* filter method is used and *Use feed* is selected, from DataMiner 10.1.2/10.1.5 onwards, if the feed contains multiple values, these are combined with an "or" operator.



    - *Join*: Joins two tables together. When you select this option, in the *Type* drop-down box, you will first need to select how the tables should be joined. Then you will need to select another data source (optionally refined with one or more operators) in order to specify the table you want the first table to be joined with. Optionally, you can also specify a condition to determine when rows should be joined. For instance, if one table contains elements with a custom property that details a booking ID and the other lists bookings, you could add the condition that the property in the first table must match the ID in the second table.

        The *Inner* type of join only includes rows if they match the condition. *Left* displays all rows from the first table (i.e. the table on the left) and only the matching rows from the other table. *Right* does the opposite. *Outer* displays first the non-matching rows from the left table, then the matching rows from both tables, then the non-matching rows from the right table.

    - *Select*: Displays the selected columns only. When you have selected the columns to display, you can apply another operator to refine the query.

        From DataMiner 10.1.0\[CU1\]/10.1.3 onwards, up and down arrow buttons in the list of columns allow you to modify the order in which the columns are loaded. Click an arrow button to make a column switch places with the column below or above it in the list. Press Ctrl while clicking an arrow button to make the column switch places with the previous or next selected column instead.

        From DataMiner 10.2.0/10.1.5 onwards, a *Use feed* checkbox is available that allows you to add parameters from an existing feed in the dashboard to the selectable items.

    - *Top X*: Displays the top or bottom items of a specific column, with X being the number of items to display. When you select this option, you will need to specify the column from which items should be displayed and the number of items that should be displayed. By default, the top items are displayed. To display the bottom items instead, select the *Ascending* checkbox.



        > [!NOTE]
        > From DataMiner 10.1.0/10.1.3 onwards, exception values are not taken into account by this operator.



6. Drag the configured query to the component in order to use it.

#### Importing a query

From DataMiner 10.1.4 onwards, you can import a query from a different dashboard in the DMS. To do so:

1. In the data pane, select *Queries* and click the import icon (to the right of the + icon).

2. In the dialog box, select the dashboard from which you want to import the query and the query itself, and specify a name for the query in your dashboard.

3. Click *Import*. The query will now be available for use in the data pane.

#### Notes on GQI queries

Please note the following regarding query data input:

- It is possible to refer to a query in the dashboard URL, using the following format: *?queries=\[***alias***\]\\x1F\[***queryJsonString***\]
<br>*In this format, \[alias\] is the name of the query and \[queryJsonString\] is the query in the format of a JSON string, for example: *?queries=Get Elements/{"ID": "Elements"}*.

- When a query has been created, the columns from the table that results from the query are available as individual data items in the data pane, so that you can use them to filter or group a component.

- It is not possible to retrieve data from a stopped element.

- From DataMiner 10.1.0/10.1.3 onwards, dynamic units will automatically be used when applicable for the retrieved data if this is enabled in the dashboard settings. This means that parameter units will change dynamically based on their value and protocol definition. You can override the behavior configured for the dashboard in the settings for the component.

- From DataMiner 10.2.0/10.1.4 onwards, if a row is selected in a table component that uses a query feed, any view, service or element linked to that row is also exposed as a feed. In practice, this means that a feed will be available in the *feeds* section of the data pane that will change based on the selection in the table.

- From DataMiner 10.2.0/10.1.5 onwards, you can link GQI nodes that require a time range selection to a time range feed by selecting the *From feed* checkbox.

## Customizing the component layout

Each component in a dashboard has a number of default options. By default, the configuration of these options is determined on dashboard level. However, it is possible to override this. The way this can be done depends on the DataMiner version.

From DataMiner 10.0.8 onwards:

1. Select the component and go to the *Layout* tab on the right.

2. In the *Styles* section, you can then change the component theme in different ways:

    - To change the component theme to one of the different existing component themes for your current dashboard theme, click the current theme and select a different theme in the drop-down list.

    - To customize the component theme, either select *Custom theme* in the drop-down list, or enable the *Customize* toggle button to customize the currently selected theme.

        You can then configure the title, color, spacing, border and shadow in the box below. These are the same as the options detailed below for earlier DataMiner versions, except that the *Container* section is now called the *Spacing* section. In addition, from DataMiner 10.0.9 onwards, you can also set the component border to only be shown for specific sides, e.g. at the top and bottom only. From DataMiner 10.0.12 onwards, under *Colors* > *Color palette*, you can customize additional component colors, e.g. for the lines in a line chart.

        When you have customized a component theme, you can also save it, so that it becomes available with the other component themes for the current dashboard theme. To do so, click *Save as component theme* and specify the name of the theme. However, note that this is only possible if the dashboard is currently using a saved dashboard theme. If it is not, you will first need to save the dashboard theme before you can save the component theme.

Prior to DataMiner 10.0.8:

1. Select the component and go to the *Layout* tab on the right.

2. Clear the checkbox *Inherit from dashboard*.

3. Configure the following options in the expandable sections according to your preference:

    - In the *Title* section, select the alignment for the component title and specify whether a border should be displayed around the title.

    - In the *Colors* section specify a custom background color and/or font color, either by specifying the color in RGB format or by using the color picker box on the right.

    - In the *Container* section, specify the following:

        - *Vertical margin*: The amount of space (in pixels) above the component.

        - *Horizontal margin*: The amount of space (in pixels) next to the component.

        - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the component.

        - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the component.

        > [!NOTE]
        > If a smaller value than the dashboard’s default value is configured for these settings, it will not be taken into account.

    - In the *Borders* section, select the type of border that should be displayed around the components.

    - In the *Shadow* section, select the size of the shadow displayed behind the components.

Depending on the visualization, additional layout options may be available. For more information, refer to the relevant section in [Available visualizations](xref:Available_visualizations).

## Deleting a component

You can delete a dashboard component as follows:

- Click on the component or hover the mouse over the component and click the red recycle bin icon.

- Select the component and click *Delete component* in the header bar of the app.

- Select the component and press the *Delete* key (supported from DataMiner 10.2.0/10.1.1 onwards).
