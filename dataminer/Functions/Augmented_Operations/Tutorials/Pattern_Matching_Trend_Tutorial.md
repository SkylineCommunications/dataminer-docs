---
uid: Pattern_Matching_Trend_Tutorial
---

# Working with trend patterns in DataMiner Cube

This tutorial showcases DataMiner's [pattern matching](xref:Pattern_matching) feature. You will first learn how to select a time range where multiple parameters exhibit a recurring pattern and create a trend pattern, which will help provide context information in your trend graphs. Then you will find out how you can avoid having to create the same pattern several times for different elements using the same protocol or for different rows in a table. Finally, you will learn how to work with pattern events in the Alarm Console, as well as how you can clean up the patterns that have been created in the system.

This tutorial will make use of [history sets](xref:How_to_use_history_sets_on_a_protocol_parameter) to establish the parameters' normal behavior, enabling DataMiner to detect unexpected behavior. Trending is enabled on all parameters used in this tutorial.

The content and screenshots for this tutorial have been created in DataMiner 10.4.8.

Estimated duration: 20 minutes.

## Prerequisites

- DataMiner 10.3.8 or higher with [Storage as a Service (STaaS)](xref:STaaS) (recommended) or a [self-managed Cassandra-compatible database and indexing database](xref:Supported_system_data_storage_architectures).

- Pattern matching is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)

- [Step 2: Add context to a trend graph](#step-2-add-context-to-a-trend-graph)

- [Step 3: Configure a pattern for all elements with the same protocol](#step-3-configure-a-pattern-for-all-elements-with-the-same-protocol)

- [Step 4: Configure a multivariate pattern for all rows in a table](#step-4-configure-a-multivariate-pattern-for-all-rows-in-a-table)

- [Step 5: Create pattern events](#step-5-create-pattern-events)

- [Step 6: Clean up patterns](#step-6-clean-up-patterns)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/aee71207-bd32-49d2-a87b-e31078e6ea5a>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create four DataMiner elements, named "PM Video Server 1", "PM Video Server 2", "PM Tables", and "PM Event Creator" in your system, which will be used throughout the rest of the tutorial. The elements will be located in the view *DataMiner Catalog* > *KATA Working with Pattern Matching in Trend Graphs*.

## Step 2: Add context to a trend graph

1. In the DataMiner Cube Surveyor, select the element *PM Video Server 1*.

   This element provides information about the available physical memory, CPU load, free disk space, and video feed of a fictional server.

1. On the *General* data page of the element, next to the *CPU Load* parameter, click the trend icon.

   Depending on the detected trend behavior, this icon can be an arrow icon, or it can look like this: ![the trend icon](~/dataminer/images/trend_icon_unknown.png).

1. In the top-right corner of the trending page, select *Week to date* to inspect the trend data for the past week.

   You will see some CPU spikes that look similar. However, these may not have the same cause. To investigate further, some extra parameters need to be added to the trend graph.

1. Add the parameters *Free Disk Space*, *Available Physical Memory*, and *Video Feed* to the trend graph:

   1. In the lower-right corner, click the expand icon ![expand icon](~/dataminer/images/ExpandUp.png) to expand the parameter pane.

   1. Click *Add parameter*.

   1. Specify the parameter.

   1. Repeat the previous two steps until all the necessary parameters have been added.

   1. Click *Show trend*.

   > [!TIP]
   > See also: [Working with the parameter pane](xref:Working_with_the_parameter_pane)

   ![Adding parameters to the trend graph](~/dataminer/images/tutorial_pattern_matching_parameters.gif)

   The graph will now show two different *CPU Load* spikes:

   - The first one coincides with a significant drop in the *Free Disk Space*, which happens during a backup.
   - The second is a downward spike in the *Available Physical Memory* coinciding with an upward spike in the *Video Feed*.

1. Create a multivariate pattern for the backup behavior:

   1. Select the section of the graph where you see this recurring behavior.

      The way you can do so depends on the configuration of the trending user settings. See [Trending settings](xref:User_settings#trending-settings).

   1. Click the tag icon and then click the cogwheel icon.

   1. Enter the name *Backup*.

   1. Clear the checkboxes for the *Available Physical Memory* and *Video Feed* subpatterns.

      You can scroll in the *Patterns* area to see all the subpatterns.

   1. Click *OK*.

   > [!TIP]
   > See also: [Defining a pattern](xref:Defining_a_pattern)

   ![Backup pattern for video server](~/dataminer/images/tutorial_pattern_matching_multivariate_backup.gif)

1. Create a multivariate pattern for the recurring behavior where a downward spike in the *Available Physical Memory* coincides with an upward spike in the *Video Feed*:

   1. Select the section of the graph where you see this recurring behavior, in the same way as before.

   1. Click the tag icon and then click the cogwheel icon.

   1. Enter the name *Video Feed*.

   1. Clear the checkbox for the *Free Disk Space* subpattern.

   1. Click *OK*.

   ![Video Feed pattern for video server](~/dataminer/images/tutorial_pattern_matching_multivariate_video_feed.gif)

1. In the top-left corner, click *Up to Data Display*.

1. Click the trend icon next to the *CPU Load* parameter again.

1. In the top-right corner of the trending page, select *Week to date*.

You will now see that context information is available for the different CPU spikes. The multivariate icon ![multivariate](~/dataminer/images/multivariate_icon.png) indicates that the pattern combines trend information from different parameters. Clicking this icon will load all trend graphs of the parameters that are part of the pattern. Hovering the mouse pointer over the tag will highlight all trend lines that are part of the pattern.

![Context in your trend graph](~/dataminer/images/tutorial_pattern_matching_context.gif)

## Step 3: Configure a pattern for all elements with the same protocol

1. In the Surveyor, select the element *PM Video Server 1*.

1. Click the trend icon next to the *CPU Load* parameter.

1. In the top-right corner of the trending page, select *Week to date*.

1. Click the tag button above the pattern *Video Feed*.

1. Click the pencil icon and then click the cogwheel icon.

1. For all subpatterns, click the element name next to *Apply to* and select *protocol* instead.

   > [!TIP]
   > See also: [Editing a pattern](xref:Editing_a_pattern_definition)

1. Click OK.

1. In the Surveyor, select the element *PM Video Server 2*.

1. Click the trend icon next to the *CPU Load* parameter, and click *Week to date*.

You will see that the *Video Feed* pattern is indicated, but the *Backup* pattern is not.

![Pattern for all elements with the same protocol](~/dataminer/images/tutorial_pattern_matching_protocol.gif)

## Step 4: Configure a multivariate pattern for all rows in a table

1. In the Surveyor, select the element *PM in Tables*.

   This element provides information about the CPU usage and free disk space of multiple fictional servers in a table.

1. In the *Server overview* table, click the trend icon in the *CPU Usage* column and the *Server 1* row.

1. In the top-right corner of the trending page, select *Month to date*.

1. Add the *Free Disk Space* parameter to the trend graph:

   1. In the lower-right corner, click the expand icon ![expand icon](~/dataminer/images/ExpandUp.png) to expand the parameter pane.

   1. Click *Add parameter*.

   1. Select the parameter *Server overview: Free Disk Space*.

   1. Click *Show trend*.

1. Create a multivariate pattern for the *Backup* behavior:

   1. Select the section of the graph where you can see this recurring behavior.

   1. Click the tag icon and then click the cogwheel icon.

   1. Enter the name *Backup*. The pattern name does not have to be unique.

   1. For all subpatterns, next to *Apply to*, click *single row '...'* and select *all rows* instead.

   1. Click *OK*.

1. Click *Up to Data Display* in the top-left corner.

1. In the *Server overview* table, click the trend icon in the *CPU Usage* column and the *Server 4* row.

1. In the top-right corner of the trending page, select *Month to date*.

You will see that the *Backup* pattern is marked where relevant.

![Pattern for all rows in the same table](~/dataminer/images/tutorial_pattern_matching_rows.gif)

## Step 5: Create pattern events

1. Select the element *PM Event Creator* in the Surveyor.

   This element provides information about the power consumption of a fictional server.

1. On the *General* data page, click the trend icon next to the *Power Consumption* parameter.

1. Zoom in on the spike at the beginning of the trend data.

   > [!TIP]
   > See also: [Zooming in/out on a trend graph](xref:Zooming_in_out_on_a_trend_graph)

1. Create a univariate pattern for the power spike behavior:

   1. Select the section of the graph where you see the power spike.

   1. Click the tag icon.

   1. Enter the name *Power spike*.

   1. Click the check mark icon.

1. Click *Up to Data Display* in the top-left corner.

1. Click the *Generate Pattern* button to generate a new power spike.

1. Click the trend icon next to the *Power Consumption* parameter.

1. Wait until the new tag appears for the new power spike. Zoom in if necessary to better see the spike.

1. If the Alarm Console is not yet expanded, in the lower-right corner of the Cube window, click the expand icon ![expand icon](~/dataminer/images/ExpandUp.png) to expand it.

1. In the top-right corner of the Alarm Console, click the light bulb icon.

   This icon lights up in blue to indicate that DataMiner Analytics has found something interesting. For more detailed info, see [Working with the Alarm Console light bulb feature](xref:Light_Bulb_Feature).

1. Click the menu item *1 recent pattern occurrence detected*.

   ![Suggestion event triggered](~/dataminer/images/tutorial_pattern_matching_recent.png)

A new *Patterns* tab will now be shown in the Alarm Console, listing the pattern that were detected.

![Pattern event](~/dataminer/images/tutorial_pattern_matching_event.gif)

## Step 6: Clean up patterns

1. Select the element *PM Video Server 1* in the Surveyor.

1. On the *General* data page, click the trend icon next to the *CPU Load* parameter.

1. Right-click the trend graph and select *Trend Patterns*.

   This will open an overview of all the patterns available for the parameter.

1. Select the checkbox *Show all patterns* to have an overview of all patterns in the system.

1. Click the garbage can icon next to each pattern to delete the patterns.

![Cleaning up patterns in your system](~/dataminer/images/tutorial_pattern_matching_cleanup.gif)

> [!IMPORTANT]
> We want to keep improving our pattern matching feature, and your feedback is very helpful for this. That is why you can also earn DevOps Points by sending us examples of patterns that are valuable for your operations and/or situations where pattern matching can be improved (e.g., the feature did not perform as well as you had hoped).
>
> Use the following email format to send us your examples:
>
> - Subject: Tutorial - Pattern matching feedback
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
>   - Feedback: Provide a short explanation of what is shown in the examples you are sending us and why relation learning was useful or not.
> - Attachment: A screenshot relevant to your use case
>
> Skyline will review your submission. Upon successful validation, you will be awarded DevOps Points.
