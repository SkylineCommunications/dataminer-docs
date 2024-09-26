---
uid: trend_patterns_backup_failures
---

# Using trend patterns to detect backup failures

This tutorial illustrates DataMiner's [pattern matching](xref:Working_with_pattern_matching) feature in the context of Dashboards and Low-Code apps. It will show you how to access patterns and occurrences within a dashboard and how to effectively handle missing pattern occurrences, using the example of server backups. By utilizing a trend pattern, DataMiner will detect the backups. The goal of the example dashboard in this tutorial is to generate a comprehensive report indicating whether daily backup patterns have been detected for all servers.

Estimated duration: 20 minutes.

> [!TIP]
>
> - For more information, such as technical limitations of pattern matching, see [Working with behavioral pattern matching](xref:Working_with_pattern_matching).
> - See also: [Kata #41: Trend patterns in Cube - recap Empower](https://community.dataminer.services/courses/kata-41/) on DataMiner Dojo.
> - See also: [Kata #42: Trend patterns in Dashboards & LCA](https://community.dataminer.services/courses/kata-42/) on DataMiner Dojo.

## Prerequisites

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- DataMiner 10.4.4 or higher with [Storage as a Service (STaaS)](xref:STaaS) or a [self-hosted Cassandra database with indexing](xref:Supported_system_data_storage_architectures).
- Pattern matching is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Compile a list of the most recent backup pattern occurrences per server](#step-2-compile-a-list-of-the-most-recent-backup-pattern-occurrences-per-server)
- [Step 3: Interpret the timestamp of every occurrence](#step-3-interpret-the-timestamp-of-every-occurrence)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/cc65fcf5-de87-4e3f-8209-fdd027928e56>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create a DataMiner element named *Kata - Server overview* in your system, which will be used throughout the rest of the tutorial. The element will be located in the view *Kata* > *Trend patterns in Dashboards and LCA*. This will also create a trend pattern and generate occurrences. This might take a couple of minutes.

1. In DataMiner Cube, check whether the element *Kata - Server overview* has been created before you continue to the next step.

## Step 2: Compile a list of the most recent backup pattern occurrences per server

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Drag and drop the *Dropdown* visualization from the pane on the left to the top of the dashboard.

   ![Drop down visualizations](~/user-guide/images/Tutorial_patterns_in_dashboards_add_dropdown.png)

   This component will allow users to select a specific trend pattern, which will be used in a query to retrieve the occurrences.

1. Drag and drop the *table* visualization from the pane on the left to the dashboard, below the Dropdown component.

   ![Table visualizations](~/user-guide/images/Tutorial_patterns_in_dashboards_add_table.png)

   This will add a table component. In this component, you will show the output of a GQI query.

1. Drag the edges of the table component to resize it until it takes up the width of your screen.

1. In the data pane, open the *QUERIES* section and click the "+" icon to create a new query.

   ![Add Query](~/user-guide/images/Tutorial_patterns_in_dashboards_add_query.png)

1. Name the new query `Patterns`.

1. Configure the query as follows:

   1. Select the *Get trend data patterns* data source.

   1. Add a *Select* operator and make sure to have both *Pattern name* and *Pattern ID* selected.

      ![Select](~/user-guide/images/Tutorial_patterns_in_dashboards_query_patterns.png)

1. Drag the query to the Dropdown component at the top of the dashboard.

   This will link the component to the query, allowing the user to select any of the patterns in the system

1. In the Dropdown component, select the pattern *Kata backup*.

   This pattern has been added by the package you installed earlier.

1. Create another query and name it `Most recent pattern occurrences per server`.

1. Drag the query to the Table component in order to link the component to this query.

1. Configure the query as follows:

   1. Select the *Get trend data pattern events* data source.

   1. Add a *Filter* operator and configure it as follows:

      - Column: *Pattern ID*.
      - Filter method: *Equals*
      - Value: Click the link icon in the value box, then select your Dropdown feed and the property *Pattern ID*, and click Apply

        ![Filter Pattern ID](~/user-guide/images/Tutorial_patterns_in_dashboards_filter_pattern.png)

1. In our Parameter table that links to the pattern occurrences, the server name is part of the table key, so we'll use *ParameterKeyToSeparateColumns* operator to extract that from the *Parameter ID* Column

   - At the bottom of your query, select *Apply custom operator*, and then select *ParameterKeyToSeparateColumns*.
   - In the *Parameter Key Column* box, select *Parameter ID*.

   ![ParameterKeyToSeparateColumns](~/user-guide/images/Tutorial_patterns_in_dashboards_customop_Parameterkeytoseparatecolumns.png)

1. Follow the same procedure to add another custom operator *Rename column* to rename the *Table Index* column to *Server*.

   ![Rename](~/user-guide/images/Tutorial_patterns_in_dashboards_customop_renamecolumn.png)

1. We will use the *Aggregate* operator to get the most recent pattern occurrence per server, but since the *Aggregate* operator does not support DateTime columns yet, we will apply a workaround by transforming our DateTime field to a double and back.

    - Add another custom operator *DateTimeToDouble* on the column *StartTime*.
    - Then add an *Aggregate* operator that takes the *Maximum* from the new column *StartTime (as double)*.
    - Add a *Groupby" operator by *Server*.
    - Now add the custom operator *DoubleToDateTime* to get the result back to a DateTime format.
    - Your query should look like this:

    ![Rename](~/user-guide/images/Tutorial_patterns_in_dashboards_aggregate.png)

1. Add another *Rename column* custom operator to rename the aggregated result column to "Most recent pattern occurrence".

    ![Rename](~/user-guide/images/Tutorial_patterns_in_dashboards_customop_renamecolumn2.png)

## Step 3: Interpret the timestamp of every occurrence

Now we have the most recent pattern occurrence per server, it's time to make some judgement on those time stamps. We'll do that with a custom operator. This gives us a lot of flexibility, since we can code in there whatever we want. For this tutorial, we will use the custom operator from the catalog *DateIsOlderThan* which adds a column with the judgement of the date being older than a given number of days. The custom operator is also included in the package you have installed in step 1.

1. Add a custom operator *DateIsOlderThan* and link the column *Most recent pattern occurrence*. Choose "1" as *Number of days*.

    ![DateTimeIsOlderThan](~/user-guide/images/Tutorial_patterns_in_dashboards_customop_DateTimeIsOlderThan.png)

1. Select the table and use the [Template editor](xref:Template_Editor) in *Layout/Column appearance/Customize preset*, to apply a nice validation icon/color on the *Most recent pattern occurrence* column.

    ![Customize preset](~/user-guide/images/Tutorial_patterns_in_dashboards_customize_preset.png)

    - Start from the *Left* preset
    - Click '...' and choose *Customize preset*.
    - Add a new *Icon* layer via Tools
    - Draw the icon layer in the template totally to the left.
    - Specify an extra left margin for the *Text* layer.
    - Use conditions to use a 'check' icon and green text color if the validation was ok (value=yes).
    - Use an exclamation mark icon and red text color in case the validation returned invalid (value=no).

      ![Template](~/user-guide/images/Tutorial_patterns_in_dashboards_template.png)

   > [!TIP]
   > See also: [Template editor](xref:Template_Editor).

1. The *validation* column is no longer needed now in the visualization, but we cannot remove it from the query, since we are using it in our cell template. We'll hide the column via Table filter options. We can do that by dragging the columns we want to see from our query to the table in the dashboard. To get access to the columns, go out of edit mode of your query and click the little arrow in front of your query. Now drag the column *Server* and *Most recent pattern occurrence* to the table component.

      ![Template](~/user-guide/images/Tutorial_patterns_in_column_filter.png)

    The resulting dashboard could for instance look like this:

      ![Result](~/user-guide/images/Tutorial_patterns_in_result.png)
