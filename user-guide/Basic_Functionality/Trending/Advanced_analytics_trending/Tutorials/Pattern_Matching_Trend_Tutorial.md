---
uid: Pattern_Matching_Trend_Tutorial
---

# Trend patterns in Cube

This tutorial showcases DataMiner's [pattern matching](xref:Working_with_pattern_matching) feature. You will learn how to select a time range where multiple parameters exhibit a recurring pattern and create a trend pattern.

This tutorial will make use of [history sets](xref:How_to_use_history_sets_on_a_protocol_parameter) to establish the parameters' normal behavior, enabling DataMiner to detect unexpected behavior. Trending is enabled on all parameters used in this tutorial.

The content and screenshots for this tutorial have been created in DataMiner 10.4.8.0.

Estimated duration: 20 minutes.

## Prerequisites

- DataMiner 10.3.8 or higher with [Storage as a Service (STaaS)](xref:STaaS) or a [self-hosted Cassandra-compatible database and indexing database](xref:Supported_system_data_storage_architectures).

- Pattern Matching is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)

- [Step 2: Adding context to your trend graph](#step-2-adding-context-to-your-trend-graph)

- [Step 3: Avoid duplicating the pattern multiple times for elements with the same protocol](#step-3-avoid-duplicating-the-pattern-multiple-times-for-elements-with-the-same-protocol)

- [Step 4: Avoid duplicating the pattern multiple times for rows in the same table](#step-4-avoid-duplicating-the-pattern-multiple-times-for-rows-in-the-same-table)

- [Step 5: Creating pattern events](#step-5-creating-pattern-events)

- [Step 6: Clean-up patterns](#step-6-clean-up-patterns)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/aee71207-bd32-49d2-a87b-e31078e6ea5a>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create four DataMiner elements named "PM Video Server 1", "PM Video Server 2", "PM Tables", "PM Event Creator" in your system, which will be used throughout the rest of the tutorial. The elements will be located in the view *DataMiner Catalog* > *KATA Working with Pattern Matching in Trend Graphs*.

## Step 2: Adding context to your trend graph

1. In DataMiner Cube, select the element *PM Video Server 1* in the Surveyor.

   This element gives insights into the available physical memory, cpu load, free disk space and video feed of a fictional server.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *CPU Load* parameter.

1. Select *Week to date* from the options available in the top-right corner of the trending page to inspect the trend data for the past week.

   We see some cpu spikes that look similar but they don't have the same cause. To investigate further, let's add some extra parameters to the trend graph.

1. Add the following parameters *Free Disk Space*, *Available Physical Memory* and *Video Feed* to the trend graph by:

   1. Expanding the parameter pane by clicking the ![expand icon](~/user-guide/images/ExpandUp.png) on the right under the main graph area.

   1. Click *Add parameter*.

   1. Specify the parameter.

   1. Repeat from step b until all necessary parameters have been added.

   1. Click *Show trend*

   > [!TIP]
   > See also: [Working with the parameter pane](xref:Working_with_the_parameter_pane)

![Add all parameter to trend graph](~/user-guide/images/tutorial_pattern_matching_parameters.gif)

1. We see two different *CPU Load* spikes appearing, the first one is where the *Free Disk Space* has a significant drop at the same time. We will create a multivariate pattern for this *Backup* behavior. First select the section of the graph where we see this recurring behavior. The way you can do so depends on the configuration of the trending user settings. See [Trending settings](xref:User_settings#trending-settings).

1. Click the tag icon and then click the cogwheel icon.

1. Enter the name *Backup*.

1. Unselect the subpatterns belonging to *Available Physical Memory* and *Video Feed*. You can scroll in the subpatterns area to see all the subpatterns.

1. Press OK.

   > [!TIP]
   > See also: [Defining a pattern](xref:Defining_a_pattern)

![Backup pattern for video server](~/user-guide/images/tutorial_pattern_matching_multivariate_backup.gif)

1. We can also see a second multivariate pattern appearing. When there is a downward spike in the *Available Physical Memory* and a upward spike in the *Video Feed*. Again select the section of the graph where we see this recurring behavior.

1. Click the tag icon and then click the cogwheel icon.

1. Enter the name *Video Feed*.

1. Unselect the subpatterns belonging to *Free Disk Space*.

1. Press OK.

![Video Feed pattern for video server](~/user-guide/images/tutorial_pattern_matching_multivariate_video_feed.gif)

1. Click *Up to Data Display* in the top left corner.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *CPU Load* parameter.

1. Select *Week to date* from the options available in the top-right corner of the trending page to inspect the trend data for the past week. Now some interesting context is added to the different cpu spikes. The ![multivariate](~/user-guide/images/multivariate_icon.png) icon indicates that the pattern combines trend information from different parameters. By clicking this icon, you can load all trend graphs of the parameters that are part of the pattern. Hoovering over the tag will highlight all trend graphs that are part of the pattern.

![Context in your trend graph](~/user-guide/images/tutorial_pattern_matching_context.gif)

## Step 3: Avoid duplicating the pattern multiple times for elements with the same protocol

1. Select the element *PM Video Server 1* in the Surveyor.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *CPU Load* parameter.

1. Select *Week to date* from the options available in the top-right corner of the trending page.

1. Click the tag button above the pattern *Video Feed*.

1. Click the pencil icon and then click the cogwheel icon.

1. For all subpatterns, change *Apply to* from element to protocol by clicking on the element name.

1. Press OK.

   > [!TIP]
   > See also: [Editing a pattern](xref:Editing_a_pattern_definition)

1. Select the element *PM Video Server 2* in the Surveyor.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *CPU Load* parameter. See the *Video Feed* pattern appearing but not the *Backup* pattern.

![Pattern for all elements with the same protocol](~/user-guide/images/tutorial_pattern_matching_protocol.gif)

## Step 4: Avoid duplicating the pattern multiple times for rows in the same table

1. Select the element *PM in Tables* in the Surveyor.

   This element gives insights into the cpu usage and free disk space of multiple fictional servers in a table.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *CPU Usage* parameter for index *Server 1*.

1. Select *Month to date* from the options available in the top-right corner of the trending page to inspect the trend data for the past month.

1. Add the following parameter *Free Disk Space* to the trend by:

    1. Expanding the parameter pane by clicking the ![expand icon](~/user-guide/images/ExpandUp.png) on the right under the main graph area.

    1. Click *Add parameter*.

    1. Select *Free Disk Space* parameter.

    1. Click *Show trend*

1. Create a multivariate pattern for the *Backup* behavior. First select the section of the graph where we see this recurring behavior.

1. Click the tag icon and then click the cogwheel icon.

1. Enter the name *Backup*. Note, the pattern name might not be unique.

1. For all subpatterns, next to *Apply to* select *all rows* by clicking on the index.

1. Press OK.

1. Click *Up to Data Display* in the top left corner.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *CPU Usage* parameter for index *Server 4*.

1. Select *Month to date* from the options available in the top-right corner of the trending page to inspect the trend data for the past month. And see the *Backup* pattern appearing.

![Pattern for all rows in the same table](~/user-guide/images/tutorial_pattern_matching_rows.gif)

## Step 5: Creating pattern events

1. Select the element *PM Event Creator* in the Surveyor.

   This element gives insights into the Power Consumption of a fictional server.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Power Consumption* parameter.

1. Zoom in on the spike in the beginning of the trend data.

   > [!TIP]
   > See also: [Zooming in/out on a trend graph](xref:Zooming_in_out_on_a_trend_graph)

1. Create a univariate pattern for the power spike behavior. First select the section of the graph where we see this recurring behavior.

1. Click the tag icon.

1. Enter the name *Power spike*.

1. Click the check mark icon.

1. Click *Up to Data Display* in the top left corner.

1. Click the *Generate Pattern* button to generate a new power spike.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *Power Consumption* parameter.

1. Wait until the new tag appears for the new power spike. If wanted you can also zoom in a bit.

1. Click the light bulb icon in the top-right corner of the Alarm Console.

   This icon lights up in blue to indicate that DataMiner Analytics found something interesting. For more detailed info, see [Working with the Alarm Console light bulb feature](xref:Light_Bulb_Feature).

1. Click the menu item *1 recent pattern occurrence detected*.

   ![Suggestion event triggered](~/user-guide/images/tutorial_pattern_matching_recent.png)

    A new *Patterns* tab will now be shown in the Alarm Console, listing the pattern that were triggered.

![Pattern event](~/user-guide/images/tutorial_pattern_matching_event.gif)

## Step 6: Clean-up patterns

1. Select the element *PM Video Server 1* in the Surveyor.

1. Click ![the trend icon](~/user-guide/images/trend_icon_unknown.png) next to the *CPU Load* parameter.

1. Right Click on the trend graph and select *Trend Patterns...*. Now you have an overview of all pattern available for the parameter.

1. Select the checkbox *Show all patterns* to have an overview for all patterns in your system.

1. Delete all patterns by trashcan icon next to the pattern.

![Cleaning up patterns in your system](~/user-guide/images/tutorial_pattern_matching_cleanup.gif)

> [!IMPORTANT]
> We want to keep improving our pattern matching feature, and your feedback is very helpful for this. That is why you can also earn DevOps Points by sending us examples of patterns that are valuable for your operations and/or situations where pattern matching can be improved (e.g. the feature did not perform as well as you had hoped).
>
> Use the following email format to send us your examples:
>
> - Subject: Tutorial - Pattern matching feedback
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
>   - Feedback: Provide a short explanation of what is shown in the examples you are sending us and why relation learning was useful or not.
> - Attachment: a screenshot relevant to your use case
>
> Skyline will review your submission. Upon successful validation, you will be awarded DevOps Points.
