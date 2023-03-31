---
uid: Components_for_one_single_element_or_service
---

# Components for one single element or service

For one single element or service, the building blocks described below are available in report templates.

## Alarm Distribution Graph

Graph showing the distribution of alarms over a selected time span, with several options:

- You can choose to show data from the *Last 24 Hours*, *Yesterday*, a *Week to Date* or a *Month to Date*.

- Depending on the selected time range, you can select different possibilities for the average range that will be shown as a reference in the graph.

- It is possible to include only certain severities.

## Alarm List

Overview of an element’s active alarms or history alarms, with the following options:

- You can choose between different time spans: *Active*, to show only active alarms, *Last Hour*, *Last 24 Hours*, *Yesterday*, *Week to Date*, *Month to Date*, *Previous Month*, or *Year to Date*.

- It is possible to include only certain severities and alarm types.

- In order to only include certain parameters, you can apply a filter.

  Up to DataMiner 9.5.0, you can enter a filter directly, in order to filter on parameter name. Use a semicolon to combine several parameters in the filter, e.g. “Audio Output Level;CPU:SLelement.0”. For more information, see [Using quick filters](xref:Using_quick_filters).

  From DataMiner 9.5.1 onwards, you can select one of the alarm filters saved in the DMS. For more information on saved alarm filters, see [Working with saved alarm filters](xref:ApplyingAlarmFiltersInTheAlarmConsole#working-with-saved-alarm-filters).

- You can choose to sort the list either by element name or by alarm time.

## Alarm State

Pie graph showing how long an element or service has been in each alarm state. You can choose between many different time spans, or set a custom time span.

## CPE

Only available in a DMS with EPM (formerly known as CPE) implementation. The following items can be displayed with this component:

- A status report, which can show a list with connected objects on the lower topology levels, and the real-time values of specific KPIs. Optionally, this can include the average and minimum/maximum trending values for a selected time range, and a link to the EPM interface.

- A trend graph for one or more KPIs. Different options are available as to the time range for the graph, and you can choose whether to include average trending only, or to include minimum and maximum values.

- A heat map, with different options for the time range and different layout options: *Highlight Highest Values*, *Highlight Lowest Values*, and *Apply Alarm Template*.

- A top X list of alarm states or alarm count. This is an overview of the items that either had the highest number of alarm events or spent the most time in alarm state. The following options are available:

  - You can choose between many different time spans, or set a custom time span.

  - You can exclude or include certain alarm severities

  - A textual overview can be included, which can be sorted either by name or by rank.

  - The list can be limited to the top 10, 20, 30, 40 or 50 objects.

When you generate a report with this component, you can then:

- Select the topology fields for which you want to create a report.

- Specify particular KPIs or objects on the lower topology levels.

- For selected KPIs, determine whether to show the average, minimum, maximum or real-time value.

> [!NOTE]
> If the report is generated as Excel/CSV, at most 1 million total table rows of a [partial table](xref:Table_parameters#partial-tables) can be displayed. If the report is generated as HTML/MHT, only the first page of a partial table will be displayed, using the page size configured in the protocol.

## DMS Status

General information about the DMS. The displayed information will contain:

- An overview of the total number and the number of active elements and services per DMA.

- An overview of the total number and the number of active elements and services in the DMS.

- DataMiner version number and build ID.

## Element/Service info

General information about the element or service.

## Heat Map

Heat map with average trend values. The following options are available:

- You can choose between different time spans: *Hour*, *Day*, *Week*, *Month*, *Year*.

- You can choose between three options for the way the colors will be applied: *Highlight Highest Values*, *Highlight Lowest Values*, *Apply Alarm Template*.

## Info Table

List of active alarms or list of documents for the element, depending on your selection.

## New Alarm Types

Pie graph showing the number of alarms for each alarm severity. You can choose between many different time spans, or set a custom time span.

## Parameter Reports

A parameter report with current reading and trending information for each parameter contained in the report. Each parameter will be displayed with a background color matching its alarm state.

> [!NOTE]
> Up to DataMiner 9.5.11, this component only supports element parameters, not parameters of enhanced services.

## Bookings / Reservations

Available from DataMiner 9.5.4 onwards on systems with the appropriate Service & Resource Management licenses. See [Bookings / Reservations component of custom templates](xref:Bookings_Reservations_component_of_custom_templates#bookings--reservations-component-of-custom-templates).

## SLA Historic Service Alarm List

Only applicable for SLA elements. This component shows a table with an overview of history service alarms for the SLA, with above this a summary listing the following items:

- The service monitored by the SLA.

- The start and end time of the period represented in the report.

- The total affected time, i.e. the actual total duration of all alarms that occurred in the indicated time span, without corrections.

- The total violation time, i.e. the total duration of all SLA violations that occurred in the indicated time span.

- The minimum availability, i.e. the percentage of time that must be without violations in order for the SLA not to be breached.

- The measured availability, i.e. the percentage of time that the SLA was without violations.

- The deviation, i.e. the difference between the minimum and the measured availability (deviation = measured - minimum availability).

- The number of violations.

The following options are available:

- You can choose between different time spans: *Active*, to show only active alarms, *Last Hour*, *Last 24 Hours*, *Yesterday*, *Week to Date*, *Month to Date*, *Previous Month*, or *Year to Date*.

- It is possible to include only certain severities and alarm types.

- In order to only include certain parameters, you can filter on parameter name.

    Use a semicolon to combine several parameters in the filter. For more information on using filters, see [Using quick filters](xref:Using_quick_filters).

- In order to keep alarms from being displayed if they have been filtered out by violation filters, select *Hide violation filtered alarms*.

- In order to keep alarms from being displayed if they occur during the offline window, select *Hide alarms from the offline window without impact*. In this case, alarms that have been configured to override the offline window will still be displayed. In order to hide these as well, select *Also hide alarms from the offline window with impact*.

    > [!TIP]
    > See also:
    > [Setting the offline window for an SLA](xref:Setting_the_offline_window_for_an_SLA)

## Spectrum Buffers

Only applicable for Spectrum Analyzer elements. Shows the contents of the last measured trace for each of the available spectrum monitor buffers.

## State Timeline

A timeline showing the alarm state of the element or service in the selected time span. The following options are available:

- You can choose between many different time spans, or set a custom time span.

- You can choose to include a *Textual Overview*, i.e. a table with detailed information

- You can choose to only show the *Textual Overview*, instead of the timeline.

## State Timeline (Parameters)

A timeline showing the alarm state of the selected parameters in the selected time span. The following options are available:

- You can choose between many different time spans, or set a custom time span.

- You can choose to include a *Textual Overview*, i.e. a table with detailed information

- You can choose to only show the *Textual Overview*, instead of the timeline.

## Status Report

Overview of the status of each parameter. Parameters that are in an alarm state will have a matching background color. For parameters that have average trending enabled, a clickable link will allow you to go to the trend graph for that parameter.

The following options are available for this component:

- Select *Limit to selected parameters* to allow the user to select which parameters to include when configuring a mail report. Only these parameters will then be displayed. For table parameters, only those columns and rows will be included that match the selected parameters.

- When the *Limit to selected parameters* option is enabled, an additional option becomes available: *Allow trending avg/min/max to be included*. Select this option and specify a time span. When configuring the report, the user will then be able to select which trending columns should be displayed: “Avg”, “Min” and “Max”, “Realtime” (= current value), or any combination of these.

- To make sure that parameters that are not initialized are not displayed in the report, select *Hide “Not Initialized” Parameters*.

- To add tables as an Excel attachment to an email report, select *Add tables as Excel attachment also*. The report will then have a link to the Excel file next to all of its status report tables. Only one Excel file, named ExcelTableData.xls, will be included in the email report, with different tables on different worksheets in the file.

## Status Query

Overview of parameter states of all elements using the same protocol as the current element. The following options are available:

- In order to add columns with the minimum/maximum/average trending information for some parameters, select *Allow trending avg/min/max to be included*, and select a time span for the trending.

- To add a pie chart for the first parameter in the status query, select *Add pie chart for first parameter*.

> [!NOTE]
> - To view parameters of multiple elements or protocols, up to DataMiner 9.5.12, add this component in an “Elements/Services container” building block, in a template type for multiple elements/services. From DataMiner 9.5.13 onwards, this component is also available in templates for multiple elements/services. See [Status Query](xref:Components_for_multiple_elements_or_services#status-query).
> - From DataMiner 9.6.0 CU23/10.0.0 CU13/10.1.0 CU2/10.1.5 onwards, if a report containing a status query is exported to CSV/Excel, the status query result will be included as a separate CSV file or Excel table.

## Trend Graphs

Trend graph per parameter, with the following options:

- You can choose between different time spans: *Active*, to show only active alarms, *Last Hour*, *Last 24 Hours*, *Yesterday*, *Week to Date*, *Month to Date*, *Previous Month*, or *Year to Date*.

- You can choose to include average trending only, or to display minimum and maximum values.

- To add an overview comparing the data with a previous time span, select *Include overview instead of TOC*.

## Top Parameters

Overview of the parameters that had the most alarm events in a selected time span. The following options are available:

- You can choose between many different time spans, or set a custom time span.

- The list can be limited to 10, 20, 30, 40 or 50 parameters.

## Visual Overview

The Visual Overview for the element or service.
