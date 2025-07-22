---
uid: Creating_Anomaly_Overview_Dashboard
---

# Creating an anomaly overview dashboard

This tutorial illustrates DataMiner's [behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection) feature in the context of Dashboards and Low-Code Apps. While creating an anomaly overview dashboard, you will learn how to access the behavioral change event data in a dashboard and gain insight in how to build great dashboards and low-code apps.

Estimated duration: 35 minutes.

> [!NOTE]
> The content and screenshots for this tutorial were created in DataMiner 10.4.9. To follow the complete tutorial, you will need at least DataMiner 10.4.7. If you only create the statistical overview but do not follow the last two steps of the tutorial, DataMiner 10.3.12 is sufficient.

> [!TIP]
>
> - For more information, such as technical limitations of anomaly detection, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).
> - See also: [Anomaly Detection Tutorial](xref:Anomaly_Tutorial), [Kata #12: Automatically detect anomalies with DataMiner](https://community.dataminer.services/courses/kata-12/) on DataMiner Dojo, and [Kata #39: Building an anomaly overview dashboard](https://community.dataminer.services/courses/kata-39/) on DataMiner Dojo.

## Prerequisites

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- [Storage as a Service (STaaS)](xref:STaaS) (recommended) or a [self-managed Cassandra database with indexing](xref:Supported_system_data_storage_architectures).

- Behavioral anomaly detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The [time to live](xref:Specifying_TTL_overrides) for trending is at least 1 day for real-time trending and 1 month for minute records.

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Compile a list of anomalies](#step-2-compile-a-list-of-anomalies)
- [Step 3: Include statistical overview with filter options](#step-3-include-statistical-overview-with-filter-options)
- [Step 4: Enhance the table view by replacing IDs with names](#step-4-enhance-the-table-view-by-replacing-ids-with-names)
- [Step 5: Add a trending component and timeline view to visualize the anomalies](#step-5-add-a-trending-component-and-timeline-view-to-visualize-the-anomalies)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/c270f156-3d8d-4b40-a6d9-0d0cc599062a>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will deploy both the custom operators that you will need in later in this tutorial and an example of the end result of the tutorial.

## Step 2: Compile a list of anomalies

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Drag and drop a *Time range* visualization from the pane on the left onto the dashboard to add a time range component.

   ![Time range visualizations](~/dataminer/images/Tutorial_anomaly_dashboard_add_time_range.png)

   This component will allow users to select a specific time range, which will be used in a query to retrieve behavioral change points later on.

1. While the component is selected, go to the *Settings* tab on the right and change the default range to *This week*.

1. Drag and drop the *Table* visualization from the pane on the left to the dashboard.

   ![Table visualizations](~/dataminer/images/Tutorial_anomaly_dashboard_add_table.png)

   This will add a table component. In this component, you will show the output of a GQI query.

1. In the data pane, open the *QUERIES* section and click the "+" icon.

   ![Add a query](~/dataminer/images/Tutorial_anomaly_dashboard_add_query.png)

1. Name your query `Anomalies filtered on time`.

1. Select the data source *Get behavioral change events*.

1. Add a *Filter* operator, and configure it as follows:

   - Column: *Anomalous*.
   - Filter method: *equals*.
   - Select *Value*, which will set the value to *true*.

   ![Filter configuration](~/dataminer/images/Tutorial_anomaly_dashboard_first_filter.png)

1. Add another *Filter* operator for the start time:

   - Column: *Start time*.
   - Filter method: *greater than*.
   - Value: Click the link icon in the value box, then select your time range feed and the property *From*, and click *Apply*.

     ![Link the filter to a feed](~/dataminer/images/Tutorial_anomaly_dashboard_filter_feed.png)

1. Add a final *Filter* operator for the end time:

   - Column: *End time*.
   - Filter method: *less than or equals*.
   - Value: Click the link icon in the value box, then select your time range feed and the property *To*, and click *Apply*.

   The resulting query should look like this:

   ![Anomalies query](~/dataminer/images/Tutorial_anomaly_dashboard_query.png)

1. Drag the query from the data pane onto the table component.

The table component should now display the raw anomalies from the system within the time range that is selected. If you cannot see any items in your table, select a wider time range with the time range component.

## Step 3: Include statistical overview with filter options

1. Duplicate the query you made in the previous step, by clicking the ... icon to the right of the query and selecting *Duplicate*.

   ![Duplicate option](~/dataminer/images/Tutorial_anomaly_dashboard_duplicate_query.png)

1. Name the new query `Anomalies by Type`.

1. Add an *Aggregate* operator, and configure it as follows:

   - Column: *Change Point ID*.
   - Method: *Count*.

   ![Aggregate operator](~/dataminer/images/Tutorial_anomaly_dashboard_add_Aggregate_operator.png)

1. Add a *Group by* operator, and set it to the column *Change type*.

   ![Group by operator](~/dataminer/images/Tutorial_anomaly_dashboard_add_Group_by_operator.png)

1. Drag and drop the *State* visualization from the pane on the left to the top of the dashboard.

1. Drag the query *Anomalies by Type* onto the *State* component.

   The state component should now show the number of anomalies for each type.

   ![State component showing the number of anomalies by type](~/dataminer/images/Tutorial_anomaly_dashboard_State_component.png)

1. Fine-tune the layout of the state component:

   1. While the component is selected, go to the *Layout* tab on the right.
   1. Clear the checkbox *Display query name*
   1. Under *Design*, select *Large*.

   ![State component showing the number of anomalies by type](~/dataminer/images/Tutorial_anomaly_dashboard_State_component_fine-tuned.png)

1. Click one of the *State* items in the component to make a selection.

1. Modify the *Anomalies filtered on time* query so it also takes that selection into account:

   1. Click the pencil icon next to the query to start editing it.

   1. Rename the query to `Anomalies filtered on time and type`.

   1. Add a *Filter* operator, and configure it as follows:

   - Column: *Change type*.
   - Filter method: *equals*.
   - Value: Click the link icon in the value box, then select your state component, and click *Apply*.

Now the statistical overview at the top of the dashboard will give a good indication of the anomalies that have been detected in the system in the specified time range, and clicking one of the change types in the overview will filter the table so it only shows the selected type.

![The resulting overview](~/dataminer/images/Tutorial_anomaly_dashboard_statistical_overview.png)

## Step 4: Enhance the table view by replacing IDs with names

The *Element ID* and *Parameter ID* columns in the table contain the IDs of the elements and parameters where the anomalies occur. To enhance the overview, you can show the names of the elements and parameters instead.

1. To resolve the element names, modify the *Anomalies filtered on time and type* query:

1. Add a *Join* operator of type *Left*.

1. Add the data source *Get elements*, and configure it as follows:

   - Operator: Select
   - Columns: *Element ID*, *Protocol*, *ProtocolVersion*, and *Name*.

1. Below this, select which column should be used to join the table by selecting *Element ID* both on the left and on the right.

   ![Join selection](~/dataminer/images/Tutorial_anomaly_dashboard_join_selection.png)

1. Optionally, add the *ParameterKeyToSeparateColumns* custom operator to also include the table key for table parameters:

   1. At the bottom of your query, select *Apply custom operator*, and then select *ParameterKeyToSeparateColumns*.

   1. In the *Parameter Key Column* box, select *Parameter ID*.

   ![ParameterKeyToSeparateColumns operator added](~/dataminer/images/Tutorial_anomaly_dashboard_ParameterKeyToSeparateColumns.png)

1. Add the *Parameter KeyToName* custom operator:

   1. At the bottom of your query, select *Apply custom operator*, and then select *Parameter KeyToName*.

   1. In the *Parameter Key Column* box, select *Parameter ID*.

   1. In the *Protocol Name* and *Protocol Version* boxes, select *Protocol* and *ProtocolVersion*, respectively.

   ![Parameter KeyToName operator added](~/dataminer/images/Tutorial_anomaly_dashboard_ParameterKeyName.png)

1. Add the *Rename column* custom operator:

   1. Select *Apply custom operator*, and then select *Rename column*.

   1. In the *Column* box, select *Name*.

   1. In the *New name* box, enter *Element*.

   ![Rename column operator added](~/dataminer/images/Tutorial_anomaly_dashboard_RenameColumn.png)

1. Add an operator to concatenate the parameter name with the parameter key into one single parameter column:

   1. At the bottom of your query, select *Column manipulations*.

   1. Select the manipulation method *Concatenate*.

   1. Select the columns *Parameter ID* and *Parameter Name*.

   1. Using the placeholders {0} and {1}, in the *Format* box, indicate how the concatenated data should be displayed, e.g. `{1} ({0})`.

   1. In the *New column name* box, specify `Parameter`.

   ![Concatenate operator added](~/dataminer/images/Tutorial_anomaly_dashboard_concatenate.png)

1. Add a *Select* operator, and make sure only the columns *Element*, *Parameter*, *Change type*, *Start time* and *End time* are selected.

   ![Select operator added](~/dataminer/images/Tutorial_anomaly_dashboard_select.png)

1. Optionally, drag and drop the column headers of the table to rearrange the columns, so that the *Element* and *Parameter* columns are shown first.

![Table end result](~/dataminer/images/Tutorial_anomaly_dashboard_enhanced_table_view.png)

> [!NOTE]
> The custom operators mentioned above are included in the package you installed in step 1. You can also find them on GitHub: [Parameter KeyToName](https://github.com/SkylineCommunications/SLC-GQIO-Parameter-KeyToName), [ParameterKeyToSeparateColumns](https://github.com/SkylineCommunications/SLC-GQIO-ParameterKeyToSeparateColumns), and [RenameColumn](https://catalog.dataminer.services/details/9707180b-6a73-480d-a2bb-81d9f8f59498). Note that the *Parameter KeyToName* operator can make a dashboard load significantly more slowly.\
> Key in the *Parameter KeyToName* operator are [IGQIOnInit](xref:GQI_IGQIOnInit) and its [GQIDMS](xref:GQI_GQIDMS#iconnection-getconnection) interface, which provides access to protocol and parameter information via the element or protocol. The operator has a very basic protocol cache in place. Specifying the *Protocol* and *ProtocolVersion* in the *Parameter KeyToName* operator is optional, but will result in better performance because the operator will be able to reuse protocol information for the elements of the same protocol and version. Overridden parameter names (e.g. information template) will then go back to the name from the protocol.\
> Key in the *ParameterKeyToSeparateColumns* operator is the *ParamID* Object (slnettypes.dll).

## Step 5: Add a trending component and timeline view to visualize the anomalies

In this step, you will add a line chart to show the trending of the parameter linked to the selected anomaly. Below the chart, you will add a timeline that will show a template for the selected anomaly.

1. Drag and drop the *Line & area chart* from the pane on the left onto the dashboard, below the table component.

   ![Line chart visualization](~/dataminer/images/Tutorial_anomaly_dashboard_line_chart.png)

1. Drag and drop the *Timeline* from the pane on the left onto the dashboard, below the line & area chart.

   ![Timeline visualization](~/dataminer/images/Tutorial_anomaly_dashboard_timeline.png)

1. Select a row in the table so that it becomes available as a feed.

1. In the data pane on the right, go to *Feeds* > *Table x* > *Selected rows*, and drag the *Parameters* row to the line & area chart component.

1. In the data pane on the right, go to *Feeds* > *Table x* > *Selected rows*, and drag the *Timespans* row to the line & area chart component as a filter.

1. In the data pane on the right, go to *Feeds* > *Table x* > *Selected rows*, and drag the *Query rows* row to the timeline component.

1. Edit the template of the timeline so it shows the change type of the anomaly and appears in a custom color:

   1. While the timeline component is select, go to the *Layout* pane on the right, scroll down to the *Item templates* section, and click *Edit*.

      ![Edit button](~/dataminer/images/Tutorial_anomaly_dashboard_edit_template.png)

      This will open the template editor.

   1. In the pane on the right, while the text layer is selected, instead of *{Element}*, specify *{Change type}*, and modify the layout according to your preferences.

      ![Text layer in the template editor](~/dataminer/images/Tutorial_anomaly_dashboard_text_layer.png)

   1. Select the rectangle layer instead, and tweak the layout according to your preferences.

      ![Rectangle layer in the template editor](~/dataminer/images/Tutorial_anomaly_dashboard_rectangle_layer.png)

   1. Click *Save*.

   > [!TIP]
   > See also: [Template editor](xref:Template_Editor).

1. Link the time ranges of the timeline and the line chart:

   1. Select the timeline component and go to the *Settings* pane on the right.

   1. Next to *Link time range to feed*, click the link button.

      ![Link button](~/dataminer/images/Tutorial_anomaly_dashboard_link_time_range_to_feed.png)

   1. Select *Line & area chart x* and click *Apply*.

1. Finally, add another custom operator to your query in order to apply a time range that adds a bit of time before and after the anomaly start and end time, so that displayed time range is more user-friendly:

   1. In the data pane, click the pencil icon to edit the *Anomalies filtered on time and type*.

   1. At the bottom of the query, click *Apply custom operator*.

   1. Select the operator *Time Range Feed Extending*.

      > [!NOTE]
      > This operator was also included in the package you installed in step 1 and is also available separately on [Github](https://github.com/SkylineCommunications/SLC-GQIO-TimeRangeExtending). This is an operator with relatively simple logic, which illustrates two nice capabilities of custom operators:
      >
      > - Adding extra columns with new information, in this case, the columns *TimeRange Feed Start* and *TimeRange Feed End*, which show the result of the applied offsets on the linked *Start* and *End* columns.
      > - Overriding the *Time range* feed by setting new values for the *StartTime* and *EndTime* in the TimeRangeMetadata in the rows.

   1. In the *Start* and *End* boxes, select *Start time* and *End time*, respectively.

   1. In the *Amount of hours before* box, specify *8*.

   1. In the *Amount of hours after* box, specify *4*.

   ![Time Range Feed Extending custom operator](~/dataminer/images/Tutorial_anomaly_dashboard_time_range_feed_extending.png)

The resulting dashboard could for instance look like this:

![Final result](~/dataminer/images/Tutorial_anomaly_dashboard_end_result.png)
