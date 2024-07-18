---
uid: Creating_Anomaly_Overview_Dashboard
---

# Creating an anomaly overview dashboard

This tutorial illustrates DataMiner's [Behavioral Anomaly Detection](xref:Working_with_behavioral_anomaly_detection) in the context of Dashboards and Low code apps. It has two main objectives. First objective is showing you how to get access to the behavioral change event data in a dashboard. Second objective is to show you how to deal with some of the challenges you might face, how to resolve them.

Estimated duration: 45 minutes.

> [!TIP]
>
> - For more information, such as technical limitations of anomaly detection, see [Working with behavioral anomaly detection](xref:Working_with_behavioral_anomaly_detection).
> - See also: [Kata #xx: Creating an anomaly overview dashboard](https://community.dataminer.services/courses/kata-xx/) on DataMiner Dojo
> - See also: [Anomaly Detection Tutorial](xref:Anomaly_Tutorial)
> - See also: [Kata #12: Automatically detect anomalies with DataMiner](https://community.dataminer.services/courses/kata-12/) on DataMiner Dojo

## Prerequisites

- DataMiner 10.3.12 or higher with [Storage as a Service (STaaS)](xref:STaaS) or a [self-hosted Cassandra database with indexing](xref:Supported_system_data_storage_architectures).

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Behavioral Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The [time to live](xref:Specifying_TTL_overrides) for trending is at least 1 day for real-time trending and 1 month for minute records.

## Overview

The tutorial consists of the following steps:

- [Step 1: Compile a list of anomalies](#step-1-compile-a-list-of-anomalies)
- [Step 2: Include statistical overview with filter options](#step-2-include-statistical-overview-with-filter-options)
- [Step 3: Enhance the table view by replacing IDs with names](#step-3-enhance-the-table-view-by-replacing-ids-with-names)
- [Step 4: Integrate with a trending component and timeline view to visualize the anomalies](#step-4-integrate-with-a-trending-component-and-timeline-view-to-visualize-the-anomalies)

## Step 1: Compile a list of anomalies

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Drag and drop *time range* visualization from the pane on the left to the dashboard.

   This will add a time range component, where users will be able to select a specific time range that we will use in our query to retrieve behavioral change points later on.

1. Drag and drop the *table* visualization from the pane on the left to the dashboard.

   This will add a table component, where the output of the GQI query will be shown.

   > [!NOTE]
   > There are multiple table components available. Take the one that shows 'Table'. Other table component are for example *Parameter table*, *Alarm table*, ... but for this dashboard we need the generic *Table* component we can link to GQI queries.

1. In the data pane, open the *QUERIES* section and click the "+" icon.
1. Name your query "Anomalies filtered on time"
1. Select the *Get behavioral change events' data source
1. Add a *Filter* operator to filter the *Anomalous* *equals* *true*
1. Add a *Filter* operator to filter the *Start time* *greater than* Time range x / From
1. Add a *Filter* operator to filter the *End time** *less than or equals* Time range x / From
1. Drag the query from the data pane onto the table component.
 
The table component should now display the 'raw' anomalies from the system within the time range that is selected.

## Step 2: Include statistical overview with filter options

1. Duplicate the existing query and name it "Anomalies by Type"
1. Add a *Aggregate* operator and choose for example *Change Point ID*, get the *Count*
1. Add a *Group by" operator and choose to group by *Change type*
1. Drag and drop the *State* component from the pane on the left to the dashboard. Position it somewhere at the top of your dashboard.
1. Drag the query *Anomalies by Type* onto the *State* component, select the component and in the layout section uncheck 'Display query name' and choose the *Large* design
1. Click on one of the *state* items to make a selection
1. Edit the query 'Anomalies filtered on time' and rename it to 'Anomalies filtered on time and type'
1. Add a *Filter* operator to filter *Change type* *equals* *State x / Query rows / Change type* (via the *Link to feed* icon in the Value field)

The statistical overview on top of your dashboard should give a good indication of the anomalies that have been detected in the system in the time range that is specified. Clicking one of the *Change types* should filter the table with the selected *Change type*

## Step 3: Enhance the table view by replacing IDs with Names

The *Element ID* and *Parameter ID* columns in our table hold the IDs of element & parameter of our anomalies. Let's try to turn them into the names of the element and parameter and as such enhance the overview.

1. To resolve the Element name, we'll join the query with the *Get elements* data source. We link the two sources via the *Element ID* column that is available on both sources. Ensure to have the *Protocol* and *ProtocolVersion* column available in your *Get elements* branch via a *Select* operator.
1. To resolve the parameter name and extract the parameter key in case of table parameters, we'll use two custom operators from the Catalog: [ParameterKeyToSeparateColumns](https://catalog.dataminer.services/details/3109b9a4-b29a-4d2b-b54e-79384fa40909) and [Parameter KeyToName](). After deployment, refresh your dashboard and add both operators. Link the Parameter Key Column to the *Parameter ID* column and for the *Parameter KeyToName* operator also link the *Protocol* and *ProtocolVersion* columns.

   > [!NOTE]
   > The *Parameter KeyToName* operator is available on [Github](https://github.com/SkylineCommunications/SLC-GQIO-Parameter-KeyToName).

   > [!NOTE]
   > The *Parameter KeyToName* operator can introduce a significant loading time of your dashboard.

   > [!NOTE]
   > Specifying the *Protocol* and *ProtocolVersion* in the *Parameter KeyToName* operator is optional, but will result in better performance because the operator will be able to reuse protocol information for the elements of the same protocol and version.

   > [!NOTE]
   > The *ParameterKeyToSeparateColumns* operator is available on [Github](https://github.com/SkylineCommunications/SLC-GQIO-ParameterKeyToSeparateColumns).

   > [!NOTE]
   > Key in the ParameterKeyToSeparateColumns operator is the *ParamID* Object, from slnettypes.dll.

   > [!NOTE]
   > Key in the Parameter KeyToName operator are [IGQIOnInit](xref:GQI_IGQIOnInit) and its [GQIDMS](xref:GQI_GQIDMS#iconnection-getconnection) interface where we get access to protocol and parameter information via the element or protocol. The operators has a very basic protocol cache in place that is subject for change.

1. Use the [RenameColumn](https://catalog.dataminer.services/details/9707180b-6a73-480d-a2bb-81d9f8f59498) custom operator to enhance the column name 'Name' to 'Element' and the *Concatenate* Operator to concatenate the parameter name with the parameter Key.
1. End your Query with a *Select* operator checking *Element*, *Parameter*, *Change type*, *Start time* and *End time*.

## Step 4: Integrate with a trending component and timeline view to visualize the anomalies

In this step, we will be adding a trend chart to show the trending of the parameter linked to the selected anomaly. Below the trend chart, we'll add a timeline in which we will show a block for the selected *Anomaly*.

1. Drag and drop the *Line & area chart* from the pane on the left to the dashboard.
1. Drag and drop the *Timeline* from the pane on the left to the dashboard.
1. Make a selection in the table and link the *Parameters* feed from the table to the *Line & area chart*. You can find the *Parameters* feed in the *Data* panel, section *Feeds*, *Table x*, *Selected rows*, *Parameters*.
1. Link the *Query rows* feed from the table to the *Timeline* and edit the item template of the Timeline via the [Template editor](xref:Template_Editor), so it shows the type of anomaly and appears in a nice color.
1. Link the time ranges of the Timeline and Line chart by selecting the *Timeline*, opening the *Settings* pane at the right, linking the *Line & area chart* feed via the button near *Link time range to feed*.
1. In order to get a good view on the anomaly we want to apply a time range of the anomaly we selected. But when we do so, we zoom in that much that this does not give us a great insight. Ideally we can apply a time range that adds a bit of time before and after the anomaly start and end time. In order to do so we will use the custom operator again. Deploy [Time Range Feed Extending]() and refresh your dashboard. Add the operator and link to the start and end column that come with the anomalies. Specify an *Amount of hours before* of 8 and *Amount of hours* after of 4. 
1. Now link the TimeRange feed coming from the table to the *Line & Area* chart by dragging *Feeds/Table x/selected rows/Timespans* to the *Line & Area chart*.

   > [!NOTE]
   > The *Time Range Feed Extending* operator is available on [Github](https://github.com/SkylineCommunications/SLC-GQIO-TimeRangeExtending).

   > [!NOTE]
   > While the *Time Range Feed Extending* operator is rather basic in its logic, it illustrates two nice capabilities of custom operators. First one is adding extra columns with new information. In this case, the columns *TimeRange Feed Start* and *TimeRange Feed End* are being added. These two columns show the result of the applied offsets on the linked *Start* and *End* columns. Second capability illustrated and key here in the dashboard is the one where we override the *TimeRange* feed by setting new values for the *StartTime* and *EndTime* in the TimeRangeMetadata in the rows.
