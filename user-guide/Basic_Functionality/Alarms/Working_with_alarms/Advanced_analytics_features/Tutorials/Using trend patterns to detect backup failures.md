---
uid: trend_patterns_backup_failures
---

# Using trend patterns to detect backup failures

Coming soon!

We are still working on this tutorial. Check back soon to learn more about how you can work with pattern matching data in a dashboard.
<!-- 
This tutorial illustrates DataMiner's [pattern matching](xref:Working_with_pattern_matching) feature in the context of Dashboards and Low-Code apps. It will show how to access patterns and occurrences within a dashboard and how to effectively handle missing pattern occurrences, using the example of server backups. By utilizing a trend pattern, DataMiner will detect the backups. The goal of the tutorial is to generate a comprehensive report indicating whether daily backup patterns have been detected for all servers.

Estimated duration: 20 minutes.

> [!TIP]
> For more information, such as technical limitations of pattern matching, see [Working with behavioral pattern matching](xref:Working_with_pattern_matching).

## Prerequisites

- DataMiner 10.3.12 or higher with [Storage as a Service (STaaS)](xref:STaaS) or a [self-hosted Cassandra database with indexing](xref:Supported_system_data_storage_architectures).

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Pattern matching is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

## Overview

The tutorial consists of the two steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Compile a list of most recent backup pattern occurrence per server](#step-2-compile-a-list-of-most-recent-backup-pattern-occurrence-per-server)
- [Step 3: Interpret the timestamp of every occurrence](#step-3-interpret-the-timestamp-of-every-occurrence)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/package/xxxx>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create a DataMiner element named "..." in your system, which will be used throughout the rest of the tutorial. The element will be located in the view *DataMiner Catalog* > *Augmented Operations* > *Relation Learning Tutorial*.
   This will also create a trend pattern and generate occurrences. This might take a couple of minutes. Time to go for a quick cup of coffee now.

## Step 2: Compile a list of most recent backup pattern occurrence per server

1. [Create a new dashboard](xref:Creating_a_completely_new_dashboard).

1. Drag and drop *Dropdown* visualization from the pane on the left to the dashboard. Put it somewhere on top of your dashboard.

   This will add a dropdown component, where the available patterns in your dms will end up.

1. Drag and drop the *table* visualization from the pane on the left to the dashboard.

   This will add a table component, where the server overview will be presented.
   Put it below your Dropdown and let it take the width of your screen.

   > [!NOTE]
   > There are multiple table components available. Take the one that shows 'Table'. Other table component are for example *Parameter table*, *Alarm table*, ... but for this dashboard we need the generic *Table* component we can link to GQI queries.

1. In the data pane, open the *QUERIES* section and click the "+" icon.

1. Name your query "Patterns"

1. Select the *Get trend data patterns' data source

1. Add a *Select" operator and make sure to have both *Pattern name* and *Pattern ID* selected.

1. Link the Query to the Dropdown on the dashboard and verify that the dropdown lists all the patterns in your system, including the one from the package with name 'Kata backup pattern'. Select that pattern in the dropdown.

1. Create another Query and name it "Most recent pattern occurrences per server"

1. Select the *Get trend data pattern events* data source

1. Add a *Filter* operator and filter on the *Pattern ID*

1. Choose filter method *Equals* and use the *Link to feed* button to link it to the Pattern ID from the dropdown.

1. The server name is part of our table key, so we'll use *ParameterKeyToSeparateColumns* Operator to extract that from the *Parameter ID* Column

1. To do so add a custom operator node *ParameterKeyToSeparateColumns* and select the *Parameter ID* column

1. Add a custom operator node *Rename column* to rename the *Table Index* column to *Server*.

1. We will use the *Aggregate* operator to get the most recent pattern occurrence per server, but since the *Aggregate* operator does not support DateTime columns yet, we will apply a workaround by transforming our DateTime field to a double and back.

1. So add a custom operator node *DateTimeToDouble* on the column *StartTime*

1. Then add an *Aggregate* operator that takes the *Maximum* from the new column *StartTime (as double)*

1. Add a *Groupby" operator by *Server*

1. We'll now add the custom operator *DoubleToDateTime* to get the result back to a DateTime format

1. We'll add another *Rename column* custom operator to rename the aggregated result column to "Most recent pattern occurrence".

## Step 3: Interpret the timestamp of every occurrence

Now we have the most recent pattern occurrence per server, it's time to make some judgement on those time stamps. We'll do that with a custom operator which gives us a lot of option since we can code in there whatever we want. For this tutorial, we will use the custom operator from the catalog *DateIsOlderThan* which adds a column with the judgement of the date being older than a given number of days.

1. Add a custom operator *DateIsOlderThan* and link the column *Most recent pattern occurrence*. Choose "1" as *Number of days*.

1. Select the table and use the [Template editor](xref:Template_Editor) in Layout/Column appearance/Customize template, to apply a nice validation icon/color on the *Most recent pattern occurrence* column. Use a 'check' icon and green color if the validation was ok (value=yes). Use an exclamation mark icon and red color in case the validation returned invalid (value=no).

1. The *validation* column is no longer needed now in the visualization, but we cannot remove it from the query, since we are using it in our cell template. We'll hide the column via Table filter options. We can do that by dragging the columns we want to see from our query to the table in the dashboard. To get access to the columns, go out of edit mode of your query and click the little arrow in front of your query. -->